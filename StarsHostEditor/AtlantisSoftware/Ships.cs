namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Ships : Ships._Ships
    {
        private int xDamage;
        private int xShipCount;
        private int xSlot;

        [DispId(3)]
        public int AtlantisSoftware.Ships._Ships.Damage
        {
            get
            {
                return this.xDamage;
            }
            set
            {
                this.xDamage = value;
            }
        }

        [DispId(1)]
        public int AtlantisSoftware.Ships._Ships.DesignID
        {
            get
            {
                return this.xSlot;
            }
            set
            {
                this.xSlot = value;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Ships._Ships.ShipCount
        {
            get
            {
                return this.xShipCount;
            }
            set
            {
                this.xShipCount = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.xDamage;
            }
            set
            {
                this.xDamage = value;
            }
        }

        public int DesignID
        {
            get
            {
                return this.xSlot;
            }
            set
            {
                this.xSlot = value;
            }
        }

        public int ShipCount
        {
            get
            {
                return this.xShipCount;
            }
            set
            {
                this.xShipCount = value;
            }
        }

        [ComVisible(true)]
        public interface _Ships
        {
            [DispId(3)]
            int Damage { [DispId(3)] get; [DispId(3)] set; }

            [DispId(1)]
            int DesignID { [DispId(1)] get; [DispId(1)] set; }

            [DispId(2)]
            int ShipCount { [DispId(2)] get; [DispId(2)] set; }
        }
    }
}

