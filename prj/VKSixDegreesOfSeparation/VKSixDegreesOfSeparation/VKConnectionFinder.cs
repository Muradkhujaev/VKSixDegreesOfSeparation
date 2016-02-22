using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    /// <summary>
    /// Find connection between two vk user.
    /// </summary>
    class VKConnectionFinder
    {
        public VKConnectionFinder(VKUser start, VKUser target)
        {
            _startUser = start;
            _targetUser = target;

            _startQueue = new VKFriendsQueue(start);
            _targetQueue = new VKFriendsQueue(target);

            _path = new List<VKUser>();

            _currLevel = 0;
        }

        /// <summary>
        /// Returns status of connection finder
        /// </summary>
        public FetchResult Status
        {
            get
            {
                return _status;
            }
        }

        public async Task<List<VKUserViewData>> getConnection()
        {
            await prepareQueues();

            //path to self
            if ((_startUser.ID == _targetUser.ID) 
                || (_targetQueue.containsUser(_startUser) 
                    && _startQueue.containsUser(_startUser))) //already friends
            {
                _path.Add(_startUser);
                _path.Add(_targetUser);
                return await getUserDataForPath();
            }
            
            await findConnection();
            
            return await getUserDataForPath();
        }

        private async Task findConnection()
        {
            while (_startQueue.hasHextUser())
            {
                //teory failed
                if (_startQueue.CurrLevel + _targetQueue.CurrLevel >= 6)
                {
                    break;
                }

                if (_startQueue.CurrLevel > _currLevel && _currLevel != 0)
                {
                    swapQueuesIfNeeded();
                    _currLevel++;
                    continue;
                }

                //get next user
                VKUser user = _startQueue.getNextUser();
                _currLevel = user.Level;

                System.Console.WriteLine("currLevel = {0}, currQ={1}, currUser={2}", _currLevel, _startQueue.Root.ID, user.ID);

                await prepareUser(user, _startQueue);
                VKUser res = proceedUser(user);
                if (res != null)
                {
                    makeConnection(res);
                    break;
                }
            }
        }

        private async Task<List<VKUserViewData>> getUserDataForPath()
        {
            List<VKUserViewData> list = new List<VKUserViewData>();
            foreach (VKUser user in _path)
            {
                UserInfoFetcher fetcher = new UserInfoFetcher(user.ID.ToString());
                VKUserViewData userInfo = await fetcher.fetchInfo();
                if (fetcher.Status != FetchResult.Success) {
                    break;
                }
                list.Add(userInfo);
            }

            return list;
        } 

        /// <summary>
        /// Prepares queues to start search
        /// </summary>
        /// <returns></returns>
        private async Task prepareQueues()
        {
            await prepareUser(_startUser, _startQueue);
            await prepareUser(_targetUser, _targetQueue);

            swapQueuesIfNeeded();
        }

        /// <summary>
        /// Swaps if start has more friends
        /// </summary>
        private void swapQueuesIfNeeded()
        {
            if (_startQueue.UserCount > _targetQueue.UserCount)
            {
                VKFriendsQueue temp = _startQueue;
                _startQueue = _targetQueue;
                _targetQueue = temp;
            }
        }

        /// <summary>
        /// Checks if friends of user has common friends with target user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private VKUser proceedUser(VKUser user)
        {
            foreach (VKUser fr in user.Childs)
            {
                if (_targetQueue.containsUser(fr))
                {
                    return fr;
                }
            }

            return null;
        }

        /// <summary>
        /// Get friends and adds to queue.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private async Task prepareUser(VKUser user, VKFriendsQueue q)
        {
            if (user.Childs.Count == 0)
            {
                q.addUser(user);

                FriendsFetcher fetcher = new FriendsFetcher(user);
                List<VKUser> friends = await fetcher.fetchFriends();
                _status = fetcher.Status;

                foreach (VKUser usr in friends)
                {
                    if (q.addUser(usr))
                    {
                        user.addChild(usr);
                    }
                }

                
            }
        }

        /// <summary>
        /// Makes start queue as default (root = _startUser)
        /// </summary>
        private void makeDefaultQueues()
        {
            if (_startQueue.Root.ID != _startUser.ID)
            {
                VKFriendsQueue temp = _startQueue;
                _startQueue = _targetQueue;
                _targetQueue = temp;
            }
        }

        /// <summary>
        /// Restores path from user to father and adds to result path.
        /// </summary>
        /// <param name="user"></param>
        private void makeConnection(VKUser user)
        {
            makeDefaultQueues();

            VKUser startSide = _startQueue.getUser(user.ID);
            VKUser targetSide = _targetQueue.getUser(user.ID);

            List<VKUser> tempList = new List<VKUser>();
            VKUser currUser = startSide;
            while (currUser != null)
            {
                tempList.Add(currUser);
                currUser = currUser.Father;
            }
            tempList.Reverse();
            _path.AddRange(tempList);

            tempList.Clear();
            currUser = targetSide.Father;
            while (currUser != null)
            {
                tempList.Add(currUser);
                currUser = currUser.Father;
            }
            _path.AddRange(tempList);

        }

        private VKUser _startUser;                          //start user
        private VKUser _targetUser;                         //targer user

        private VKFriendsQueue _startQueue;                 //start queue
        private VKFriendsQueue _targetQueue;                //target queue

        private List<VKUser> _path;                         //result path

        private FetchResult _status;                        //status

        private int _currLevel;                             //curr level for search
    }
}
