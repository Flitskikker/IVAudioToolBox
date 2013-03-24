using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IVAUDToolBox
{
    public partial class frmOpen : Form
    {
        public frmOpen()
        {
            this.Icon = Properties.Resources.IVAUD;
            
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (radioButtonSingle.Checked) IVAUD.fileType = IVAUD.IVAUDType.Single;
            if (radioButtonSingleC.Checked) IVAUD.fileType = IVAUD.IVAUDType.SingleC;
            if (radioButtonMulti.Checked) IVAUD.fileType = IVAUD.IVAUDType.Multi;
            if (radioButtonMultiC.Checked) IVAUD.fileType = IVAUD.IVAUDType.MultiC;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmOpen_Load(object sender, EventArgs e)
        {
            if (IVAUD.readType()){
                if (IVAUD.fileType == IVAUD.IVAUDType.Single) radioButtonSingle.Checked = true;
                else if (IVAUD.fileType == IVAUD.IVAUDType.SingleC) radioButtonSingleC.Checked = true;
                else if (IVAUD.fileType == IVAUD.IVAUDType.Multi) radioButtonMulti.Checked = true;
                else if (IVAUD.fileType == IVAUD.IVAUDType.MultiC) radioButtonMultiC.Checked = true;
                else {
                    MessageBox.Show("An error occured while determing the audio file type. (OPEN1)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                }
            }else{
                MessageBox.Show("An error occured while determing the audio file type. (OPEN2)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
    }
}
