using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CustomBase64
{
    class B64Converter
    {
        
        public static bool ToBase64(string inPath, string outPath)
        {
            char[] ConversionTable =
            {
                'A', 'B', 'C', 'D', 'E', 'F',
                'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f',
                'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x',
                'y', 'z',
                '0', '1', '2', '3', '4', '5',
                '6', '7', '8', '9', '+', '/'
             };

            using (BinaryReader inStream = new BinaryReader(File.Open(inPath, FileMode.Open)))
            using (BinaryWriter outStream = new BinaryWriter(File.Open(outPath, FileMode.Create)))
            {
                //3 bajty wejściowe
                byte[] inBytes = new byte[3];
                long inLength = new FileInfo(inPath).Length;

                if (inLength<1)
                {
                    return false;
                }

                long lastOctets = inLength % 3;

                //bity trzech oktetów sklejone
                BitArray inBits;

                BitArray inBits_1 = new BitArray(6);
                BitArray inBits_2 = new BitArray(6);
                BitArray inBits_3 = new BitArray(6);
                BitArray inBits_4 = new BitArray(6);

                int[] b1 = new int[1];
                int[] b2 = new int[1];
                int[] b3 = new int[1];
                int[] b4 = new int[1];

                for (long i = 0; i < inLength; i+=3)
                {

                    //rozpatrywanie paddingu tylko na sam koniec
                    if (i+3>=inLength)
                    {
                        inBytes[2] = inStream.ReadByte();
                        if (lastOctets!=1)
                        {
                            inBytes[1] = inStream.ReadByte();
                        }
                        if (lastOctets==0)
                        {
                            inBytes[0] = inStream.ReadByte();
                        }
                    }
                    else
                    {
                        inBytes[2] = inStream.ReadByte();
                        inBytes[1] = inStream.ReadByte();
                        inBytes[0] = inStream.ReadByte();
                    }

                    //3 bajty bit po bicie
                    inBits = new BitArray(inBytes);

                    //przepisywanie bitów...
                    
                    inBits_1[0] = inBits[0];
                    inBits_1[1] = inBits[1];
                    inBits_1[2] = inBits[2];
                    inBits_1[3] = inBits[3];
                    inBits_1[4] = inBits[4];
                    inBits_1[5] = inBits[5];

                    inBits_2[0] = inBits[6];
                    inBits_2[1] = inBits[7];
                    inBits_2[2] = inBits[8];
                    inBits_2[3] = inBits[9];
                    inBits_2[4] = inBits[10];
                    inBits_2[5] = inBits[11];

                    inBits_3[0] = inBits[12];
                    inBits_3[1] = inBits[13];
                    inBits_3[2] = inBits[14];
                    inBits_3[3] = inBits[15];
                    inBits_3[4] = inBits[16];
                    inBits_3[5] = inBits[17];

                    inBits_4[0] = inBits[18];
                    inBits_4[1] = inBits[19];
                    inBits_4[2] = inBits[20];
                    inBits_4[3] = inBits[21];
                    inBits_4[4] = inBits[22];
                    inBits_4[5] = inBits[23];

                    inBits_1.CopyTo(b1, 0);
                    inBits_2.CopyTo(b2, 0);
                    inBits_3.CopyTo(b3, 0);
                    inBits_4.CopyTo(b4, 0);

                    //wyjście

                    outStream.Write(ConversionTable[b4[0]]);
                    outStream.Write(ConversionTable[b3[0]]);

                    //j/w - padding
                    if (i + 3 >= inLength)
                    {
                        if (lastOctets == 1)
                            outStream.Write('=');
                        else
                            outStream.Write(ConversionTable[b2[0]]);

                        if (lastOctets != 0)
                            outStream.Write('=');
                        else
                            outStream.Write(ConversionTable[b1[0]]);
                    }
                    else
                    {
                        outStream.Write(ConversionTable[b2[0]]);
                        outStream.Write(ConversionTable[b1[0]]);
                    }
                }

            }
            return true;
        }

        public static bool FromBase64(string inPath, string outPath)
        {

            using (BinaryReader inStream = new BinaryReader(File.Open(inPath, FileMode.Open)))
            using (BinaryWriter outStream = new BinaryWriter(File.Open(outPath, FileMode.Create)))
            {


            }

            return false;
        }
    }

}
