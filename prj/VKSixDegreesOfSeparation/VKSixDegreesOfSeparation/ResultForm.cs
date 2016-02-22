using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace VKSixDegreesOfSeparation
{
    public partial class ResultForm : Form
    {
        public ResultForm(List<VKUserViewData> path)
        {
            InitializeComponent();

            _viewPath = path;
            _images = new List<Bitmap>();
            titleLabel.Text = "Yout path to " + _viewPath[_viewPath.Count - 1].Name;
        }

        public async Task prepareView()
        {
            if (_images.Count != _viewPath.Count)
            {
                await prepareData();
            }

            for (int i = 0; i < _viewPath.Count; i++)
            {
                placeUserPicture(i);
                placeUserLabel(i);
            }
        }


        //-------------------------------View
        private void drawConnection(Graphics gr)
        {
            // Create pen.
            Pen pen = new Pen(Color.DarkGray, 5);

            // Create points that define line.
            Point point1 = new Point(50, 125);
            Point point2 = new Point(_images.Count*150-50, 125);

            // Draw line to screen.
            gr.DrawLine(pen, point1, point2);
        }

        private void placeUserPicture(int num)
        {
            //if we have no images
            if (_images.Count-1 < num)
            {
                return;
            }

            PictureBox picture = new PictureBox
            {
                Name = "pictureBox" + num,
                Size = new Size(100, 125),
                Location = new Point(20 + num * 150, 50),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = _images[num]
            };

            picture.MouseClick += pictureBoxClicked;
            this.Controls.Add(picture);
        }

        private void placeUserLabel(int num)
        {
            Label label = new Label
            {
                Name = "label" + num,
                Text = _viewPath[num].Name,
                AutoSize = true,
                Location = new Point(20 + num * 150, 180)
            };
            this.Controls.Add(label);
        }

        private void pictureBoxClicked(object sender, EventArgs e)
        {
            string name = ((PictureBox)sender).Name;
            int index = (int)name[name.Length - 1];
            navigateToUser(_viewPath[index]);
        }

        private void navigateToUser(VKUserViewData user)
        {
            System.Diagnostics.Process.Start("https://vk.com/id" + user.ID);
        }


        //-------------------------------Data
        public async Task prepareData()
        {
            foreach (VKUserViewData user in _viewPath)
            {
                Bitmap img = await getImage(user.PhotoUrl);
                _images.Add(img);
            }
        }

        private async Task<Bitmap> getImage(string url)
        {
            return await Task<Bitmap>.Factory.StartNew(() =>
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(url);
                Bitmap photo = new Bitmap(stream);
                stream.Flush();
                stream.Close();
                return photo;
            });
        }

        private List<VKUserViewData> _viewPath;
        private List<Bitmap> _images;

        private void ResultForm_Paint(object sender, PaintEventArgs e)
        {
            drawConnection(e.Graphics);
        }
    }
}
