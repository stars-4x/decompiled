namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class Minefield : Minefield._Minefield
    {
        private bool xExplodingMinefield;
        private uint xMinecount;
        private int xMinefieldID;
        private int xPlayerID;
        private int xTurnNo;
        private int xType;
        private int xUnknown1;
        private int xUnknown2;
        private int xUnknown3;
        private int xX;
        private int xY;

        public Minefield(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xMinefieldID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x1ff));
            this.xPlayerID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x200)), 15));
            this.xX = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xY = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xMinecount = Conversions.ToUInteger(functions.GetBytes(Data, ref start, 4));
            this.xUnknown1 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown2 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xType = Conversions.ToInteger(functions.GetBits(this.xUnknown2, 0, 2));
            this.xExplodingMinefield = Conversions.ToBoolean(functions.GetBit(this.xUnknown2, 9));
            this.xUnknown3 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xTurnNo = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        [DispId(10)]
        public bool AtlantisSoftware.Minefield._Minefield.ExplodingMinefield
        {
            get
            {
                return this.xExplodingMinefield;
            }
        }

        [DispId(5)]
        public uint AtlantisSoftware.Minefield._Minefield.Minecount
        {
            get
            {
                return this.xMinecount;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.Minefield._Minefield.MinefieldID
        {
            get
            {
                return this.xMinefieldID;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Minefield._Minefield.PlayerID
        {
            get
            {
                return this.xPlayerID;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Minefield._Minefield.Type
        {
            get
            {
                return this.xType;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.Minefield._Minefield.Unknown1
        {
            get
            {
                return this.xUnknown1;
            }
        }

        [DispId(8)]
        public int AtlantisSoftware.Minefield._Minefield.Unknown2
        {
            get
            {
                return this.xUnknown2;
            }
        }

        [DispId(9)]
        public int AtlantisSoftware.Minefield._Minefield.Unknown3
        {
            get
            {
                return this.xUnknown3;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Minefield._Minefield.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.Minefield._Minefield.Y
        {
            get
            {
                return this.xY;
            }
        }

        public bool ExplodingMinefield
        {
            get
            {
                return this.xExplodingMinefield;
            }
            internal set
            {
                this.xExplodingMinefield = value;
                if (value)
                {
                    this.xUnknown2 |= 0x100;
                }
                else
                {
                    this.xUnknown2 &= 0xfeff;
                }
            }
        }

        public uint Minecount
        {
            get
            {
                return this.xMinecount;
            }
            internal set
            {
                this.xMinecount = value;
            }
        }

        public int MinefieldID
        {
            get
            {
                return this.xMinefieldID;
            }
            internal set
            {
                this.xMinefieldID = value;
            }
        }

        public int PlayerID
        {
            get
            {
                return this.xPlayerID;
            }
            internal set
            {
                this.xPlayerID = value;
            }
        }

        public int Type
        {
            get
            {
                return this.xType;
            }
            internal set
            {
                this.xType = value;
            }
        }

        public int Unknown1
        {
            get
            {
                return this.xUnknown1;
            }
            internal set
            {
                this.xUnknown1 = value;
            }
        }

        public int Unknown2
        {
            get
            {
                return this.xUnknown2;
            }
            internal set
            {
                this.xUnknown2 = value;
            }
        }

        public int Unknown3
        {
            get
            {
                return this.xUnknown3;
            }
            internal set
            {
                this.xUnknown3 = value;
            }
        }

        public int X
        {
            get
            {
                return this.xX;
            }
            internal set
            {
                this.xX = value;
            }
        }

        public int Y
        {
            get
            {
                return this.xY;
            }
            internal set
            {
                this.xY = value;
            }
        }

        [ComVisible(true)]
        public interface _Minefield
        {
            [DispId(10)]
            bool ExplodingMinefield { [DispId(10)] get; }

            [DispId(5)]
            uint Minecount { [DispId(5)] get; }

            [DispId(1)]
            int MinefieldID { [DispId(1)] get; }

            [DispId(2)]
            int PlayerID { [DispId(2)] get; }

            [DispId(6)]
            int Type { [DispId(6)] get; }

            [DispId(7)]
            int Unknown1 { [DispId(7)] get; }

            [DispId(8)]
            int Unknown2 { [DispId(8)] get; }

            [DispId(9)]
            int Unknown3 { [DispId(9)] get; }

            [DispId(3)]
            int X { [DispId(3)] get; }

            [DispId(4)]
            int Y { [DispId(4)] get; }
        }
    }
}

