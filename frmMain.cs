using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Media;
using WAV;

namespace IVAUDToolBox
{
    public partial class frmMain : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private SoundPlayer sp = new SoundPlayer();
        private bool askSave = false;
        public string toOpen = "";
        private List<int> toHighlight = new List<int>();
        
        public frmMain()
        {
            this.Icon = Properties.Resources.IVAUD;

            InitializeComponent();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            frmAbout abt = new frmAbout();
            abt.Show();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            if (askSave){
                if (MessageBox.Show(this, "There is already a file opened. If you close it now, changes may be lost.\n\nDo you want to close this file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) return;
            }
            if (openFileDialogOpenIVAUD.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                prepareOpenFile(openFileDialogOpenIVAUD.FileName);
            }
        }

        private void prepareOpenFile(string path)
        {
            askSave = false;
            toHighlight.Clear();
            if(IVAUD.file != null) IVAUD.close();
            this.Cursor = Cursors.WaitCursor;
            File.Copy(path, Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp", true);
            openFileDialogOpenIVAUD.FileName = path;
            this.Cursor = Cursors.Default;
            if (IVAUD.load(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp")){
                frmOpen open = new frmOpen();
                open.label2.Text = String.Format(open.label2.Text, Path.GetFileName(path));
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK){                        
                    this.Cursor = Cursors.WaitCursor;
                    if (openFile()) labelFile.Text = path;
                    this.Cursor = Cursors.Default;
                }else{
                    if (IVAUD.file != null) IVAUD.close();
                }
            }else{
                MessageBox.Show("An error occured while loading the audio file. (MAIN1)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool openFile()
        {
            listView.Items.Clear();
            listViewFileProperties.Items.Clear();
            listViewSampleProperties.Items.Clear();
            labelFile.Text = "< No file opened >";
            labelSample.Text = "< No sample selected >";
            this.listView.ListViewItemSorter = null;

            ListViewItem lviFocus = null;

            if ((IVAUD.fileType == IVAUD.IVAUDType.Single) || (IVAUD.fileType == IVAUD.IVAUDType.SingleC)){
                if (IVAUDSingle.read()){
                    for (int i = 0; i < IVAUDSingle.WIHhash.Count; i++){                        
                        listView.Items.Add(Utils.createListItem((i+1).ToString(), Utils.getSampleName(IVAUDSingle.WIHhash[i]), Utils.getDurationString(IVAUDSingle.WInumSamples16Bit[i], IVAUDSingle.WIsamplerate[i]), IVAUDSingle.WIsamplerate[i].ToString() + " Hz", (IVAUDSingle.WIoffset[i] + IVAUDSingle.headerSize).ToString(), (IVAUDSingle.WInumSamplesInBytes[i] / 1024).ToString() + " KB"));
                        if (toHighlight.Contains(i)) highlightRow(i);
                        if (toHighlight.Count > 0){
                            if (toHighlight[toHighlight.Count - 1] == i) lviFocus = listView.Items[i];
                        }
                    }
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("Type:", IVAUD.fileType.ToString().Replace("eC", "e Compressed").Replace("Single", "Single Channel")));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("Size:", IVAUD.file.Length.ToString() + " bytes"));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("# of Samples:", listView.Items.Count.ToString()));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("Header size:", IVAUDSingle.headerSize.ToString() + " bytes"));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("# of Blocks:", IVAUDSingle.numBlocks.ToString()));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("WaveInfo offset:", IVAUDSingle.offsetWaveInfo.ToString()));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("Unknown table offset:", IVAUDSingle.offsetUnknownTable.ToString()));
                    listViewFileProperties.Items.Add(Utils.createPropertyListItem("# of Unknown table entries:", IVAUDSingle.numUnknownTableEntries.ToString()));
                    if ((IVAUD.fileType == IVAUD.IVAUDType.Single) && (IVAUDSingle.WIis_compressed[0] == true)) {
                        IVAUD.fileType = IVAUD.IVAUDType.SingleC;
                        if (openFile()) labelFile.Text = openFileDialogOpenIVAUD.FileName;
                        MessageBox.Show(this, "A compressed sample has been found in the file, while the selected audio type is Single Channel Uncompressed.\nTherefore, the file was reloaded as Single Channel Compressed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //if (MessageBox.Show(this, "A compressed sample has been found in the file, while the selected audio type is Single Channel Uncompressed.\nWe strongly recommend you to reopen the file and select Single Channel Uncompressed as the file type.\n\nDo you want to reopen the Open File dialog?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) toolStripButtonOpen_Click(new object(), new EventArgs());
                    }
                    if ((IVAUD.fileType == IVAUD.IVAUDType.SingleC) && (IVAUDSingle.WIis_compressed[0] == false)) {
                        IVAUD.fileType = IVAUD.IVAUDType.Single;
                        if (openFile()) labelFile.Text = openFileDialogOpenIVAUD.FileName;
                        MessageBox.Show(this, "An uncompressed sample has been found in the file, while the selected audio type is Single Channel Compressed.\nTherefore, the file was reloaded as Single Channel Uncompressed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //if (MessageBox.Show(this, "An uncompressed sample has been found in the file, while the selected audio type is Single Channel Compressed.\nWe strongly recommend you to reopen the file and select Single Channel Compressed as the file type.\n\nDo you want to reopen the Open File dialog?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) toolStripButtonOpen_Click(new object(), new EventArgs());
                    }
                } else {
                    MessageBox.Show("An error occured while reading the audio file. (MAIN2)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } else if ((IVAUD.fileType == IVAUD.IVAUDType.Multi) || (IVAUD.fileType == IVAUD.IVAUDType.MultiC)) {
                if (IVAUDMulti.read()){
                    // MULTI CHANNEL HANDLING
                } else {
                    MessageBox.Show("An error occured while reading the audio file. (MAIN9)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } else {
                MessageBox.Show("An error occured while opening the audio file. (MAIN3)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.listView.ListViewItemSorter = lvwColumnSorter;

            if (lviFocus != null) listView.TopItem = lviFocus; // lviFocus.EnsureVisible();

            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Utils.loadDictionaries();
            Utils.loadSessionID();

            lvwColumnSorter = new ListViewColumnSorter();            

            Directory.CreateDirectory(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB");
            if((toOpen != "") && (File.Exists(toOpen))) prepareOpenFile(toOpen);
        }        

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            if (listView.SelectedItems.Count == 1) i = Convert.ToInt32(listView.SelectedItems[0].Text) - 1; else return;

            listViewSampleProperties.Items.Clear();
            labelSample.Text = listView.SelectedItems[0].SubItems[1].Text;

            if ((IVAUD.fileType == IVAUD.IVAUDType.Single) || (IVAUD.fileType == IVAUD.IVAUDType.SingleC)){
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("ID:", (i + 1).ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Hash:", "0x" + IVAUDSingle.WIHhash[i].ToString("X")));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Swapped Endian Hash:", "0x" + Utils.swapUInt32(IVAUDSingle.WIHhash[i]).ToString("X")));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Name:", Utils.getSampleName(IVAUDSingle.WIHhash[i])));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Header offset:", IVAUDSingle.WIHoffset[i].ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Header size:", IVAUDSingle.WIHsize[i].ToString() + " bytes"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Offset:", IVAUDSingle.WIoffset[i].ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Offset in file:", (IVAUDSingle.WIoffset[i] + IVAUDSingle.headerSize).ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Size:", IVAUDSingle.WInumSamplesInBytes[i].ToString() + " bytes"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Padded size:", IVAUDSingle.WInumSamplesInBytes_computed[i].ToString() + " bytes"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Compressed:", IVAUDSingle.WIis_compressed[i].ToString().Replace("True", "Yes").Replace("False", "No")));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("# of 16 bit samples:", IVAUDSingle.WInumSamples16Bit[i].ToString() + " bytes"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("# of 16 bit samples #2:", IVAUDSingle.WInumSamples16Bit2[i].ToString() + " bytes"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Sample Rate:", IVAUDSingle.WIsamplerate[i].ToString() + " Hz"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Offset to ADPCM states:", IVAUDSingle.WIoffsetToStates[i].ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("# of ADPCM states:", IVAUDSingle.WInumStates[i].ToString()));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Duration:", Math.Round(Convert.ToDouble(IVAUDSingle.WInumSamples16Bit[i]) / Convert.ToDouble(IVAUDSingle.WIsamplerate[i]), 3).ToString() + " second(s)"));
                listViewSampleProperties.Items.Add(Utils.createPropertyListItem("Duration (mm:ss):", Utils.getDurationString(IVAUDSingle.WInumSamples16Bit[i], IVAUDSingle.WIsamplerate[i]).ToString()));
            } else if ((IVAUD.fileType == IVAUD.IVAUDType.Multi) || (IVAUD.fileType == IVAUD.IVAUDType.MultiC)) {

            }
        }

        private void toolStripMenuItemExportWAV_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0){
                if(listView.SelectedItems.Count == 1){
                    saveFileDialogExport.FileName = listView.SelectedItems[0].SubItems[1].Text + ".wav";
                    if(saveFileDialogExport.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        this.Cursor = Cursors.WaitCursor;
                        if (!exportSample(saveFileDialogExport.FileName, Convert.ToInt32(listView.SelectedItems[0].Text) - 1)) return;
                        this.Cursor = Cursors.Default;
                        if (MessageBox.Show(this, "Export successful! Do you want to open it now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes) Process.Start(saveFileDialogExport.FileName);
                    } else {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }else{
                    if(folderBrowserDialogExport.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        this.Cursor = Cursors.WaitCursor;
                        for (int i = 0; i < listView.SelectedItems.Count; i++){
                            if (!exportSample(folderBrowserDialogExport.SelectedPath + "\\" + listView.SelectedItems[i].SubItems[1].Text + ".wav", Convert.ToInt32(listView.SelectedItems[i].Text) - 1)) return;
                        }                        
                        this.Cursor = Cursors.Default;
                        if (MessageBox.Show(this, "Export successful! Do you want to open the export folder now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes) Process.Start(folderBrowserDialogExport.SelectedPath);
                    } else {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
            }else{
                MessageBox.Show("No files selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            this.Cursor = Cursors.Default;            
        }

        private bool exportSample(string path, int index)
        {
            if (IVAUD.fileType == IVAUD.IVAUDType.Single) {
                if (!IVAUDSingle.exportSampleAsWAV(index, path)) {
                    MessageBox.Show("An error occured while saving the audio file. (MAIN5)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.SingleC) {
                if (!IVAUDSingleC.exportSampleAsWAV(index, path)) {
                    MessageBox.Show("An error occured while saving the audio file. (MAIN6)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.Multi) {
                if (!IVAUDMulti.exportSampleAsWAV(index, path)) {
                    MessageBox.Show("An error occured while saving the audio file. (MAIN7)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.MultiC) {
                if (!IVAUDMultiC.exportSampleAsWAV(index, path)) {
                    MessageBox.Show("An error occured while saving the audio file. (MAIN8)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else {
                MessageBox.Show("An error occured while saving the audio file. (MAIN4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool replaceSample(string path, int index)
        {
            if (IVAUD.fileType == IVAUD.IVAUDType.Single) {
                if (!IVAUDSingle.replaceSample(index, path)) {
                    MessageBox.Show("An error occured while replacing the sample. (MAIN11)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.SingleC) {
                if (!IVAUDSingleC.replaceSample(index, path)) {
                    MessageBox.Show("An error occured while replacing the sample. (MAIN12)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.Multi) {
                if (!IVAUDMulti.replaceSample(index, path)) {
                    MessageBox.Show("An error occured while replacing the sample. (MAIN14)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else if (IVAUD.fileType == IVAUD.IVAUDType.MultiC) {
                if (!IVAUDMultiC.replaceSample(index, path)) {
                    MessageBox.Show("An error occured while replacing the sample. (MAIN15)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            } else {
                MessageBox.Show("An error occured while replacing the sample. (MAIN16)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;
            sp.Stop();
            removeImages();
            this.Cursor = Cursors.WaitCursor;
            if(sampleToSoundPlayer()) listView.SelectedItems[0].ImageIndex = 1;
            this.Cursor = Cursors.Default;
            sp.Play();
        }

        private void toolStripButtonPlayLooped_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;
            sp.Stop();
            removeImages();
            this.Cursor = Cursors.WaitCursor;
            sampleToSoundPlayer();
            if (sampleToSoundPlayer()) listView.SelectedItems[0].ImageIndex = 2;
            this.Cursor = Cursors.Default;
            sp.PlayLooping();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            sp.Stop();
            removeImages();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;
            toolStripButtonPlay_Click(new object(), new EventArgs());
        }

        private bool sampleToSoundPlayer()
        {
            sp = new SoundPlayer();
            if (!exportSample(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Play" + Utils.sessionID + ".tmp", Convert.ToInt32(listView.SelectedItems[0].Text) - 1)) return false;
            sp = new SoundPlayer(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Play" + Utils.sessionID + ".tmp");
            return true;
        }

        private void removeImages()
        {
            foreach (ListViewItem lvi in listView.Items) lvi.ImageIndex = 0;
        }

        private void toolStripMenuItemExportWAVMulti_Click(object sender, EventArgs e)
        {
            if((IVAUD.fileType == IVAUD.IVAUDType.Multi) || (IVAUD.fileType == IVAUD.IVAUDType.MultiC)){
                toolStripMenuItemExportWAV_Click(new object(), new EventArgs());
            }else{
                MessageBox.Show("This file is not multi channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
        }

        private void toolStripMenuItemExportAll_Click(object sender, EventArgs e)
        {
            listView.BeginUpdate();
            this.Cursor = Cursors.WaitCursor;
            foreach (ListViewItem lvi in listView.Items) lvi.Selected = true;
            this.Cursor = Cursors.Default;
            listView.EndUpdate();
            toolStripMenuItemExportWAV_Click(new object(), new EventArgs());
        }

        private void toolStripButtonReplace_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1){
                if (openFileDialogReplace.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                    frmReplace rplc = new frmReplace();
                    rplc.WAVPath = openFileDialogReplace.FileName;
                    rplc.labelFile.Text = Path.GetFileName(openFileDialogReplace.FileName);
                    rplc.labelSample.Text = listView.SelectedItems[0].SubItems[1].Text;
                    rplc.label2.Text = String.Format(rplc.label2.Text, Path.GetFileName(openFileDialogReplace.FileName), listView.SelectedItems[0].SubItems[1].Text);
                    if ((IVAUD.fileType == IVAUD.IVAUDType.Single) || (IVAUD.fileType == IVAUD.IVAUDType.SingleC)){
                        rplc.sampleSize = IVAUDSingle.WInumSamplesInBytes[Convert.ToInt32(listView.SelectedItems[0].Text) - 1];
                        rplc.sampleSamples16Bit = IVAUDSingle.WInumSamples16Bit[Convert.ToInt32(listView.SelectedItems[0].Text) - 1];
                        rplc.sampleSampleRate = IVAUDSingle.WIsamplerate[Convert.ToInt32(listView.SelectedItems[0].Text) - 1];
                        rplc.sampleBitsPerSecond = 16;
                        rplc.sampleChannels = 1;
                    } else if ((IVAUD.fileType == IVAUD.IVAUDType.Multi) || (IVAUD.fileType == IVAUD.IVAUDType.MultiC)) {
                        // FILL DIALOG MULTI CHANNEL
                    }
                    if (rplc.ShowDialog() == System.Windows.Forms.DialogResult.OK){                        
                        this.Cursor = Cursors.WaitCursor;
                        if (replaceSample(openFileDialogReplace.FileName, Convert.ToInt32(listView.SelectedItems[0].Text) - 1)){ //replace
                            MessageBox.Show("The sample has been successfully replaced.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            askSave = true;
                            toHighlight.Add(Convert.ToInt32(listView.SelectedItems[0].Text) - 1);
                            if (openFile()) labelFile.Text = openFileDialogOpenIVAUD.FileName;
                        }
                        this.Cursor = Cursors.Default;
                    }else{
                        this.Cursor = Cursors.Default;
                    }
                }
            }else if (listView.SelectedItems.Count > 1){
                if (MessageBox.Show("You've selected more than 1 file. Do you want to replace multiple files?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes){
                    if (MessageBox.Show("Multi replacing is heavily BETA!\nIn the following window, select the folder with the new files. All files with the same names as the selected samples with the suffix .wav will be replaced (e.g. NIKO_CRASH_CAR_20.wav). Everything else will be discarded.\nMake sure everything has the correct bitrate and such, otherwise the progress may result in an error.\nThis process may take some time for very large amounts of files to be replaced.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK) {
                        if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {                            
                            int counter = 0;
                            string[] allFiles = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.wav", SearchOption.TopDirectoryOnly);

                            this.Cursor = Cursors.WaitCursor;
                            
                            for (int i = 0; i < allFiles.Length; i++) {
                                //Debug.WriteLine(allFiles[i]);
                                for (int x = 0; x < listView.SelectedItems.Count; x++) {
                                    //Debug.WriteLine(listView.SelectedItems[x].SubItems[1].Text);
                                    if (Path.GetFileNameWithoutExtension(allFiles[i]) == listView.SelectedItems[x].SubItems[1].Text) {
                                        if (replaceSample(allFiles[i], Convert.ToInt32(listView.SelectedItems[x].Text) - 1)) { //replace
                                            counter++;
                                            toHighlight.Add(Convert.ToInt32(listView.SelectedItems[x].Text) - 1);
                                            //if (openFile()) labelFile.Text = openFileDialogOpenIVAUD.FileName;
                                            Application.DoEvents();
                                        }
                                    }
                                }
                            }

                            if (openFile()) labelFile.Text = openFileDialogOpenIVAUD.FileName;
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Replaced " + counter.ToString() + " samples.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }else{
                MessageBox.Show("Not 1 file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            this.Cursor = Cursors.Default;  
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (askSave){
                if (MessageBox.Show(this, "There is a file opened that has changes applied. If you quit now, these changes will be lost.\n\nDo you want to quit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) { e.Cancel = true; return; }
            }
            sp.Stop();
            if (IVAUD.file != null) IVAUD.close();
            try { if (Directory.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB")) Directory.Delete(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB", true); } catch { }
        }
        
        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp")) return;
            saveFileDialogSaveAs.FileName = Path.GetFileName(openFileDialogOpenIVAUD.FileName);
            if(saveFileDialogSaveAs.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.Cursor = Cursors.WaitCursor;
                if (saveFile(saveFileDialogSaveAs.FileName)) {
                    openFileDialogOpenIVAUD.FileName = saveFileDialogSaveAs.FileName;
                    labelFile.Text = openFileDialogOpenIVAUD.FileName;
                    MessageBox.Show("The file has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearHighlights();
                    askSave = false;
                } else {
                    MessageBox.Show("An error occured while saving the file. It could be write-protected. (MAIN10)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;                
            } else {
                this.Cursor = Cursors.Default;
                return;
            }            
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp")) return;
            if (saveFile(openFileDialogOpenIVAUD.FileName)) {
                MessageBox.Show("The file has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearHighlights();
                askSave = false;
            } else {
                MessageBox.Show("An error occured while saving the file. It could be write-protected. (MAIN10)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool saveFile(string target)
        {
            try{
                this.Cursor = Cursors.WaitCursor;
                File.Copy(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp", target, true);
                this.Cursor = Cursors.Default;  
                return true;
            }catch{
                this.Cursor = Cursors.Default;  
                return false;
            }
        }

        private void highlightRow(int index)
        {
            foreach (ListViewItem.ListViewSubItem lvi in listView.Items[index].SubItems) lvi.Font = new Font("Tahoma", 8, FontStyle.Bold);
        }

        private void clearHighlights()
        {
            foreach (ListViewItem lvi in listView.Items){
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems) lvsi.Font = new Font("Tahoma", 8);
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn){
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending){
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else{
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
            ListViewSortIcon.SetSortIcon(listView, lvwColumnSorter.SortColumn, lvwColumnSorter.Order);
        }
    }
}
