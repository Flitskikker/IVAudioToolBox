using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IVAUDToolBox
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            this.Icon = Properties.Resources.IVAUD;
            
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label1.Text = "IV Audio ToolBox - Version " + Application.ProductVersion;
        }
    }
}
