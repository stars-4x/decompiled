namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Salvage : Salvage._Salvage
    {
        private int xBoranium;
        private int xGermanium;
        private int xIronium;
        private int xOwnerID;
        private int xSalvageID;
        private int xTargetPlanetID;
        private int xTurnNo;
        private int xUnknown;
        private int xWarpOverLimit;
        private int xWarpSpeed;
        private int xX;
        private int xY;

        public Salvage(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xSalvageID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x1ff));
            this.xOwnerID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x200)), 15));
            this.xX = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xY = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xTargetPlanetID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x3ff));
            this.xWarpSpeed = Conversions.ToInteger(Operators.AddObject(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x400)), 15), 4));
            this.xWarpOverLimit = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x4000)));
            this.xIronium = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xBoranium = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xGermanium = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xTurnNo = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        [DispId(9)]
        public int AtlantisSoftware.Salvage._Salvage.Boranium
        {
            get
            {
                return this.xBoranium;
            }
        }

        [DispId(10)]
        public int AtlantisSoftware.Salvage._Salvage.Germanium
        {
            get
            {
                return this.xGermanium;
            }
        }

        [DispId(8)]
        public int AtlantisSoftware.Salvage._Salvage.Ironium
        {
            get
            {
                return this.xIronium;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Salvage._Salvage.OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.Salvage._Salvage.SalvageID
        {
            get
            {
                return this.xSalvageID;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.Salvage._Salvage.TargetPlanetID
        {
            get
            {
                return this.xTargetPlanetID;
            }
        }

        [DispId(11)]
        public int AtlantisSoftware.Salvage._Salvage.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.Salvage._Salvage.WarpOverLimit
        {
            get
            {
                return this.xWarpOverLimit;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Salvage._Salvage.WarpSpeed
        {
            get
            {
                return this.xWarpSpeed;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Salvage._Salvage.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.Salvage._Salvage.Y
        {
            get
            {
                return this.xY;
            }
        }

        public int Boranium
        {
            get
            {
                return this.xBoranium;
            }
            internal set
            {
                this.xBoranium = value;
            }
        }

        public int Germanium
        {
            get
            {
                return this.xGermanium;
            }
            internal set
            {
                this.xGermanium = value;
            }
        }

        public int Ironium
        {
            get
            {
                return this.xIronium;
            }
            internal set
            {
                this.xIronium = value;
            }
        }

        public int OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
            internal set
            {
                this.xOwnerID = value;
            }
        }

        public int SalvageID
        {
            get
            {
                return this.xSalvageID;
            }
            internal set
            {
                this.xSalvageID = value;
            }
        }

        public int TargetPlanetID
        {
            get
            {
                return this.xTargetPlanetID;
            }
            internal set
            {
                this.xTargetPlanetID = value;
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

        public int WarpOverLimit
        {
            get
            {
                return this.xWarpOverLimit;
            }
            internal set
            {
                this.xWarpOverLimit = value;
            }
        }

        public int WarpSpeed
        {
            get
            {
                return this.xWarpSpeed;
            }
            internal set
            {
                this.xWarpSpeed = value;
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
        public interface _Salvage
        {
            [DispId(9)]
            int Boranium { [DispId(9)] get; }

            [DispId(10)]
            int Germanium { [DispId(10)] get; }

            [DispId(8)]
            int Ironium { [DispId(8)] get; }

            [DispId(2)]
            int OwnerID { [DispId(2)] get; }

            [DispId(1)]
            int SalvageID { [DispId(1)] get; }

            [DispId(5)]
            int TargetPlanetID { [DispId(5)] get; }

            [DispId(11)]
            int Unknown { [DispId(11)] get; }

            [DispId(7)]
            int WarpOverLimit { [DispId(7)] get; }

            [DispId(6)]
            int WarpSpeed { [DispId(6)] get; }

            [DispId(3)]
            int X { [DispId(3)] get; }

            [DispId(4)]
            int Y { [DispId(4)] get; }
        }
    }
}

