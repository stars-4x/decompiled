namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class Race
    {
        public Collection Attributes;
        private byte[] xRaceData;

        public int Homeworld
        {
            get
            {
                return Conversions.ToInteger(this.Attributes["Homeworld"]);
            }
            set
            {
                if ((value >= 0) & (value <= 0x3ff))
                {
                    this.Attributes.Remove("Homeworld");
                    this.Attributes.Add(value, "Homeworld", null, null);
                    int num = ((this.xRaceData[8] + (this.xRaceData[9] * 0x100)) & 0xfb00) + value;
                    this.xRaceData[8] = (byte) (num % 0x100);
                    this.xRaceData[9] = (byte) Math.Round(Conversion.Int((double) (((double) num) / 256.0)));
                }
            }
        }

        public byte[] RaceData
        {
            get
            {
                return this.xRaceData;
            }
            set
            {
                this.Attributes = new Collection();
                this.xRaceData = value;
                this.Attributes.Add(value[0], "RaceID", null, null);
                this.Attributes.Add((value[8] + (value[9] * 0x100)) & 0x3ff, "Homeworld", null, null);
            }
        }

        public int RaceID
        {
            get
            {
                return Conversions.ToInteger(this.Attributes["RaceID"]);
            }
        }
    }
}

