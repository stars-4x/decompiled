namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using System;

    public class Planet
    {
        public int NameID;
        public int OwnerID;
        public int PlanetID;
        public QueueItem[] ProductionQueue;
        public int X;
        public int Y;

        public Planet()
        {
            this.PlanetID = -1;
            this.OwnerID = -1;
            this.X = -1;
            this.Y = -1;
        }

        public Planet(byte[] Data)
        {
            this.PlanetID = -1;
            this.OwnerID = -1;
            this.X = -1;
            this.Y = -1;
            this.PlanetData = Data;
        }

        public byte[] PlanetData
        {
            get
            {
                return new byte[1];
            }
            set
            {
                this.PlanetID = (value[0] + (value[1] * 0x100)) & 0x3ff;
                this.OwnerID = (int) Math.Round(Conversion.Int((double) (((double) value[1]) / 8.0)));
                if (this.OwnerID == 0x1f)
                {
                    this.OwnerID = -1;
                }
            }
        }
    }
}

