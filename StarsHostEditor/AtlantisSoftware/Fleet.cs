namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class Fleet : Fleet._Fleet
    {
        public Collection Waypoints = new Collection();
        private int xBattlePlan;
        private int xBoranium;
        private byte[] xFleetData;
        private int xFleetID;
        private int xFuel;
        private int xGermanium;
        private int xIronium;
        private int xOwnerID;
        private int xPopulation;
        private int xPositionObjectID;
        private Collection xShips = new Collection();
        private int xUnknown;
        private int xX;
        private int xY;

        public Fleet(byte[] Data)
        {
            this.FleetData = Data;
        }

        public Collection Ships()
        {
            return this.xShips;
        }

        [DispId(11)]
        public int AtlantisSoftware.Fleet._Fleet.BattlePlan
        {
            get
            {
                return this.xBattlePlan;
            }
            set
            {
                this.xBattlePlan = value;
            }
        }

        [DispId(8)]
        public int AtlantisSoftware.Fleet._Fleet.Boranium
        {
            get
            {
                return this.xBoranium;
            }
            set
            {
                this.xBoranium = value;
            }
        }

        [DispId(1)]
        public byte[] AtlantisSoftware.Fleet._Fleet.FleetData
        {
            get
            {
                return this.xFleetData;
            }
            set
            {
                int num3;
                this.xFleetData = value;
                int start = 0;
                this.xFleetData = value;
                object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                this.xFleetID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x1ff));
                this.xOwnerID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x200)), 15));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                if (Operators.ConditionalCompareObjectEqual(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 3, 1), 1, false))
                {
                    num3 = 1;
                }
                else
                {
                    num3 = 2;
                }
                object obj5 = RuntimeHelpers.GetObjectValue(functions.GetBit(Conversions.ToInteger(objectValue), 4));
                obj5 = 1;
                int num2 = Conversions.ToInteger(functions.GetBit(Conversions.ToInteger(objectValue), 6));
                num2 = 1;
                this.xPositionObjectID = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xX = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xY = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                int num4 = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                int bit = 0;
                do
                {
                    if (Operators.ConditionalCompareObjectEqual(functions.GetBit(num4, bit), 1, false))
                    {
                        AtlantisSoftware.Ships item = new AtlantisSoftware.Ships();
                        item.DesignID = bit;
                        item.ShipCount = Conversions.ToInteger(functions.GetBytes(value, ref start, num3));
                        this.Ships().Add(item, "ID" + Conversions.ToString(this.xOwnerID) + "-" + Conversions.ToString(bit), null, null);
                    }
                    bit++;
                }
                while (bit <= 15);
                object obj4 = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                object obj8 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 0, 2), 1))));
                object obj3 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 2, 2), 1))));
                object obj7 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 4, 2), 1))));
                object obj9 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 6, 2), 1))));
                object obj6 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 8, 2), 1))));
                this.xIronium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj8)));
                this.xBoranium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj3)));
                this.xGermanium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj7)));
                this.xPopulation = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj9)));
                this.xFuel = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj6)));
                if (Conversions.ToBoolean(obj5))
                {
                    object obj10 = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                    int num6 = 0;
                    do
                    {
                        if (Operators.ConditionalCompareObjectEqual(functions.GetBit(Conversions.ToInteger(obj10), num6), 1, false))
                        {
                            IEnumerator enumerator;
                            try
                            {
                                enumerator = this.Ships().GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    AtlantisSoftware.Ships current = (AtlantisSoftware.Ships) enumerator.Current;
                                    if (current.DesignID == num6)
                                    {
                                        current.Damage = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                                    }
                                }
                            }
                            finally
                            {
                                if (enumerator is IDisposable)
                                {
                                    (enumerator as IDisposable).Dispose();
                                }
                            }
                        }
                        num6++;
                    }
                    while (num6 <= 15);
                }
                if (num2 > 0)
                {
                    this.xBattlePlan = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                }
                this.xUnknown = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Fleet._Fleet.FleetID
        {
            get
            {
                return this.xFleetID;
            }
            set
            {
                this.xFleetID = value;
            }
        }

        [DispId(10)]
        public int AtlantisSoftware.Fleet._Fleet.Fuel
        {
            get
            {
                return this.xFuel;
            }
            set
            {
                this.xFuel = value;
            }
        }

        [DispId(9)]
        public int AtlantisSoftware.Fleet._Fleet.Germanium
        {
            get
            {
                return this.xGermanium;
            }
            set
            {
                this.xGermanium = value;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.Fleet._Fleet.Ironium
        {
            get
            {
                return this.xIronium;
            }
            set
            {
                this.xIronium = value;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.Fleet._Fleet.OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
            set
            {
                this.xOwnerID = value;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Fleet._Fleet.PositionObjectID
        {
            get
            {
                return this.xPositionObjectID;
            }
            set
            {
                this.xPositionObjectID = value;
                this.xFleetData[6] = (byte) (value % 0x100);
                this.xFleetData[7] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        [DispId(12)]
        public int AtlantisSoftware.Fleet._Fleet.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.Fleet._Fleet.X
        {
            get
            {
                return this.xX;
            }
            set
            {
                this.xX = value;
                this.xFleetData[8] = (byte) (value % 0x100);
                this.xFleetData[9] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Fleet._Fleet.Y
        {
            get
            {
                return this.xY;
            }
            set
            {
                this.xY = value;
                this.xFleetData[10] = (byte) (value % 0x100);
                this.xFleetData[11] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        public int BattlePlan
        {
            get
            {
                return this.xBattlePlan;
            }
            set
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
            set
            {
                this.xBoranium = value;
            }
        }

        public byte[] FleetData
        {
            get
            {
                return this.xFleetData;
            }
            set
            {
                int num3;
                this.xFleetData = value;
                int start = 0;
                this.xFleetData = value;
                object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                this.xFleetID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x1ff));
                this.xOwnerID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x200)), 15));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 1));
                if (Operators.ConditionalCompareObjectEqual(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 3, 1), 1, false))
                {
                    num3 = 1;
                }
                else
                {
                    num3 = 2;
                }
                object obj5 = RuntimeHelpers.GetObjectValue(functions.GetBit(Conversions.ToInteger(objectValue), 4));
                obj5 = 1;
                int num2 = Conversions.ToInteger(functions.GetBit(Conversions.ToInteger(objectValue), 6));
                num2 = 1;
                this.xPositionObjectID = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xX = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                this.xY = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                int num4 = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                int bit = 0;
                do
                {
                    if (Operators.ConditionalCompareObjectEqual(functions.GetBit(num4, bit), 1, false))
                    {
                        AtlantisSoftware.Ships item = new AtlantisSoftware.Ships();
                        item.DesignID = bit;
                        item.ShipCount = Conversions.ToInteger(functions.GetBytes(value, ref start, num3));
                        this.Ships().Add(item, "ID" + Conversions.ToString(this.xOwnerID) + "-" + Conversions.ToString(bit), null, null);
                    }
                    bit++;
                }
                while (bit <= 15);
                object obj4 = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                object obj8 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 0, 2), 1))));
                object obj3 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 2, 2), 1))));
                object obj7 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 4, 2), 1))));
                object obj9 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 6, 2), 1))));
                object obj6 = RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(obj4), 8, 2), 1))));
                this.xIronium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj8)));
                this.xBoranium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj3)));
                this.xGermanium = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj7)));
                this.xPopulation = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj9)));
                this.xFuel = Conversions.ToInteger(functions.GetBytes(value, ref start, Conversions.ToInteger(obj6)));
                if (Conversions.ToBoolean(obj5))
                {
                    object obj10 = RuntimeHelpers.GetObjectValue(functions.GetBytes(value, ref start, 2));
                    int num6 = 0;
                    do
                    {
                        if (Operators.ConditionalCompareObjectEqual(functions.GetBit(Conversions.ToInteger(obj10), num6), 1, false))
                        {
                            IEnumerator enumerator;
                            try
                            {
                                enumerator = this.Ships().GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    AtlantisSoftware.Ships current = (AtlantisSoftware.Ships) enumerator.Current;
                                    if (current.DesignID == num6)
                                    {
                                        current.Damage = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                                    }
                                }
                            }
                            finally
                            {
                                if (enumerator is IDisposable)
                                {
                                    (enumerator as IDisposable).Dispose();
                                }
                            }
                        }
                        num6++;
                    }
                    while (num6 <= 15);
                }
                if (num2 > 0)
                {
                    this.xBattlePlan = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                }
                this.xUnknown = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
            }
        }

        public int FleetID
        {
            get
            {
                return this.xFleetID;
            }
            set
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
            set
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
            set
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
            set
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
            set
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
                this.xFleetData[6] = (byte) (value % 0x100);
                this.xFleetData[7] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
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
            set
            {
                this.xX = value;
                this.xFleetData[8] = (byte) (value % 0x100);
                this.xFleetData[9] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
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
                this.xFleetData[10] = (byte) (value % 0x100);
                this.xFleetData[11] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        [ComVisible(true)]
        public interface _Fleet
        {
            [DispId(13)]
            Collection Ships();

            [DispId(11)]
            int BattlePlan { [DispId(11)] get; [DispId(11)] set; }

            [DispId(8)]
            int Boranium { [DispId(8)] get; [DispId(8)] set; }

            [DispId(1)]
            byte[] FleetData { [DispId(1)] get; [DispId(1)] set; }

            [DispId(3)]
            int FleetID { [DispId(3)] get; [DispId(3)] set; }

            [DispId(10)]
            int Fuel { [DispId(10)] get; [DispId(10)] set; }

            [DispId(9)]
            int Germanium { [DispId(9)] get; [DispId(9)] set; }

            [DispId(7)]
            int Ironium { [DispId(7)] get; [DispId(7)] set; }

            [DispId(4)]
            int OwnerID { [DispId(4)] get; [DispId(4)] set; }

            [DispId(2)]
            int PositionObjectID { [DispId(2)] get; [DispId(2)] set; }

            [DispId(12)]
            int Unknown { [DispId(12)] get; }

            [DispId(5)]
            int X { [DispId(5)] get; [DispId(5)] set; }

            [DispId(6)]
            int Y { [DispId(6)] get; [DispId(6)] set; }
        }
    }
}

