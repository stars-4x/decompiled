namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class StarsHostEditor : StarsHostEditor._StarsHostEditor
    {
        private Fleet $STATIC$ReadBlock$20511D5108101D5108108$LastFleet;
        public Collection Fleets = new Collection();
        private byte[] hstFile;
        private bool hstLoaded = false;
        private Collection mFiles = new Collection();
        public int[] PlanetIDs = new int[0x401];
        private string xGameName;
        private int xPlanetCount;
        private Collection xPlanets = new Collection();
        private int xPlayerCount;
        private Collection xRaces = new Collection();
        private byte[] xyFile;

        public long Load(string Filename)
        {
            long num3;
            this.xPlanets = new Collection();
            Decryptor decryptor = new Decryptor();
            if (Filename.Substring(Filename.Length - 4).ToUpper() == ".HST")
            {
                Filename = Filename.Substring(0, Filename.Length - 4);
            }
            this.xyFile = decryptor.OpenFile(Filename + ".xy");
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
                Planet item = new Planet(i);
                item.X = (this.xyFile[(0x54 + (i * 4)) + 0] + ((this.xyFile[(0x54 + (i * 4)) + 1] & 3) * 0x100)) + x;
                x = item.X;
                item.y = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 1]) / 4.0)) + ((this.xyFile[(0x54 + (i * 4)) + 2] & 0x3f) * 0x40)));
                item.NameID = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 2]) / 64.0)) + (this.xyFile[(0x54 + (i * 4)) + 3] * 4)));
                this.Planets().Add(item, "ID" + Conversions.ToString(i), null, null);
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
                byte[] buffer2 = decryptor.OpenFile(Filename + ".m" + Conversions.ToString(j));
                this.mFiles.Add(buffer2, null, null, null);
            }
            return num3;
        }

        public Collection Planets()
        {
            return this.xPlanets;
        }

        public Collection Races()
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
                    byte num = Data[0];
                    Race item = new Race();
                    item.RaceData = Data;
                    this.xRaces.Add(item, "ID" + Conversions.ToString(num), null, null);
                    break;
                }
                case 13:
                {
                    int num2 = Data[0] + ((Data[1] & 3) * 0x100);
                    Planet planet = (Planet) this.Planets()["ID" + Conversions.ToString(num2)];
                    planet.PlanetData = Data;
                    break;
                }
                case 0x10:
                {
                    Fleet fleet = new Fleet(Data);
                    int num3 = Data[0] + (Data[1] * 0x100);
                    this.Fleets.Add(fleet, "ID" + Conversions.ToString(num3), null, null);
                    this.$STATIC$ReadBlock$20511D5108101D5108108$LastFleet = fleet;
                    break;
                }
                case 20:
                {
                    Waypoint waypoint = new Waypoint(Data);
                    this.$STATIC$ReadBlock$20511D5108101D5108108$LastFleet.Waypoints.Add(waypoint, null, null, null);
                    break;
                }
            }
            hstPosition = (hstPosition + 2) + Size;
        }

        public long Save(string Filename)
        {
            long num2;
            int length;
            int num16;
            if (Filename.Substring(Filename.Length - 4).ToUpper() == ".HST")
            {
                Filename = Filename.Substring(0, Filename.Length - 4);
            }
            int position = 0;
        Label_0034:
            length = this.hstFile[position + 0] + ((this.hstFile[position + 1] & 3) * 0x100);
            double num15 = Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0));
            switch (num15)
            {
                case 0.0:
                case 8.0:
                    goto Label_0390;

                case 6.0:
                {
                    num16 = position + 2;
                    object right = Operators.AndObject(functions.GetBytes(this.hstFile, ref num16, 2), 15);
                    Race race = (Race) this.xRaces[Operators.ConcatenateObject("ID", right)];
                    functions.DeleteObject(ref this.hstFile, position);
                    functions.InsertObject(ref this.hstFile, 6, race.RaceData, position);
                    length = race.RaceData.Length;
                    goto Label_0390;
                }
                case 13.0:
                {
                    IEnumerator enumerator;
                    num16 = position + 2;
                    object obj3 = Operators.AndObject(functions.GetBytes(this.hstFile, ref num16, 2), 0x3ff);
                    try
                    {
                        enumerator = this.Planets().GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Planet current = (Planet) enumerator.Current;
                            if (Operators.ConditionalCompareObjectEqual(current.PlanetID, obj3, false))
                            {
                                functions.DeleteObject(ref this.hstFile, position);
                                functions.InsertObject(ref this.hstFile, 13, current.PlanetData, position);
                                length = current.PlanetData.Length;
                            }
                        }
                        goto Label_0390;
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    break;
                }
                case 16.0:
                {
                    IEnumerator enumerator2;
                    num16 = position + 2;
                    object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(this.hstFile, ref num16, 2));
                    try
                    {
                        enumerator2 = this.Fleets.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            Fleet fleet = (Fleet) enumerator2.Current;
                            if (Operators.ConditionalCompareObjectEqual(fleet.FleetID + (fleet.OwnerID * 0x200), objectValue, false))
                            {
                                IEnumerator enumerator3;
                                functions.DeleteObject(ref this.hstFile, position);
                                for (int j = (int) Math.Round(Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0))); j == 20; j = (int) Math.Round(Conversion.Int((double) (((double) this.hstFile[position + 1]) / 4.0))))
                                {
                                    functions.DeleteObject(ref this.hstFile, position);
                                }
                                functions.InsertObject(ref this.hstFile, 0x10, fleet.FleetData, position);
                                length = fleet.FleetData.Length;
                                try
                                {
                                    enumerator3 = fleet.Waypoints.GetEnumerator();
                                    while (enumerator3.MoveNext())
                                    {
                                        Waypoint waypoint = (Waypoint) enumerator3.Current;
                                        functions.InsertObject(ref this.hstFile, 20, waypoint.WaypointData, (position + length) + 2);
                                        length = (length + waypoint.WaypointData.Length) + 2;
                                    }
                                }
                                finally
                                {
                                    if (enumerator3 is IDisposable)
                                    {
                                        (enumerator3 as IDisposable).Dispose();
                                    }
                                }
                                goto Label_0390;
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
                    goto Label_0390;
                }
            }
            if (((num15 == 20.0) || (num15 == 26.0)) || ((num15 != 30.0) && (num15 == 43.0)))
            {
            }
        Label_0390:
            position = (position + 2) + length;
            if (position < this.hstFile.Length)
            {
                goto Label_0034;
            }
            Decryptor decryptor = new Decryptor();
            int count = this.mFiles.Count;
            for (int i = 1; i <= count; i++)
            {
                int num8;
                int num10;
                byte[] data = (byte[]) this.mFiles[i];
                int num7 = 0;
            Label_03D6:
                num8 = data[num7 + 0] + ((data[num7 + 1] & 3) * 0x100);
                double num18 = Conversion.Int((double) (((double) data[num7 + 1]) / 4.0));
                switch (num18)
                {
                    case 0.0:
                    case 6.0:
                    case 8.0:
                        goto Label_07DD;

                    case 12.0:
                    {
                        byte[] buffer2 = new byte[] { 
                            0xb0, 13, 0xb1, 0xd9, 120, 9, 220, 0x1a, 0x41, 80, 0xd6, 0x49, 0xad, 0xe8, 0xd4, 0x16, 
                            0xd5, 0x20, 0x31, 0x90, 0xdb, 0x7d, 0xf2, 0xd6, 1, 6, 0xde, 0xdb, 0xd4, 40, 7, 0xd7, 
                            13, 0xc5, 0x16, 0x2a, 0x9f
                         };
                        goto Label_07DD;
                    }
                    default:
                    {
                        if (num18 != 13.0)
                        {
                            goto Label_0639;
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
                Planet planet2 = (Planet) this.Planets()["ID" + Conversions.ToString(num10)];
                functions.DeleteObject(ref data, num7);
                functions.InsertObject(ref data, 13, planet2.PlanetData, num7);
                num8 = planet2.PlanetData.Length;
                goto Label_07DD;
            Label_0639:
                if (num18 == 16.0)
                {
                    IEnumerator enumerator4;
                    int num13 = data[num7 + 2] + (data[num7 + 3] * 0x100);
                    try
                    {
                        enumerator4 = this.Fleets.GetEnumerator();
                        while (enumerator4.MoveNext())
                        {
                            Fleet fleet2 = (Fleet) enumerator4.Current;
                            if ((fleet2.FleetID + (fleet2.OwnerID * 0x200)) == num13)
                            {
                                IEnumerator enumerator5;
                                functions.DeleteObject(ref data, num7);
                                for (int k = (int) Math.Round(Conversion.Int((double) (((double) data[num7 + 1]) / 4.0))); k == 20; k = (int) Math.Round(Conversion.Int((double) (((double) data[num7 + 1]) / 4.0))))
                                {
                                    functions.DeleteObject(ref data, num7);
                                }
                                functions.InsertObject(ref data, 0x10, fleet2.FleetData, num7);
                                num8 = fleet2.FleetData.Length;
                                try
                                {
                                    enumerator5 = fleet2.Waypoints.GetEnumerator();
                                    while (enumerator5.MoveNext())
                                    {
                                        Waypoint waypoint2 = (Waypoint) enumerator5.Current;
                                        functions.InsertObject(ref data, 20, waypoint2.WaypointData, (num7 + num8) + 2);
                                        num8 = (num8 + waypoint2.WaypointData.Length) + 2;
                                    }
                                }
                                finally
                                {
                                    if (enumerator5 is IDisposable)
                                    {
                                        (enumerator5 as IDisposable).Dispose();
                                    }
                                }
                                goto Label_07DD;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator4 is IDisposable)
                        {
                            (enumerator4 as IDisposable).Dispose();
                        }
                    }
                }
                else if (((num18 == 20.0) || (num18 == 26.0)) || ((num18 != 30.0) && (num18 == 43.0)))
                {
                }
            Label_07DD:
                num7 = (num7 + 2) + num8;
                if (num7 < data.Length)
                {
                    goto Label_03D6;
                }
                decryptor.SaveFile(data, Filename + ".m" + Conversions.ToString(i));
            }
            decryptor.SaveFile(this.hstFile, Filename + ".hst");
            return num2;
        }

        public void SwapPlanets(int Planet1ID, int Planet2ID)
        {
            IEnumerator enumerator;
            IEnumerator enumerator2;
            Planet planet = (Planet) this.Planets()[Planet1ID + 1];
            Planet planet2 = (Planet) this.Planets()[Planet2ID + 1];
            Planet planet3 = (Planet) this.Planets()[Planet1ID + 1];
            byte[] planetData = planet3.PlanetData;
            NewLateBinding.LateSetComplex(this.Planets()[Planet1ID + 1], null, "PlanetData", new object[] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.Planets()[Planet2ID + 1], null, "PlanetData", new object[0], null, null, null)) }, null, null, false, true);
            NewLateBinding.LateSetComplex(this.Planets()[Planet2ID + 1], null, "PlanetData", new object[] { planetData }, null, null, false, true);
            NewLateBinding.LateSetComplex(this.Planets()[Planet1ID + 1], null, "PlanetID", new object[] { Planet1ID }, null, null, false, true);
            NewLateBinding.LateSetComplex(this.Planets()[Planet2ID + 1], null, "PlanetID", new object[] { Planet2ID }, null, null, false, true);
            this.PlanetIDs[Planet1ID] = Planet2ID;
            this.PlanetIDs[Planet2ID] = Planet1ID;
            try
            {
                enumerator = this.Races().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Race current = (Race) enumerator.Current;
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
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            try
            {
                enumerator2 = this.Fleets.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    Fleet fleet = (Fleet) enumerator2.Current;
                    if ((fleet.X == planet.X) & (fleet.Y == planet.y))
                    {
                        IEnumerator enumerator3;
                        fleet.X = planet2.X;
                        fleet.Y = planet2.y;
                        fleet.PositionObjectID = planet2.PlanetID;
                        try
                        {
                            enumerator3 = fleet.Waypoints.GetEnumerator();
                            while (enumerator3.MoveNext())
                            {
                                Waypoint waypoint = (Waypoint) enumerator3.Current;
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
                            if (enumerator3 is IDisposable)
                            {
                                (enumerator3 as IDisposable).Dispose();
                            }
                        }
                    }
                    else if ((fleet.X == planet2.X) & (fleet.Y == planet2.y))
                    {
                        IEnumerator enumerator4;
                        fleet.X = planet.X;
                        fleet.Y = planet.y;
                        fleet.PositionObjectID = planet.PlanetID;
                        try
                        {
                            enumerator4 = fleet.Waypoints.GetEnumerator();
                            while (enumerator4.MoveNext())
                            {
                                Waypoint waypoint2 = (Waypoint) enumerator4.Current;
                                if ((waypoint2.X == planet2.X) & (waypoint2.Y == planet2.y))
                                {
                                    waypoint2.X = planet.X;
                                    waypoint2.Y = planet.y;
                                    waypoint2.PositionObjectID = planet.PlanetID;
                                }
                            }
                            continue;
                        }
                        finally
                        {
                            if (enumerator4 is IDisposable)
                            {
                                (enumerator4 as IDisposable).Dispose();
                            }
                        }
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

        [DispId(6)]
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
            [DispId(1)]
            long Load(string Filename);
            [DispId(4)]
            Collection Planets();
            [DispId(5)]
            Collection Races();
            [DispId(3)]
            long Save(string Filename);
            [DispId(2)]
            void SwapPlanets(int Planet1ID, int Planet2ID);

            [DispId(6)]
            object PlanetCount { [DispId(6)] get; }
        }
    }
}

