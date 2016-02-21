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
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        int Medvedev = 53083705;
        int Durov = 1;
        int Dilmurad = 198489790;


        private async void findConnectionButton_Click(object sender, EventArgs e)
        {
            VKConnectionFinder connFinf = new VKConnectionFinder(new VKUser(Dilmurad), new VKUser(103982744));
            List<VKUser> path = await connFinf.getConnection();

        }
    }
}
