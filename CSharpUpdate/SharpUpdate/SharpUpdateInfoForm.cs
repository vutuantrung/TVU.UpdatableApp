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
    /// <summary>
    /// Form to show details about the update
    /// </summary>
    internal partial class SharpUpdateInfoForm : Form
    {
        /// <summary>
        ///  Create a new SharpUpdateInfoForm
        /// </summary>
        /// <param name="applicationInfo"></param>
        /// <param name="updateInfo"></param>
        internal SharpUpdateInfoForm(ISharpUpdatable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            // Fill in the UI
            this.Text = applicationInfo.ApplicationName + " - Update Info";
            this.lblVersions.Text = $"Current version: {applicationInfo.ApplicationAssembly.GetName().Version.ToString()}\nUpdate Version: {updateInfo.Version.ToString()}";
            this.txtDescription.Text = updateInfo.Description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            // Only allow Ctrl + C to copy text
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
        }
    }
}
