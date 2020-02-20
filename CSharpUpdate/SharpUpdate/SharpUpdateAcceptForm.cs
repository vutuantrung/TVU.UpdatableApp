using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateAcceptForm : Form
    {
        private ISharpUpdatable applicationInfo;

        private SharpUpdateXml updateInfo;

        private SharpUpdateInfoForm updateInfoForm;

        internal SharpUpdateAcceptForm(ISharpUpdatable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Update available";

            this.lblNewVersion.Text = $"New version: {this.updateInfo.Version.ToString()}";
        }
    }
}
