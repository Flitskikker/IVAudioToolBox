using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WAV;

namespace IVAUDToolBox
{
    public partial class frmReplace : Form
    {
        public string WAVPath = "";
        public long sampleSize = 0;
        public int sampleSamples16Bit = 0;
        public int sampleSampleRate = 0;
        public int sampleBitsPerSecond = 0;
        public int sampleChannels = 0;
        
        public frmReplace()
        {
            this.Icon = Properties.Resources.IVAUD;
            
            InitializeComponent();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmReplace_Load(object sender, EventArgs e)
        {
            labelSampleSize.Text = (sampleSize / 1024).ToString() + " KB";
            labelSampleDuration.Text = Utils.getDurationString(sampleSamples16Bit, sampleSampleRate);
            labelSampleSampleRate.Text = sampleSampleRate.ToString() + " Hz";
            labelSampleBitsPerSecond.Text = sampleBitsPerSecond.ToString();
            labelSampleChannels.Text = sampleChannels.ToString();

            WAVFile wav = new WAVFile();
            wav.Open(WAVPath, WAVFile.WAVFileMode.READ);
            labelFileSize.Text = (wav.DataSizeBytes / 1024).ToString() + " KB";
            labelFileDuration.Text = Utils.getDurationString(wav.NumSamples, wav.SampleRateHz);
            labelFileSampleRate.Text = wav.SampleRateHz.ToString() + " Hz";
            labelFileBitsPerSecond.Text = wav.BitsPerSample.ToString();
            labelFileChannels.Text = wav.NumChannels.ToString();
            labelFileCodecID.Text = wav.EncodingType.ToString();
            wav.Close();

            if(labelFileCodecID.Text != "1"){
                labelAdvice.Text = "ERROR! The file you've chosen is not Uncompressed PCM encoded and thus cannot be used as replacement.";
                labelFileCodecID.ForeColor = Color.DarkRed;
                buttonReplace.Enabled = false;
                return;
            } else { labelFileCodecID.ForeColor = Color.Green; }

            if(labelFileBitsPerSecond.Text != "16"){
                labelAdvice.Text = "ERROR! The file you've chosen does not have 16 bits per second and thus cannot be used as replacement.";
                labelFileBitsPerSecond.ForeColor = Color.DarkRed;
                labelSampleBitsPerSecond.ForeColor = Color.DarkRed;
                buttonReplace.Enabled = false;
                return;
            } else { labelSampleBitsPerSecond.ForeColor = Color.Green; labelFileBitsPerSecond.ForeColor = Color.Green; }

            if(labelFileChannels.Text != labelSampleChannels.Text){
                labelAdvice.Text = "ERROR! The file you've chosen does not have the same amount of channels as the original sample and thus cannot be used as replacement.";
                labelFileChannels.ForeColor = Color.DarkRed;
                labelSampleChannels.ForeColor = Color.DarkRed;
                buttonReplace.Enabled = false;
                return;
            } else { labelSampleChannels.ForeColor = Color.Green; labelFileChannels.ForeColor = Color.Green; }

            if(labelFileDuration.Text != labelSampleDuration.Text){
                labelFileDuration.ForeColor = Color.DarkGoldenrod;
                labelSampleDuration.ForeColor = Color.DarkGoldenrod;
                labelAdvice.ForeColor = Color.DarkGoldenrod;
                labelAdvice.Text = "WARNING! The file you've chosen does not have the same duration as the original sample. It is recommended to use a file with somewhat the same duration.";
            } else { labelSampleDuration.ForeColor = Color.Green; labelFileDuration.ForeColor = Color.Green; }
            
            if(labelFileSampleRate.Text != labelSampleSampleRate.Text){
                labelFileSampleRate.ForeColor = Color.DarkGoldenrod;
                labelSampleSampleRate.ForeColor = Color.DarkGoldenrod;
                labelAdvice.ForeColor = Color.DarkGoldenrod;
                labelAdvice.Text = "WARNING! The file you've chosen does not have the same sample rate as the original sample. It is highly recommended to use a file with the same sample rate.";
            } else { labelSampleSampleRate.ForeColor = Color.Green; labelFileSampleRate.ForeColor = Color.Green; }
                        
            labelSampleSize.ForeColor = Color.Green;
            labelFileSize.ForeColor = Color.Green;
            buttonReplace.Enabled = true;

            if (labelAdvice.Text != "Please wait...") return;
            labelAdvice.ForeColor = Color.Green;
            labelAdvice.Text = "This file looks okay as replacement. Click Replace to replace the original sample with it.";
        }
    }
}
