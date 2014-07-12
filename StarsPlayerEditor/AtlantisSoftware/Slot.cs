namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Slot : Slot._Slot
    {
        private int xCategory;
        private int xCount;
        private int xItemID;
        private int xSlotID;

        [DispId(4)]
        public int AtlantisSoftware.Slot._Slot.Count
        {
            get
            {
                return this.xCount;
            }
        }

        [DispId(2)]
        public TechCategories AtlantisSoftware.Slot._Slot.ItemCategory
        {
            get
            {
                return (TechCategories) this.xCategory;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Slot._Slot.ItemID
        {
            get
            {
                return this.xItemID;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.Slot._Slot.SlotID
        {
            get
            {
                return this.xSlotID;
            }
        }

        public int Count
        {
            get
            {
                return this.xCount;
            }
            internal set
            {
                this.xCount = value;
            }
        }

        public TechCategories ItemCategory
        {
            get
            {
                return (TechCategories) this.xCategory;
            }
            internal set
            {
                this.xCategory = 0;
            }
        }

        public int ItemID
        {
            get
            {
                return this.xItemID;
            }
            internal set
            {
                this.xItemID = value;
            }
        }

        public int SlotID
        {
            get
            {
                return this.xSlotID;
            }
            internal set
            {
                this.xSlotID = value;
            }
        }

        [ComVisible(true)]
        public interface _Slot
        {
            [DispId(4)]
            int Count { [DispId(4)] get; }

            [DispId(2)]
            Slot.TechCategories ItemCategory { [DispId(2)] get; }

            [DispId(3)]
            int ItemID { [DispId(3)] get; }

            [DispId(1)]
            int SlotID { [DispId(1)] get; }
        }

        public enum TechCategories
        {
            Armor = 8,
            BeamWeapon = 0x10,
            Bomb = 0x40,
            Electrical = 0x800,
            Empty = 0,
            Engine = 1,
            Mechanical = 0x1000,
            MineLayer = 0x100,
            MiningRobot = 0x80,
            Orbital = 0x200,
            Planetary = 0x400,
            Scanners = 2,
            Shields = 4,
            Torpedo = 0x20
        }
    }
}

