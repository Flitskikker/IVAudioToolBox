using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using WAV;

namespace IVAUDToolBox
{
    class IVAUDSingleC
    {
        public static bool exportSampleAsWAV(int sampleIndex, string path)
        {            
            byte[] buffer = new byte[1];
            short val;
            //WAV.IMAADPCM.ADPCMState state = IVAUDSingle.WIstates[sampleIndex][0];
            WAV.IMAADPCM.ADPCMState state = new IMAADPCM.ADPCMState();

            WAV.WAVFile target = new WAV.WAVFile();
            target.Create(path, false, IVAUDSingle.WIsamplerate[sampleIndex], 16, true);
            IVAUD.file.Seek(IVAUDSingle.WIoffset[sampleIndex] + IVAUDSingle.headerSize, SeekOrigin.Begin);
                        
            for (long i = 0; i < IVAUDSingle.WInumSamples16Bit[sampleIndex]; i += 2) {
                IVAUD.file.Read(buffer, 0, 1);
                val = WAV.IMAADPCM.decodeADPCM((byte)(buffer[0] & 0xf), ref state);
                target.AddSample_16bit(val);
                val = WAV.IMAADPCM.decodeADPCM((byte)((buffer[0] >> 4) & 0xf), ref state);
                target.AddSample_16bit(val);
            }
            target.Close();

            return true;
        }

        public static bool replaceSample(int sampleIndex, string path)
        {
            long offset = IVAUDSingle.WIoffset[sampleIndex] + IVAUDSingle.headerSize;
            byte[] dataBefore = new byte[offset - IVAUDSingle.headerSize];
            byte[] dataAfter = new byte[IVAUD.file.Length - (offset + IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex])];
                        
            //Get data between header and replaced sample
            IVAUD.file.Seek(IVAUDSingle.headerSize, SeekOrigin.Begin);
            IVAUD.file.Read(dataBefore, 0, dataBefore.Length);

            //Get data between replaced sample and eof
            IVAUD.file.Seek(offset + IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex], SeekOrigin.Begin);
            IVAUD.file.Read(dataAfter, 0, dataAfter.Length);

            //Close file
            IVAUD.close();

            //Open WAV file and encode it
            WAVFile wav = new WAVFile();
            wav.Open(path, WAVFile.WAVFileMode.READ);

            MemoryStream ms = new MemoryStream();
            IMAADPCM.ADPCMState state = new IMAADPCM.ADPCMState();
            //byte enc1, enc2;

            byte[] bytes = new byte[2];
            int loopValue = ((wav.DataSizeBytes - 8) / wav.BytesPerSample);

            /*Debug.WriteLine((((wav.DataSizeBytes - 8) / wav.BytesPerSample)) / 2);
            Debug.WriteLine(wav.NumSamples / 2);
            Debug.WriteLine((((wav.DataSizeBytes - 8) / wav.BytesPerSample)));
            Debug.WriteLine(wav.NumSamples);*/

            //for (long i = 0; i < wav.NumSamples / 2; i++) {
            for (long i = 0; i < loopValue / 2; i++) {
                bytes[0] = IMAADPCM.encodeADPCM(wav.GetNextSampleAs16Bit(), ref state);
                bytes[1] = IMAADPCM.encodeADPCM(wav.GetNextSampleAs16Bit(), ref state);
                ms.Write(BitConverter.GetBytes(Convert.ToInt32(Utils.binaryString(bytes[1], 4) + Utils.binaryString(bytes[0], 4), 2)), 0, 1);
            }

            long originalOffset = offset + IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex];

            //Change header values
            IVAUDSingle.WInumSamplesInBytes[sampleIndex] = (int)ms.Length;
            IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex] = Utils.getPaddedSize(IVAUDSingle.WInumSamplesInBytes[sampleIndex]);
            IVAUDSingle.WInumSamples16Bit[sampleIndex] = (int)(ms.Length * 2);
            IVAUDSingle.WIsamplerate[sampleIndex] = (ushort)wav.SampleRateHz;
            if (IVAUDSingle.WIHsize[sampleIndex] > 32) IVAUDSingle.WInumSamples16Bit2[sampleIndex] = (uint)(ms.Length * 2);

            //Change later offsets
            long newOffset = offset + IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex];
            long offsetChange = newOffset - originalOffset;

            for (int i = 0; i < IVAUDSingle.WIHoffset.Count; i++){
                if ((IVAUDSingle.WIoffset[i] + IVAUDSingle.headerSize) > offset) IVAUDSingle.WIoffset[i] += offsetChange;
            }

            wav.Close();
            
            //Get WAV data
            byte[] dataWAV = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(dataWAV, 0, (int)ms.Length);
            ms.Close();

            //Write header
            FileStream fs = new FileStream(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp", FileMode.Open, FileAccess.ReadWrite);
            fs.Seek(0, SeekOrigin.Begin);
            if (!IVAUDSingle.write(fs)) return false;
            
            //Write before-data
            fs.Seek(IVAUDSingle.headerSize, SeekOrigin.Begin);
            fs.Write(dataBefore, 0, dataBefore.Length);

            //Write sample
            fs.Seek(offset, SeekOrigin.Begin);
            fs.Write(dataWAV, 0, dataWAV.Length);

            //Write after-data
            fs.Seek(offset + IVAUDSingle.WInumSamplesInBytes_computed[sampleIndex], SeekOrigin.Begin);
            fs.Write(dataAfter, 0, dataAfter.Length);

            //Fix file length if needed
            if (offsetChange < 0) fs.SetLength(fs.Length + offsetChange);

            fs.Close();

            //Replace the file
            //IVAUD.close();
            //File.Copy(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Replace" + Utils.sessionID + ".tmp", Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp", true);
            
            //Reload the file
            IVAUD.load(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp");

            return true;
        }
    }
}
