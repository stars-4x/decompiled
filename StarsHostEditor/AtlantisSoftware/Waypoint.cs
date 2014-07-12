namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    public class Waypoint
    {
        private int xFleetID;
        private int xOwnerID;
        private int xPositionObjectID;
        private int xWarpSpeed;
        private byte[] xWaypointData;
        private int xX;
        private int xY;

        public Waypoint(byte[] Data)
        {
            this.WaypointData = Data;
        }

        public int FleetID
        {
            get
            {
                return this.xFleetID;
            }
            internal set
            {
                this.xFleetID = value;
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

        public int PositionObjectID
        {
            get
            {
                return this.xPositionObjectID;
            }
            set
            {
                this.xPositionObjectID = value;
                this.xWaypointData[4] = (byte) (this.xPositionObjectID % 0x100);
                this.xWaypointData[5] = (byte) Math.Round(Conversion.Int((double) (((double) this.xPositionObjectID) / 256.0)));
            }
        }

        public byte[] WaypointData
        {
            get
            {
                return this.xWaypointData;
            }
            set
            {
                int start = 0;
                this.xWaypointData = value;
                this.xX = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xY = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xPositionObjectID = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                this.xWarpSpeed = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x10)));
                objectValue = Operators.AndObject(objectValue, 15);
                object obj3 = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
            }
        }

        public int X
        {
            get
            {
                return this.xX;
            }
            set
            {
                this.xX = value;
                this.xWaypointData[0] = (byte) (this.xX % 0x100);
                this.xWaypointData[1] = (byte) Math.Round(Conversion.Int((double) (((double) this.xX) / 256.0)));
            }
        }

        public int Y
        {
            get
            {
                return this.xY;
            }
            set
            {
                this.xY = value;
                this.xWaypointData[2] = (byte) (this.xY % 0x100);
                this.xWaypointData[3] = (byte) Math.Round(Conversion.Int((double) (((double) this.xY) / 256.0)));
            }
        }
    }
}

