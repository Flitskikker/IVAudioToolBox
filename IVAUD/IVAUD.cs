using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;
using WAV;

namespace IVAUDToolBox
{    
    class IVAUD
    {
        public enum IVAUDType
        {
            Null, Single, SingleC, Multi, MultiC
        };

        public static FileStream file;
        public static IVAUDType fileType;
        
        public static bool load(string path)
        {
            if(file != null) file.Close();
            if (!File.Exists(path)) return false;
            file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            return true;
        }

        public static void close()
        {
            file.Close();
        }

        public static bool readType()
        {
            byte[] buffer = new byte[4];
            file.Seek(0, SeekOrigin.Begin);
            file.Read(buffer, 0, 4);
            int begin = BitConverter.ToInt32(buffer, 0);

            file.Seek(20, SeekOrigin.Begin);
            file.Read(buffer, 0, 4);
            int middle = BitConverter.ToInt32(buffer, 0);

            if (middle == 0) fileType = IVAUDType.Single;
            else if (begin != 28) fileType = IVAUDType.MultiC;
            else if (middle != 0) fileType = IVAUDType.SingleC;            
            else fileType = IVAUDType.Null;

            if (fileType == IVAUDType.Null) return false; else return true;
        }

        public static MemoryStream encodeCompressedFromWAV(string source)
        {
            WAVFile wav = new WAVFile();
            MemoryStream ms = new MemoryStream();
            wav.Open(source, WAVFile.WAVFileMode.READ);            
             
            IMAADPCM.ADPCMState state = new IMAADPCM.ADPCMState();
            byte enc1, enc2;

            for (long i = 0; i < wav.NumSamples / 2; i++) {
                enc1 = IMAADPCM.encodeADPCM(wav.GetNextSampleAs16Bit(), ref state);                            
                enc2 = IMAADPCM.encodeADPCM(wav.GetNextSampleAs16Bit(), ref state);
                ms.Write(BitConverter.GetBytes(Convert.ToInt32(Utils.binaryString(enc2, 4) + Utils.binaryString(enc1, 4), 2)), 0, 1);
            }

            wav.Close();
            return ms;
        }

        public static void decodeCompressedToWAV(MemoryStream data, WAVFile target)
        {
            //WAVFile wav = new WAVFile();
            //wav.Create(@"E:\TEMP\SPARKIV\~AudioModding\STARTING_TUNE_LEFT_DECODED.wav", false, 44100, 16, true);

            //FileStream fs = new FileStream(@"E:\TEMP\SPARKIV\~AudioModding\STARTING_TUNE_LEFT.bin", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1];

            IMAADPCM.ADPCMState state = new IMAADPCM.ADPCMState();
            short val;
                        
            for (long i = 0; i < data.Length; i++) {
                data.Read(buffer, 0, 1);
                val = IMAADPCM.decodeADPCM((byte)(buffer[0] & 0xf), ref state);
                target.AddSample_16bit(val);
                val = IMAADPCM.decodeADPCM((byte)((buffer[0] >> 4) & 0xf), ref state);
                target.AddSample_16bit(val);
            }

            data.Close();
            target.Close();
        }
    }
}
