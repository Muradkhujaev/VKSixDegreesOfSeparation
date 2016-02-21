using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    /// <summary>
    /// Stores data for ConnectionFinder
    /// </summary>
    class VKFriendsQueue
    {
        public VKFriendsQueue(VKUser root)
        {
            _root = root;
            _set = new HashSet<VKUser>(new VKUserComparer());
            _proceedQueue = new Queue<VKUser>();
            _proceedQueue.Enqueue(_root);
        }

        public VKUser Root
        {
            get
            {
                return _root;
            }
        }

        public int UserCount
        {
            get
            {
                return _proceedQueue.Count;
            }
        }

        public int CurrLevel
        {
            get
            {
                return _proceedQueue.Peek().Level;
            }
        }

        public bool containsUser(VKUser user)
        {
            return _set.Contains(user);
        }

        public VKUser getUser(int id)
        {
            if (!containsUser(new VKUser(id)))
            {
                return null;
            }

            foreach (VKUser user in _set)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }

            return null;
        }

        public bool addUser(VKUser user) {
            if (_set.Contains(user))
            {
                return false;
            }

            _set.Add(user);
            _proceedQueue.Enqueue(user);

            return true;
        }

        public bool hasHextUser()
        {
            return _proceedQueue.Count > 0;
        }

        public VKUser getNextUser()
        {
            if (_proceedQueue.Count == 0)
            {
                return null;
            }

            return _proceedQueue.Dequeue();
        }

        private VKUser _root;
        private HashSet<VKUser> _set;                           //for no duplicates
        private Queue<VKUser> _proceedQueue;                    //proceed queue 
    }

    class VKUserComparer : IEqualityComparer<VKUser>
    {
        public int GetHashCode(VKUser obj) 
        {
            return obj.ID;
        }

        public bool Equals(VKUser obj1, VKUser obj2) 
        {
            return obj1.ID == obj2.ID;
        }
    }
}
