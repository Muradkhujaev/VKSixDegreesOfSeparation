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
        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        public MainForm()
        {
            InitializeComponent();
           // AllocConsole();
        }

        private async void findConnectionButton_Click(object sender, EventArgs e)
        {
            if (!validateTextBoxes())
            {
                return;
            }

            bool res = await fetchUserInfo();
            if (!res)
            {
                return;
            }

            VKConnectionFinder connFind = new VKConnectionFinder(_startUser, _targetUser);
            statusLabel.Text = "Search the path";
            List<VKUserViewData> path = await connFind.getConnection();
            statusLabel.Text = "Path is found";
            await validatePath(connFind, path);
        }

        private async Task validatePath(VKConnectionFinder finder, List<VKUserViewData> path)
        {
            if (finder.Status == FetchResult.ConnectionError)
            {
                MessageBox.Show("There is no connection to vk servers");
            }

            if (finder.Status == FetchResult.BadData)
            {
                MessageBox.Show("VK servers returned error. Try again");
            }

            statusLabel.Text = "Downloading user info";

            ResultForm newForm = new ResultForm(path);
            await newForm.prepareView();
            newForm.Show();

            statusLabel.Text = "Ready";

            //await newForm.prepareView();
        }


        //----------------------------------------User Validation

        private async Task<bool> fetchUserInfo()
        {
            UserInfoFetcher startFetcher = new UserInfoFetcher(_startUser.Nick);
            _startUser = await startFetcher.fetchInfo();
            if (startFetcher.Status != FetchResult.Success)
            {
                updateError(startFetcher.Status);
                textBoxBadData(startTextBox);
                return false;
            }

            UserInfoFetcher targetFetcher = new UserInfoFetcher(_targetUser.Nick);
            _targetUser = await targetFetcher.fetchInfo();
            if (targetFetcher.Status != FetchResult.Success)
            {
                updateError(targetFetcher.Status);
                textBoxBadData(targetTextBox);
                return false;
            }

            return true;
        }

        private bool validateTextBoxes()
        {
            bool b1 = validateTextBox(startTextBox, out _startUser);
            bool b2 = validateTextBox(targetTextBox, out  _targetUser);
            
            if (!(b1 && b2))
            {
                statusLabel.Text = "Bad data";
            }

            return b1 && b2;
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
                    textBoxBadData(tx);
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
                textBoxBadData(tx);
                return false;
            }

            textBoxGoodData(tx);
            return true;
        }

        private bool validateUser(string userNick, out VKUserViewData user)
        {
            user = new VKUserViewData(userNick);
            if (!user.validateNick())
                return false;

            return true;
        }


        //----------------------------------------View

        private void textBoxBadData(TextBox tx)
        {
            tx.BackColor = Color.Red;
            tx.ForeColor = Color.White;
        }

        private void textBoxGoodData(TextBox tx, bool message = false)
        {
            tx.BackColor = Color.White;
            tx.ForeColor = Color.Black;
        }

        private void updateError(FetchResult status)
        {
            switch (status)
            {
                case FetchResult.ConnectionError:
                    statusLabel.Text = "There is no connection to the VK servers";
                    break;
                case FetchResult.BadData:
                    statusLabel.Text = "Bad data";
                    break;
            }
        }

        private VKUserViewData _startUser;
        private VKUserViewData _targetUser;

        private void startTextBox_Click(object sender, EventArgs e)
        {
            startTextBox.Text = "";
        }

        private void targetTextBox_Click(object sender, EventArgs e)
        {
            targetTextBox.Text = "";
        }
    }
}
