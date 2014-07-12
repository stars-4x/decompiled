namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using System;

    public class QueueItem
    {
        public int Completion;
        public int Count;
        public int ItemID;

        public QueueItem()
        {
            this.Count = -1;
            this.ItemID = -1;
            this.Completion = -1;
        }

        public QueueItem(byte[] Data)
        {
            this.Count = -1;
            this.ItemID = -1;
            this.Completion = -1;
            this.QueueItemData = Data;
        }

        public byte[] QueueItemData
        {
            get
            {
                byte[] buffer2 = new byte[4];
                int num = (this.Count + (this.ItemID * 0x400)) + ((this.Completion * 0x400) * 0x400);
                buffer2[0] = (byte) (num & 0xff);
                buffer2[1] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) num) / 256.0)))) & 0xffL);
                buffer2[2] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) num) / 65536.0)))) & 0xffL);
                buffer2[3] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) num) / 65536.0) / 256.0)))) & 0xffL);
                return buffer2;
            }
            set
            {
                this.Count = value[0] + ((value[1] & 3) * 0x100);
                this.ItemID = (int) Math.Round((double) (Conversion.Int((double) (((double) value[1]) / 4.0)) + ((value[2] & 15) * 4)));
                this.Completion = (int) Math.Round((double) (Conversion.Int((double) (((double) value[2]) / 16.0)) + (value[3] * 0x10)));
            }
        }
    }
}

