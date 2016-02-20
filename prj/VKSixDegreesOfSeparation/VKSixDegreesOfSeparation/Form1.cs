using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void findConnectionButton_Click(object sender, EventArgs e)
        {
            FriendsFetcher fetch = new FriendsFetcher(new VKUser(1));
            List<VKUser> friends = await fetch.fetchFriends();
        }
    }
}
