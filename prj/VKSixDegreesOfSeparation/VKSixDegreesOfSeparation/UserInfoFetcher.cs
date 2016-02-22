using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKSixDegreesOfSeparation
{
    class UserInfoFetcher : VKFetcher
    {

        public UserInfoFetcher(string nick)
        {
            _nick = nick;
        }

        public async Task<VKUserViewData> fetchInfo()
        {
            string response = await Task<string>.Factory.StartNew(() =>
            { return httpRequest(userInfoUrl + _nick); });

            if (_status != FetchResult.Success)
            {
                return null;
            }

            return parseResponse(response);
        }

        private VKUserViewData parseResponse(string response)
        {
            try
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(response);

                int id = jsonObj.response[0].uid;
                string name = jsonObj.response[0].first_name + " " + jsonObj.response[0].last_name;
                string photoUrl = jsonObj.response[0].photo_100;
                VKUserViewData user = new VKUserViewData(id, name, _nick, photoUrl);
                return user;
            }
            catch
            {
                _status = FetchResult.BadData;
            }

            return null;
        }

        private string _nick;
        private const string userInfoUrl = "https://api.vk.com/method/users.get?fields=photo_100&user_ids=";
    }
}
