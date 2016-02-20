using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    class VKUser
    {
        public int ID
        {
            get
            {
                return _id;
            }
        }

        public VKUser Father
        {
            get
            {
                return _father;
            }
        }

        public List<VKUser> Childs
        {
            get
            {
                return _childs;
            }
        }

        public VKUser(int id)
        {
            _id = id;
            _father = null;
            _childs = new List<VKUser>();
        }

        public VKUser(int id, VKUser father)
        {
            _id = id;
            _father = father;
            _childs = new List<VKUser>();
        }

        public void addChild(VKUser child)
        {
            _childs.Add(child);
            child._father = this;
        }


        protected int _id;
        protected VKUser _father;
        protected List<VKUser> _childs;
    }
}
