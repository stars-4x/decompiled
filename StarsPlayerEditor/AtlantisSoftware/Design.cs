namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class Design : Design._Design
    {
        private int xCategory;
        private int xDesignID;
        private int xFuel;
        private string xName;
        private int xOwnerID;
        private int xShipHullID;
        public Collection xSlots = new Collection();
        private bool xStarbase;

        public Design(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xDesignID = Conversions.ToInteger(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x400)), 15));
            this.xStarbase = Conversions.ToBoolean(Operators.AndObject(Conversion.Int(Operators.DivideObject(objectValue, 0x4000)), 1));
            objectValue = Operators.AndObject(objectValue, 0x3ff);
            this.xShipHullID = Conversions.ToInteger(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            int num2 = Conversions.ToInteger(functions.GetBytes(Data, ref start, 1));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            int num4 = num2;
            for (int i = 1; i <= num4; i++)
            {
                Slot item = new Slot();
                item.SlotID = i - 1;
                item.ItemCategory = (Slot.TechCategories) Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
                item.ItemID = Conversions.ToInteger(functions.GetBytes(Data, ref start, 1));
                item.Count = Conversions.ToInteger(functions.GetBytes(Data, ref start, 1));
                this.Slots().Add(item, null, null, null);
            }
            object obj2 = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 1));
            this.xName = Conversions.ToString(functions.DecodeText(Data, start, RuntimeHelpers.GetObjectValue(obj2)));
        }

        public Collection Slots()
        {
            return this.xSlots;
        }

        [DispId(2)]
        public int AtlantisSoftware.Design._Design.DesignID
        {
            get
            {
                return this.xDesignID;
            }
        }

        [DispId(4)]
        public string AtlantisSoftware.Design._Design.Name
        {
            get
            {
                return this.xName;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Design._Design.OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.Design._Design.ShipHullID
        {
            get
            {
                return this.xShipHullID;
            }
        }

        [DispId(1)]
        public bool AtlantisSoftware.Design._Design.Starbase
        {
            get
            {
                return this.xStarbase;
            }
        }

        public int DesignID
        {
            get
            {
                return this.xDesignID;
            }
            internal set
            {
                this.xDesignID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.xName;
            }
            internal set
            {
                this.xName = value;
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

        public int ShipHullID
        {
            get
            {
                return this.xShipHullID;
            }
            internal set
            {
                this.xShipHullID = value;
            }
        }

        public bool Starbase
        {
            get
            {
                return this.xStarbase;
            }
            internal set
            {
                this.xStarbase = value;
            }
        }

        [ComVisible(true)]
        public interface _Design
        {
            [DispId(6)]
            Collection Slots();

            [DispId(2)]
            int DesignID { [DispId(2)] get; }

            [DispId(4)]
            string Name { [DispId(4)] get; }

            [DispId(3)]
            int OwnerID { [DispId(3)] get; }

            [DispId(5)]
            int ShipHullID { [DispId(5)] get; }

            [DispId(1)]
            bool Starbase { [DispId(1)] get; }
        }
    }
}

