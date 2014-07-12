namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Wormhole : Wormhole._Wormhole
    {
        private int xBeenThrough;
        private int xCanSeeIt;
        private int xStability;
        private int xTargetWormholeID;
        private int xTurnNo;
        private int xUnknown;
        private int xWormholeID;
        private int xX;
        private int xY;

        public Wormhole(byte[] Data)
        {
            int start = 0;
            int num2 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.WormholeID = num2 & 0xfff;
            this.X = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.Y = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.Stability = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xBeenThrough = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xCanSeeIt = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.TargetWormholeID = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xTurnNo = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        [DispId(5)]
        public int AtlantisSoftware.Wormhole._Wormhole.Stability
        {
            get
            {
                return this.xStability;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Wormhole._Wormhole.TargetWormholeID
        {
            get
            {
                return this.xTargetWormholeID;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Wormhole._Wormhole.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.Wormhole._Wormhole.WormholeID
        {
            get
            {
                return this.xWormholeID;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Wormhole._Wormhole.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.Wormhole._Wormhole.Y
        {
            get
            {
                return this.xY;
            }
        }

        public int Stability
        {
            get
            {
                return this.xStability;
            }
            internal set
            {
                this.xStability = value;
            }
        }

        public int TargetWormholeID
        {
            get
            {
                return this.xTargetWormholeID;
            }
            internal set
            {
                this.xTargetWormholeID = value;
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

        public int WormholeID
        {
            get
            {
                return this.xWormholeID;
            }
            internal set
            {
                this.xWormholeID = value;
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
        public interface _Wormhole
        {
            [DispId(5)]
            int Stability { [DispId(5)] get; }

            [DispId(2)]
            int TargetWormholeID { [DispId(2)] get; }

            [DispId(6)]
            int Unknown { [DispId(6)] get; }

            [DispId(1)]
            int WormholeID { [DispId(1)] get; }

            [DispId(3)]
            int X { [DispId(3)] get; }

            [DispId(4)]
            int Y { [DispId(4)] get; }
        }
    }
}

