using System;
using System.Collections;
using System.IO;

namespace CustomBase64
{
    internal class B64Converter
    {
        private readonly static char[] ConversionTable =
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

        public static bool ToBase64(string inPath, string outPath)
        {
            using (BinaryReader inStream = new BinaryReader(File.Open(inPath, FileMode.Open)))
            using (BinaryWriter outStream = new BinaryWriter(File.Open(outPath, FileMode.Create)))
            {
                //3 bajty wejściowe
                byte[] inBytes = new byte[3];
                long inLength = new FileInfo(inPath).Length;

                if (inLength < 1)
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

                for (long i = 0; i < inLength; i += 3)
                {
                    //rozpatrywanie paddingu tylko na sam koniec
                    if (i + 3 >= inLength)
                    {
                        inBytes[2] = inStream.ReadByte();
                        if (lastOctets != 1)
                        {
                            inBytes[1] = inStream.ReadByte();
                        }
                        if (lastOctets == 0)
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
                //4 bajty wejściowe
                byte[] inBytes = new byte[4];
                long inLength = new FileInfo(inPath).Length;
                int paddingLength = 0;
                if (inLength < 1 || inLength%4!=0)
                {
                    return false;
                }

                //bity czterech bajtów sklejone
                BitArray inBits;

                BitArray inBits_1 = new BitArray(8);
                BitArray inBits_2 = new BitArray(8);
                BitArray inBits_3 = new BitArray(8);

                int[] b1 = new int[1];
                int[] b2 = new int[1];
                int[] b3 = new int[1];

                byte[] inBytesFound = new byte[4];

                for (int i = 0; i < inLength; i += 4)
                {
                    inBytes[3] = inStream.ReadByte();
                    inBytes[2] = inStream.ReadByte();
                    inBytes[1] = inStream.ReadByte();
                    inBytes[0] = inStream.ReadByte();

                    //konwersja bitów base64 na ich miejsca w tablicy ("wejściowe")
                    inBytesFound[0] = (byte)Array.FindIndex(ConversionTable, c => c == inBytes[0]);
                    inBytesFound[1] = (byte)Array.FindIndex(ConversionTable, c => c == inBytes[1]);
                    inBytesFound[2] = (byte)Array.FindIndex(ConversionTable, c => c == inBytes[2]);
                    inBytesFound[3] = (byte)Array.FindIndex(ConversionTable, c => c == inBytes[3]);

                    if (i + 4 == inLength)
                    {
                        if (inBytesFound[0] == 255)
                        {
                            if (inBytesFound[1] == 255)
                            {
                                paddingLength = 2;
                            }
                            else
                            {
                                paddingLength = 1;
                            }
                        }
                    }
                    //bajty na bity
                    inBits = new BitArray(inBytesFound);

                    //przepisanie z pomnięciem 2 bitów na bajt i zapis do pliku
                    inBits_3[0] = inBits[20];
                    inBits_3[1] = inBits[21];
                    inBits_3[2] = inBits[24];
                    inBits_3[3] = inBits[25];
                    inBits_3[4] = inBits[26];
                    inBits_3[5] = inBits[27];
                    inBits_3[6] = inBits[28];
                    inBits_3[7] = inBits[29];

                    inBits_3.CopyTo(b3, 0);
                    outStream.Write((byte)b3[0]);

                    if (paddingLength < 2)
                    {
                        inBits_2[0] = inBits[10];
                        inBits_2[1] = inBits[11];
                        inBits_2[2] = inBits[12];
                        inBits_2[3] = inBits[13];
                        inBits_2[4] = inBits[16];
                        inBits_2[5] = inBits[17];
                        inBits_2[6] = inBits[18];
                        inBits_2[7] = inBits[19];

                        inBits_2.CopyTo(b2, 0);
                        outStream.Write((byte)b2[0]);

                        if (paddingLength < 1)
                        {
                            inBits_1[0] = inBits[0];
                            inBits_1[1] = inBits[1];
                            inBits_1[2] = inBits[2];
                            inBits_1[3] = inBits[3];
                            inBits_1[4] = inBits[4];
                            inBits_1[5] = inBits[5];
                            inBits_1[6] = inBits[8];
                            inBits_1[7] = inBits[9];

                            inBits_1.CopyTo(b1, 0);
                            outStream.Write((byte)b1[0]);
                        }
                    }
                }
            }
            return true;
        }
    }
}