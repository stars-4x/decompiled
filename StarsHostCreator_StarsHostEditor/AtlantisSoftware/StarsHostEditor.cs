namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class StarsHostEditor : StarsHostEditor._StarsHostEditor
    {
        private Fleet $STATIC$ReadBlock$20511D5108101D5108108$LastFleet;
        private int ExtraGameID;
        public Fleet[] Fleets = new Fleet[0x2000];
        private byte[] hstFile;
        private bool hstLoaded = false;
        private Collection mFiles = new Collection();
        private object[] Minefields = new object[0x2000];
        private object[] MTs = new object[0x1000];
        private object[] Packets = new object[0x2000];
        public int[] PlanetIDs = new int[0x401];
        private string[] PlanetNames;
        private Collection tmpBattlePlans = new Collection();
        private object[] Wormholes = new object[0x1000];
        private int xDensity;
        private uint xGameID;
        private string xGameName;
        private int xGameSettings;
        private byte[] xHeader;
        private int xPlanetCount;
        private Planet[] xPlanets = new Planet[0x3e9];
        public int xPlayerCount;
        private object[] xRaces = new object[0x10];
        private int xStartingPositions;
        private int xTurnNo;
        private int xUniverseSize;
        private byte[] xyFile;

        public StarsHostEditor()
        {
            StreamReader reader = new StreamReader("PlanetNames.txt");
            string expression = reader.ReadToEnd();
            reader.Close();
            this.PlanetNames = Strings.Split(expression, "\r\n", -1, CompareMethod.Binary);
            int num3 = this.PlanetNames.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                int num2 = Strings.InStr(this.PlanetNames[i], "\t", CompareMethod.Binary);
                this.PlanetNames[i] = Strings.Mid(this.PlanetNames[i], num2 + 1);
            }
        }

        public void CreateHST(string XYFilename)
        {
            Decryptor decryptor = new Decryptor();
            this.xRaces = new object[0x10];
            this.xPlanets = new Planet[0x3e9];
            this.xyFile = decryptor.OpenFile(XYFilename);
            this.xGameID = this.xyFile[6];
            this.xGameID += (uint) (this.xyFile[7] * 0x100);
            this.xGameID += (uint) ((this.xyFile[8] * 0x100) * 0x100);
            this.xGameID += (uint) (((this.xyFile[9] * 0x100L) * ((ulong) 0x100L)) * ((ulong) 0x100L));
            this.xUniverseSize = this.xyFile[0x18];
            this.xDensity = this.xyFile[0x1a];
            this.xPlayerCount = this.xyFile[0x1c];
            this.xPlanetCount = this.xyFile[30] + (this.xyFile[0x1f] * 0x100);
            this.xStartingPositions = this.xyFile[0x20];
            this.xGameSettings = this.xyFile[0x24];
            this.xGameName = "";
            this.xTurnNo = 0;
            int index = 0x34;
            do
            {
                if (this.xyFile[index] == 0)
                {
                    break;
                }
                this.xGameName = this.xGameName + Conversions.ToString(Strings.Chr(this.xyFile[index]));
                index++;
            }
            while (index <= 0x53);
            byte[] destinationArray = new byte[0x10];
            Array.Copy(this.xyFile, 2, destinationArray, 0, 0x10);
            int xPlayerCount = this.xPlayerCount;
            for (int i = 1; i <= xPlayerCount; i++)
            {
                byte[] buffer2 = new byte[] { 
                    (byte) (i - 1), 0, 0, 0, 0, 0, 7, 1, (byte) i, 0, 0, 0, 0, 0, 0, 0, 
                    50, 50, 50, 40, 40, 40, 60, 60, 60, 1, 0x1a, 0x1a, 0x1a, 0x1a, 0x1a, 0x1a, 
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                    0, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0x19, 5, 
                    0x19, 5, 5, 15, 5, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                    0, 1, (byte) ((i & 7) + ((i & 8) * 2)), 1, (byte) ((i & 7) + ((i & 8) * 2))
                 };
                Race race = new Race();
                race.RaceData = buffer2;
                if (i == 1)
                {
                    race.PlanetCount = this.xPlanetCount;
                }
                BattlePlan plan = new BattlePlan(Conversions.ToString((int) (i - 1)));
                plan.AttackWho = 2;
                plan.PrimaryTarget = 3;
                plan.SecondaryTarget = 5;
                plan.Tactic = 4;
                race.BattlePlans[0] = plan;
                this.xRaces[i - 1] = race;
            }
            int x = 0x3e8;
            int xPlanetCount = this.xPlanetCount;
            for (int j = 1; j <= xPlanetCount; j++)
            {
                Planet planet = new Planet(j - 1);
                planet.NameID = (int) Math.Round(Conversion.Int((double) (((double) (this.xyFile[((j * 4) + 80) + 2] + (this.xyFile[((j * 4) + 80) + 3] * 0x100))) / 64.0)));
                planet.X = ((this.xyFile[(j * 4) + 80] + (this.xyFile[((j * 4) + 80) + 1] * 0x100)) & 0x3ff) + x;
                x = planet.X;
                planet.y = (int) (((long) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[((j * 4) + 80) + 1]) / 4.0)) + (this.xyFile[((j * 4) + 80) + 2] * 0x40)))) & 0xfffL);
                this.xPlanets[j - 1] = planet;
            }
        }

        public object DesignEditor(int RaceID)
        {
            StarsHostEditor editor2 = this;
            AtlantisSoftware.DesignEditor editor = new AtlantisSoftware.DesignEditor(RaceID, ref editor2);
            return 0;
        }

        public void ImportMFile(string Filename)
        {
            int num7;
            int num12;
            int num15;
            int num16;
            int num17;
            Waypoint waypoint;
            int num19;
            int num20;
            string str = "";
            int num3 = 0x339;
            Fleet fleet = null;
            int index = 0;
            int num2 = 0;
            byte[] sourceArray = new Decryptor().OpenFile(Filename);
            int num5 = 0;
            int num4 = 0;
            Collection collection = new Collection();
            int[] numArray = new int[0x10];
            int[] numArray2 = new int[0x10];
            Planet planet = null;
            this.xTurnNo = sourceArray[12] + (sourceArray[13] * 0x100);
            int num6 = 0;
            do
            {
                numArray[num6] = 0;
                numArray2[num6] = 0;
                num6++;
            }
            while (num6 <= 15);
        Label_0079:
            num7 = sourceArray[num5 + 0] + ((sourceArray[num5 + 1] & 3) * 0x100);
            double num8 = Conversion.Int((double) (((double) sourceArray[num5 + 1]) / 4.0));
            byte[] destinationArray = new byte[(num7 - 1) + 1];
            if (num7 > 0)
            {
                Array.Copy(sourceArray, num5 + 2, destinationArray, 0, num7);
            }
            str = str + Conversions.ToString(num8) + ",";
            double num24 = num8;
            switch (num24)
            {
                case 7.0:
                case 12.0:
                case 0.0:
                    goto Label_0B31;

                case 8.0:
                    num4 = destinationArray[12] & 0x1f;
                    this.ExtraGameID = destinationArray[15] & 0xe0;
                    goto Label_0B31;

                case 13.0:
                {
                    int num10 = (destinationArray[0] + (destinationArray[1] * 0x100)) & 0x3ff;
                    Planet planet2 = this.xPlanets[num10];
                    planet2.PlanetData = destinationArray;
                    planet2.IncompletePlanet = false;
                    planet = planet2;
                    goto Label_0B31;
                }
                case 14.0:
                {
                    Planet planet4 = new Planet(destinationArray);
                    Planet planet3 = this.xPlanets[planet4.PlanetID];
                    if (Conversions.ToBoolean(planet3.IncompletePlanet))
                    {
                        planet3.OwnerID = planet4.OwnerID;
                        if (planet4.EstimatedPopulation == 0)
                        {
                            planet3.Population = 0x9c40;
                        }
                        else
                        {
                            planet3.Population = planet4.EstimatedPopulation * 400;
                        }
                        planet3.OriginalGravity = planet4.OriginalGravity;
                        planet3.OriginalRadiation = planet4.OriginalRadiation;
                        planet3.OriginalTemperature = planet4.OriginalTemperature;
                        planet3.Gravity = planet4.Gravity;
                        planet3.Radiation = planet4.Radiation;
                        planet3.Temperature = planet4.Temperature;
                        planet3.GermaniumConcentration = planet4.GermaniumConcentration;
                        planet3.BoraniumConcentration = planet4.BoraniumConcentration;
                        planet3.IroniumConcentration = planet4.IroniumConcentration;
                        planet3.Ironium = 0xc350;
                        planet3.Boranium = 0xc350;
                        planet3.Germanium = 0xc350;
                        planet3.StarbaseSlotID = planet4.StarbaseSlotID;
                        planet3.Mines = 0xfa0;
                        planet3.Factories = 0xfa0;
                        planet3.Defenses = 0;
                        planet3.Scanner = false;
                    }
                    goto Label_0B31;
                }
                case 16.0:
                {
                    Fleet fleet2 = new Fleet(destinationArray);
                    int num11 = destinationArray[0] + (destinationArray[1] * 0x100);
                    this.Fleets[num11] = fleet2;
                    fleet = fleet2;
                    goto Label_0B31;
                }
                case 6.0:
                {
                    byte num9 = destinationArray[0];
                    Race item = (Race) this.xRaces[num9];
                    collection.Add(item, null, null, null);
                    if (destinationArray.Length > 100)
                    {
                        if (num4 == num9)
                        {
                            item.RaceData = destinationArray;
                            item.xPasswordHash = 0;
                            numArray[num9] = item.xShipDesignCount;
                            numArray2[num9] = item.xStarbaseDesignCount;
                        }
                        else
                        {
                            Race race2 = new Race();
                            race2.RaceData = destinationArray;
                            item.xShipDesignCount = race2.xShipDesignCount;
                            item.xStarbaseDesignCount = race2.xStarbaseDesignCount;
                            numArray[num9] = race2.xShipDesignCount;
                            numArray2[num9] = race2.xStarbaseDesignCount;
                            item.xName = race2.xName;
                            item.xPluralName = race2.xPluralName;
                        }
                    }
                    else
                    {
                        Race race3 = new Race();
                        race3.RaceData = destinationArray;
                        item.xShipDesignCount = race3.xShipDesignCount;
                        item.xStarbaseDesignCount = race3.xStarbaseDesignCount;
                        numArray[num9] = race3.xShipDesignCount;
                        numArray2[num9] = race3.xStarbaseDesignCount;
                        item.xName = race3.xName;
                        item.xPluralName = race3.xPluralName;
                    }
                    goto Label_0B31;
                }
                default:
                    if (num24 != 17.0)
                    {
                        switch (num24)
                        {
                            case 19.0:
                            {
                                WayPointTask task = new WayPointTask(destinationArray);
                                fleet.WaypointTasks.Add(task, null, null, null);
                                break;
                            }
                            case 20.0:
                            {
                                Waypoint waypoint2 = new Waypoint(destinationArray);
                                fleet.Waypoints.Add(waypoint2, null, null, null);
                                break;
                            }
                            case 26.0:
                            {
                                Design design = new Design();
                                design.DesignData = destinationArray;
                                design.xNumRemaining = 0;
                                design.xNumbuilt = 0;
                                int num22 = (int) (((long) Math.Round(Conversion.Int((double) (((double) destinationArray[1]) / 4.0)))) & 0x1fL);
                                if (num22 < 0x10)
                                {
                                    Race race4 = (Race) this.xRaces[index];
                                    while (numArray[index] == 0)
                                    {
                                        index++;
                                        race4 = (Race) this.xRaces[index];
                                    }
                                    Design design2 = race4.xShipDesigns[num22];
                                    if (design2 == null)
                                    {
                                        race4.xShipDesigns[num22] = design;
                                    }
                                    else if (design.Incompletedesign)
                                    {
                                        if (design2.Incompletedesign)
                                        {
                                            race4.xShipDesigns[num22] = design;
                                        }
                                        else if (design.xShipHullID != design2.xShipHullID)
                                        {
                                            race4.xShipDesigns[num22] = design;
                                        }
                                    }
                                    else
                                    {
                                        race4.xShipDesigns[num22] = design;
                                    }
                                    numArray[index]--;
                                }
                                else
                                {
                                    Race race5 = (Race) this.xRaces[num2];
                                    while (numArray2[num2] == 0)
                                    {
                                        num2++;
                                        race5 = (Race) NewLateBinding.LateIndexGet(this.Races(), new object[] { num2 }, null);
                                    }
                                    Design design3 = race5.xStarbaseDesigns[num22 - 0x10];
                                    if (design3 == null)
                                    {
                                        race5.xStarbaseDesigns[num22 - 0x10] = design;
                                    }
                                    else if (design.Incompletedesign)
                                    {
                                        if (design3.Incompletedesign)
                                        {
                                            race5.xStarbaseDesigns[num22 - 0x10] = design;
                                        }
                                    }
                                    else
                                    {
                                        race5.xStarbaseDesigns[num22 - 0x10] = design;
                                    }
                                    numArray2[num2]--;
                                }
                                break;
                            }
                            case 28.0:
                                planet.xProductionQueue = destinationArray;
                                break;

                            case 30.0:
                            {
                                this.tmpBattlePlans.Add(destinationArray, null, null, null);
                                BattlePlan plan = new BattlePlan(destinationArray);
                                NewLateBinding.LateSet(this.xRaces[plan.RaceID], null, "battleplans", new object[] { plan.BattlePlanNo, plan }, null, null);
                                break;
                            }
                            case 43.0:
                            {
                                int num23 = destinationArray[0] + (destinationArray[1] * 0x100);
                                if ((num23 >= 0) & (num23 <= 0x1fff))
                                {
                                    this.Minefields[num23] = destinationArray;
                                }
                                else if ((num23 >= 0x1fff) & (num23 <= 0x3fff))
                                {
                                    this.Packets[num23 - 0x2000] = destinationArray;
                                }
                                else if ((num23 >= 0x4000) & (num23 <= 0x4fff))
                                {
                                    this.Wormholes[num23 - 0x4000] = destinationArray;
                                }
                                else if ((num23 >= 0x6000) & (num23 <= 0x6fff))
                                {
                                    destinationArray[12] = 0;
                                    destinationArray[13] = 0;
                                    destinationArray[14] = 0;
                                    destinationArray[15] = 0;
                                    this.MTs[num23 - 0x6000] = destinationArray;
                                }
                                break;
                            }
                        }
                        goto Label_0B31;
                    }
                    if (num3 <= 0)
                    {
                        goto Label_0B31;
                    }
                    num3--;
                    num12 = (destinationArray[0] + (destinationArray[1] * 0x100)) & 0x1ff;
                    num15 = (int) (((long) Math.Round(Conversion.Int((double) (((double) destinationArray[1]) / 2.0)))) & 15L);
                    if ((destinationArray[5] & 8) == 0)
                    {
                        num16 = 2;
                    }
                    else
                    {
                        num16 = 1;
                    }
                    num19 = destinationArray[8] + (destinationArray[9] * 0x100);
                    num20 = destinationArray[10] + (destinationArray[11] * 0x100);
                    num17 = destinationArray[12] + (destinationArray[13] * 0x100);
                    waypoint = new Waypoint();
                    waypoint.X = num19;
                    waypoint.Y = num20;
                    waypoint.OwnerID = num15;
                    waypoint.FleetID = num12;
                    waypoint.PositionObjectID = 0xffff;
                    foreach (Planet planet5 in this.Planets())
                    {
                        if ((planet5 != null) && ((planet5.X == waypoint.X) & (planet5.y == waypoint.Y)))
                        {
                            waypoint.PositionObjectID = planet5.PlanetID;
                            waypoint.WaypointObjectType = 1;
                            break;
                        }
                    }
                    break;
            }
            Fleet fleet3 = new Fleet();
            fleet3.FleetID = num12;
            fleet3.OwnerID = num15;
            fleet3.X = num19;
            fleet3.Y = num20;
            fleet3.PositionObjectID = waypoint.PositionObjectID;
            fleet3.Ships().Clear();
            int num14 = 14;
            int num18 = 0;
            int left = 0;
            int num21 = 0;
            do
            {
                if ((num17 & ((long) Math.Round(Math.Pow(2.0, (double) num21)))) != 0L)
                {
                    Ships ships = new Ships();
                    ships.DesignID = num21;
                    if (num16 == 1)
                    {
                        ships.ShipCount = destinationArray[num14];
                    }
                    else
                    {
                        ships.ShipCount = destinationArray[num14] + (destinationArray[num14 + 1] * 0x100);
                    }
                    num14 += num16;
                    fleet3.Ships().Add(ships, null, null, null);
                    object[] objArray2 = new object[1];
                    Ships ships2 = ships;
                    objArray2[0] = ships2.DesignID;
                    object[] arguments = objArray2;
                    bool[] copyBack = new bool[] { true };
                    if (copyBack[0])
                    {
                        ships2.DesignID = (int) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(int));
                    }
                    left = Conversions.ToInteger(Operators.AddObject(left, Operators.MultiplyObject(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.Races(), new object[] { num15 }, null), null, "xshipdesigns", arguments, null, null, copyBack), null, "MaxFuelCapacity", new object[0], null, null, null), ships.ShipCount)));
                    num18 += ships.ShipCount;
                }
                num21++;
            }
            while (num21 <= 15);
            fleet3.Fuel = 50 * num18;
            fleet3.Fuel = left;
            fleet3.Waypoints.Add(waypoint, null, null, null);
            this.Fleets[(fleet3.OwnerID * 0x200) + fleet3.FleetID] = fleet3;
        Label_0B31:
            num5 = (num5 + 2) + num7;
            if (num5 >= sourceArray.Length)
            {
                return;
            }
            goto Label_0079;
        }

        public void ImportPFile(string Filename)
        {
            StreamReader reader = new StreamReader(Filename);
            object[] objArray = new object[] { 
                12, 12, 13, 13, 14, 14, 15, 15, 0x10, 0x11, 0x11, 0x12, 0x13, 20, 0x15, 0x16, 
                0x18, 0x19, 0x1b, 0x1d, 0x1f, 0x21, 0x24, 40, 0x2c, 50, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 
                0x3a, 0x3b, 60, 0x3e, 0x40, 0x41, 0x43, 0x45, 0x47, 0x49, 0x4b, 0x4e, 80, 0x53, 0x56, 0x59, 
                0x5c, 0x60
             };
            string expression = reader.ReadToEnd();
            reader.Close();
            string[] strArray = Strings.Split(expression, "\r\n", -1, CompareMethod.Binary);
            int num12 = strArray.Length - 1;
            for (int i = 1; i <= num12; i++)
            {
                int num4 = -1;
                int index = -1;
                int raceID = -1;
                string[] strArray2 = Strings.Split(strArray[i], "\t", -1, CompareMethod.Binary);
                if (strArray2.Length > 1)
                {
                    IEnumerator enumerator;
                    int num13 = this.PlanetNames.Length - 1;
                    for (int j = 0; j <= num13; j++)
                    {
                        if (this.PlanetNames[j].ToUpper() == strArray2[0].ToUpper())
                        {
                            num4 = j;
                            break;
                        }
                    }
                    foreach (Planet planet in this.Planets())
                    {
                        if ((planet != null) && (planet.NameID == num4))
                        {
                            index = planet.PlanetID;
                        }
                    }
                    try
                    {
                        enumerator = ((IEnumerable) this.Races()).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Race current = (Race) enumerator.Current;
                            if ((current != null) && (current.xName.ToUpper() == strArray2[1].ToUpper()))
                            {
                                raceID = current.RaceID;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    if (index >= 0)
                    {
                        Planet planet2 = this.Planets()[index];
                        if (raceID == -1)
                        {
                            planet2.OwnerID = -1;
                        }
                        else
                        {
                            planet2.OwnerID = raceID;
                            planet2.Population = 0x9c40;
                        }
                        if (Versioned.IsNumeric(strArray2[4]) && (Conversions.ToDouble(strArray2[4]) > 0.0))
                        {
                            planet2.Population = Conversions.ToInteger(strArray2[4]);
                        }
                        if (Versioned.IsNumeric(strArray2[0x10]) && (Conversions.ToDouble(strArray2[0x10]) > 0.0))
                        {
                            planet2.IroniumConcentration = Conversions.ToInteger(strArray2[0x10]);
                        }
                        if (Versioned.IsNumeric(strArray2[0x11]) && (Conversions.ToDouble(strArray2[0x11]) > 0.0))
                        {
                            planet2.GermaniumConcentration = Conversions.ToInteger(strArray2[0x11]);
                        }
                        if (Versioned.IsNumeric(strArray2[0x12]) && (Conversions.ToDouble(strArray2[0x12]) > 0.0))
                        {
                            planet2.BoraniumConcentration = Conversions.ToInteger(strArray2[0x12]);
                        }
                        double num6 = Conversion.Val(strArray2[20]);
                        if (Versioned.IsNumeric(num6))
                        {
                            if (num6 >= 0.92)
                            {
                                if (num6 > 2.0)
                                {
                                    num6 = ((num6 - 2.0) / 0.24) + 75.0;
                                }
                                else
                                {
                                    num6 = (num6 / 0.04) + 25.0;
                                }
                            }
                            else
                            {
                                int num15 = objArray.Length - 1;
                                for (int k = 0; k <= num15; k++)
                                {
                                    if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject("0.", objArray[k]), num6, false))
                                    {
                                        num6 = k;
                                        break;
                                    }
                                }
                                if (num6 < 1.0)
                                {
                                    num6 = 1.0;
                                }
                            }
                            planet2.Gravity = (int) Math.Round(num6);
                            planet2.OriginalGravity = (int) Math.Round(num6);
                        }
                        double num10 = Conversion.Val(strArray2[0x15]);
                        if (Versioned.IsNumeric(num10))
                        {
                            planet2.Temperature = (int) Math.Round((double) ((num10 / 4.0) + 50.0));
                            planet2.OriginalTemperature = (int) Math.Round((double) ((num10 / 4.0) + 50.0));
                        }
                        double num9 = Conversion.Val(strArray2[0x16]);
                        if (Versioned.IsNumeric(num9) && (num9 > 0.0))
                        {
                            planet2.Radiation = (int) Math.Round(num9);
                            planet2.OriginalRadiation = (int) Math.Round(num9);
                        }
                        if (Versioned.IsNumeric(strArray2[0x17]) && (Conversions.ToDouble(strArray2[0x17]) > 0.0))
                        {
                            planet2.OriginalGravity = Conversions.ToInteger(strArray2[0x17]);
                        }
                        double num8 = Conversion.Val(strArray2[0x15]);
                        if (Versioned.IsNumeric(num8))
                        {
                            planet2.OriginalTemperature = (int) Math.Round((double) ((num8 / 4.0) + 50.0));
                        }
                        double num7 = Conversion.Val(strArray2[0x19]);
                        if (Versioned.IsNumeric(num7) && (num7 > 0.0))
                        {
                            planet2.OriginalRadiation = (int) Math.Round(num7);
                        }
                        planet2.Factories = 0xfa0;
                        planet2.Mines = 0xfa0;
                    }
                }
            }
        }

        public void ImportRaceFile(string filename, int PlayerNo)
        {
            Decryptor decryptor = new Decryptor();
            int num = 0;
            byte[] sourceArray = decryptor.OpenFile(filename);
            do
            {
                int length = sourceArray[num + 0] + ((sourceArray[num + 1] & 3) * 0x100);
                double num3 = Conversion.Int((double) (((double) sourceArray[num + 1]) / 4.0));
                byte[] destinationArray = new byte[(length - 1) + 1];
                if (length > 0)
                {
                    Array.Copy(sourceArray, num + 2, destinationArray, 0, length);
                }
                switch (num3)
                {
                    case 6.0:
                    {
                        Race race2 = new Race();
                        race2.RaceData = destinationArray;
                        Race race = (Race) this.xRaces[PlayerNo - 1];
                        race.xPasswordHash = 0;
                        race.xPluralName = race2.xPluralName;
                        race.xName = race2.xName;
                        race.xPRT = race2.xPRT;
                        race.xGrowthRate = race2.xGrowthRate;
                        race.LowGravity = race2.LowGravity;
                        race.HighGravity = race2.HighGravity;
                        race.CentreGravity = race2.CentreGravity;
                        race.LowRadiation = race2.LowRadiation;
                        race.HighRadiation = race2.HighRadiation;
                        race.CentreRadiation = race2.CentreRadiation;
                        race.LowTemperature = race2.LowTemperature;
                        race.HighTemperature = race2.HighTemperature;
                        race.CentreTemperature = race2.CentreTemperature;
                        race.xSRTBitmap = race2.xSRTBitmap;
                        race.xPopulationEfficiency = race2.xPopulationEfficiency;
                        race.xFactoryEfficiency = race2.xFactoryEfficiency;
                        race.xFactoriesOperated = race2.xFactoriesOperated;
                        race.xResourcesToBuildFactory = race2.xResourcesToBuildFactory;
                        race.xMiningEfficiency = race2.xMiningEfficiency;
                        race.xMinesOperated = race2.xMinesOperated;
                        race.xResourcesToBuildMines = race2.xResourcesToBuildMines;
                        race.xFactoriesCost1LessGerm = race2.xFactoriesCost1LessGerm;
                        race.xExpensiveTechStartsAt3 = race2.xExpensiveTechStartsAt3;
                        race.xEnergyResearchCost = race2.xEnergyResearchCost;
                        race.xWeaponsResearchCost = race2.xWeaponsResearchCost;
                        race.xPropulsionResearchCost = race2.xPropulsionResearchCost;
                        race.xConstructionResearchCost = race2.xConstructionResearchCost;
                        race.xElectronicsResearchCost = race2.xElectronicsResearchCost;
                        race.xBiologyResearchCost = race2.xBiologyResearchCost;
                        this.xRaces[PlayerNo - 1] = race;
                    }
                }
                num = (num + 2) + length;
            }
            while (num < sourceArray.Length);
        }

        public long Load(string Filename)
        {
            long num3;
            this.xPlanets = new Planet[0x3e9];
            Decryptor decryptor = new Decryptor();
            if (Filename.Substring(Filename.Length - 4).ToUpper() == ".HST")
            {
                Filename = Filename.Substring(0, Filename.Length - 4);
            }
            this.xyFile = decryptor.OpenFile(Filename + ".xy");
            this.xGameID = this.xyFile[4];
            this.xGameID += (uint) (this.xyFile[5] * 0x100);
            this.xGameID += (uint) ((this.xyFile[6] * 0x100) * 0x100);
            this.xGameID += (uint) (((this.xyFile[7] * 0x100L) * ((ulong) 0x100L)) * ((ulong) 0x100L));
            this.xPlayerCount = this.xyFile[0x1c];
            this.xPlanetCount = this.xyFile[30] + (this.xyFile[0x1f] * 0x100);
            this.xGameName = "";
            int index = 0x34;
            do
            {
                if (this.xyFile[index] == 0)
                {
                    break;
                }
                this.xGameName = this.xGameName + Conversions.ToString(Strings.Chr(this.xyFile[index]));
                index++;
            }
            while (index <= 0x53);
            int x = 0x3e8;
            int num9 = Conversions.ToInteger(Operators.SubtractObject(this.PlanetCount, 1));
            for (int i = 0; i <= num9; i++)
            {
                Planet planet = new Planet(i);
                planet.X = (this.xyFile[(0x54 + (i * 4)) + 0] + ((this.xyFile[(0x54 + (i * 4)) + 1] & 3) * 0x100)) + x;
                x = planet.X;
                planet.y = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 1]) / 4.0)) + ((this.xyFile[(0x54 + (i * 4)) + 2] & 0x3f) * 0x40)));
                planet.NameID = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 2]) / 64.0)) + (this.xyFile[(0x54 + (i * 4)) + 3] * 4)));
                this.xPlanets[i] = planet;
                this.PlanetIDs[i] = i;
            }
            this.hstFile = decryptor.OpenFile(Filename + ".hst");
            this.hstLoaded = true;
            int hstPosition = 0;
            do
            {
                int num6;
                int num7;
                byte[] data = new byte[0x401];
                this.ReadBlock(this.hstFile, ref hstPosition, ref data, ref num7, ref num6);
            }
            while (hstPosition != this.hstFile.Length);
            int xPlayerCount = this.xPlayerCount;
            for (int j = 1; j <= xPlayerCount; j++)
            {
                byte[] item = decryptor.OpenFile(Filename + ".m" + Conversions.ToString(j));
                this.mFiles.Add(item, null, null, null);
            }
            return num3;
        }

        public Planet[] Planets()
        {
            return this.xPlanets;
        }

        public object Races()
        {
            return this.xRaces;
        }

        private void ReadBlock(byte[] file, ref int hstPosition, ref byte[] Data, ref int type, ref int Size)
        {
            Size = file[hstPosition + 0] + ((file[hstPosition + 1] & 3) * 0x100);
            type = (int) Math.Round(Conversion.Int((double) (((double) file[hstPosition + 1]) / 4.0)));
            Data = new byte[(Size - 1) + 1];
            if (Size > 0)
            {
                Array.Copy(file, hstPosition + 2, Data, 0, Size);
            }
            switch (type)
            {
                case 6:
                {
                    byte index = Data[0];
                    Race race = new Race();
                    race.RaceData = Data;
                    this.xRaces[index] = race;
                    break;
                }
                case 8:
                {
                    Header header = new Header(Data);
                    break;
                }
                case 13:
                {
                    int num2 = Data[0] + ((Data[1] & 3) * 0x100);
                    Planet planet = this.Planets()[num2];
                    planet.PlanetData = Data;
                    break;
                }
                case 0x10:
                {
                    Fleet fleet = new Fleet(Data);
                    int num3 = Data[0] + (Data[1] * 0x100);
                    this.Fleets[num3] = fleet;
                    this.$STATIC$ReadBlock$20511D5108101D5108108$LastFleet = fleet;
                    break;
                }
                case 20:
                {
                    Waypoint item = new Waypoint(Data);
                    this.$STATIC$ReadBlock$20511D5108101D5108108$LastFleet.Waypoints.Add(item, null, null, null);
                    break;
                }
            }
            hstPosition = (hstPosition + 2) + Size;
        }

        public long Save(string Filename, [Optional, DefaultParameterValue(true)] bool SkipMfiles)
        {
            try
            {
                long num2;
                int num23;
                ProjectData.ClearProjectError();
                int num22 = 0;
                if (Filename.Substring(Filename.Length - 4).ToUpper() == ".HST")
                {
                    Filename = Filename.Substring(0, Filename.Length - 4);
                }
                int position = 0;
                do
                {
                    int num16;
                    int length = this.hstFile[position + 0] + ((this.hstFile[position + 1] & 3) * 0x100);
                    double num15 = Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0));
                    switch (num15)
                    {
                        case 0.0:
                        case 8.0:
                            break;

                        case 6.0:
                        {
                            num16 = position + 2;
                            object obj2 = Operators.AndObject(functions.GetBytes(this.hstFile, ref num16, 2), 15);
                            Race race = (Race) this.xRaces[Conversions.ToInteger(obj2)];
                            functions.DeleteObject(ref this.hstFile, position);
                            functions.InsertObject(ref this.hstFile, 6, race.RaceData, position);
                            length = race.RaceData.Length;
                            break;
                        }
                        case 13.0:
                        {
                            num16 = position + 2;
                            object right = Operators.AndObject(functions.GetBytes(this.hstFile, ref num16, 2), 0x3ff);
                            foreach (Planet planet in this.Planets())
                            {
                                if ((planet != null) && Operators.ConditionalCompareObjectEqual(planet.PlanetID, right, false))
                                {
                                    functions.DeleteObject(ref this.hstFile, position);
                                    functions.InsertObject(ref this.hstFile, 13, planet.PlanetData, position);
                                    length = planet.PlanetData.Length;
                                    break;
                                }
                            }
                            break;
                        }
                        case 16.0:
                        {
                            num16 = position + 2;
                            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.hstFile, ref num16, 2));
                            foreach (Fleet fleet in this.Fleets)
                            {
                                if ((fleet != null) && Operators.ConditionalCompareObjectEqual(fleet.FleetID + (fleet.OwnerID * 0x200), objectValue, false))
                                {
                                    functions.DeleteObject(ref this.hstFile, position);
                                    for (int i = (int) Math.Round(Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0))); i == 20; i = (int) Math.Round(Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0))))
                                    {
                                        functions.DeleteObject(ref this.hstFile, position);
                                    }
                                    functions.InsertObject(ref this.hstFile, 0x10, fleet.FleetData, position);
                                    length = fleet.FleetData.Length;
                                    IEnumerator enumerator = fleet.Waypoints.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        Waypoint current = (Waypoint) enumerator.Current;
                                        functions.InsertObject(ref this.hstFile, 20, current.WaypointData, (position + length) + 2);
                                        length = (length + current.WaypointData.Length) + 2;
                                    }
                                    if (enumerator is IDisposable)
                                    {
                                        (enumerator as IDisposable).Dispose();
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                        default:
                            if (((num15 == 20.0) || (num15 == 26.0)) || ((num15 != 30.0) && (num15 == 43.0)))
                            {
                            }
                            break;
                    }
                    position = (position + 2) + length;
                }
                while (position < this.hstFile.Length);
                Decryptor decryptor = new Decryptor();
                if (!SkipMfiles)
                {
                    int count = this.mFiles.Count;
                    for (int j = 1; j <= count; j++)
                    {
                        int num8;
                        int num10;
                        byte[] data = (byte[]) this.mFiles[j];
                        int num7 = 0;
                    Label_03AD:
                        num8 = data[num7 + 0] + ((data[num7 + 1] & 3) * 0x100);
                        double num20 = Conversion.Int((double) (((double) data[num7 + 1]) / 4.0));
                        switch (num20)
                        {
                            case 0.0:
                            case 6.0:
                            case 8.0:
                                goto Label_0781;

                            case 12.0:
                            {
                                byte[] buffer2 = new byte[] { 
                                    0xb0, 13, 0xb1, 0xd9, 120, 9, 220, 0x1a, 0x41, 80, 0xd6, 0x49, 0xad, 0xe8, 0xd4, 0x16, 
                                    0xd5, 0x20, 0x31, 0x90, 0xdb, 0x7d, 0xf2, 0xd6, 1, 6, 0xde, 0xdb, 0xd4, 40, 7, 0xd7, 
                                    13, 0xc5, 0x16, 0x2a, 0x9f
                                 };
                                goto Label_0781;
                            }
                            default:
                            {
                                if (num20 != 13.0)
                                {
                                    goto Label_05F5;
                                }
                                int num11 = (data[num7 + 2] + (data[num7 + 3] * 0x100)) & 0x3ff;
                                num10 = -1;
                                int index = 0;
                                do
                                {
                                    if (this.PlanetIDs[index] == num11)
                                    {
                                        num10 = index;
                                        break;
                                    }
                                    index++;
                                }
                                while (index <= 0x3ff);
                                break;
                            }
                        }
                        Planet planet2 = this.xPlanets[num10];
                        functions.DeleteObject(ref data, num7);
                        functions.InsertObject(ref data, 13, planet2.PlanetData, num7);
                        num8 = planet2.PlanetData.Length;
                        goto Label_0781;
                    Label_05F5:
                        if (num20 == 16.0)
                        {
                            int num13 = data[num7 + 2] + (data[num7 + 3] * 0x100);
                            foreach (Fleet fleet2 in this.Fleets)
                            {
                                if ((fleet2 != null) && ((fleet2.FleetID + (fleet2.OwnerID * 0x200)) == num13))
                                {
                                    functions.DeleteObject(ref data, num7);
                                    for (int k = (int) Math.Round(Conversion.Int((double) (((double) data[num7 + 1]) / 4.0))); k == 20; k = (int) Math.Round(Conversion.Int((double) (((double) data[num7 + 1]) / 4.0))))
                                    {
                                        functions.DeleteObject(ref data, num7);
                                    }
                                    functions.InsertObject(ref data, 0x10, fleet2.FleetData, num7);
                                    num8 = fleet2.FleetData.Length;
                                    IEnumerator enumerator2 = fleet2.Waypoints.GetEnumerator();
                                    while (enumerator2.MoveNext())
                                    {
                                        Waypoint waypoint2 = (Waypoint) enumerator2.Current;
                                        functions.InsertObject(ref data, 20, waypoint2.WaypointData, (num7 + num8) + 2);
                                        num8 = (num8 + waypoint2.WaypointData.Length) + 2;
                                    }
                                    if (enumerator2 is IDisposable)
                                    {
                                        (enumerator2 as IDisposable).Dispose();
                                    }
                                    break;
                                }
                            }
                        }
                        else if (((num20 == 20.0) || (num20 == 26.0)) || ((num20 != 30.0) && (num20 == 43.0)))
                        {
                        }
                    Label_0781:
                        num7 = (num7 + 2) + num8;
                        if (num7 < data.Length)
                        {
                            goto Label_03AD;
                        }
                        decryptor.SaveFile(data, Filename + ".m" + Conversions.ToString(j));
                    }
                }
                decryptor.SaveFile(this.hstFile, Filename + ".hst");
                if (num23 != 0)
                {
                    ProjectData.ClearProjectError();
                }
                return num2;
            Label_07D7:
                num23 = -1;
                switch (num22)
                {
                    case 0:
                    case 1:
                        goto Label_080D;
                }
            }
            catch (object obj1) when (?)
            {
                ProjectData.SetProjectError((Exception) obj1);
                goto Label_07D7;
            }
        Label_080D:
            throw ProjectData.CreateProjectError(-2146828237);
        }

        public void SaveHST(string Filename)
        {
            int playerID = Strings.InStr(Filename, ".hst", CompareMethod.Text);
            string str2 = Strings.Left(Filename, playerID - 1);
            int num4 = this.xPlayerCount - 1;
            for (playerID = 0; playerID <= num4; playerID++)
            {
                this.SaveMFile(str2 + ".m" + Conversions.ToString((int) (playerID + 1)), playerID);
            }
            byte[] data = new byte[0];
            Header header = new Header();
            header.GameID = this.xGameID;
            header.TurnNo = this.xTurnNo;
            header.PlayerNo = 0x1f;
            header.FileType = 2;
            header.Flags = (header.Flags & 0x3f) | this.ExtraGameID;
            functions.InsertObject(ref data, 8, header.Data, data.Length);
            int xPlayerCount = this.xPlayerCount;
            for (playerID = 1; playerID <= xPlayerCount; playerID++)
            {
                Race race = (Race) this.xRaces[playerID - 1];
                byte[] fullRaceData = race.FullRaceData;
                if (playerID == 1)
                {
                    fullRaceData[2] = (byte) (this.xPlanetCount & 0xff);
                    fullRaceData[3] = (byte) Math.Round(Conversion.Int((double) (((double) this.xPlanetCount) / 256.0)));
                }
                else
                {
                    fullRaceData[2] = 0;
                    fullRaceData[3] = 0;
                }
                fullRaceData[4] = 0;
                int num3 = 0;
                foreach (Fleet fleet in this.Fleets)
                {
                    if ((fleet != null) && (fleet.OwnerID == race.RaceID))
                    {
                        num3++;
                    }
                }
                fullRaceData[4] = (byte) (num3 & 0xff);
                fullRaceData[5] = (byte) Math.Round(Conversion.Int((double) (((double) num3) / 256.0)));
                fullRaceData[5] = (byte) ((fullRaceData[5] & 15) + (race.StarbaseDesignCount * 0x10));
                fullRaceData[10] = (byte) playerID;
                functions.InsertObject(ref data, 6, fullRaceData, data.Length);
            }
            int xPlanetCount = this.xPlanetCount;
            for (playerID = 1; playerID <= xPlanetCount; playerID++)
            {
                Planet planet = this.xPlanets[playerID - 1];
                functions.InsertObject(ref data, 13, planet.FullPlanetData, data.Length);
                if (planet.xProductionQueue != null)
                {
                    functions.InsertObject(ref data, 0x1c, planet.xProductionQueue, data.Length);
                }
            }
            foreach (Race race2 in this.xRaces)
            {
                if (race2 != null)
                {
                    foreach (Design design in race2.xShipDesigns)
                    {
                        if (!Information.IsNothing(design))
                        {
                            functions.InsertObject(ref data, 0x1a, (byte[]) design.FulldesignData, data.Length);
                        }
                    }
                }
            }
            foreach (Fleet fleet2 in this.Fleets)
            {
                if (fleet2 != null)
                {
                    IEnumerator enumerator;
                    IEnumerator enumerator2;
                    functions.InsertObject(ref data, 0x10, (byte[]) fleet2.FullFleetData, data.Length);
                    try
                    {
                        enumerator = fleet2.Waypoints.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Waypoint current = (Waypoint) enumerator.Current;
                            functions.InsertObject(ref data, 20, (byte[]) current.FullWaypointData, data.Length);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    try
                    {
                        enumerator2 = fleet2.WaypointTasks.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            WayPointTask task = (WayPointTask) enumerator2.Current;
                            functions.InsertObject(ref data, 0x13, task.WaypointTaskData, data.Length);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
            }
            foreach (Race race3 in this.xRaces)
            {
                if (race3 != null)
                {
                    foreach (Design design2 in race3.xStarbaseDesigns)
                    {
                        if (!Information.IsNothing(design2))
                        {
                            functions.InsertObject(ref data, 0x1a, (byte[]) design2.FulldesignData, data.Length);
                        }
                    }
                }
            }
            int num2 = 0;
            object[] minefields = this.Minefields;
            for (int i = 0; i < minefields.Length; i++)
            {
                if (RuntimeHelpers.GetObjectValue(minefields[i]) != null)
                {
                    num2++;
                }
            }
            object[] mTs = this.MTs;
            for (int j = 0; j < mTs.Length; j++)
            {
                if (RuntimeHelpers.GetObjectValue(mTs[j]) != null)
                {
                    num2++;
                }
            }
            object[] packets = this.Packets;
            for (int k = 0; k < packets.Length; k++)
            {
                if (RuntimeHelpers.GetObjectValue(packets[k]) != null)
                {
                    num2++;
                }
            }
            byte[] newObject = new byte[] { (byte) (num2 & 0xff), (byte) Math.Round(Conversion.Int((double) (((double) num2) / 256.0))) };
            functions.InsertObject(ref data, 0x2b, newObject, data.Length);
            object[] objArray6 = this.Minefields;
            for (int m = 0; m < objArray6.Length; m++)
            {
                object objectValue = RuntimeHelpers.GetObjectValue(objArray6[m]);
                if (objectValue != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) objectValue, data.Length);
                }
            }
            object[] objArray7 = this.Packets;
            for (int n = 0; n < objArray7.Length; n++)
            {
                object obj6 = RuntimeHelpers.GetObjectValue(objArray7[n]);
                if (obj6 != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) obj6, data.Length);
                }
            }
            object[] objArray8 = this.MTs;
            for (int num18 = 0; num18 < objArray8.Length; num18++)
            {
                object obj7 = RuntimeHelpers.GetObjectValue(objArray8[num18]);
                if (obj7 != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) obj7, data.Length);
                }
            }
            foreach (Race race4 in this.xRaces)
            {
                if (race4 != null)
                {
                    foreach (BattlePlan plan in race4.BattlePlans)
                    {
                        if (plan != null)
                        {
                            functions.InsertObject(ref data, 30, plan.BattlePlanData, data.Length);
                        }
                    }
                }
            }
            byte[] buffer = new byte[] { 0, 0 };
            functions.InsertObject(ref data, 0, buffer, data.Length);
            new Decryptor().SaveFile(data, Filename);
        }

        public void SaveMFile(string Filename, int PlayerID)
        {
            Header header = new Header();
            byte[] data = new byte[0];
            header.GameID = this.xGameID;
            header.TurnNo = this.xTurnNo;
            header.PlayerNo = PlayerID;
            header.FileType = 3;
            header.Flags = (header.Flags & 0x3f) | this.ExtraGameID;
            int num2 = 0;
            int num = 0;
            Race race = (Race) this.xRaces[PlayerID];
            foreach (Planet planet in this.xPlanets)
            {
                if ((planet != null) && (planet.OwnerID == PlayerID))
                {
                    num2++;
                }
            }
            foreach (Fleet fleet in this.Fleets)
            {
                if ((fleet != null) && (fleet.OwnerID == PlayerID))
                {
                    num++;
                }
            }
            functions.InsertObject(ref data, 8, header.Data, data.Length);
            byte[] fullRaceData = race.FullRaceData;
            fullRaceData[1] = (byte) race.ShipDesignCount;
            fullRaceData[2] = (byte) (num2 & 0xff);
            fullRaceData[3] = (byte) Math.Round(Conversion.Int((double) (((double) num2) / 256.0)));
            fullRaceData[4] = (byte) (num & 0xff);
            fullRaceData[5] = (byte) Math.Round((double) (Conversion.Int((double) (((double) num) / 256.0)) + (race.StarbaseDesignCount * 0x10)));
            functions.InsertObject(ref data, 6, fullRaceData, data.Length);
            foreach (Planet planet2 in this.xPlanets)
            {
                if ((planet2 != null) && (planet2.OwnerID == PlayerID))
                {
                    functions.InsertObject(ref data, 13, planet2.FullPlanetData, data.Length);
                    if (planet2.xProductionQueue != null)
                    {
                        functions.InsertObject(ref data, 0x1c, planet2.xProductionQueue, data.Length);
                    }
                }
            }
            foreach (Design design in race.xShipDesigns)
            {
                if (design != null)
                {
                    functions.InsertObject(ref data, 0x1a, (byte[]) design.FulldesignData, data.Length);
                }
            }
            foreach (Fleet fleet2 in this.Fleets)
            {
                if ((fleet2 != null) && (fleet2.OwnerID == PlayerID))
                {
                    IEnumerator enumerator;
                    IEnumerator enumerator2;
                    functions.InsertObject(ref data, 0x10, (byte[]) fleet2.FullFleetData, data.Length);
                    try
                    {
                        enumerator = fleet2.Waypoints.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Waypoint current = (Waypoint) enumerator.Current;
                            functions.InsertObject(ref data, 20, (byte[]) current.FullWaypointData, data.Length);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    try
                    {
                        enumerator2 = fleet2.WaypointTasks.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            WayPointTask task = (WayPointTask) enumerator2.Current;
                            functions.InsertObject(ref data, 0x13, task.WaypointTaskData, data.Length);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
            }
            foreach (Design design2 in race.xStarbaseDesigns)
            {
                if (design2 != null)
                {
                    functions.InsertObject(ref data, 0x1a, (byte[]) design2.FulldesignData, data.Length);
                }
            }
            int num3 = 0;
            object[] minefields = this.Minefields;
            for (int i = 0; i < minefields.Length; i++)
            {
                if (RuntimeHelpers.GetObjectValue(minefields[i]) != null)
                {
                    num3++;
                }
            }
            object[] mTs = this.MTs;
            for (int j = 0; j < mTs.Length; j++)
            {
                if (RuntimeHelpers.GetObjectValue(mTs[j]) != null)
                {
                    num3++;
                }
            }
            object[] packets = this.Packets;
            for (int k = 0; k < packets.Length; k++)
            {
                if (RuntimeHelpers.GetObjectValue(packets[k]) != null)
                {
                    num3++;
                }
            }
            byte[] newObject = new byte[] { (byte) (num3 & 0xff), (byte) Math.Round(Conversion.Int((double) (((double) num3) / 256.0))) };
            functions.InsertObject(ref data, 0x2b, newObject, data.Length);
            object[] objArray4 = this.Minefields;
            for (int m = 0; m < objArray4.Length; m++)
            {
                object objectValue = RuntimeHelpers.GetObjectValue(objArray4[m]);
                if (objectValue != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) objectValue, data.Length);
                }
            }
            object[] objArray5 = this.Packets;
            for (int n = 0; n < objArray5.Length; n++)
            {
                object obj6 = RuntimeHelpers.GetObjectValue(objArray5[n]);
                if (obj6 != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) obj6, data.Length);
                }
            }
            object[] objArray6 = this.MTs;
            for (int num15 = 0; num15 < objArray6.Length; num15++)
            {
                object obj7 = RuntimeHelpers.GetObjectValue(objArray6[num15]);
                if (obj7 != null)
                {
                    functions.InsertObject(ref data, 0x2b, (byte[]) obj7, data.Length);
                }
            }
            foreach (BattlePlan plan in race.BattlePlans)
            {
                if (plan != null)
                {
                    functions.InsertObject(ref data, 30, plan.BattlePlanData, data.Length);
                }
            }
            byte[] buffer = new byte[] { 0, 0 };
            functions.InsertObject(ref data, 0, buffer, data.Length);
            new Decryptor().SaveFile(data, Filename);
        }

        public void SwapPlanets(int Planet1ID, int Planet2ID)
        {
            IEnumerator enumerator;
            Planet1ID--;
            Planet2ID--;
            Planet planet = this.xPlanets[Planet1ID];
            Planet planet2 = this.xPlanets[Planet2ID];
            Planet planet3 = this.xPlanets[Planet1ID];
            byte[] planetData = planet3.PlanetData;
            this.xPlanets[Planet1ID].PlanetData = this.xPlanets[Planet2ID].PlanetData;
            this.xPlanets[Planet2ID].PlanetData = planetData;
            this.xPlanets[Planet1ID].PlanetID = Planet1ID;
            this.xPlanets[Planet2ID].PlanetID = Planet2ID;
            this.PlanetIDs[Planet1ID] = Planet2ID;
            this.PlanetIDs[Planet2ID] = Planet1ID;
            try
            {
                enumerator = ((IEnumerable) this.Races()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Race current = (Race) enumerator.Current;
                    if (current != null)
                    {
                        if (current.Homeworld == Planet1ID)
                        {
                            current.Homeworld = Planet2ID;
                        }
                        else if (current.Homeworld == Planet2ID)
                        {
                            current.Homeworld = Planet1ID;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            foreach (Fleet fleet in this.Fleets)
            {
                if (fleet != null)
                {
                    if ((fleet.X == planet.X) & (fleet.Y == planet.y))
                    {
                        IEnumerator enumerator2;
                        fleet.X = planet2.X;
                        fleet.Y = planet2.y;
                        fleet.PositionObjectID = planet2.PlanetID;
                        try
                        {
                            enumerator2 = fleet.Waypoints.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                Waypoint waypoint = (Waypoint) enumerator2.Current;
                                if ((waypoint.X == planet.X) & (waypoint.Y == planet.y))
                                {
                                    waypoint.X = planet2.X;
                                    waypoint.Y = planet2.y;
                                    waypoint.PositionObjectID = planet2.PlanetID;
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                    }
                    else if ((fleet.X == planet2.X) & (fleet.Y == planet2.y))
                    {
                        IEnumerator enumerator3;
                        fleet.X = planet.X;
                        fleet.Y = planet.y;
                        fleet.PositionObjectID = planet.PlanetID;
                        try
                        {
                            enumerator3 = fleet.Waypoints.GetEnumerator();
                            while (enumerator3.MoveNext())
                            {
                                Waypoint waypoint2 = (Waypoint) enumerator3.Current;
                                if ((waypoint2.X == planet2.X) & (waypoint2.Y == planet2.y))
                                {
                                    waypoint2.X = planet.X;
                                    waypoint2.Y = planet.y;
                                    waypoint2.PositionObjectID = planet.PlanetID;
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator3 is IDisposable)
                            {
                                (enumerator3 as IDisposable).Dispose();
                            }
                        }
                    }
                }
            }
        }

        [DispId(13)]
        public object AtlantisSoftware.StarsHostEditor._StarsHostEditor.PlanetCount
        {
            get
            {
                return this.xPlanetCount;
            }
        }

        public object PlanetCount
        {
            get
            {
                return this.xPlanetCount;
            }
        }

        [ComVisible(true)]
        public interface _StarsHostEditor
        {
            [DispId(2)]
            void CreateHST(string XYFilename);
            [DispId(1)]
            object DesignEditor(int RaceID);
            [DispId(7)]
            void ImportMFile(string Filename);
            [DispId(6)]
            void ImportPFile(string Filename);
            [DispId(5)]
            void ImportRaceFile(string filename, int PlayerNo);
            [DispId(8)]
            long Load(string Filename);
            [DispId(11)]
            Planet[] Planets();
            [DispId(12)]
            object Races();
            [DispId(10)]
            long Save(string Filename, [Optional, DefaultParameterValue(true)] bool SkipMfiles);
            [DispId(4)]
            void SaveHST(string Filename);
            [DispId(3)]
            void SaveMFile(string Filename, int PlayerID);
            [DispId(9)]
            void SwapPlanets(int Planet1ID, int Planet2ID);

            [DispId(13)]
            object PlanetCount { [DispId(13)] get; }
        }
    }
}

