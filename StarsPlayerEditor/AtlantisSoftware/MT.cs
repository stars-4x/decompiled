namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class MT : MT._MT
    {
        private int xDestX;
        private int xDestY;
        private int xItems;
        private int xMetMT;
        private int xMTID;
        private int xSpeed;
        private int xTurnNo;
        private int xUnknown;
        private int xX;
        private int xY;

        public MT(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xMTID = Conversions.ToInteger(Operators.AndObject(objectValue, 0xfff));
            this.xX = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xY = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xDestX = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xDestY = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xSpeed = this.xUnknown & 15;
            this.xMetMT = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xItems = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xTurnNo = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        [DispId(4)]
        public int AtlantisSoftware.MT._MT.DestX
        {
            get
            {
                return this.xDestX;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.MT._MT.DestY
        {
            get
            {
                return this.xDestY;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.MT._MT.MTID
        {
            get
            {
                return this.xMTID;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.MT._MT.Speed
        {
            get
            {
                return this.xSpeed;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.MT._MT.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.MT._MT.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.MT._MT.Y
        {
            get
            {
                return this.xY;
            }
        }

        public int DestX
        {
            get
            {
                return this.xDestX;
            }
            internal set
            {
                this.xDestX = value;
            }
        }

        public int DestY
        {
            get
            {
                return this.xDestY;
            }
            internal set
            {
                this.xDestY = value;
            }
        }

        public int MTID
        {
            get
            {
                return this.xMTID;
            }
            internal set
            {
                this.xMTID = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.xSpeed;
            }
            internal set
            {
                this.xSpeed = value;
            }
        }

        public int Unknown
        {
            get
            {
                return this.xUnknown;
            }
            internal set
            {
                this.xUnknown = value;
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
        public interface _MT
        {
            [DispId(4)]
            int DestX { [DispId(4)] get; }

            [DispId(5)]
            int DestY { [DispId(5)] get; }

            [DispId(1)]
            int MTID { [DispId(1)] get; }

            [DispId(6)]
            int Speed { [DispId(6)] get; }

            [DispId(7)]
            int Unknown { [DispId(7)] get; }

            [DispId(2)]
            int X { [DispId(2)] get; }

            [DispId(3)]
            int Y { [DispId(3)] get; }
        }
    }
}

