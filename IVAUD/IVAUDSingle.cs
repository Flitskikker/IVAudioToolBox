using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using WAV;

namespace IVAUDToolBox
{
    class IVAUDSingle
    {
        //IVAUD Header
        public static long offsetWaveInfo;
        public static long offsetUnknownTable;
        public static int numBlocks;
        public static int numUnknownTableEntries;
        public static int headerSize;

        //WaveInfoHeader
        public static List<long> WIHoffset = new List<long>();
        public static List<uint> WIHhash = new List<uint>();
        public static List<int> WIHsize = new List<int>();

        //WaveInfo
        public static List<long> WIoffset = new List<long>();
        public static List<uint> WIhash = new List<uint>();
        public static List<int> WInumSamplesInBytes = new List<int>();
        public static List<int> WInumSamples16Bit = new List<int>();
        public static List<ushort> WIsamplerate = new List<ushort>();
        public static List<long> WIoffsetToStates = new List<long>();
        public static List<uint> WInumSamples16Bit2 = new List<uint>();
        public static List<int> WInumStates = new List<int>();
        public static List<WAV.IMAADPCM.ADPCMState[]> WIstates = new List<WAV.IMAADPCM.ADPCMState[]>();
        public static List<int> WInumSamplesInBytes_computed = new List<int>();
        public static List<bool> WIis_compressed = new List<bool>();
        public static List<int> WIunk5 = new List<int>();
        public static List<ushort> WIunk6 = new List<ushort>();
        public static List<int> WIunk7 = new List<int>();
        public static List<uint> WIunk11 = new List<uint>();
        public static List<uint> WIunk12 = new List<uint>();

        public static bool read()
        {
            //Clear ALL the things!
            WIHoffset.Clear(); WIHhash.Clear(); WIHsize.Clear();
            WIoffset.Clear(); WIhash.Clear(); WInumSamplesInBytes.Clear(); WInumSamples16Bit.Clear();
            WIsamplerate.Clear(); WIoffsetToStates.Clear(); WInumSamples16Bit2.Clear(); WInumStates.Clear();
            WIstates.Clear(); WInumSamplesInBytes_computed.Clear(); WIis_compressed.Clear();

            
            BinaryReader br = new BinaryReader(IVAUD.file);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            
            //Read Header
            offsetWaveInfo = br.ReadInt64();
            offsetUnknownTable = br.ReadInt64();
            numBlocks = br.ReadInt32();
            numUnknownTableEntries = br.ReadInt32();
            headerSize = br.ReadInt32();

            if (offsetWaveInfo > headerSize) return false; //throw new Exception("WaveInfo is outside of header");
            
            //Read WaveInfo Header
            br.BaseStream.Seek(offsetWaveInfo, SeekOrigin.Begin);

            for (int i = 0; i < numBlocks; i++){
                WIHoffset.Add(br.ReadInt64());
                WIHhash.Add(br.ReadUInt32());
                WIHsize.Add(br.ReadInt32());
            }

            //Read WaveInfo
            long position = br.BaseStream.Position;

            for (int i = 0; i < WIHoffset.Count; i++){
                br.BaseStream.Seek(position + WIHoffset[i], SeekOrigin.Begin);

                WIoffset.Add(br.ReadInt64());
                WIhash.Add(br.ReadUInt32());
                WInumSamplesInBytes.Add(br.ReadInt32());
                WInumSamplesInBytes_computed.Add(Utils.getPaddedSize(WInumSamplesInBytes[i]));
                WInumSamples16Bit.Add(br.ReadInt32());
                WIunk5.Add(br.ReadInt32()); //unk5
                WIsamplerate.Add(br.ReadUInt16());
                WIunk6.Add(br.ReadUInt16()); //unk6

                if (WIHsize[i] > 32) {
                    WIunk7.Add(br.ReadInt32()); //unk7
                    WIoffsetToStates.Add(br.ReadInt64());
                    WInumSamples16Bit2.Add(br.ReadUInt32());
                    WIunk11.Add(br.ReadUInt32()); //unk11
                    WIunk12.Add(br.ReadUInt32()); //unk12
                    WInumStates.Add(br.ReadInt32());
                    if (WInumStates[i] > 0){
                        WIis_compressed.Add(true);
                        WIstates.Add(new WAV.IMAADPCM.ADPCMState[WInumStates[i]]);
                        for (int j = 0; j < WInumStates[i]; j++){
                            WAV.IMAADPCM.ADPCMState state = new WAV.IMAADPCM.ADPCMState();
                            state.valprev = br.ReadInt16();
                            state.index = br.ReadByte();
                            WIstates[i][j] = state;
                        }
                    }else{
                        WIis_compressed.Add(false);
                        WIstates.Add(new WAV.IMAADPCM.ADPCMState[0]);
                    }
                }else{
                    WIunk7.Add(0); //unk7
                    WIoffsetToStates.Add(0);
                    WInumSamples16Bit2.Add(0);
                    WIunk11.Add(0); //unk11
                    WIunk12.Add(0); //unk12
                    WInumStates.Add(0);
                    WIis_compressed.Add(false);
                    WIstates.Add(new WAV.IMAADPCM.ADPCMState[0]);
                }
            }

            //br.Close();
            return true;
        }

