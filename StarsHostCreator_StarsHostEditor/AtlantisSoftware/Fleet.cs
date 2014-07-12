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
        public bool IncompleteInfo;
        public Collection Waypoints;
        public Collection WaypointTasks;
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
        private Collection xShips;
        private int xUnknown;
        private int xX;
        private int xY;

        public Fleet()
        {
            this.xShips = new Collection();
            this.Waypoints = new Collection();
            this.WaypointTasks = new Collection();
            this.IncompleteInfo = true;
            this.FleetData = new byte[] { 
                1, 0, 0, 0, 3, 0x29, 0xff, 0xff, 0xec, 4, 6, 4, 0, 1, 1, 0, 
                0, 0x10, 0, 0, 0
             };
        }

        public Fleet(byte[] Data)
        {
            this.xShips = new Collection();
            this.Waypoints = new Collection();
            this.WaypointTasks = new Collection();
            this.IncompleteInfo = true;
            this.FleetData = Data;
        }

        public Collection Ships()
        {
            return this.xShips;
        }

        [DispId(12)]
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

        [DispId(9)]
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

        [DispId(2)]
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
                this.xShips = new Collection();
                this.Waypoints = new Collection();
                this.WaypointTasks = new Collection();
                int start = 0;
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

        [DispId(4)]
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

        [DispId(11)]
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

        [DispId(1)]
        public object AtlantisSoftware.Fleet._Fleet.FullFleetData
        {
            get
            {
                IEnumerator enumerator;
                IEnumerator enumerator2;
                IEnumerator enumerator4;
                IEnumerator enumerator5;
                byte[] buffer = new byte[0x401];
                buffer[0] = (byte) (this.xFleetID & 0xff);
                buffer[1] = (byte) ((((long) Math.Round(Conversion.Int((double) (((double) this.xFleetID) / 256.0)))) & 1L) + (this.xOwnerID * 2));
                buffer[2] = (byte) this.xOwnerID;
                buffer[3] = 0;
                buffer[4] = 7;
                int num3 = 8;
                try
                {
                    enumerator = this.xShips.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        AtlantisSoftware.Ships current = (AtlantisSoftware.Ships) enumerator.Current;
                        if (current.ShipCount > 0x100)
                        {
                            num3 = 0;
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
                buffer[5] = (byte) (num3 + 1);
                buffer[6] = (byte) (this.xPositionObjectID & 0xff);
                buffer[7] = (byte) Math.Round(Conversion.Int((double) (((double) this.xPositionObjectID) / 256.0)));
                buffer[8] = (byte) (this.xX & 0xff);
                buffer[9] = (byte) Math.Round(Conversion.Int((double) (((double) this.xX) / 256.0)));
                buffer[10] = (byte) (this.xY & 0xff);
                buffer[11] = (byte) Math.Round(Conversion.Int((double) (((double) this.xY) / 256.0)));
                int num4 = 0;
                try
                {
                    enumerator2 = this.xShips.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        AtlantisSoftware.Ships ships2 = (AtlantisSoftware.Ships) enumerator2.Current;
                        num4 = (int) Math.Round((double) (num4 + Math.Pow(2.0, (double) ships2.DesignID)));
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
                buffer[12] = (byte) (num4 & 0xff);
                buffer[13] = (byte) Math.Round(Conversion.Int((double) (((double) num4) / 256.0)));
                int num2 = 0;
                int num5 = 0;
                do
                {
                    IEnumerator enumerator3;
                    try
                    {
                        enumerator3 = this.xShips.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            AtlantisSoftware.Ships ships3 = (AtlantisSoftware.Ships) enumerator3.Current;
                            if (ships3.DesignID == num5)
                            {
                                if (num3 == 8)
                                {
                                    buffer[14 + num2] = (byte) ships3.ShipCount;
                                    num2++;
                                }
                                else
                                {
                                    buffer[14 + num2] = (byte) (ships3.ShipCount & 0xff);
                                    buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) ships3.ShipCount) / 256.0)));
                                    num2 += 2;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable)
                        {
                            (enumerator3 as IDisposable).Dispose();
                        }
                    }
                    num5++;
                }
                while (num5 <= 15);
                buffer[14 + num2] = 0xff;
                buffer[15 + num2] = 3;
                num2 += 2;
                buffer[14 + num2] = (byte) (this.xIronium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xIronium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xIronium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xIronium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xBoranium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xBoranium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xBoranium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xBoranium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xGermanium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xGermanium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xGermanium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xGermanium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xPopulation & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPopulation) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xPopulation) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xPopulation) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xFuel & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xFuel) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xFuel) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xFuel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                long num = 0L;
                try
                {
                    enumerator4 = this.xShips.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        AtlantisSoftware.Ships ships4 = (AtlantisSoftware.Ships) enumerator4.Current;
                        if (ships4.Damage > 0)
                        {
                            num |= (long) Math.Round(Math.Pow(2.0, (double) ships4.DesignID));
                        }
                    }
                }
                finally
                {
                    if (enumerator4 is IDisposable)
                    {
                        (enumerator4 as IDisposable).Dispose();
                    }
                }
                buffer[14 + num2] = (byte) (num & 0xffL);
                buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) num) / 256.0)));
                num2 += 2;
                try
                {
                    enumerator5 = this.xShips.GetEnumerator();
                    while (enumerator5.MoveNext())
                    {
                        AtlantisSoftware.Ships ships5 = (AtlantisSoftware.Ships) enumerator5.Current;
                        if (ships5.Damage > 0)
                        {
                            buffer[14 + num2] = (byte) (ships5.Damage & 0xff);
                            buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) ships5.Damage) / 256.0)));
                            num2 += 2;
                        }
                    }
                }
                finally
                {
                    if (enumerator5 is IDisposable)
                    {
                        (enumerator5 as IDisposable).Dispose();
                    }
                }
                buffer[14 + num2] = (byte) this.xBattlePlan;
                buffer[15 + num2] = (byte) (this.Waypoints.Count + this.WaypointTasks.Count);
                return (byte[]) Utils.CopyArray((Array) buffer, new byte[(15 + num2) + 1]);
            }
        }

        [DispId(10)]
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

        [DispId(8)]
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

        [DispId(5)]
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

        [DispId(3)]
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

        [DispId(13)]
        public int AtlantisSoftware.Fleet._Fleet.Unknown
        {
            get
            {
                return this.xUnknown;
            }
        }

        [DispId(6)]
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

        [DispId(7)]
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
                this.xShips = new Collection();
                this.Waypoints = new Collection();
                this.WaypointTasks = new Collection();
                int start = 0;
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

        public object FullFleetData
        {
            get
            {
                IEnumerator enumerator;
                IEnumerator enumerator2;
                IEnumerator enumerator4;
                IEnumerator enumerator5;
                byte[] buffer = new byte[0x401];
                buffer[0] = (byte) (this.xFleetID & 0xff);
                buffer[1] = (byte) ((((long) Math.Round(Conversion.Int((double) (((double) this.xFleetID) / 256.0)))) & 1L) + (this.xOwnerID * 2));
                buffer[2] = (byte) this.xOwnerID;
                buffer[3] = 0;
                buffer[4] = 7;
                int num3 = 8;
                try
                {
                    enumerator = this.xShips.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        AtlantisSoftware.Ships current = (AtlantisSoftware.Ships) enumerator.Current;
                        if (current.ShipCount > 0x100)
                        {
                            num3 = 0;
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
                buffer[5] = (byte) (num3 + 1);
                buffer[6] = (byte) (this.xPositionObjectID & 0xff);
                buffer[7] = (byte) Math.Round(Conversion.Int((double) (((double) this.xPositionObjectID) / 256.0)));
                buffer[8] = (byte) (this.xX & 0xff);
                buffer[9] = (byte) Math.Round(Conversion.Int((double) (((double) this.xX) / 256.0)));
                buffer[10] = (byte) (this.xY & 0xff);
                buffer[11] = (byte) Math.Round(Conversion.Int((double) (((double) this.xY) / 256.0)));
                int num4 = 0;
                try
                {
                    enumerator2 = this.xShips.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        AtlantisSoftware.Ships ships2 = (AtlantisSoftware.Ships) enumerator2.Current;
                        num4 = (int) Math.Round((double) (num4 + Math.Pow(2.0, (double) ships2.DesignID)));
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
                buffer[12] = (byte) (num4 & 0xff);
                buffer[13] = (byte) Math.Round(Conversion.Int((double) (((double) num4) / 256.0)));
                int num2 = 0;
                int num5 = 0;
                do
                {
                    IEnumerator enumerator3;
                    try
                    {
                        enumerator3 = this.xShips.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            AtlantisSoftware.Ships ships3 = (AtlantisSoftware.Ships) enumerator3.Current;
                            if (ships3.DesignID == num5)
                            {
                                if (num3 == 8)
                                {
                                    buffer[14 + num2] = (byte) ships3.ShipCount;
                                    num2++;
                                }
                                else
                                {
                                    buffer[14 + num2] = (byte) (ships3.ShipCount & 0xff);
                                    buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) ships3.ShipCount) / 256.0)));
                                    num2 += 2;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable)
                        {
                            (enumerator3 as IDisposable).Dispose();
                        }
                    }
                    num5++;
                }
                while (num5 <= 15);
                buffer[14 + num2] = 0xff;
                buffer[15 + num2] = 3;
                num2 += 2;
                buffer[14 + num2] = (byte) (this.xIronium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xIronium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xIronium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xIronium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xBoranium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xBoranium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xBoranium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xBoranium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xGermanium & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xGermanium) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xGermanium) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xGermanium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xPopulation & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPopulation) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xPopulation) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xPopulation) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                buffer[14 + num2] = (byte) (this.xFuel & 0xff);
                buffer[15 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xFuel) / 256.0)))) & 0xffL);
                buffer[0x10 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xFuel) / 256.0) / 256.0)))) & 0xffL);
                buffer[0x11 + num2] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xFuel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                num2 += 4;
                long num = 0L;
                try
                {
                    enumerator4 = this.xShips.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        AtlantisSoftware.Ships ships4 = (AtlantisSoftware.Ships) enumerator4.Current;
                        if (ships4.Damage > 0)
                        {
                            num |= (long) Math.Round(Math.Pow(2.0, (double) ships4.DesignID));
                        }
                    }
                }
                finally
                {
                    if (enumerator4 is IDisposable)
                    {
                        (enumerator4 as IDisposable).Dispose();
                    }
                }
                buffer[14 + num2] = (byte) (num & 0xffL);
                buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) num) / 256.0)));
                num2 += 2;
                try
                {
                    enumerator5 = this.xShips.GetEnumerator();
                    while (enumerator5.MoveNext())
                    {
                        AtlantisSoftware.Ships ships5 = (AtlantisSoftware.Ships) enumerator5.Current;
                        if (ships5.Damage > 0)
                        {
                            buffer[14 + num2] = (byte) (ships5.Damage & 0xff);
                            buffer[15 + num2] = (byte) Math.Round(Conversion.Int((double) (((double) ships5.Damage) / 256.0)));
                            num2 += 2;
                        }
                    }
                }
                finally
                {
                    if (enumerator5 is IDisposable)
                    {
                        (enumerator5 as IDisposable).Dispose();
                    }
                }
                buffer[14 + num2] = (byte) this.xBattlePlan;
                buffer[15 + num2] = (byte) (this.Waypoints.Count + this.WaypointTasks.Count);
                return (byte[]) Utils.CopyArray((Array) buffer, new byte[(15 + num2) + 1]);
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
            [DispId(14)]
            Collection Ships();

            [DispId(12)]
            int BattlePlan { [DispId(12)] get; [DispId(12)] set; }

            [DispId(9)]
            int Boranium { [DispId(9)] get; [DispId(9)] set; }

            [DispId(2)]
            byte[] FleetData { [DispId(2)] get; [DispId(2)] set; }

            [DispId(4)]
            int FleetID { [DispId(4)] get; [DispId(4)] set; }

            [DispId(11)]
            int Fuel { [DispId(11)] get; [DispId(11)] set; }

            [DispId(1)]
            object FullFleetData { [DispId(1)] get; }

            [DispId(10)]
            int Germanium { [DispId(10)] get; [DispId(10)] set; }

            [DispId(8)]
            int Ironium { [DispId(8)] get; [DispId(8)] set; }

            [DispId(5)]
            int OwnerID { [DispId(5)] get; [DispId(5)] set; }

            [DispId(3)]
            int PositionObjectID { [DispId(3)] get; [DispId(3)] set; }

            [DispId(13)]
            int Unknown { [DispId(13)] get; }

            [DispId(6)]
            int X { [DispId(6)] get; [DispId(6)] set; }

            [DispId(7)]
            int Y { [DispId(7)] get; [DispId(7)] set; }
        }
    }
}

