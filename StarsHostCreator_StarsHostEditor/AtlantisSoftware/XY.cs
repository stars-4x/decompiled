namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class XY
    {
        private byte[] xData;
        private int xDensity;
        private string xGameName;
        private int xPlanetPercentage;
        private bool xPlanetPercentageUsed;
        private int xPlayercount;
        private int xPlayerPositions;
        private int xSettingsFlag;
        private int xStarCount;
        private int xUniversSize;

        public byte[] Data
        {
            get
            {
                return this.xData;
            }
            set
            {
                this.xData = value;
                this.xPlayercount = value[0x1c];
                this.xStarCount = value[30] + (value[0x1f] * 0x100);
                this.xGameName = "";
                int index = 0x34;
                do
                {
                    if (value[index] == 0)
                    {
                        break;
                    }
                    this.xGameName = this.xGameName + Conversions.ToString(Strings.Chr(value[index]));
                    index++;
                }
                while (index <= 0x53);
            }
        }

        public string GameName
        {
            get
            {
                return this.xGameName;
            }
            set
            {
                int num2 = Strings.Len(value);
                for (int i = 1; i <= num2; i++)
                {
                    if (i <= 0x20)
                    {
                        this.xData[0x33 + i] = (byte) Strings.Asc(Strings.Mid(value, i, 1));
                    }
                }
                if (Strings.Len(value) < 0x20)
                {
                    this.xData[0x34 + Strings.Len(value)] = 0;
                }
            }
        }

        public int Playercount
        {
            get
            {
                return this.xPlayercount;
            }
            set
            {
                this.xPlayercount = value;
                this.xData[0x1c] = (byte) value;
            }
        }

        public int Starcount
        {
            get
            {
                return this.xStarCount;
            }
            set
            {
                this.xStarCount = value;
                this.xData[30] = (byte) (value % 0x100);
                this.xData[0x1f] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }
    }
}

