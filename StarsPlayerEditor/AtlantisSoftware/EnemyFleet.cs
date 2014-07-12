namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class EnemyFleet : EnemyFleet._EnemyFleet
    {
        private int xBattlePlan;
        private int xBoranium = -1;
        private int xFleetID;
        private int xFuel = -1;
        private int xGermanium = -1;
        private int xIronium = -1;
        private int xOwnerID;
        private int xShipCountLength;
        private Collection xShips = new Collection();
        private int xShipTypes;
        private int xTotalWeight;
        private int xUnknown;
        private int xUnknown2;
        private int xUnknown3;
        private int xWarpSpeed;
        private int xX;
        private int xY;

        public EnemyFleet(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xFleetID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x1ff));
            this.xOwnerID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x200)), 15));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            if (Operators.ConditionalCompareObjectEqual(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 4, 1), 1, false))
            {
                this.xShipCountLength = 1;
            }
            else
            {
                this.xShipCountLength = 1;
            }
            object obj3 = RuntimeHelpers.GetObjectValue(functions.GetBit(Conversions.ToInteger(objectValue), 4));
            obj3 = 1;
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            this.xX = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xY = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xShipTypes = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            int bit = 0;
            do
            {
                if (Operators.ConditionalCompareObjectEqual(functions.GetBit(this.xShipTypes, bit), 1, false))
                {
                    AtlantisSoftware.Ships item = new AtlantisSoftware.Ships();
                    item.DesignID = bit;
                    item.ShipCount = Conversions.ToInteger(functions.GetBytes(Data, ref start, this.xShipCountLength));
                    this.Ships().Add(item, "ID" + Conversions.ToString(bit), null, null);
                }
                bit++;
            }
            while (bit <= 15);
            this.xUnknown = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown2 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xWarpSpeed = this.xUnknown & 15;
            this.xTotalWeight = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnknown3 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        public Collection Ships()
        {
            return this.xShips;
        }

        [DispId(9)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.BattlePlan
        {
            get
            {
                return this.xBattlePlan;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Boranium
        {
            get
            {
                return this.xBoranium;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.FleetID
        {
            get
            {
                return this.xFleetID;
            }
        }

        [DispId(8)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Fuel
        {
            get
            {
                return this.xFuel;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Germanium
        {
            get
            {
                return this.xGermanium;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Ironium
        {
            get
            {
                return this.xIronium;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
        }

        [DispId(10)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.EnemyFleet._EnemyFleet.Y
        {
            get
            {
                return this.xY;
            }
        }

        public int BattlePlan
        {
            get
            {
                return this.xBattlePlan;
            }
            internal set
            {
                this.xBattlePlan = value;
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

        public int Fuel
        {
            get
            {
                return this.xFuel;
            }
            internal set
            {
                this.xFuel = value;
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
        public interface _EnemyFleet
        {
            [DispId(11)]
            Collection Ships();

            [DispId(9)]
            int BattlePlan { [DispId(9)] get; }

            [DispId(6)]
            int Boranium { [DispId(6)] get; }

            [DispId(1)]
            int FleetID { [DispId(1)] get; }

            [DispId(8)]
            int Fuel { [DispId(8)] get; }

            [DispId(7)]
            int Germanium { [DispId(7)] get; }

            [DispId(5)]
            int Ironium { [DispId(5)] get; }

            [DispId(2)]
            int OwnerID { [DispId(2)] get; }

            [DispId(10)]
            int Unknown { [DispId(10)] get; }

            [DispId(3)]
            int X { [DispId(3)] get; }

            [DispId(4)]
            int Y { [DispId(4)] get; }
        }
    }
}

