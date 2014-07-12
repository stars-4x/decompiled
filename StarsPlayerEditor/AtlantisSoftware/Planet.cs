namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComClass, ClassInterface(ClassInterfaceType.None)]
    public class Planet : Planet._Planet
    {
        private int tConcentration;
        private int tInstallations;
        private int tStarbase;
        private int tSurface;
        private bool xArtefact;
        private int xBoranium;
        private int xBoraniumConcentration;
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
        private int xNameID;
        private int xOriginalGravity;
        private int xOriginalRadiation;
        private int xOriginalTemperature;
        private int xOwnerID;
        private int xPlanetID;
        private int xPopulation;
        private int xRadiation;
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
            this.xPlanetID = -1;
            this.xOwnerID = -1;
            this.xHomeworld = true;
            this.xStarbase = -1;
            this.xInstallations = true;
            this.xArtefact = true;
            this.xSurfaceMinerals = true;
            this.xIronium = -1;
            this.xBoranium = -1;
            this.xGermanium = -1;
            this.xPopulation = -1;
            this.xExcessPopulation = -1;
            this.xIroniumConcentration = -1;
            this.xBoraniumConcentration = -1;
            this.xGermaniumConcentration = -1;
            this.xTemperature = -1;
            this.xGravity = -1;
            this.xRadiation = -1;
            this.xOriginalTemperature = -1;
            this.xOriginalGravity = -1;
            this.xOriginalRadiation = -1;
            this.xTerraformed = true;
            this.xX = -1;
            this.xY = -1;
            this.xNameID = -1;
            this.xEstimatedPopulation = -1;
            this.xFactories = -1;
            this.xMines = -1;
            this.xDefenses = -1;
            this.xStarbaseSlotID = -1;
            this.xScanner = true;
            this.xUnknown1 = -1;
            this.xUnknown2 = -1;
            this.xUnknown3 = -1;
            this.xStarbaseUnknown1 = -1;
            this.xMDTarget = -1;
            this.xMDSpeed = -1;
            this.xStarbaseDamage = -1;
            this.tConcentration = -1;
            this.tSurface = -1;
            this.tInstallations = -1;
            this.tStarbase = -1;
            this.PlanetData = Data;
        }

        public Planet(int PlanetID)
        {
            this.xPlanetID = -1;
            this.xOwnerID = -1;
            this.xHomeworld = true;
            this.xStarbase = -1;
            this.xInstallations = true;
            this.xArtefact = true;
            this.xSurfaceMinerals = true;
            this.xIronium = -1;
            this.xBoranium = -1;
            this.xGermanium = -1;
            this.xPopulation = -1;
            this.xExcessPopulation = -1;
            this.xIroniumConcentration = -1;
            this.xBoraniumConcentration = -1;
            this.xGermaniumConcentration = -1;
            this.xTemperature = -1;
            this.xGravity = -1;
            this.xRadiation = -1;
            this.xOriginalTemperature = -1;
            this.xOriginalGravity = -1;
            this.xOriginalRadiation = -1;
            this.xTerraformed = true;
            this.xX = -1;
            this.xY = -1;
            this.xNameID = -1;
            this.xEstimatedPopulation = -1;
            this.xFactories = -1;
            this.xMines = -1;
            this.xDefenses = -1;
            this.xStarbaseSlotID = -1;
            this.xScanner = true;
            this.xUnknown1 = -1;
            this.xUnknown2 = -1;
            this.xUnknown3 = -1;
            this.xStarbaseUnknown1 = -1;
            this.xMDTarget = -1;
            this.xMDSpeed = -1;
            this.xStarbaseDamage = -1;
            this.tConcentration = -1;
            this.tSurface = -1;
            this.tInstallations = -1;
            this.tStarbase = -1;
            this.xPlanetID = PlanetID;
        }

        public bool Artefact
        {
            get
            {
                return this.xArtefact;
            }
            internal set
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

        [DispId(0x12)]
        public bool AtlantisSoftware.Planet._Planet.Artefact
        {
            get
            {
                return this.xArtefact;
            }
        }

        [DispId(0x15)]
        public int AtlantisSoftware.Planet._Planet.Boranium
        {
            get
            {
                return this.xBoranium;
            }
        }

        [DispId(0x19)]
        public int AtlantisSoftware.Planet._Planet.BoraniumConcentration
        {
            get
            {
                return this.xBoraniumConcentration;
            }
        }

        [DispId(4)]
        public int AtlantisSoftware.Planet._Planet.Defenses
        {
            get
            {
                return this.xDefenses;
            }
        }

        [DispId(30)]
        public int AtlantisSoftware.Planet._Planet.EstimatedPopulation
        {
            get
            {
                return this.xEstimatedPopulation;
            }
        }

        [DispId(2)]
        public int AtlantisSoftware.Planet._Planet.Factories
        {
            get
            {
                return this.xFactories;
            }
        }

        [DispId(0x16)]
        public int AtlantisSoftware.Planet._Planet.Germanium
        {
            get
            {
                return this.xGermanium;
            }
        }

        [DispId(0x1a)]
        public int AtlantisSoftware.Planet._Planet.GermaniumConcentration
        {
            get
            {
                return this.xGermaniumConcentration;
            }
        }

        [DispId(0x1c)]
        public int AtlantisSoftware.Planet._Planet.Gravity
        {
            get
            {
                return this.xGravity;
            }
        }

        [DispId(0x10)]
        public bool AtlantisSoftware.Planet._Planet.Homeworld
        {
            get
            {
                return this.xHomeworld;
            }
        }

        [DispId(20)]
        public int AtlantisSoftware.Planet._Planet.Ironium
        {
            get
            {
                return this.xIronium;
            }
        }

        [DispId(0x18)]
        public int AtlantisSoftware.Planet._Planet.IroniumConcentration
        {
            get
            {
                return this.xIroniumConcentration;
            }
        }

        [DispId(10)]
        public int AtlantisSoftware.Planet._Planet.MDSpeed
        {
            get
            {
                return this.xMDSpeed;
            }
        }

        [DispId(9)]
        public int AtlantisSoftware.Planet._Planet.MDTarget
        {
            get
            {
                return this.xMDTarget;
            }
        }

        [DispId(3)]
        public int AtlantisSoftware.Planet._Planet.Mines
        {
            get
            {
                return this.xMines;
            }
        }

        [DispId(14)]
        public int AtlantisSoftware.Planet._Planet.NameID
        {
            get
            {
                return this.xNameID;
            }
        }

        [DispId(15)]
        public int AtlantisSoftware.Planet._Planet.OwnerID
        {
            get
            {
                return this.xOwnerID;
            }
        }

        [DispId(1)]
        public byte[] AtlantisSoftware.Planet._Planet.PlanetData
        {
            get
            {
                return this.xData;
            }
        }

        [DispId(11)]
        public int AtlantisSoftware.Planet._Planet.PlanetID
        {
            get
            {
                return this.xPlanetID;
            }
        }

        [DispId(0x17)]
        public int AtlantisSoftware.Planet._Planet.Population
        {
            get
            {
                return this.xPopulation;
            }
        }

        [DispId(0x1d)]
        public int AtlantisSoftware.Planet._Planet.Radiation
        {
            get
            {
                return this.xRadiation;
            }
        }

        [DispId(0x11)]
        public bool AtlantisSoftware.Planet._Planet.Scanner
        {
            get
            {
                return this.xScanner;
            }
        }

        [DispId(0x20)]
        public object AtlantisSoftware.Planet._Planet.StarbaseDamage
        {
            get
            {
                return this.xStarbaseDamage;
            }
        }

        [DispId(0x1f)]
        public int AtlantisSoftware.Planet._Planet.StarbaseSlotID
        {
            get
            {
                return this.xStarbaseSlotID;
            }
        }

        [DispId(8)]
        public int AtlantisSoftware.Planet._Planet.StarbaseUnknown1
        {
            get
            {
                return this.xStarbaseUnknown1;
            }
        }

        [DispId(0x1b)]
        public int AtlantisSoftware.Planet._Planet.Temperature
        {
            get
            {
                return this.xTemperature;
            }
        }

        [DispId(0x13)]
        public bool AtlantisSoftware.Planet._Planet.Terraformed
        {
            get
            {
                return this.xTerraformed;
            }
        }

        [DispId(5)]
        public int AtlantisSoftware.Planet._Planet.Unknown1
        {
            get
            {
                return this.xUnknown1;
            }
        }

        [DispId(6)]
        public int AtlantisSoftware.Planet._Planet.Unknown2
        {
            get
            {
                return this.xUnknown2;
            }
        }

        [DispId(7)]
        public int AtlantisSoftware.Planet._Planet.Unknown3
        {
            get
            {
                return this.xUnknown3;
            }
        }

        [DispId(12)]
        public int AtlantisSoftware.Planet._Planet.X
        {
            get
            {
                return this.xX;
            }
        }

        [DispId(13)]
        public int AtlantisSoftware.Planet._Planet.Y
        {
            get
            {
                return this.xY;
            }
        }

        public int Boranium
        {
            get
            {
                return this.xBoranium;
            }
            internal set
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
            internal set
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
            internal set
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
            internal set
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

        public int Germanium
        {
            get
            {
                return this.xGermanium;
            }
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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

        public int NameID
        {
            get
            {
                return this.xNameID;
            }
            internal set
            {
                this.xNameID = value;
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
            internal set
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
                this.xHomeworld = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 7));
                this.xStarbase = Conversions.ToInteger(functions.GetBit(Conversions.ToInteger(objectValue), 9));
                this.xTerraformed = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 10));
                this.xInstallations = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 11));
                this.xArtefact = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 12));
                this.xSurfaceMinerals = Conversions.ToBoolean(functions.GetBit(Conversions.ToInteger(objectValue), 13));
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
                if (this.xOwnerID != -1)
                {
                    this.xEstimatedPopulation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 2));
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
                this.xPopulation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, num6));
                if (num6 > 0)
                {
                    this.xExcessPopulation = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
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
                this.xScanner = Conversions.ToBoolean(Operators.NotObject(functions.GetBits(this.xUnknown2, 0, 1)));
                this.xUnknown3 = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                this.tStarbase = start;
                if (this.xStarbase > 0)
                {
                    objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 1));
                    this.xStarbaseSlotID = Conversions.ToInteger(Operators.AndObject(objectValue, 15));
                    this.xStarbaseDamage = Conversions.ToInteger(Conversion.Int(Operators.DivideObject(objectValue, 0x10)));
                    this.xStarbaseUnknown1 = Conversions.ToInteger(functions.GetBytes(this.xData, ref start, 1));
                    this.xStarbaseDamage += (this.xStarbaseUnknown1 & 0x1f) * 0x10;
                    objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.xData, ref start, 2));
                    this.xMDTarget = Conversions.ToInteger(Operators.AndObject(objectValue, 0x3ff));
                    this.xMDSpeed = Conversions.ToInteger(Operators.AddObject(Conversion.Int(Operators.DivideObject(objectValue, 0x400)), 4));
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
        }

        public int Population
        {
            get
            {
                return this.xPopulation;
            }
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
            {
                if (value < -1)
                {
                    value = -1;
                }
                if (value > 9)
                {
                    value = 9;
                }
                if (value == -1)
                {
                    if (this.xStarbase > 0)
                    {
                        Array.Copy(this.xData, this.tStarbase + 4, this.xData, this.tStarbase, (this.xData.Length - this.tStarbase) - 4);
                        this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) - 4) + 1]);
                        this.xData[3] = (byte) (this.xData[3] & 0xfd);
                        this.xStarbase = 0;
                    }
                }
                else
                {
                    if (~this.xStarbase > 0)
                    {
                        this.xData = (byte[]) Utils.CopyArray((Array) this.xData, new byte[((this.xData.Length - 1) + 4) + 1]);
                        Array.Copy(this.xData, this.tStarbase, this.xData, this.tStarbase + 4, (this.xData.Length - this.tStarbase) - 4);
                        this.xData[3] = (byte) (this.xData[3] | 2);
                        this.xStarbase = -1;
                        this.xData[this.tStarbase + 1] = 0;
                        this.xData[this.tStarbase + 2] = 0;
                        this.xData[this.tStarbase + 3] = 0;
                    }
                    this.xData[this.tStarbase] = (byte) (this.xData[this.tStarbase] & (240 + value));
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
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
            internal set
            {
                this.xX = value;
            }
        }

        public int Y
        {
            get
            {
                return this.xY;
            }
            internal set
            {
                this.xY = value;
            }
        }

        [ComVisible(true)]
        public interface _Planet
        {
            [DispId(0x12)]
            bool Artefact { [DispId(0x12)] get; }

            [DispId(0x15)]
            int Boranium { [DispId(0x15)] get; }

            [DispId(0x19)]
            int BoraniumConcentration { [DispId(0x19)] get; }

            [DispId(4)]
            int Defenses { [DispId(4)] get; }

            [DispId(30)]
            int EstimatedPopulation { [DispId(30)] get; }

            [DispId(2)]
            int Factories { [DispId(2)] get; }

            [DispId(0x16)]
            int Germanium { [DispId(0x16)] get; }

            [DispId(0x1a)]
            int GermaniumConcentration { [DispId(0x1a)] get; }

            [DispId(0x1c)]
            int Gravity { [DispId(0x1c)] get; }

            [DispId(0x10)]
            bool Homeworld { [DispId(0x10)] get; }

            [DispId(20)]
            int Ironium { [DispId(20)] get; }

            [DispId(0x18)]
            int IroniumConcentration { [DispId(0x18)] get; }

            [DispId(10)]
            int MDSpeed { [DispId(10)] get; }

            [DispId(9)]
            int MDTarget { [DispId(9)] get; }

            [DispId(3)]
            int Mines { [DispId(3)] get; }

            [DispId(14)]
            int NameID { [DispId(14)] get; }

            [DispId(15)]
            int OwnerID { [DispId(15)] get; }

            [DispId(1)]
            byte[] PlanetData { [DispId(1)] get; }

            [DispId(11)]
            int PlanetID { [DispId(11)] get; }

            [DispId(0x17)]
            int Population { [DispId(0x17)] get; }

            [DispId(0x1d)]
            int Radiation { [DispId(0x1d)] get; }

            [DispId(0x11)]
            bool Scanner { [DispId(0x11)] get; }

            [DispId(0x20)]
            object StarbaseDamage { [DispId(0x20)] get; }

            [DispId(0x1f)]
            int StarbaseSlotID { [DispId(0x1f)] get; }

            [DispId(8)]
            int StarbaseUnknown1 { [DispId(8)] get; }

            [DispId(0x1b)]
            int Temperature { [DispId(0x1b)] get; }

            [DispId(0x13)]
            bool Terraformed { [DispId(0x13)] get; }

            [DispId(5)]
            int Unknown1 { [DispId(5)] get; }

            [DispId(6)]
            int Unknown2 { [DispId(6)] get; }

            [DispId(7)]
            int Unknown3 { [DispId(7)] get; }

            [DispId(12)]
            int X { [DispId(12)] get; }

            [DispId(13)]
            int Y { [DispId(13)] get; }
        }
    }
}

