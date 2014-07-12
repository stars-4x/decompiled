namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    public class Planet
    {
        public object IncompletePlanet;
        private int tConcentration;
        private int tInstallations;
        private int tStarbase;
        private int tSurface;
        private bool xArtefact;
        private int xBoranium;
        private int xBoraniumConcentration;
        private bool xContributeOnlyLeftOverResourcesToResearch;
        private byte[] xData;
        private int xDefenses;
        private int xEstimatedPopulation;
        private int xExcessPopulation;
        private int xFactories;
        private int xGermanium;
        private int xGermaniumConcentration;
        private int xGravity;
        private bool xHomeworld;
        private bool xInstallations;
        private int xIronium;
        private int xIroniumConcentration;
        private int xMDSpeed;
        private int xMDTarget;
        private int xMines;
        private string xName;
        private int xNameID;
        private int xOriginalGravity;
        private int xOriginalRadiation;
        private int xOriginalTemperature;
        private int xOwnerID;
        private int xPlanetID;
        private int xPopulation;
        public byte[] xProductionQueue;
        private int xRadiation;
        private int xRouteTo;
        private bool xScanner;
        private int xStarbase;
        private int xStarbaseDamage;
        private int xStarbaseSlotID;
        private int xStarbaseUnknown1;
        private bool xSurfaceMinerals;
        private int xTemperature;
        private bool xTerraformed;
        private int xUnknown1;
        private int xUnknown2;
        private int xUnknown3;
        private int xX;
        private int xY;

        public Planet(byte[] Data)
        {
            this.xStarbaseSlotID = -1;
            this.xRouteTo = -1;
            this.xContributeOnlyLeftOverResourcesToResearch = true;
            this.IncompletePlanet = true;
            this.PlanetData = Data;
        }

        public Planet(int PlanetID)
        {
            this.xStarbaseSlotID = -1;
            this.xRouteTo = -1;
            this.xContributeOnlyLeftOverResourcesToResearch = true;
            this.IncompletePlanet = true;
            this.xPlanetID = PlanetID;
            this.PlanetData = new byte[] { 
                (byte) (PlanetID & 0xff), (byte) Math.Round((double) (Conversion.Int((double) (((double) PlanetID) / 256.0)) + 248.0)), 7, 1, 0, 100, 100, 100, 50, 50, 50, 0, 0, 0, 0, 0, 
                0, 0, 0
             };
        }

        public bool Artefact
        {
            get
            {
                return this.xArtefact;
            }
            set
            {
                this.xArtefact = value;
                if (value)
                {
                    this.xData[2] = (byte) (this.xData[3] | 0x10);
                }
                else
                {
                    this.xData[2] = (byte) (this.xData[3] & 0xef);
                }
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
                if (value < 0)
                {
                    this.xBoranium = 0;
                }
                else if (value > 0x7fffffff)
                {
                    this.xBoranium = 0x7fffffff;
                }
                else
                {
                    this.xBoranium = value;
                }
                int num2 = (this.tSurface + 5) + 3;
                for (int i = this.tSurface + 5; i <= num2; i++)
                {
                    this.xData[i] = (byte) (value & 0xff);
                    value = (int) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
                }
            }
        }

        public int BoraniumConcentration
        {
            get
            {
                return this.xBoraniumConcentration;
            }
            set
            {
                if (value < 0)
                {
                    this.xBoraniumConcentration = 0;
                }
                else if (value >= 0x100)
                {
                    this.xBoraniumConcentration = 0xff;
                }
                else
                {
                    this.xBoraniumConcentration = value;
                }
                this.xData[this.tConcentration + 1] = (byte) this.xBoraniumConcentration;
            }
        }

        public int Defenses
        {
            get
            {
                return this.xDefenses;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xfff)
                {
                    value = 0xfff;
                }
                this.xDefenses = value;
                this.xData[this.tInstallations + 3] = (byte) (value & 0xff);
                this.xData[this.tInstallations + 4] = (byte) Math.Round((double) ((this.xData[this.tInstallations + 4] & 240) + Conversion.Int((double) (((double) value) / 256.0))));
            }
        }

        public int EstimatedPopulation
        {
            get
            {
                return this.xEstimatedPopulation;
            }
        }

        public int Factories
        {
            get
            {
                return this.xFactories;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xfff)
                {
                    value = 0xfff;
                }
                this.xFactories = value;
                this.xData[this.tInstallations + 1] = (byte) ((this.xData[this.tInstallations + 1] & 15) + (Conversion.Int((int) (value & 15)) * 0x10));
                this.xData[this.tInstallations + 2] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 16.0)));
            }
        }

        public byte[] FullPlanetData
        {
            get
            {
                byte[] buffer2 = new byte[0x3e9];
                int index = 0;
                buffer2[0] = (byte) (this.xPlanetID & 0xff);
                if (this.xOwnerID >= 0)
                {
                    buffer2[1] = (byte) Math.Round((double) (Conversion.Int((double) (((double) this.xPlanetID) / 256.0)) + (this.xOwnerID * 8)));
                }
                else
                {
                    buffer2[1] = (byte) Math.Round((double) (Conversion.Int((double) (((double) this.xPlanetID) / 256.0)) + 248.0));
                }
                buffer2[2] = 7;
                if (this.xHomeworld)
                {
                    buffer2[2] = (byte) (buffer2[2] | 0x80);
                }
                int num2 = 0;
                if (this.xStarbaseSlotID >= 0)
                {
                    num2 |= 2;
                }
                num2 |= 4;
                num2 |= 8;
                if (this.xArtefact)
                {
                    num2 |= 0x10;
                }
                num2 |= 0x20;
                if (this.xRouteTo >= 0)
                {
                    num2 |= 0x40;
                }
                buffer2[3] = (byte) num2;
                buffer2[4] = 0x15;
                buffer2[5] = 0;
                buffer2[6] = 0;
                buffer2[7] = 0;
                buffer2[8] = (byte) this.xIroniumConcentration;
                buffer2[9] = (byte) this.xBoraniumConcentration;
                buffer2[10] = (byte) this.xGermaniumConcentration;
                buffer2[11] = (byte) this.xGravity;
                buffer2[12] = (byte) this.xTemperature;
                buffer2[13] = (byte) this.xRadiation;
                buffer2[14] = (byte) this.xOriginalGravity;
                buffer2[15] = (byte) this.xOriginalTemperature;
                buffer2[0x10] = (byte) this.xOriginalRadiation;
                buffer2[0x11] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPopulation) / 400.0)))) & 0xffL);
                if (Conversion.Int((double) (((double) this.xPopulation) / 400.0)) < 255.0)
                {
                    buffer2[0x12] = (byte) Math.Round(Conversion.Int((double) (((double) this.xPopulation) / 400.0)));
                }
                else
                {
                    buffer2[0x12] = 0xff;
                }
                buffer2[0x13] = 0xff;
                buffer2[20] = (byte) (this.xIronium & 0xff);
                buffer2[0x15] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xIronium) / 256.0)))) & 0xffL);
                buffer2[0x16] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xIronium) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x17] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xIronium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x18] = (byte) (this.xBoranium & 0xff);
                buffer2[0x19] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xBoranium) / 256.0)))) & 0xffL);
                buffer2[0x1a] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xBoranium) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x1b] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xBoranium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x1c] = (byte) (this.xGermanium & 0xff);
                buffer2[0x1d] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xGermanium) / 256.0)))) & 0xffL);
                buffer2[30] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xGermanium) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x1f] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xGermanium) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x20] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPopulation) / 100.0)))) & 0xffL);
                buffer2[0x21] = (byte) (((long) Math.Round(Conversion.Int((double) (Conversion.Int((double) (((double) this.xPopulation) / 100.0)) / 256.0)))) & 0xffL);
                buffer2[0x22] = (byte) (((long) Math.Round(Conversion.Int((double) ((Conversion.Int((double) (((double) this.xPopulation) / 100.0)) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x23] = (byte) (((long) Math.Round(Conversion.Int((double) (((Conversion.Int((double) (((double) this.xPopulation) / 100.0)) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer2[0x24] = (byte) (this.xPopulation % 100);
                buffer2[0x25] = (byte) (this.xMines & 0xff);
                buffer2[0x26] = (byte) Math.Round((double) (Conversion.Int((double) (((double) this.xMines) / 256.0)) + ((this.xFactories & 15) * 0x10)));
                buffer2[0x27] = (byte) Math.Round(Conversion.Int((double) (((double) this.xFactories) / 16.0)));
                buffer2[40] = (byte) (this.xDefenses & 0xff);
                buffer2[0x29] = (byte) Math.Round((double) (Conversion.Int((double) (((double) this.xDefenses) / 256.0)) + 240.0));
                num2 = 0;
                if (this.xContributeOnlyLeftOverResourcesToResearch)
                {
                    num2 |= 0x80;
                }
                if (!this.xScanner)
                {
                    num2 |= 1;
                }
                buffer2[0x2a] = (byte) (num2 & 0xff);
                buffer2[0x2b] = (byte) Math.Round(Conversion.Int((double) (((double) num2) / 256.0)));
                index = 0x2c;
                if (this.xStarbaseSlotID >= 0)
                {
                    buffer2[index] = (byte) (this.xStarbaseSlotID + (this.xStarbaseDamage & 15));
                    buffer2[index + 1] = (byte) Math.Round(Conversion.Int((double) (((double) this.xStarbaseDamage) / 16.0)));
                    buffer2[index + 2] = (byte) (this.xMDTarget & 0xff);
                    if (this.xMDSpeed >= 4)
                    {
                        buffer2[index + 3] = (byte) Math.Round((double) (Conversion.Int((double) (((double) this.xMDTarget) / 256.0)) + ((this.xMDSpeed - 4) * 4)));
                    }
                    else
                    {
                        buffer2[index + 3] = (byte) Math.Round(Conversion.Int((double) (((double) this.xMDTarget) / 256.0)));
                    }
                    index += 4;
                }
                if (this.xRouteTo >= 0)
                {
                    buffer2[index] = (byte) (this.xRouteTo & 0xff);
                    buffer2[index + 1] = (byte) Math.Round(Conversion.Int((double) (((double) this.xRadiation) / 256.0)));
                    index += 2;
                }
                return (byte[]) Utils.CopyArray((Array) buffer2, new byte[(index - 1) + 1]);
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
                if (value < 0)
                {
                    this.xGermanium = 0;
                }
                else if (value > 0x7fffffff)
                {
                    this.xGermanium = 0x7fffffff;
                }
                else
                {
                    this.xGermanium = value;
                }
                int num2 = (this.tSurface + 9) + 3;
                for (int i = this.tSurface + 9; i <= num2; i++)
                {
                    this.xData[i] = (byte) (value & 0xff);
                    value = (int) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
                }
            }
        }

        public int GermaniumConcentration
        {
            get
            {
                return this.xGermaniumConcentration;
            }
            set
            {
                if (value < 0)
                {
                    this.xGermaniumConcentration = 0;
                }
                else if (value >= 0x100)
                {
                    this.xGermaniumConcentration = 0xff;
                }
                else
                {
                    this.xGermaniumConcentration = value;
                }
                this.xData[this.tConcentration + 2] = (byte) this.xGermaniumConcentration;
            }
        }

        public int Gravity
        {
            get
            {
                return this.xGravity;
            }
            set
            {
                if (value < 0)
                {
                    this.xGravity = 0;
                }
                else if (value >= 100)
                {
                    this.xGravity = 100;
                }
                else
                {
                    this.xGravity = value;
                }
                this.xData[this.tConcentration + 3] = (byte) this.xGravity;
            }
        }

        public bool Homeworld
        {
            get
            {
                return this.xHomeworld;
            }
            set
            {
                this.xHomeworld = value;
                if (value)
                {
                    this.xData[2] = (byte) (this.xData[2] | 0x80);
                }
                else
                {
                    this.xData[2] = (byte) (this.xData[2] & 0x7f);
                }
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
                if (value < 0)
                {
                    this.xIronium = 0;
                }
                else if (value > 0x7fffffff)
                {
                    value = 0x7fffffff;
                }
                this.xIronium = value;
                object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBits(this.xData[this.tSurface], 0, 2));
                int num2 = (this.tSurface + 1) + 3;
                for (int i = this.tSurface + 1; i <= num2; i++)
                {
                    this.xData[i] = (byte) (value & 0xff);
                    value = (int) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
                }
            }
        }

        public int IroniumConcentration
        {
            get
            {
                return this.xIroniumConcentration;
            }
            set
            {
                if (value < 0)
                {
                    this.xIroniumConcentration = 0;
                }
                else
                {
                    if (value >= 0x100)
                    {
                        this.xIroniumConcentration = 0xff;
                    }
                    else
                    {
                        this.xIroniumConcentration = value;
                    }
                    this.xData[this.tConcentration] = (byte) this.xIroniumConcentration;
                }
            }
        }

        public int MDSpeed
        {
            get
            {
                return this.xMDSpeed;
            }
            set
            {
                if (value < 4)
                {
                    value = 4;
                }
                if (value > 0x10)
                {
                    value = 0x10;
                }
                this.xMDSpeed = value;
                this.xData[this.tStarbase + 3] = (byte) ((this.xData[this.tStarbase + 3] & 3) + ((value - 4) * 4));
            }
        }

        public int MDTarget
        {
            get
            {
                return this.xMDTarget;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0x3ff)
                {
                    value = 0;
                }
                this.xMDTarget = value;
                this.xData[this.tStarbase + 2] = (byte) (value & 0xff);
                this.xData[this.tStarbase + 3] = (byte) Math.Round((double) ((this.xData[this.tStarbase + 3] & 0xfc) + Conversion.Int((double) (((double) value) / 256.0))));
            }
        }

        public int Mines
        {
            get
            {
                return this.xMines;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xfff)
                {
                    value = 0xfff;
                }
                this.xMines = value;
                this.xData[this.tInstallations] = (byte) (value & 0xff);
                this.xData[this.tInstallations + 1] = (byte) Math.Round((double) ((this.xData[this.tInstallations + 1] & 240) + Conversion.Int((double) (((double) value) / 256.0))));
            }
        }

        public string Name
        {
            get
            {
                return this.xName;
            }
        }

        public int NameID
        {
            get
            {
                return this.xNameID;
            }
            set
            {
                this.xNameID = value;
                this.xName = PlanetNames.PlanetNames[this.xNameID];
            }
        }

        public int OriginalGravity
        {
            get
            {
                return this.xOriginalGravity;
            }
            set
            {
                if (value < 0)
                {
                    this.xOriginalGravity = 0;
                }
                else if (value >= 100)
                {
                    this.xOriginalGravity = 100;
                }
                else
                {
                    this.xOriginalGravity = value;
                }
                this.xData[this.tConcentration + 6] = (byte) this.xOriginalGravity;
            }
        }

        public int OriginalRadiation
        {
            get
            {
                return this.xOriginalRadiation;
            }
            set
            {
                if (value < 0)
                {
                    this.xOriginalRadiation = 0;
                }
                else if (value >= 100)
                {
                    this.xOriginalRadiation = 100;
                }
                else
                {
                    this.xOriginalRadiation = value;
                }
                this.xData[this.tConcentration + 8] = (byte) this.xOriginalRadiation;
            }
        }

        public int OriginalTemperature
        {
            get
            {
                return this.xOriginalTemperature;
            }
            set
            {
                if (value < 0)
                {
                    this.xOriginalTemperature = 0;
                }
                else if (value >= 100)
                {
                    this.xOriginalTemperature = 100;
                }
                else
                {
                    this.xOriginalTemperature = value;
                }
                this.xData[this.tConcentration + 7] = (byte) this.xOriginalTemperature;
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
                if ((value >= 0) & (value <= 15))
                {
                    if (this.xOwnerID == -1)
                    {
                        this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 2) + 1]);
                        Array.Copy(this.xData, (int) (this.tConcentration + 9), this.xData, (int) (this.tConcentration + 11), (int) ((this.xData.Length - this.tConcentration) - 11));
                        this.xData[this.tConcentration + 9] = 0;
                        this.xData[this.tConcentration + 10] = 0;
                        this.tSurface += 2;
                        this.tInstallations += 2;
                        this.tStarbase += 2;
                    }
                    this.xData[1] = (byte) (this.xData[1] & (7 + (value * 8)));
                    this.xOwnerID = value;
                }
                else
                {
                    if (this.xOwnerID != -1)
                    {
                        Array.Copy(this.xData, (int) (this.tConcentration + 11), this.xData, (int) (this.tConcentration + 9), (int) ((this.xData.Length - this.tConcentration) - 11));
                        this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) - 2) + 1]);
                        this.tSurface -= 2;
                        this.tInstallations -= 2;
                        this.tStarbase -= 2;
                    }
                    this.xOwnerID = -1;
                    this.xData[1] = (byte) (this.xData[1] & 0xff);
                }
            }
        }

        public byte[] PlanetData
        {
            get
            {
                return this.xData;
            }
            set
            {
                int start = 0;
                this.xData = value;
                object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 2));
                this.xPlanetID = Conversions.ToInteger(Operators.AndObject(objectValue, 0x3ff));
                this.xOwnerID = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x800)));
                if (this.xOwnerID == 0x1f)
                {
                    this.xOwnerID = -1;
                }
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 2));
                object obj4 = RuntimeHelpers.GetObjectValue(functions.GetBit(Conversions.ToInteger(objectValue), 1));
                this.xHomeworld = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 7));
                this.xStarbase = Conversions.ToInteger(functions.GetBit(Conversions.ToInteger(objectValue), 9));
                this.xTerraformed = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 10));
                this.xInstallations = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 11));
                this.xArtefact = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 12));
                this.xSurfaceMinerals = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 13));
                if (Conversions.ToBoolean(obj4))
                {
                    objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 1));
                    object obj3 = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, Conversions.ToInteger(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 0, 2))));
                    obj3 = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, Conversions.ToInteger(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 2, 2))));
                    obj3 = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, Conversions.ToInteger(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 4, 2))));
                    this.tConcentration = start;
                    this.xIroniumConcentration = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xBoraniumConcentration = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xGermaniumConcentration = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xGravity = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xTemperature = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xRadiation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                }
                else
                {
                    this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 6) + 1]);
                    Array.Copy(this.xData, start, this.xData, start + 6, (this.xData.Length - start) - 6);
                    this.xData[start] = 50;
                    this.xData[start + 1] = 50;
                    this.xData[start + 2] = 50;
                    this.xData[start + 3] = 1;
                    this.xData[start + 4] = 1;
                    this.xData[start + 5] = 1;
                    this.xGravity = 50;
                    this.xTemperature = 50;
                    this.xRadiation = 50;
                    this.xIroniumConcentration = 1;
                    this.xGermaniumConcentration = 1;
                    this.xBoraniumConcentration = 1;
                    start += 6;
                }
                if (!this.xTerraformed)
                {
                    this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 3) + 1]);
                    Array.Copy(this.xData, start, this.xData, start + 3, (this.xData.Length - start) - 3);
                    this.xData[start] = (byte) this.xGravity;
                    this.xData[start + 1] = (byte) this.xTemperature;
                    this.xData[start + 2] = (byte) this.xRadiation;
                    this.xData[3] = (byte) (this.xData[3] | 4);
                    this.xTerraformed = true;
                }
                this.xOriginalGravity = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                this.xOriginalTemperature = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                this.xOriginalRadiation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                if (Conversions.ToBoolean(obj4) && (this.xOwnerID != -1))
                {
                    this.xEstimatedPopulation = Conversions.ToInteger(Operators.AndObject(functions.GetBytes(this.xData, ref start, 2), 0xfff));
                }
                this.tSurface = start;
                if (!this.xSurfaceMinerals)
                {
                    this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 1) + 1]);
                    Array.Copy(this.xData, start, this.xData, start + 1, (this.xData.Length - start) - 1);
                    this.xData[3] = (byte) (this.xData[3] | 0x20);
                    this.xSurfaceMinerals = true;
                    this.xData[start] = 0;
                }
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 1));
                int length = Conversions.ToInteger(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 0, 2), 1)));
                int num = Conversions.ToInteger(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 2, 2), 1)));
                int num2 = Conversions.ToInteger(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 4, 2), 1)));
                int num6 = Conversions.ToInteger(Operators.ExponentObject(2, Operators.SubtractObject(functions.GetBits(RuntimeHelpers.GetObjectValue(objectValue), 6, 2), 1)));
                this.xIronium = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, length));
                this.xBoranium = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, num));
                this.xGermanium = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, num2));
                this.xPopulation = Conversions.ToInteger(Operators.MultiplyObject(functions.GetBytes(this.xData, ref start, num6), 100));
                if (this.xInstallations)
                {
                    this.xExcessPopulation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xPopulation += this.xExcessPopulation;
                    num6++;
                }
                int num7 = ((length + num) + num2) + num6;
                int num4 = 0x11;
                this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[(((this.xData.Length - 1) + num4) - num7) + 1]);
                Array.Copy(this.xData, start, this.xData, (start + num4) - num7, ((this.xData.Length - num4) + num7) - start);
                this.xData[this.tSurface] = 0xff;
                start = (start + num4) - num7;
                this.Ironium = this.xIronium;
                this.Boranium = this.xBoranium;
                this.Germanium = this.xGermanium;
                this.Population = this.xPopulation;
                if (!this.xInstallations)
                {
                    this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 7) + 1]);
                    Array.Copy(this.xData, start, this.xData, start + 7, (this.xData.Length - start) - 7);
                    this.xData[3] = (byte) (this.xData[3] | 8);
                    this.xData[start] = 0;
                    this.xData[start + 1] = 0;
                    this.xData[start + 2] = 0;
                    this.xData[start + 3] = 0;
                    this.xData[start + 4] = 0;
                    this.xData[start + 5] = 1;
                    this.xData[start + 6] = 0;
                }
                this.tInstallations = start;
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 3));
                this.xMines = Conversions.ToInteger(Operators.AndObject(objectValue, 0xfff));
                this.xFactories = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x1000)));
                objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 2));
                this.xDefenses = Conversions.ToInteger(Operators.AndObject(objectValue, 0xfff));
                this.xUnknown1 = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x1000)));
                this.xUnknown2 = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                this.xScanner = Operators.ConditionalCompareObjectEqual(functions.GetBits(this.xUnknown2, 0, 1), 0, false);
                this.xContributeOnlyLeftOverResourcesToResearch = Conversions.ToBoolean(functions.GetBits(this.xUnknown2, 7, 1));
                this.xUnknown3 = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                this.tStarbase = start;
                if (this.xStarbase > 0)
                {
                    objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 1));
                    this.xStarbaseSlotID = Conversions.ToInteger(Operators.AndObject(objectValue, 15));
                    this.xStarbaseDamage = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x10)));
                    if (this.xData.Length < start)
                    {
                        this.xStarbaseUnknown1 = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                        this.xStarbaseDamage += (this.xStarbaseUnknown1 & 0x1f) * 0x10;
                        objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 2));
                        this.xMDTarget = Conversions.ToInteger(Operators.AndObject(objectValue, 0x3ff));
                        this.xMDSpeed = Conversions.ToInteger(Operators.AddObject(Conversion.Int(Operators.DivideObject(objectValue, 0x400)), 4));
                    }
                }
                else
                {
                    this.xStarbaseSlotID = -1;
                }
            }
        }

        public int PlanetID
        {
            get
            {
                return this.xPlanetID;
            }
            set
            {
                if ((value >= 0) & (value <= 0x3ff))
                {
                    this.xPlanetID = value;
                    int start = 0;
                    object left = Operators.OrObject(Operators.AndObject(functions.GetBytes(this.xData, ref start, 2), 0xfc00), value);
                    this.xData[0] = Conversions.ToByte(Operators.ModObject(left, 0x100));
                    this.xData[1] = Conversions.ToByte(Conversion.Int(Operators.DivideObject(left, 0x100)));
                }
            }
        }

        public int Population
        {
            get
            {
                return this.xPopulation;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 0x7fffffff)
                {
                    value = 0x7fffffff;
                }
                this.xPopulation = value;
                this.xExcessPopulation = value % 100;
                value = (int) Math.Round(Conversion.Int((double) (((double) value) / 100.0)));
                int num2 = (this.tSurface + 13) + 3;
                for (int i = this.tSurface + 13; i <= num2; i++)
                {
                    this.xData[i] = (byte) (value & 0xff);
                    value = (int) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
                }
            }
        }

        public int Radiation
        {
            get
            {
                return this.xRadiation;
            }
            set
            {
                if (value < 0)
                {
                    this.xRadiation = 0;
                }
                else if (value >= 100)
                {
                    this.xRadiation = 100;
                }
                else
                {
                    this.xRadiation = value;
                }
                this.xData[this.tConcentration + 5] = (byte) this.xRadiation;
            }
        }

        public bool Scanner
        {
            get
            {
                return this.xScanner;
            }
            set
            {
                this.xScanner = value;
                if (value)
                {
                    this.xData[this.tInstallations + 5] = (byte) (this.xData[this.tInstallations + 5] & 0xfe);
                }
                else
                {
                    this.xData[this.tInstallations + 5] = (byte) (this.xData[this.tInstallations + 5] | 1);
                }
            }
        }

        public object StarbaseDamage
        {
            get
            {
                return this.xStarbaseDamage;
            }
            set
            {
                if (Operators.ConditionalCompareObjectLess(value, 0, false))
                {
                    value = 0;
                }
                if (Operators.ConditionalCompareObjectGreater(value, 0x1ff, false))
                {
                    value = 0x1ff;
                }
                this.xStarbaseDamage = Conversions.ToInteger(value);
                this.xData[this.tStarbase] = Conversions.ToByte(Operators.AddObject(this.xData[this.tStarbase] & 15, Operators.AndObject(value, 15)));
                this.xData[this.tStarbase + 1] = Conversions.ToByte(Operators.AddObject(this.xData[this.tStarbase + 1] & 0xe0, Conversion.Int(Operators.DivideObject(value, 0x10))));
            }
        }

        public int StarbaseSlotID
        {
            get
            {
                return this.xStarbaseSlotID;
            }
            set
            {
                if ((value < -1) | (value > 9))
                {
                    value = -1;
                }
                this.xStarbaseSlotID = value;
            }
        }

        public int StarbaseUnknown1
        {
            get
            {
                return this.xStarbaseUnknown1;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xff)
                {
                    value = 0xff;
                }
                this.xStarbaseUnknown1 = value;
                this.xData[this.tStarbase + 1] = (byte) value;
            }
        }

        public int Temperature
        {
            get
            {
                return this.xTemperature;
            }
            set
            {
                if (value < 0)
                {
                    this.xTemperature = 0;
                }
                else if (value >= 100)
                {
                    this.xTemperature = 100;
                }
                else
                {
                    this.xTemperature = value;
                }
                this.xData[this.tConcentration + 4] = (byte) this.xTemperature;
            }
        }

        public bool Terraformed
        {
            get
            {
                return this.xTerraformed;
            }
        }

        public int Unknown1
        {
            get
            {
                return this.xUnknown1;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 15)
                {
                    value = 15;
                }
                this.xUnknown1 = value;
                this.xData[this.tInstallations + 4] = (byte) ((this.xData[this.tInstallations + 4] & 15) + (value * 0x10));
            }
        }

        public int Unknown2
        {
            get
            {
                return this.xUnknown2;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xff)
                {
                    value = 0xff;
                }
                this.xUnknown2 = value;
                this.xData[this.tInstallations + 5] = (byte) value;
            }
        }

        public int Unknown3
        {
            get
            {
                return this.xUnknown3;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 0xff)
                {
                    value = 0xff;
                }
                this.xUnknown3 = value;
                this.xData[this.tInstallations + 6] = (byte) value;
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
            }
        }

        public int y
        {
            get
            {
                return this.xY;
            }
            set
            {
                this.xY = value;
            }
        }
    }
}

