namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using System;
    using System.IO;

    internal class Decryptor
    {
        private uint[] raw = new uint[] { 
            3, 5, 7, 11, 13, 0x11, 0x13, 0x17, 0x1d, 0x1f, 0x25, 0x29, 0x2b, 0x2f, 0x35, 0x3b, 
            0x3d, 0x43, 0x47, 0x49, 0x4f, 0x53, 0x59, 0x61, 0x65, 0x67, 0x6b, 0x6d, 0x71, 0x7f, 0x83, 0x89, 
            0x8b, 0x95, 0x97, 0x9d, 0xa3, 0xa7, 0xad, 0xb3, 0xb5, 0xbf, 0xc1, 0xc5, 0xc7, 0xd3, 0xdf, 0xe3, 
            0xe5, 0xe9, 0xef, 0xf1, 0xfb, 0x101, 0x107, 0x117, 0x10f, 0x115, 0x119, 0x11b, 0x125, 0x133, 0x137, 0x139
         };
        private uint RndA;
        private uint RndB;

        public void Decrypt(ref byte[] Data, int Size)
        {
            int num3 = Size - 1;
            for (int i = 0; i <= num3; i += 4)
            {
                uint num = Data[i];
                num += (uint) (Data[i + 1] * 0x100);
                num += (uint) (Data[i + 2] * 0x10000);
                num += (uint) (Data[i + 3] * 0x1000000L);
                num ^= this.NextRandom();
                Data[i] = (byte) (((ulong) num) % 0x100L);
                Data[i + 1] = (byte) Math.Round((double) (Conversion.Int((double) (((double) num) / 256.0)) % 256.0));
                Data[i + 2] = (byte) Math.Round((double) (Conversion.Int((double) (((double) num) / 65536.0)) % 256.0));
                Data[i + 3] = (byte) Math.Round((double) (Conversion.Int((double) (((double) num) / 16777216.0)) % 256.0));
            }
        }

        public void DisplayBlock(ref byte[] Data, int type, int size, BinaryWriter outfile)
        {
            outfile.Write((byte) (((type * 0x400) + size) % 0x100));
            outfile.Write((byte) Math.Round(Conversion.Int((double) (((double) ((type * 0x400) + size)) / 256.0))));
            int num2 = size - 1;
            for (int i = 0; i <= num2; i++)
            {
                outfile.Write(Data[i]);
            }
        }

        public void DisplayPlanet(ref byte[] Data, BinaryWriter outfile)
        {
            int index = 0;
            do
            {
                outfile.Write(Data[index]);
                index++;
            }
            while (index <= 3);
        }

        public void InitDecrypt(int a, int b, int c, int d, uint e)
        {
            int index = d & 0x1f;
            int num2 = (int) (((long) Math.Round(Conversion.Int((double) (((double) d) / 32.0)))) & 0x1fL);
            if ((d & 0x400) > 0)
            {
                index += 0x20;
            }
            else
            {
                num2 += 0x20;
            }
            this.RndA = this.raw[index];
            this.RndB = this.raw[num2];
            for (index = ((int) ((((e & 3L) + ((ulong) 1L)) * ((c & 3) + 1)) * ((b & 3) + 1))) + a; index >= 1; index += -1)
            {
                this.NextRandom();
            }
        }

        public uint NextRandom()
        {
            int num = (int) Math.Round((double) (((((ulong) this.RndA) % 0xd1a4L) * ((ulong) 0x9c4eL)) - (Conversion.Int((double) (((double) this.RndA) / 53668.0)) * 12211.0)));
            if (num < 0)
            {
                num += 0x7fffffab;
            }
            this.RndA = (uint) num;
            int num2 = (int) Math.Round((double) (((((ulong) this.RndB) % 0xce26L) * ((ulong) 0x9ef4L)) - (Conversion.Int((double) (((double) this.RndB) / 52774.0)) * 3791.0)));
            if (num2 < 0)
            {
                num2 += 0x7fffff07;
            }
            this.RndB = (uint) num2;
            if (num >= num2)
            {
                return (uint) (num - num2);
            }
            return (uint) Math.Round((double) (4294967296 + (num - num2)));
        }

        public byte[] OpenFile(string Filename)
        {
            FileStream input = new FileStream(Filename, FileMode.Open);
            MemoryStream output = new MemoryStream();
            BinaryReader file = new BinaryReader(input);
            BinaryWriter outfile = new BinaryWriter(output);
            do
            {
                int num;
                int num2;
                byte[] data = new byte[0x401];
                this.ReadBlock(file, ref data, ref num2, ref num);
                this.DisplayBlock(ref data, num2, num, outfile);
                if (num2 == 7)
                {
                    int num4 = data[10] + (data[11] * 0x100);
                    int num5 = num4 - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        this.ReadPlanet(file, ref data);
                        this.DisplayPlanet(ref data, outfile);
                    }
                }
            }
            while (input.Position != input.Length);
            input.Close();
            byte[] buffer = new byte[((int) (output.Length - 1L)) + 1];
            output.Seek(0L, SeekOrigin.Begin);
            output.Read(buffer, 0, (int) output.Length);
            output.Close();
            return buffer;
        }

        public void ProcessBlock(ref byte[] Data, byte type, int Size)
        {
            if (type == 8)
            {
                int a = Data[14] + (Data[15] * 0x100);
                int b = Data[12] + (Data[13] * 0x100);
                int c = Data[10] + (Data[11] * 0x100);
                int d = b;
                uint e = Data[4];
                e += (uint) (Data[5] * 0x100);
                e += (uint) (Data[6] * 0x10000);
                e += (uint) ((Data[7] * 0x10000L) * ((ulong) 0x100L));
                a = (int) (((long) Math.Round(Conversion.Int((double) (((double) a) / 4096.0)))) & 1L);
                b &= 0x1f;
                d = (int) Math.Round(Conversion.Int((double) (((double) d) / 32.0)));
                this.InitDecrypt(a, b, c, d, e);
            }
            else
            {
                this.Decrypt(ref Data, Size);
            }
        }

        public void ReadBlock(BinaryReader file, ref byte[] Data, ref int type, ref int Size)
        {
            file.Read(Data, 0, 2);
            Size = Data[0] + ((Data[1] & 3) * 0x100);
            type = (int) Math.Round(Conversion.Int((double) (((double) Data[1]) / 4.0)));
            if (Size > 0)
            {
                file.Read(Data, 0, Size);
            }
            this.ProcessBlock(ref Data, (byte) type, Size);
        }

        public void ReadPlanet(BinaryReader File, ref byte[] Data)
        {
            File.Read(Data, 0, 4);
        }

        public void SaveFile(byte[] Bytes, string Filename)
        {
            MemoryStream input = new MemoryStream();
            FileStream output = new FileStream(Filename, FileMode.Create);
            input.Write(Bytes, 0, Bytes.Length);
            input.Seek(0L, SeekOrigin.Begin);
            BinaryReader file = new BinaryReader(input);
            BinaryWriter outfile = new BinaryWriter(output);
            do
            {
                int num;
                int num2;
                byte[] data = new byte[0x401];
                this.ReadBlock(file, ref data, ref num2, ref num);
                this.DisplayBlock(ref data, num2, num, outfile);
                if (num2 == 7)
                {
                    int num4 = data[10] + (data[11] * 0x100);
                    int num5 = num4 - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        this.ReadPlanet(file, ref data);
                        this.DisplayPlanet(ref data, outfile);
                    }
                }
            }
            while (input.Position != input.Length);
            output.Close();
        }
    }
}

