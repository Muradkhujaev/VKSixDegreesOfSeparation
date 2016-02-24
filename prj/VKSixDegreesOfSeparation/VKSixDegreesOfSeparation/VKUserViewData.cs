using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    public class VKUserViewData : VKUser
    {
        public string Nick
        {
            get
            {
                return _nick;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }
        }

        public VKUserViewData(string nick) 
            : base(0)
        {
            _nick = nick;
            _photoUrl = "";
        }

        public VKUserViewData(VKUser user)
            : base(user.ID, user.Father)
        {
            _nick = "";
            _photoUrl = "";
        }

        public VKUserViewData(int id, string name, string nick, string photoUrl)
            : base(id)
        {
            _nick = nick;
            _photoUrl = photoUrl;
            _name = name;
        }

        public VKUserViewData()
            : base(0)
        {
            _nick = "";
        }
        //test
        public bool validateNick()
        {
            if (_nick == "")
            {
                return false;
            }

            return true;
        }

        protected string _nick;
        protected string _name;
        protected string _photoUrl;
    }
}
