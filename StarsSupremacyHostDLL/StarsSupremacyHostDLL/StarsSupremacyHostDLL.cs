namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;

    public class StarsSupremacyHostDLL
    {
        public bool AcceleratedBBS;
        public bool ComputerPlayersFormAlliances;
        public int Density = -1;
        public bool GalaxyClumping;
        public int GameID = -1;
        public string GameName;
        public bool MaxMinerals;
        public bool NoRandomEvents;
        public int PlanetCount = -1;
        public Planet[] Planets = new Planet[0x3e8];
        public int PlayerCount = -1;
        public bool PublicPlayerScores;
        public Race[] Races = new Race[0x10];
        public StarsSupremacyHostDLL.Settings Settings = new StarsSupremacyHostDLL.Settings();
        public bool SlowerTechAdvances;
        public int StartingPositions = -1;
        public bool Tutorial;
        public int UniverseSize = -1;
        public XFile[] XFiles = new XFile[0x10];

        public object CheckXFile(string Filename)
        {
            string str = "";
            string str2 = "";
            int index = Strings.InStrRev(Filename, ".", -1, CompareMethod.Binary);
            if (index > 0)
            {
                str2 = Filename.Substring(0, index - 1);
            }
            this.LoadXYFile(str2 + ".xy");
            this.LoadHSTFile(str2 + ".hst");
            int num2 = this.LoadXFile(Filename);
            if (!this.Settings.Allow22OrMoreSuperlatinumInASlot[num2])
            {
                index = 0;
                do
                {
                    if (this.Races[num2].ShipDesigns[index] != null)
                    {
                        Design design = this.Races[num2].ShipDesigns[index];
                        foreach (DesignSlot slot in design.Slots)
                        {
                            if ((slot != null) && (((slot.CategoryID == 8) & (slot.ItemID == 11)) & (slot.Count >= 0x16)))
                            {
                                str = str + "You are not allowed to have 22 Superlatinum in one slot on the " + design.Name + " design\r\n";
                            }
                        }
                    }
                    index++;
                }
                while (index <= 15);
                index = 0;
                do
                {
                    if (this.Races[num2].StarbaseDesigns[index] != null)
                    {
                        Design design2 = this.Races[num2].StarbaseDesigns[index];
                        foreach (DesignSlot slot2 in design2.Slots)
                        {
                            if ((slot2 != null) && (((slot2.CategoryID == 8) & (slot2.ItemID == 11)) & (slot2.Count >= 0x16)))
                            {
                                str = str + "You are not allowed to have 22 Superlatinum in one slot on the " + design2.Name + " design\r\n";
                            }
                        }
                    }
                    index++;
                }
                while (index <= 9);
            }
            if (!this.Settings.AllowTenthStarbaseSlotToBeUsed[num2] && (this.Races[num2].StarbaseDesigns[9] != null))
            {
                str = str + "You are not allowed to use the 10th Starbase design slot\r\n";
            }
            if (!this.Settings.AllowDesignChangesToPartiallyCompletedItems[num2])
            {
                int num6 = this.PlanetCount - 1;
                for (int i = 0; i <= num6; i++)
                {
                    Planet planet = this.Planets[i];
                    if (planet.ProductionQueue != null)
                    {
                        foreach (QueueItem item in planet.ProductionQueue)
                        {
                            if (((item.Completion > 0) && ((item.ItemID >= 0x20) & (item.ItemID <= 0x29))) && ((this.Races[num2].StarbaseDesigns[item.ItemID - 0x20] != null) && this.Races[num2].StarbaseDesigns[item.ItemID - 0x20].Dirty))
                            {
                                str = str + "You are not allowed to edit the starbase designs " + this.Races[num2].StarbaseDesigns[item.ItemID - 0x20].Name + " because one is already partially completed at Planet No " + Conversions.ToString((int) (i + 1)) + "\r\n";
                            }
                        }
                    }
                }
            }
            return str;
        }

        public object LoadHSTFile(string Filename)
        {
            byte[] sourceArray = new Decryptor().OpenFile(Filename);
            int num2 = 0;
            do
            {
                int planetID;
                int length = sourceArray[num2 + 0] + ((sourceArray[num2 + 1] & 3) * 0x100);
                double num4 = Conversion.Int((double) (((double) sourceArray[num2 + 1]) / 4.0));
                byte[] destinationArray = new byte[(length - 1) + 1];
                if (length > 0)
                {
                    Array.Copy(sourceArray, num2 + 2, destinationArray, 0, length);
                }
                double num6 = num4;
                switch (num6)
                {
                    case 0.0:
                    case 9.0:
                    case 16.0:
                    case 20.0:
                    case 26.0:
                        break;

                    case 6.0:
                        Race race;
                        this.Races[race.RaceID] = new Race(destinationArray);
                        break;

                    case 8.0:
                    {
                        Header header = new Header(destinationArray);
                        break;
                    }
                    case 13.0:
                    {
                        Planet planet = new Planet(destinationArray);
                        planet.X = this.Planets[planet.PlanetID].X;
                        planet.Y = this.Planets[planet.PlanetID].Y;
                        planet.NameID = this.Planets[planet.PlanetID].NameID;
                        planet.ProductionQueue = null;
                        planetID = planet.PlanetID;
                        break;
                    }
                    case 28.0:
                    {
                        Planet planet2 = this.Planets[planetID];
                        planet2.ProductionQueue = new QueueItem[((int) Math.Round((double) ((((double) destinationArray.Length) / 4.0) - 1.0))) + 1];
                        int num7 = destinationArray.Length - 1;
                        for (int i = 0; i <= num7; i += 4)
                        {
                            byte[] data = new byte[] { destinationArray[i], destinationArray[i + 1], destinationArray[i + 2], destinationArray[i + 3] };
                            QueueItem item = new QueueItem(data);
                            planet2.ProductionQueue[(int) Math.Round((double) (((double) i) / 4.0))] = item;
                        }
                        break;
                    }
                    default:
                        if ((num6 != 30.0) && (num6 != 43.0))
                        {
                            Debug.Print(Conversions.ToString(num4));
                        }
                        break;
                }
                num2 = (num2 + 2) + length;
            }
            while (num2 < sourceArray.Length);
            return 0;
        }

        public int LoadXFile(string filename)
        {
            Decryptor decryptor = new Decryptor();
            int index = -1;
            byte[] sourceArray = decryptor.OpenFile(filename);
            int num3 = 0;
            XFile file = new XFile();
            do
            {
                int length = sourceArray[num3 + 0] + ((sourceArray[num3 + 1] & 3) * 0x100);
                double num5 = Conversion.Int((double) (((double) sourceArray[num3 + 1]) / 4.0));
                byte[] destinationArray = new byte[(length - 1) + 1];
                if (length > 0)
                {
                    Array.Copy(sourceArray, num3 + 2, destinationArray, 0, length);
                }
                double num8 = num5;
                switch (num8)
                {
                    case 0.0:
                    case 9.0:
                        break;

                    case 8.0:
                    {
                        Header header = new Header(destinationArray);
                        index = header.PlayerID;
                        break;
                    }
                    case 27.0:
                    {
                        Design design = new Design(destinationArray, 0x1b);
                        design.Dirty = true;
                        if (design.DesignID < 0x10)
                        {
                            if (design.DeletedDesign)
                            {
                                this.Races[index].ShipDesigns[design.DesignID] = null;
                            }
                            else
                            {
                                this.Races[index].ShipDesigns[design.DesignID] = design;
                            }
                        }
                        else if (design.DeletedDesign)
                        {
                            this.Races[index].StarbaseDesigns[design.DesignID - 0x10] = null;
                        }
                        else
                        {
                            this.Races[index].StarbaseDesigns[design.DesignID - 0x10] = design;
                        }
                        break;
                    }
                    default:
                        if (num8 == 29.0)
                        {
                            int num6 = (destinationArray[0] + (destinationArray[1] * 0x100)) & 0x3ff;
                            this.Planets[num6].ProductionQueue = new QueueItem[((int) Math.Round((double) ((((double) (destinationArray.Length - 2)) / 4.0) - 1.0))) + 1];
                            int num9 = destinationArray.Length - 1;
                            for (int i = 2; i <= num9; i += 4)
                            {
                                byte[] data = new byte[] { destinationArray[i], destinationArray[i + 1], destinationArray[i + 2], destinationArray[i + 3] };
                                QueueItem item = new QueueItem(data);
                                this.Planets[num6].ProductionQueue[(int) Math.Round((double) (((double) (i - 2)) / 4.0))] = item;
                            }
                        }
                        else
                        {
                            Debug.Print(Conversions.ToString(num5));
                        }
                        break;
                }
                num3 = (num3 + 2) + length;
            }
            while (num3 < sourceArray.Length);
            return index;
        }

        public object LoadXYFile(string Filename)
        {
            byte[] buffer = new Decryptor().OpenFile(Filename);
            if (buffer.Length <= 0x54)
            {
                return 1;
            }
            string str = Conversions.ToString(Strings.Chr(buffer[2])) + Conversions.ToString(Strings.Chr(buffer[3])) + Conversions.ToString(Strings.Chr(buffer[4])) + Conversions.ToString(Strings.Chr(buffer[5]));
            this.GameID = ((buffer[6] + (buffer[7] * 0x100)) + (buffer[8] * 0x10000)) + ((buffer[9] * 0x10000) * 0x100);
            uint num6 = (uint) (buffer[10] + (buffer[11] * 0x100));
            uint num5 = (uint) (buffer[12] + (buffer[13] * 0x100));
            uint num4 = (uint) (buffer[14] & 0x1f);
            byte num2 = buffer[0x10];
            byte num3 = buffer[0x11];
            if (num2 != 0)
            {
                return 2;
            }
            this.UniverseSize = buffer[0x18];
            this.Density = buffer[0x1a];
            this.PlayerCount = buffer[0x1c] + (buffer[0x1d] * 0x100);
            this.PlanetCount = buffer[30] + (buffer[0x1f] * 0x100);
            this.StartingPositions = buffer[0x20];
            uint num8 = buffer[0x24];
            if ((num8 & 1L) == 1L)
            {
                this.MaxMinerals = true;
            }
            else
            {
                this.MaxMinerals = false;
            }
            if ((num8 & 2L) == 2L)
            {
                this.SlowerTechAdvances = true;
            }
            else
            {
                this.SlowerTechAdvances = false;
            }
            if ((num8 & 4L) == 4L)
            {
                this.AcceleratedBBS = true;
            }
            else
            {
                this.AcceleratedBBS = false;
            }
            if ((num8 & 8L) == 8L)
            {
                this.Tutorial = true;
            }
            else
            {
                this.Tutorial = false;
            }
            if ((num8 & 0x10L) == 0x10L)
            {
                this.NoRandomEvents = true;
            }
            else
            {
                this.NoRandomEvents = false;
            }
            if ((num8 & 0x20L) == 0x20L)
            {
                this.ComputerPlayersFormAlliances = true;
            }
            else
            {
                this.ComputerPlayersFormAlliances = false;
            }
            if ((num8 & 0x40L) == 0x40L)
            {
                this.PublicPlayerScores = true;
            }
            else
            {
                this.PublicPlayerScores = false;
            }
            if ((num8 & 0x80L) == 0x80L)
            {
                this.GalaxyClumping = true;
            }
            else
            {
                this.GalaxyClumping = false;
            }
            this.GameName = "";
            int index = 0x34;
            do
            {
                if (buffer[index] == 0)
                {
                    break;
                }
                this.GameName = this.GameName + Conversions.ToString(Strings.Chr(buffer[index]));
                index++;
            }
            while (index <= 0x53);
            this.Planets = new Planet[(this.PlanetCount - 1) + 1];
            uint x = 0x3e8;
            int num12 = this.PlanetCount - 1;
            for (int i = 0; i <= num12; i++)
            {
                uint num11 = (uint) (buffer[0x54 + (i * 4)] + (buffer[(0x54 + (i * 4)) + 1] * 0x100));
                num11 += (uint) (buffer[(0x54 + (i * 4)) + 2] * 0x10000);
                num11 += (uint) (buffer[(0x54 + (i * 4)) + 3] * 0x1000000L);
                Planet planet = new Planet();
                planet.PlanetID = i;
                planet.X = (int) (x + (num11 & 0x3ffL));
                x = (uint) planet.X;
                planet.Y = (int) (((long) Math.Round(Conversion.Int((double) (((double) num11) / 1024.0)))) & 0xfffL);
                planet.NameID = (int) Math.Round(Conversion.Int((double) ((((double) num11) / 1024.0) / 4096.0)));
                this.Planets[i] = planet;
            }
            return 0;
        }

        public object xCheckXFile(string Filename)
        {
            string str = "";
            int num = this.LoadXFile(Filename);
            byte[] sourceArray = new Decryptor().OpenFile(Filename);
            int num2 = 0;
            XFile file = new XFile();
            do
            {
                int length = sourceArray[num2 + 0] + ((sourceArray[num2 + 1] & 3) * 0x100);
                double num4 = Conversion.Int((double) (((double) sourceArray[num2 + 1]) / 4.0));
                byte[] destinationArray = new byte[(length - 1) + 1];
                if (length > 0)
                {
                    Array.Copy(sourceArray, num2 + 2, destinationArray, 0, length);
                }
                switch (num4)
                {
                    case 0.0:
                    case 9.0:
                        break;

                    case 8.0:
                    {
                        Header header = new Header(destinationArray);
                        file.AddObject(header);
                        break;
                    }
                    case 27.0:
                    {
                        Design design = new Design(destinationArray, 0x1b);
                        file.AddObject(design);
                        break;
                    }
                    default:
                        Debug.Print(Conversions.ToString(num4));
                        break;
                }
                num2 = (num2 + 2) + length;
            }
            while (num2 < sourceArray.Length);
            Debug.Print("");
            if (!this.Settings.Allow22OrMoreSuperlatinumInASlot[file.PlayerID])
            {
                int index = 0;
                do
                {
                    if (file.Designs[index] != null)
                    {
                        Design design2 = file.Designs[index];
                        foreach (DesignSlot slot in design2.Slots)
                        {
                            if ((slot != null) && (((slot.CategoryID == 8) & (slot.ItemID == 11)) & (slot.Count >= 0x16)))
                            {
                                str = str + "You are not allowed to have 22 Superlatinum in one slot on the " + design2.Name + " design\r\n";
                            }
                        }
                    }
                    index++;
                }
                while (index <= 0x19);
            }
            if (!this.Settings.AllowTenthStarbaseSlotToBeUsed[file.PlayerID] && (file.Designs[0x19] != null))
            {
                str = str + "You are not allowed to use the 10th Starbase design slot\r\n";
            }
            return str;
        }
    }
}

