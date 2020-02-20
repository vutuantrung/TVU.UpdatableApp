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
    /// Form to prompt the user to accept the update
    /// </summary>
    internal partial class SharpUpdateAcceptForm : Form
    {
        /// <summary>
        /// The program to update's infor
        /// </summary>
        private ISharpUpdatable applicationInfo;

        /// <summary>
        /// The update info from the update.xml
        /// </summary>
        private SharpUpdateXml updateInfo;

        /// <summary>
        /// The update info display form
        /// </summary>
        private SharpUpdateInfoForm updateInfoForm;

        /// <summary>
        /// Creates a new SharpUpdateAcceptForm
        /// </summary>
        /// <param name="applicationInfo"></param>
        /// <param name="updateInfo"></param>
        internal SharpUpdateAcceptForm(ISharpUpdatable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            // Assigns the icon if ot isn't null
            this.Text = this.applicationInfo.ApplicationName + " - Update available";

            // Adds the update version # to the form
            this.lblNewVersion.Text = $"New version: {this.updateInfo.Version.ToString()}";
        }

        /// <summary>
        /// Button Yes click's event
        /// </summary>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Button No click's event
        /// </summary>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Button Details click's event
        /// </summary>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
                this.updateInfoForm = new SharpUpdateInfoForm(this.applicationInfo, this.updateInfo);

            this.updateInfoForm.ShowDialog(this);
        }
    }
}
