using CustomLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSharp
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        public Form1()
        {
            InitializeComponent();

            this.lblTesting.Text = this.ApplicationAssembly.GetName().Version.ToString();
        }

        public string ApplicationName
        {
            get { return "AppSharp"; }
        }

        public string ApplicationID
        {
            get { return "AppSharp"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Uri UpdateXmlApplication
        {
            get { return new Uri(""); }
        }

        public Form Context
        {
            get { return this; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
