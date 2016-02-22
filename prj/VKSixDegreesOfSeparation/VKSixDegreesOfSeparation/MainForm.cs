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

            VKConnectionFinder connFinf = new VKConnectionFinder(new VKUser(Dilmurad), new VKUser(103982744));
            List<VKUser> path = await connFinf.getConnection();
        }

        private bool validateTextBoxes()
        {
            bool b1 = validateTextBox(startTextBox, _startUser);
            bool b2 = validateTextBox(targetTextBox, _targetUser);
            return b1 && b2;
        }


        private bool validateUser(string userNick, VKUserViewData user)
        {
            user = new VKUserViewData(userNick);
            if (!user.validateNick())
                return false;
            return true;
        }

        private bool validateTextBox(TextBox tx, VKUserViewData user)
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

            if (!validateUser(userNick, user))
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

        private VKUserViewData _startUser;
        private VKUserViewData _targetUser;
    }
}