        public static bool write(FileStream fs)
        {
            BinaryWriter bw = new BinaryWriter(fs);
            long startOffset = bw.BaseStream.Position;

            bw.Write(offsetWaveInfo);
            bw.Write(offsetUnknownTable);
            bw.Write(numBlocks);
            bw.Write(numUnknownTableEntries);
            bw.Write(headerSize);

            if (offsetWaveInfo > headerSize) return false; //throw new Exception("WaveInfo is outside of header");
            
            //Read WaveInfo Header
            bw.BaseStream.Seek(startOffset + offsetWaveInfo, SeekOrigin.Begin);

            for (int i = 0; i < numBlocks; i++){
                bw.Write(WIHoffset[i]);
                bw.Write(WIHhash[i]);
                bw.Write(WIHsize[i]);
            }

            //Read WaveInfo
            long position = bw.BaseStream.Position;

            for (int i = 0; i < WIHoffset.Count; i++){
                bw.BaseStream.Seek(position + WIHoffset[i], SeekOrigin.Begin);                
                bw.Write(WIoffset[i]);
                bw.Write(WIhash[i]);
                bw.Write(WInumSamplesInBytes[i]);
                bw.Write(WInumSamples16Bit[i]);
                bw.Write(WIunk5[i]); //unk5
                bw.Write(WIsamplerate[i]);
                bw.Write(WIunk6[i]); //unk6

                if (WIHsize[i] > 32) {
                    bw.Write(WIunk7[i]);
                    bw.Write(WIoffsetToStates[i]);
                    bw.Write(WInumSamples16Bit2[i]);
                    bw.Write(WIunk11[i]); //unk11
                    bw.Write(WIunk12[i]); //unk12
                    bw.Write(WInumStates[i]);
                    if (WInumStates[i] > 0){
                        for (int j = 0; j < WInumStates[i]; j++){
                            bw.Write(WIstates[i][j].valprev);
                            bw.Write(WIstates[i][j].index);
                        }
                    }
                }
            }

            return true;
        }

        public static bool exportSampleAsWAV(int sampleIndex, string path)
        {
            byte[] buffer = new byte[2];

            WAV.WAVFile target = new WAV.WAVFile();
            target.Create(path, false, WIsamplerate[sampleIndex], 16, true);
            IVAUD.file.Seek(WIoffset[sampleIndex] + headerSize, SeekOrigin.Begin);
                        
            for (long i = 0; i < WInumSamples16Bit[sampleIndex]; i++) {
                IVAUD.file.Read(buffer, 0, 2);
                target.AddSample_16bit(BitConverter.ToInt16(buffer, 0));
            }
            target.Close();
            
            return true;
        }

        public static bool replaceSample(int sampleIndex, string path)
        {
            long offset = WIoffset[sampleIndex] + headerSize;
            byte[] dataBefore = new byte[offset - headerSize];
            byte[] dataAfter = new byte[IVAUD.file.Length - (offset + WInumSamplesInBytes_computed[sampleIndex])];
            
            //Get data between header and replaced sample
            IVAUD.file.Seek(headerSize, SeekOrigin.Begin);
            IVAUD.file.Read(dataBefore, 0, dataBefore.Length);

            //Get data between replaced sample and eof
            IVAUD.file.Seek(offset + WInumSamplesInBytes_computed[sampleIndex], SeekOrigin.Begin);
            IVAUD.file.Read(dataAfter, 0, dataAfter.Length);

            //Close file
            IVAUD.close();

            //Open WAV file and save replacement
            WAVFile wav = new WAVFile();
            wav.Open(path, WAVFile.WAVFileMode.READ);
            wav.SeekToAudioDataStart();

            long WAVOffset = wav.FilePosition;
            long WAVLength = wav.DataSizeBytes;
            long originalOffset = offset + WInumSamplesInBytes_computed[sampleIndex];
            
            //Change header values
            WInumSamplesInBytes[sampleIndex] = wav.DataSizeBytes;
            WInumSamplesInBytes_computed[sampleIndex] =  Utils.getPaddedSize(WInumSamplesInBytes[sampleIndex]);
            WInumSamples16Bit[sampleIndex] = wav.NumSamples;
            WIsamplerate[sampleIndex] = (ushort)wav.SampleRateHz;
            if (WIHsize[sampleIndex] > 32) WInumSamples16Bit2[sampleIndex] = (uint)wav.NumSamples;

            //Change later offsets
            long newOffset = offset + WInumSamplesInBytes_computed[sampleIndex];
            long offsetChange = newOffset - originalOffset;

            for (int i = 0; i < WIHoffset.Count; i++){
                if ((WIoffset[i] + headerSize) > offset) WIoffset[i] += offsetChange;
            }

            wav.Close();
            
            //Get WAV data
            FileStream fsWAV = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] dataWAV = new byte[WAVLength];
            fsWAV.Seek(WAVOffset, SeekOrigin.Begin);
            fsWAV.Read(dataWAV, 0, (int)WAVLength);
            fsWAV.Close();

            //Write header
            FileStream fs = new FileStream(Environment.GetEnvironmentVariable("TEMP") + "\\IVATB\\Current" + Utils.sessionID + ".tmp", FileMode.Open, FileAccess.ReadWrite);
            fs.Seek(0, SeekOrigin.Begin);
            if (!write(fs)) return false;
            
            //Write before-data
            fs.Seek(headerSize, SeekOrigin.Begin);
            fs.Write(dataBefore, 0, dataBefore.Length);

            //Write sample
            fs.Seek(offset, SeekOrigin.Begin);
            fs.Write(dataWAV, 0, dataWAV.Length);

            //Write after-data
            fs.Seek(offset + WInumSamplesInBytes_computed[sampleIndex], SeekOrigin.Begin);
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
