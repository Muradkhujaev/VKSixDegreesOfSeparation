using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    /// <summary>
    /// Model
    /// </summary>
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

        public int Level
        {
            get
            {
                return _level;
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
            _level = 0;
            _childs = new List<VKUser>();
        }

        public VKUser(int id, VKUser father)
        {
            _id = id;
            _father = father;
            _level = _father.Level + 1;
            _childs = new List<VKUser>();
        }

        public void addChild(VKUser child)
        {
            _childs.Add(child);
            child._father = this;
        }


        protected int _id;                              //id of the user
        protected VKUser _father;                       //father of the user. Shortest friend for start user.
        protected List<VKUser> _childs;                 //friends of the user
        protected int _level;                           //level in connection
    }
}
