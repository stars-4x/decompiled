namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Header : Header._Header
    {
        private byte[] xData;
        private int xEncryptionSeed;
        private int xFiletype;
        private int xFlags;
        private uint xGameID;
        private bool xHostUsingFile;
        private int xPlayerNo;
        private bool xSubmitted;
        private uint xTurnNo;
        private uint xVersion;

        public Header()
        {
            this.xData = new byte[0x10];
            this.xData[0] = 0x4a;
            this.xData[1] = 0x33;
            this.xData[2] = 0x4a;
            this.xData[3] = 0x33;
            this.xData[13] = 1;
            this.xData[8] = 0x60;
            this.xData[9] = 0x2a;
            this.xData[14] = 2;
            this.xData[15] = 0x80;
        }

        public Header(byte[] value)
        {
            this.Data = value;
        }

        [DispId(1)]
        public byte[] AtlantisSoftware.Header._Header.Data
        {
            get
            {
                return this.xData;
            }
            set
            {
                this.xData = value;
                this.xGameID = value[4];
                this.xGameID += (uint) (value[5] * 0x100);
                this.xGameID += (uint) ((value[6] * 0x100) * 0x100);
                this.xGameID += (uint) (((value[7] * 0x100) * 0x100) * 0x100);
                this.xVersion = (uint) (value[8] + (value[9] * 0x100));
                this.xTurnNo = (uint) (value[10] + (value[11] * 0x100));
                this.xPlayerNo = value[12] & 0x1f;
                this.xFiletype = value[14];
                this.xFlags = value[15];
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.Header._Header.FileType
        {
            get
            {
                return this.xFiletype;
            }
            set
            {
                this.xFiletype = value;
                this.xData[14] = (byte) (value % 0x100);
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Header._Header.Flags
        {
            get
            {
                return this.xFlags;
            }
            set
            {
                this.xFlags = value;
                this.xData[15] = (byte) value;
            }
        }

        [DispId(4)]
        public uint AtlantisSoftware.Header._Header.GameID
        {
            get
            {
                return this.xGameID;
            }
            set
            {
                this.xGameID = value;
                this.xData[4] = (byte) (value & 0xffL);
                this.xData[5] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) value) / 256.0)))) & 0xffL);
                this.xData[6] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) value) / 256.0) / 256.0)))) & 0xffL);
                this.xData[7] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) value) / 256.0) / 256.0) / 256.0)))) & 0xffL);
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Header._Header.PlayerNo
        {
            get
            {
                return this.xPlayerNo;
            }
            set
            {
                this.xPlayerNo = value;
                this.xData[12] = (byte) ((this.xData[12] & 0xe0) + value);
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.Header._Header.TurnNo
        {
            get
            {
                return (int) this.xTurnNo;
            }
            set
            {
                this.xTurnNo = (uint) value;
                this.xData[10] = (byte) (value % 0x100);
                this.xData[11] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Header._Header.Version
        {
            get
            {
                return (int) this.xVersion;
            }
            set
            {
                this.xVersion = (uint) value;
                this.xData[8] = (byte) (value % 0x100);
                this.xData[9] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        public byte[] Data
        {
            get
            {
                return this.xData;
            }
            set
            {
                this.xData = value;
                this.xGameID = value[4];
                this.xGameID += (uint) (value[5] * 0x100);
                this.xGameID += (uint) ((value[6] * 0x100) * 0x100);
                this.xGameID += (uint) (((value[7] * 0x100) * 0x100) * 0x100);
                this.xVersion = (uint) (value[8] + (value[9] * 0x100));
                this.xTurnNo = (uint) (value[10] + (value[11] * 0x100));
                this.xPlayerNo = value[12] & 0x1f;
                this.xFiletype = value[14];
                this.xFlags = value[15];
            }
        }

        public int FileType
        {
            get
            {
                return this.xFiletype;
            }
            set
            {
                this.xFiletype = value;
                this.xData[14] = (byte) (value % 0x100);
            }
        }

        public int Flags
        {
            get
            {
                return this.xFlags;
            }
            set
            {
                this.xFlags = value;
                this.xData[15] = (byte) value;
            }
        }

        public uint GameID
        {
            get
            {
                return this.xGameID;
            }
            set
            {
                this.xGameID = value;
                this.xData[4] = (byte) (value & 0xffL);
                this.xData[5] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) value) / 256.0)))) & 0xffL);
                this.xData[6] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) value) / 256.0) / 256.0)))) & 0xffL);
                this.xData[7] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) value) / 256.0) / 256.0) / 256.0)))) & 0xffL);
            }
        }

        public int PlayerNo
        {
            get
            {
                return this.xPlayerNo;
            }
            set
            {
                this.xPlayerNo = value;
                this.xData[12] = (byte) ((this.xData[12] & 0xe0) + value);
            }
        }

        public int TurnNo
        {
            get
            {
                return (int) this.xTurnNo;
            }
            set
            {
                this.xTurnNo = (uint) value;
                this.xData[10] = (byte) (value % 0x100);
                this.xData[11] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        public int Version
        {
            get
            {
                return (int) this.xVersion;
            }
            set
            {
                this.xVersion = (uint) value;
                this.xData[8] = (byte) (value % 0x100);
                this.xData[9] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        [ComVisible(true)]
        public interface _Header
        {
            [DispId(1)]
            byte[] Data { [DispId(1)] get; [DispId(1)] set; }

            [DispId(7)]
            int FileType { [DispId(7)] get; [DispId(7)] set; }

            [DispId(2)]
            int Flags { [DispId(2)] get; [DispId(2)] set; }

            [DispId(4)]
            uint GameID { [DispId(4)] get; [DispId(4)] set; }

            [DispId(3)]
            int PlayerNo { [DispId(3)] get; [DispId(3)] set; }

            [DispId(5)]
            int TurnNo { [DispId(5)] get; [DispId(5)] set; }

            [DispId(6)]
            int Version { [DispId(6)] get; [DispId(6)] set; }
        }
    }
}

