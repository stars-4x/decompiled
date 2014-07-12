namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class Race
    {
        public BattlePlan[] BattlePlans = new BattlePlan[0x10];
        public int CentreGravity;
        public int CentreRadiation;
        public int CentreTemperature;
        public int HighGravity;
        public int HighRadiation;
        public int HighTemperature;
        public int LowGravity;
        public int LowRadiation;
        public int LowTemperature;
        public int xBiologyLevel;
        public int xBiologyPtsSincePrevLevel;
        public int xBiologyResearchCost;
        public int xConstructionLevel;
        public int xConstructionPtsSincePrevLevel;
        public int xConstructionResearchCost;
        private int xCurrentResearchPriority;
        public int xElectronicsLevel;
        public int xElectronicsPtsSincePrevLevel;
        public int xElectronicsResearchCost;
        public int xEnergyLevel;
        public int xEnergyPtsSincePrevLevel;
        public int xEnergyResearchCost;
        public bool xExpensiveTechStartsAt3;
        public bool xFactoriesCost1LessGerm;
        public int xFactoriesOperated;
        public int xFactoryEfficiency;
        public int xGrowthRate;
        private int xHomeworld;
        private int xLogo;
        public int xMinesOperated;
        public int xMiningEfficiency;
        public int xMTItemBitmap;
        public string xName;
        private int xNameLength;
        private int xNextResearchPriority;
        public uint xPasswordHash;
        private int xPlanetCount;
        private int xPlayerRelationsCount;
        public string xPluralName;
        private int xPluralNameLength;
        public int xPopulationEfficiency;
        public int xPropulsionLevel;
        public int xPropulsionPtsSincePrevLevel;
        public int xPropulsionResearchCost;
        public int xPRT;
        private byte[] xRaceData;
        private int xRaceID;
        private int xRank;
        private int xResearchPercentage;
        private int xResearchPointsPreviousYear;
        public int xResourcesToBuildFactory;
        public int xResourcesToBuildMines;
        public int xShipDesignCount;
        public Design[] xShipDesigns = new Design[0x10];
        private int xSpendLeftoverPointsOn;
        public int xSRTBitmap;
        public int xStarbaseDesignCount;
        public Design[] xStarbaseDesigns = new Design[11];
        public int xWeaponsLevel;
        public int xWeaponsPtsSincePrevLevel;
        public int xWeaponsResearchCost;

        public byte[] FullRaceData
        {
            get
            {
                byte[] buffer4 = new byte[0x401];
                buffer4[0] = (byte) this.xRaceID;
                buffer4[1] = (byte) this.ShipDesignCount;
                buffer4[2] = 0;
                buffer4[3] = 0;
                buffer4[4] = 0;
                buffer4[5] = (byte) (this.xStarbaseDesignCount * 0x10);
                buffer4[6] = (byte) (7 + (this.xLogo * 8));
                buffer4[7] = 1;
                buffer4[8] = (byte) (this.xHomeworld & 0xff);
                buffer4[9] = (byte) Math.Round(Conversion.Int((double) (((double) this.xHomeworld) / 256.0)));
                buffer4[10] = (byte) this.xRank;
                buffer4[11] = 0;
                buffer4[12] = (byte) (this.xPasswordHash & 0xffL);
                buffer4[13] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPasswordHash) / 256.0)))) & 0xffL);
                buffer4[14] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xPasswordHash) / 256.0) / 256.0)))) & 0xffL);
                buffer4[15] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xPasswordHash) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x10] = (byte) this.CentreGravity;
                buffer4[0x11] = (byte) this.CentreTemperature;
                buffer4[0x12] = (byte) this.CentreRadiation;
                buffer4[0x13] = (byte) this.LowGravity;
                buffer4[20] = (byte) this.LowTemperature;
                buffer4[0x15] = (byte) this.LowRadiation;
                buffer4[0x16] = (byte) this.HighGravity;
                buffer4[0x17] = (byte) this.HighTemperature;
                buffer4[0x18] = (byte) this.HighRadiation;
                buffer4[0x19] = (byte) this.xGrowthRate;
                buffer4[0x1a] = (byte) this.xEnergyLevel;
                buffer4[0x1b] = (byte) this.xWeaponsLevel;
                buffer4[0x1c] = (byte) this.xPropulsionLevel;
                buffer4[0x1d] = (byte) this.xConstructionLevel;
                buffer4[30] = (byte) this.xElectronicsLevel;
                buffer4[0x1f] = (byte) this.xBiologyLevel;
                buffer4[0x20] = (byte) (this.xEnergyPtsSincePrevLevel & 0xff);
                buffer4[0x21] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xEnergyPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[0x22] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xEnergyPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x23] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xEnergyPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x24] = (byte) (this.xWeaponsPtsSincePrevLevel & 0xff);
                buffer4[0x25] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xWeaponsPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[0x26] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xWeaponsPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x27] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xWeaponsPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[40] = (byte) (this.xPropulsionPtsSincePrevLevel & 0xff);
                buffer4[0x29] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPropulsionPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[0x2a] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xPropulsionPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x2b] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xPropulsionPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x2c] = (byte) (this.xConstructionPtsSincePrevLevel & 0xff);
                buffer4[0x2d] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xConstructionPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[0x2e] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xConstructionPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x2f] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xConstructionPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x30] = (byte) (this.xElectronicsPtsSincePrevLevel & 0xff);
                buffer4[0x31] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xElectronicsPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[50] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xElectronicsPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x33] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xElectronicsPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x34] = (byte) (this.xBiologyPtsSincePrevLevel & 0xff);
                buffer4[0x35] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xBiologyPtsSincePrevLevel) / 256.0)))) & 0xffL);
                buffer4[0x36] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xBiologyPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x37] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xBiologyPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x38] = (byte) this.xResearchPercentage;
                buffer4[0x39] = (byte) (this.xCurrentResearchPriority + (this.xNextResearchPriority * 0x10));
                buffer4[0x3a] = (byte) (this.xResearchPointsPreviousYear & 0xff);
                buffer4[0x3b] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xResearchPointsPreviousYear) / 256.0)))) & 0xffL);
                buffer4[60] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xResearchPointsPreviousYear) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x3d] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xResearchPointsPreviousYear) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                buffer4[0x3e] = (byte) this.xPopulationEfficiency;
                buffer4[0x3f] = (byte) this.xFactoryEfficiency;
                buffer4[0x40] = (byte) this.xResourcesToBuildFactory;
                buffer4[0x41] = (byte) this.xFactoriesOperated;
                buffer4[0x42] = (byte) this.xMiningEfficiency;
                buffer4[0x43] = (byte) this.xResourcesToBuildMines;
                buffer4[0x44] = (byte) this.xMinesOperated;
                buffer4[0x45] = (byte) this.xSpendLeftoverPointsOn;
                buffer4[70] = (byte) this.xEnergyResearchCost;
                buffer4[0x47] = (byte) this.xWeaponsResearchCost;
                buffer4[0x48] = (byte) this.xPropulsionResearchCost;
                buffer4[0x49] = (byte) this.xConstructionResearchCost;
                buffer4[0x4a] = (byte) this.xElectronicsResearchCost;
                buffer4[0x4b] = (byte) this.xBiologyResearchCost;
                buffer4[0x4c] = (byte) this.xPRT;
                buffer4[0x4d] = 0;
                buffer4[0x4e] = (byte) (this.xSRTBitmap & 0xff);
                buffer4[0x4f] = (byte) Math.Round(Conversion.Int((double) (((double) this.xSRTBitmap) / 256.0)));
                buffer4[80] = 0;
                buffer4[0x51] = 0;
                if (this.xExpensiveTechStartsAt3)
                {
                    buffer4[0x51] = (byte) (buffer4[0x51] + 0x20);
                }
                if (this.xFactoriesCost1LessGerm)
                {
                    buffer4[0x51] = (byte) (buffer4[0x51] + 0x80);
                }
                buffer4[0x52] = (byte) (this.xMTItemBitmap & 0xff);
                buffer4[0x53] = (byte) Math.Round(Conversion.Int((double) (((double) this.xMTItemBitmap) / 256.0)));
                buffer4[0x70] = 0;
                byte[] buffer2 = functions.EncodeText(this.xName);
                byte[] buffer3 = functions.EncodeText(this.xPluralName);
                buffer4[0x71] = (byte) buffer2.Length;
                int num3 = buffer2.Length - 1;
                for (int i = 0; i <= num3; i++)
                {
                    buffer4[0x72 + i] = buffer2[i];
                }
                buffer4[0x72 + buffer2.Length] = (byte) buffer3.Length;
                int num4 = buffer3.Length - 1;
                for (int j = 0; j <= num4; j++)
                {
                    buffer4[(0x73 + buffer2.Length) + j] = buffer3[j];
                }
                return (byte[]) Utils.CopyArray((Array) buffer4, new byte[(((0x73 + buffer2.Length) + buffer3.Length) - 1) + 1]);
            }
        }

        public int Homeworld
        {
            get
            {
                return this.xHomeworld;
            }
            set
            {
                if ((value >= 0) & (value <= 0x3ff))
                {
                    this.xHomeworld = value;
                    int num = ((this.xRaceData[8] + (this.xRaceData[9] * 0x100)) & 0xfb00) + value;
                    this.xRaceData[8] = (byte) (num % 0x100);
                    this.xRaceData[9] = (byte) Math.Round(Conversion.Int((double) (((double) num) / 256.0)));
                }
            }
        }

        public int PlanetCount
        {
            get
            {
                return this.xPlanetCount;
            }
            set
            {
                this.xPlanetCount = value;
                this.xRaceData[2] = (byte) (value & 0xff);
                this.xRaceData[3] = (byte) Math.Round(Conversion.Int((double) (((double) value) / 256.0)));
            }
        }

        public byte[] RaceData
        {
            get
            {
                this.xRaceData[0x1a] = (byte) this.xEnergyLevel;
                this.xRaceData[0x1b] = (byte) this.xWeaponsLevel;
                this.xRaceData[0x1c] = (byte) this.xPropulsionLevel;
                this.xRaceData[0x1d] = (byte) this.xConstructionLevel;
                this.xRaceData[30] = (byte) this.xElectronicsLevel;
                this.xRaceData[0x1f] = (byte) this.xBiologyLevel;
                this.xRaceData[0x20] = (byte) (this.xEnergyPtsSincePrevLevel & 0xff);
                this.xRaceData[0x21] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xEnergyPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[0x22] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xEnergyPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x23] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xEnergyPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x24] = (byte) (this.xWeaponsPtsSincePrevLevel & 0xff);
                this.xRaceData[0x25] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xWeaponsPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[0x26] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xWeaponsPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x27] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xWeaponsPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[40] = (byte) (this.xPropulsionPtsSincePrevLevel & 0xff);
                this.xRaceData[0x29] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xPropulsionPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[0x2a] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xPropulsionPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x2b] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xPropulsionPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x2c] = (byte) (this.xConstructionPtsSincePrevLevel & 0xff);
                this.xRaceData[0x2d] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xConstructionPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[0x2e] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xConstructionPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x2f] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xConstructionPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x30] = (byte) (this.xElectronicsPtsSincePrevLevel & 0xff);
                this.xRaceData[0x31] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xElectronicsPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[50] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xElectronicsPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x33] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xElectronicsPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x34] = (byte) (this.xBiologyPtsSincePrevLevel & 0xff);
                this.xRaceData[0x35] = (byte) (((long) Math.Round(Conversion.Int((double) (((double) this.xBiologyPtsSincePrevLevel) / 256.0)))) & 0xffL);
                this.xRaceData[0x36] = (byte) (((long) Math.Round(Conversion.Int((double) ((((double) this.xBiologyPtsSincePrevLevel) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x37] = (byte) (((long) Math.Round(Conversion.Int((double) (((((double) this.xBiologyPtsSincePrevLevel) / 256.0) / 256.0) / 256.0)))) & 0xffL);
                this.xRaceData[0x52] = (byte) (this.xMTItemBitmap & 0xff);
                this.xRaceData[0x53] = (byte) Math.Round(Conversion.Int((double) (((double) this.xMTItemBitmap) / 256.0)));
                return this.xRaceData;
            }
            set
            {
                this.xRaceData = value;
                this.xRaceID = value[0];
                this.xShipDesignCount = value[1];
                this.xPlanetCount = (value[2] + (value[3] * 0x100)) & 0x3ff;
                this.xStarbaseDesignCount = (int) Math.Round(Conversion.Int((double) (((double) value[5]) / 16.0)));
                this.xLogo = (int) Math.Round(Conversion.Int((double) (((double) value[6]) / 8.0)));
                if ((value[6] & 4) == 4)
                {
                    this.xHomeworld = value[8] + (value[9] * 0x100);
                    this.xRank = value[10];
                    this.xPasswordHash = value[12];
                    this.xPasswordHash += (uint) (value[13] * 0x100);
                    this.xPasswordHash += (uint) (value[14] * 0x10000);
                    this.xPasswordHash += (uint) (value[15] * 0x1000000L);
                    this.CentreGravity = value[0x10];
                    this.CentreTemperature = value[0x11];
                    this.CentreRadiation = value[0x12];
                    this.LowGravity = value[0x13];
                    this.LowTemperature = value[20];
                    this.LowRadiation = value[0x15];
                    this.HighGravity = value[0x16];
                    this.HighTemperature = value[0x17];
                    this.HighRadiation = value[0x18];
                    this.xGrowthRate = value[0x19];
                    this.xEnergyLevel = value[0x1a];
                    this.xWeaponsLevel = value[0x1b];
                    this.xPropulsionLevel = value[0x1c];
                    this.xConstructionLevel = value[0x1d];
                    this.xElectronicsLevel = value[30];
                    this.xBiologyLevel = value[0x1f];
                    this.xEnergyPtsSincePrevLevel = ((value[0x20] + (value[0x21] * 0x100)) + (value[0x22] * 0x10000)) + ((value[0x23] * 0x100) * 0x10000);
                    this.xWeaponsPtsSincePrevLevel = ((value[0x24] + (value[0x25] * 0x100)) + (value[0x26] * 0x10000)) + ((value[0x27] * 0x100) * 0x10000);
                    this.xPropulsionPtsSincePrevLevel = ((value[40] + (value[0x29] * 0x100)) + (value[0x2a] * 0x10000)) + ((value[0x2b] * 0x100) * 0x10000);
                    this.xConstructionPtsSincePrevLevel = ((value[0x2c] + (value[0x2d] * 0x100)) + (value[0x2e] * 0x10000)) + ((value[0x2f] * 0x100) * 0x10000);
                    this.xElectronicsPtsSincePrevLevel = ((value[0x30] + (value[0x31] * 0x100)) + (value[50] * 0x10000)) + ((value[0x33] * 0x100) * 0x10000);
                    this.xBiologyPtsSincePrevLevel = ((value[0x34] + (value[0x35] * 0x100)) + (value[0x36] * 0x10000)) + ((value[0x37] * 0x100) * 0x10000);
                    this.xResearchPercentage = value[0x38];
                    this.xCurrentResearchPriority = value[0x39] & 15;
                    this.xNextResearchPriority = (int) Math.Round(Conversion.Int((double) (((double) value[0x39]) / 16.0)));
                    this.xResearchPointsPreviousYear = ((value[0x3a] + (value[0x3b] * 0x100)) + (value[60] * 0x10000)) + ((value[0x3d] * 0x100) * 0x10000);
                    this.xPopulationEfficiency = value[0x3e];
                    this.xFactoryEfficiency = value[0x3f];
                    this.xResourcesToBuildFactory = value[0x40];
                    this.xFactoriesOperated = value[0x41];
                    this.xMiningEfficiency = value[0x42];
                    this.xResourcesToBuildMines = value[0x43];
                    this.xMinesOperated = value[0x44];
                    this.xSpendLeftoverPointsOn = value[0x45];
                    this.xEnergyResearchCost = value[70];
                    this.xWeaponsResearchCost = value[0x47];
                    this.xPropulsionResearchCost = value[0x48];
                    this.xConstructionResearchCost = value[0x49];
                    this.xElectronicsResearchCost = value[0x4a];
                    this.xBiologyResearchCost = value[0x4b];
                    this.xPRT = value[0x4c];
                    this.xSRTBitmap = value[0x4e] + (value[0x4f] * 0x100);
                    if ((value[0x51] & 0x20) == 0)
                    {
                        this.xExpensiveTechStartsAt3 = false;
                    }
                    else
                    {
                        this.xExpensiveTechStartsAt3 = true;
                    }
                    if ((value[0x51] & 0x80) == 0)
                    {
                        this.xFactoriesCost1LessGerm = false;
                    }
                    else
                    {
                        this.xFactoriesCost1LessGerm = true;
                    }
                    this.xMTItemBitmap = value[0x52] + (value[0x53] * 0x100);
                    this.xPlayerRelationsCount = value[0x70];
                    this.xNameLength = value[0x71 + this.xPlayerRelationsCount];
                    this.xName = Conversions.ToString(functions.DecodeText(value, 0x72 + this.xPlayerRelationsCount, this.xNameLength));
                    this.xPluralNameLength = value[(0x72 + this.xPlayerRelationsCount) + this.xNameLength];
                    this.xPluralName = Conversions.ToString(functions.DecodeText(value, (0x73 + this.xPlayerRelationsCount) + this.xNameLength, this.xPluralNameLength));
                }
                else
                {
                    this.xNameLength = value[8 + this.xPlayerRelationsCount];
                    this.xName = Conversions.ToString(functions.DecodeText(value, 9 + this.xPlayerRelationsCount, this.xNameLength));
                    this.xPluralNameLength = value[(9 + this.xPlayerRelationsCount) + this.xNameLength];
                    this.xPluralName = Conversions.ToString(functions.DecodeText(value, (10 + this.xPlayerRelationsCount) + this.xNameLength, this.xPluralNameLength));
                }
            }
        }

        public int RaceID
        {
            get
            {
                return this.xRaceID;
            }
        }

        public int ShipDesignCount
        {
            get
            {
                int num = 0;
                Design[] xShipDesigns = this.xShipDesigns;
                for (int i = 0; i < xShipDesigns.Length; i++)
                {
                    if (xShipDesigns[i] != null)
                    {
                        num++;
                    }
                }
                return num;
            }
            set
            {
                this.xShipDesignCount = value;
                this.xRaceData[1] = (byte) ((this.xRaceData[1] & 240) + value);
            }
        }

        public int StarbaseDesignCount
        {
            get
            {
                int num = 0;
                Design[] xStarbaseDesigns = this.xStarbaseDesigns;
                for (int i = 0; i < xStarbaseDesigns.Length; i++)
                {
                    if (xStarbaseDesigns[i] != null)
                    {
                        num++;
                    }
                }
                return num;
            }
            set
            {
                this.xStarbaseDesignCount = value;
                this.xRaceData[5] = (byte) ((this.xRaceData[5] & 15) + (value * 0x10));
            }
        }
    }
}

