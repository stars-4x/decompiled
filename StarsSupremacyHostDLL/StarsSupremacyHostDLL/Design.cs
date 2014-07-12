namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class Design
    {
        public int Armor;
        public bool DeletedDesign;
        public int DesignID;
        public bool Dirty;
        public int HullID;
        public int Mass;
        public string Name;
        public DesignSlot[] Slots;
        public int TotalBuilt;
        public int TotalRemaining;
        private byte[] xdata;

        public Design()
        {
            this.DesignID = -1;
            this.HullID = -1;
            this.Mass = -1;
            this.Armor = -1;
            this.TotalBuilt = -1;
            this.TotalRemaining = -1;
            this.DeletedDesign = true;
            this.Dirty = false;
        }

        public Design(byte[] Data, [Optional, DefaultParameterValue(0x1a)] int TypeID)
        {
            this.DesignID = -1;
            this.HullID = -1;
            this.Mass = -1;
            this.Armor = -1;
            this.TotalBuilt = -1;
            this.TotalRemaining = -1;
            this.DeletedDesign = true;
            this.Dirty = false;
            if (TypeID == 0x1a)
            {
                this.Type26DesignData = Data;
            }
            else
            {
                this.Type27DesignData = Data;
            }
        }

        public byte[] Type26DesignData
        {
            get
            {
                return this.xdata;
            }
            set
            {
                int index = 0;
                this.xdata = value;
                uint num3 = (uint) (value[0] + (value[1] * 0x100));
                bool flag = (num3 & 4L) > 0L;
                this.DesignID = (int) (((long) Math.Round(Conversion.Int((double) (((double) num3) / 1024.0)))) & 0x1fL);
                this.HullID = value[2];
                if (flag)
                {
                    this.Armor = value[4] + (value[5] * 0x100);
                    uint num4 = value[6];
                    this.Slots = new DesignSlot[((int) (num4 - 1L)) + 1];
                    this.TotalBuilt = value[9] + (value[10] * 0x100);
                    this.TotalRemaining = value[13] + (value[14] * 0x100);
                    index = 0x11;
                    long num6 = num4 - 1L;
                    for (long i = 0L; i <= num6; i += 1L)
                    {
                        DesignSlot slot = new DesignSlot();
                        slot.CategoryID = (byte) (value[index] + value[index + 1]);
                        slot.ItemID = value[index + 2];
                        slot.Count = value[index + 3];
                        this.Slots[(int) i] = slot;
                        index += 4;
                    }
                }
                else
                {
                    this.Mass = value[4] + (value[5] * 0x100);
                    index = 6;
                }
                int length = value[index];
                this.Name = Conversions.ToString(Functions.DecodeText(value, index + 1, length));
                this.DeletedDesign = false;
                Debug.Print("");
            }
        }

        public byte[] Type27DesignData
        {
            get
            {
                byte[] destinationArray = new byte[(this.xdata.Length + 1) + 1];
                destinationArray[1] = (byte) this.HullID;
                Array.Copy(this.xdata, 0, destinationArray, 2, this.xdata.Length);
                return this.xdata;
            }
            set
            {
                byte[] destinationArray = new byte[((value.Length - 2) - 1) + 1];
                this.DesignID = value[1] & 0x1f;
                if (value.Length > 2)
                {
                    Array.Copy(value, 2, destinationArray, 0, value.Length - 2);
                    this.Type26DesignData = destinationArray;
                }
                else
                {
                    this.DeletedDesign = true;
                }
            }
        }
    }
}

