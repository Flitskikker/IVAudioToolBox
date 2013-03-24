namespace IVAUDToolBox
{
    partial class frmOpen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxFileType = new System.Windows.Forms.GroupBox();
            this.radioButtonMultiC = new System.Windows.Forms.RadioButton();
            this.radioButtonMulti = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleC = new System.Windows.Forms.RadioButton();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.groupBoxFileType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(98, 271);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 25);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOpen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpen.Location = new System.Drawing.Point(300, 271);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(85, 25);
            this.buttonOpen.TabIndex = 9;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Open file...";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 57);
            this.label2.TabIndex = 11;
            this.label2.Text = "You want to open the file \"{0}\".\r\nThe file type has been guessed. Please check if" +
    " the file type is correct below and click Open.";
            this.label2.UseMnemonic = false;
            // 
            // groupBoxFileType
            // 
            this.groupBoxFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFileType.Controls.Add(this.radioButtonMultiC);
            this.groupBoxFileType.Controls.Add(this.radioButtonMulti);
            this.groupBoxFileType.Controls.Add(this.radioButtonSingleC);
            this.groupBoxFileType.Controls.Add(this.radioButtonSingle);
            this.groupBoxFileType.Location = new System.Drawing.Point(15, 102);
            this.groupBoxFileType.Name = "groupBoxFileType";
            this.groupBoxFileType.Size = new System.Drawing.Size(369, 163);
            this.groupBoxFileType.TabIndex = 12;
            this.groupBoxFileType.TabStop = false;
            this.groupBoxFileType.Text = "File Type";
            // 
            // radioButtonMultiC
            // 
            this.radioButtonMultiC.AutoSize = true;
            this.radioButtonMultiC.Enabled = false;
            this.radioButtonMultiC.Location = new System.Drawing.Point(11, 126);
            this.radioButtonMultiC.Name = "radioButtonMultiC";
            this.radioButtonMultiC.Size = new System.Drawing.Size(151, 17);
            this.radioButtonMultiC.TabIndex = 3;
            this.radioButtonMultiC.TabStop = true;
            this.radioButtonMultiC.Text = "Multi Channel Compressed";
            this.radioButtonMultiC.UseVisualStyleBackColor = true;
            // 
            // radioButtonMulti
            // 
            this.radioButtonMulti.AutoSize = true;
            this.radioButtonMulti.Enabled = false;
            this.radioButtonMulti.Location = new System.Drawing.Point(11, 92);
            this.radioButtonMulti.Name = "radioButtonMulti";
            this.radioButtonMulti.Size = new System.Drawing.Size(89, 17);
            this.radioButtonMulti.TabIndex = 2;
            this.radioButtonMulti.TabStop = true;
            this.radioButtonMulti.Text = "Multi Channel";
            this.radioButtonMulti.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingleC
            // 
            this.radioButtonSingleC.AutoSize = true;
            this.radioButtonSingleC.Location = new System.Drawing.Point(11, 58);
            this.radioButtonSingleC.Name = "radioButtonSingleC";
            this.radioButtonSingleC.Size = new System.Drawing.Size(157, 17);
            this.radioButtonSingleC.TabIndex = 1;
            this.radioButtonSingleC.TabStop = true;
            this.radioButtonSingleC.Text = "Single Channel Compressed";
            this.radioButtonSingleC.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(11, 25);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(95, 17);
            this.radioButtonSingle.TabIndex = 0;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "Single Channel";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            // 
            // frmOpen
            // 
            this.AcceptButton = this.buttonOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(397, 310);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxFileType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open file...";
            this.Load += new System.EventHandler(this.frmOpen_Load);
            this.groupBoxFileType.ResumeLayout(false);
            this.groupBoxFileType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxFileType;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButtonSingleC;
        private System.Windows.Forms.RadioButton radioButtonMultiC;
        private System.Windows.Forms.RadioButton radioButtonMulti;
    }
}