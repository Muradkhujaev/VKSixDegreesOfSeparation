using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    class VKUserViewData : VKUser
    {
        public VKUserViewData(string nick) 
            : base(0)
        {
            _nick = nick;
        }

        public VKUserViewData()
            : base(0)
        {
            _nick = "";
        }

        public bool validateNick()
        {
            if (_nick == "")
            {
                return false;
            }

            //get user id from net
            //или сделать загрузку инфы сверху этого класса. 
            return true;
        }

        protected string _nick;
    }
}
