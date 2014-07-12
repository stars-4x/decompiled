namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class Design
    {
        private int[] HullFuelCapacity = new int[] { 
            130, 450, 0xa28, 0x1f40, 50, 0x7d, 280, 600, 0x578, 0xaf0, 0x1194, 650, 0x8ca, 0x9c4, 150, 200, 
            120, 400, 750, 750, 210, 210, 500, 850, 0x514, 750, 0x8ca, 400, 0x898, 0x1388, 50, 700
         };
        public bool Incompletedesign = true;
        public DesignSlot[] Slots;
        private int xArmor;
        private byte[] xDesignData;
        public int xDesignID;
        private int xMass;
        public string xName;
        public int xNumbuilt;
        public int xNumRemaining;
        public int xShipHullID;
        private int xSlotCount;

        public byte[] DesignData
        {
            get
            {
                return this.xDesignData;
            }
            set
            {
                this.xDesignData = value;
                int start = 0;
                uint num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 2));
                this.xDesignID = Conversions.ToInteger(functions.GetBits(num4, 10, 5));
                int num = (int) (((long) Math.Round(Conversion.Int((double) (((double) value[1]) / 4.0)))) & 0x1fL);
                int num2 = value[0];
                this.xShipHullID = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 1));
                if ((num2 & 4) == 0)
                {
                    this.Incompletedesign = true;
                    this.xMass = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                    this.Slots = new DesignSlot[1];
                    if (this.xShipHullID < 0x20)
                    {
                        DesignSlot slot = new DesignSlot();
                        slot.xItemCategory = 1;
                        slot.xItemID = 1;
                        slot.xItemCount = 1;
                        this.Slots[0] = slot;
                    }
                }
                else
                {
                    this.Incompletedesign = false;
                    this.xArmor = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                    this.xSlotCount = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                    this.Slots = new DesignSlot[this.xSlotCount + 1];
                    num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 2));
                    this.xNumbuilt = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                    num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 2));
                    this.xNumRemaining = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                    num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 2));
                    int xSlotCount = this.xSlotCount;
                    for (int i = 1; i <= xSlotCount; i++)
                    {
                        DesignSlot slot2 = new DesignSlot();
                        slot2.xItemCategory = Conversions.ToInteger(functions.GetBytes(value, ref start, 2));
                        slot2.xItemID = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                        slot2.xItemCount = Conversions.ToInteger(functions.GetBytes(value, ref start, 1));
                        this.Slots[i - 1] = slot2;
                    }
                }
                num4 = Conversions.ToUInteger(functions.GetBytes(value, ref start, 1));
                this.xName = Conversions.ToString(functions.DecodeText(value, start, num4));
            }
        }

        public object FulldesignData
        {
            get
            {
                byte[] buffer2 = new byte[] { 
                    7, (byte) ((this.xDesignID * 4) + 1), (byte) this.xShipHullID, 0x18, (byte) (this.xArmor & 0xff), (byte) Math.Round(Conversion.Int((double) (((double) this.xArmor) / 256.0))), (byte) this.xSlotCount, 0, 0, (byte) (this.xNumbuilt & 0xff), (byte) Math.Round(Conversion.Int((double) (((double) this.xNumbuilt) / 256.0))), 0, 0, (byte) (this.xNumRemaining & 0xff), (byte) Math.Round(Conversion.Int((double) (((double) this.xNumRemaining) / 256.0))), 0, 
                    0
                 };
                int index = 0x11;
                this.xSlotCount = 0;
                if (this.Slots != null)
                {
                    foreach (DesignSlot slot in this.Slots)
                    {
                        if (slot != null)
                        {
                            buffer2 = (byte[]) Utils.CopyArray((Array) buffer2, new byte[(index + 3) + 1]);
                            buffer2[index] = (byte) (slot.xItemCategory & 0xff);
                            buffer2[index + 1] = (byte) Math.Round(Conversion.Int((double) (((double) slot.xItemCategory) / 256.0)));
                            buffer2[index + 2] = (byte) slot.xItemID;
                            buffer2[index + 3] = (byte) slot.xItemCount;
                            index += 4;
                            this.xSlotCount++;
                        }
                    }
                }
                buffer2[6] = (byte) this.xSlotCount;
                byte[] buffer = functions.EncodeText(this.xName);
                buffer2 = (byte[]) Utils.CopyArray((Array) buffer2, new byte[(index + buffer.Length) + 1]);
                buffer2[index] = (byte) buffer.Length;
                int num4 = buffer.Length - 1;
                for (int i = 0; i <= num4; i++)
                {
                    buffer2[(index + 1) + i] = buffer[i];
                }
                return buffer2;
            }
        }

        public int MaxFuelCapacity
        {
            get
            {
                if ((this.xShipHullID >= 0) & (this.xShipHullID <= 0x1f))
                {
                    return this.HullFuelCapacity[this.xShipHullID];
                }
                return 0;
            }
        }
    }
}

