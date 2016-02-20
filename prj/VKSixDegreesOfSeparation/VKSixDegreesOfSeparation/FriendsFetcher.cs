using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKSixDegreesOfSeparation
{

    class FriendsFetcher : VKFetcher
    {
        public FriendsFetcher(VKUser user)
        {
            _user = user;
            _friends = new List<VKUser>();
        }

        public async Task<List<VKUser>> fetchFriends()
        {
            string response = await Task<string>.Factory.StartNew(() => { return httpRequest(fetchFriendsUrl + _user.ID); });
            parseResponse(response);
            return _friends;
        }
        
        private void parseResponse(string response)
        {
            dynamic jsonObj = JsonConvert.DeserializeObject(response);

            for (int i = 0; i < jsonObj.response.Count; i++)
            {
                _friends.Add(new VKUser((int)jsonObj.response[i], _user));
            }
        }

        private const string fetchFriendsUrl = "https://api.vk.com/method/friends.get?uid=";

        private List<VKUser> _friends;
    }
}
