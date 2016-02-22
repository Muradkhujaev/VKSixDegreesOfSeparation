using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKSixDegreesOfSeparation
{
    public partial class ResultForm : Form
    {
        public ResultForm(List<VKUserViewData> path)
        {
            InitializeComponent();

            _viewPath = path;
        }

        public void prepareView()
        {
            //TODO: picture boxes and labels
        }

        public async Task<FetchResult> prepareData()
        {
            //TODO: download images

            return FetchResult.Success;
        }

        private List<VKUserViewData> _viewPath;
    }
}
