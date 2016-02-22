using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace VKSixDegreesOfSeparation
{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
        }

        int Medvedev = 53083705;
        int Durov = 1;
        int Dilmurad = 198489790;


        private async void findConnectionButton_Click(object sender, EventArgs e)
        {
            if (!validateTextBoxes())
            {
                return;
            }

            await fetchUserInfo();

            VKConnectionFinder connFinf = new VKConnectionFinder(new VKUser(Dilmurad), new VKUser(103982744));
            List<VKUser> path = await connFinf.getConnection();
        }

        private async Task fetchUserInfo()
        {
            UserInfoFetcher startFetcher = new UserInfoFetcher(_startUser.Nick);
            _startUser = await startFetcher.fetchInfo();
            if (startFetcher.Status != FetchResult.Success)
            {
                updateView(startFetcher.Status, "something");
                return;
            }

            UserInfoFetcher targetFetcher = new UserInfoFetcher(_targetUser.Nick);
            _targetUser = await targetFetcher.fetchInfo();
            if (startFetcher.Status != FetchResult.Success)
            {
                updateView(startFetcher.Status, "something");
                return;
            }
        }

        private bool validateTextBoxes()
        {
            bool b1 = validateTextBox(startTextBox, out _startUser);
            bool b2 = validateTextBox(targetTextBox,out  _targetUser);
            return b1 && b2;
        }

        private bool validateUser(string userNick, out VKUserViewData user)
        {
            user = new VKUserViewData(userNick);
            if (!user.validateNick())
                return false;

            return true;
        }

        private bool validateTextBox(TextBox tx, out VKUserViewData user)
        {
            int start = -1;
            string url = tx.Text;
            int s = url.IndexOf("http://vk.com/");
            if (s == -1)
            {
                s = url.IndexOf("https://vk.com/");
                if (s == -1)
                {
                    tx.BackColor = Color.Red;
                    tx.ForeColor = Color.White;
                    statusLabel.Text = "Some errors";
                    user = null;
                    return false;
                }
                start = s + "https://vk.com/".Length;
            }
            else
            {
                start = s + "http://vk.com/".Length;
            }

            string userNick = "";
            for (int i = start; i < tx.Text.Length; i++)
            {
                userNick += tx.Text[i];
            }

            if (!validateUser(userNick, out user))
            {
                tx.BackColor = Color.Red;
                tx.ForeColor = Color.White;
                statusLabel.Text = "User doesn't exist";
                return false;
            }

            tx.BackColor = Color.White;
            tx.ForeColor = Color.Black;
            return true;
        }

        private void updateView(FetchResult status, string message = "")
        {

        }

        private VKUserViewData _startUser;
        private VKUserViewData _targetUser;
    }
}
