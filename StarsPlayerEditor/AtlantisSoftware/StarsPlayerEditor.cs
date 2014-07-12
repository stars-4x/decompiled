namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class StarsPlayerEditor : StarsPlayerEditor._StarsPlayerEditor
    {
        private byte[] hFile;
        private bool hstLoaded = false;
        private byte[] mFile;
        private int PlayerNo;
        private int Type43CountPos = -1;
        public Collection xEnemyFleets = new Collection();
        public Collection xErrors = new Collection();
        public Collection xFleets = new Collection();
        private string xGameName;
        public Collection xMinefields = new Collection();
        public Collection xMTs = new Collection();
        private int xPlanetCount;
        private Collection xPlanets = new Collection();
        private int xPlayerCount;
        public Collection xSalvage = new Collection();
        public Collection xScores = new Collection();
        public Collection xShipDesigns = new Collection();
        public Collection xStarbaseDesigns = new Collection();
        private int xTurnNo;
        public Collection xWormholes = new Collection();
        private byte[] xyFile;

        public Collection Enemyfleets()
        {
            return this.xEnemyFleets;
        }

        public Collection Errors()
        {
            return this.xErrors;
        }

        public Collection Fleets()
        {
            return this.xFleets;
        }

        public long Load(string Filename)
        {
            long num2;
            this.xPlanets = new Collection();
            Decryptor decryptor = new Decryptor();
            int num4 = Strings.InStrRev(Filename, ".m", -1, CompareMethod.Text);
            if (num4 > 0)
            {
                this.PlayerNo = Conversions.ToInteger(Filename.Substring(num4 + 1));
                Filename = Filename.Substring(0, num4 - 1);
            }
            else
            {
                Interaction.MsgBox("A valid .m file must be entered", MsgBoxStyle.ApplicationModal, null);
                return num2;
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
            int num9 = this.PlanetCount - 1;
            for (int i = 0; i <= num9; i++)
            {
                Planet item = new Planet(i);
                item.X = (this.xyFile[(0x54 + (i * 4)) + 0] + ((this.xyFile[(0x54 + (i * 4)) + 1] & 3) * 0x100)) + x;
                x = item.X;
                item.Y = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 1]) / 4.0)) + ((this.xyFile[(0x54 + (i * 4)) + 2] & 0x3f) * 0x40)));
                item.NameID = (int) Math.Round((double) (Conversion.Int((double) (((double) this.xyFile[(0x54 + (i * 4)) + 2]) / 64.0)) + (this.xyFile[(0x54 + (i * 4)) + 3] * 4)));
                this.Planets().Add(item, "ID" + Conversions.ToString(i), null, null);
            }
            this.mFile = decryptor.OpenFile(Filename + ".m" + Conversions.ToString(this.PlayerNo));
            this.hstLoaded = true;
            int hstPosition = 0;
            do
            {
                int num7;
                int num8;
                byte[] data = new byte[0x401];
                this.ReadBlock(this.mFile, ref hstPosition, ref data, ref num8, ref num7);
            }
            while (hstPosition != this.mFile.Length);
            return num2;
        }

        public Collection MineFields()
        {
            return this.xMinefields;
        }

        public Collection MTs()
        {
            return this.xMTs;
        }

        public Collection Planets()
        {
            return this.xPlanets;
        }

        private void ReadBlock(byte[] file, ref int hstPosition, ref byte[] Data, ref int type, ref int Size)
        {
            Size = file[hstPosition + 0] + ((file[hstPosition + 1] & 3) * 0x100);
            type = (int) Math.Round(Conversion.Int((double) (((double) file[hstPosition + 1]) / 4.0)));
            try
            {
                Design design;
                int num3;
                Data = new byte[(Size - 1) + 1];
                if (Size > 0)
                {
                    Array.Copy(file, hstPosition + 2, Data, 0, Size);
                }
                switch (type)
                {
                    case 8:
                    {
                        int start = 12;
                        this.xTurnNo = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
                        goto Label_0375;
                    }
                    case 13:
                    {
                        int num = Data[0] + ((Data[1] & 3) * 0x100);
                        Planet planet = (Planet) this.Planets()["ID" + Conversions.ToString(num)];
                        planet.PlanetData = Data;
                        goto Label_0375;
                    }
                    case 0x10:
                    {
                        Fleet item = new Fleet(Data);
                        this.Fleets().Add(item, null, null, null);
                        goto Label_0375;
                    }
                    case 0x11:
                    {
                        EnemyFleet fleet2 = new EnemyFleet(Data);
                        this.Enemyfleets().Add(fleet2, null, null, null);
                        goto Label_0375;
                    }
                    case 0x1a:
                        design = new Design(Data);
                        if (!design.Starbase)
                        {
                            break;
                        }
                        this.StarbaseDesigns().Add(design, null, null, null);
                        goto Label_0375;

                    case 0x2b:
                    {
                        int num2 = 0;
                        if (this.Type43CountPos != -1)
                        {
                            goto Label_01FC;
                        }
                        this.Type43CountPos = Conversions.ToInteger(functions.GetBytes(Data, ref num2, 2));
                        goto Label_0375;
                    }
                    case 0x2d:
                    {
                        Score score = new Score(Data);
                        score.YearNo = this.TurnNo + 0x960;
                        this.Scores().Add(score, null, null, null);
                        goto Label_0375;
                    }
                    default:
                        goto Label_0375;
                }
                this.ShipDesigns().Add(design, null, null, null);
                goto Label_0375;
            Label_01FC:
                num3 = Data[0] + (Data[1] * 0x100);
                if ((num3 >= 0) & (num3 <= 0x1fff))
                {
                    Minefield minefield = new Minefield(Data);
                    this.MineFields().Add(minefield, null, null, null);
                }
                if ((num3 >= 0x2000) & (num3 <= 0x4000))
                {
                    AtlantisSoftware.Salvage salvage = new AtlantisSoftware.Salvage(Data);
                    this.Salvage().Add(salvage, null, null, null);
                }
                if ((num3 >= 0x4000) & (num3 <= 0x5f9f))
                {
                    Wormhole wormhole = new Wormhole(Data);
                    this.WormHoles().Add(wormhole, null, null, null);
                }
                if ((num3 >= 0x6000) & (num3 <= 0x6fff))
                {
                    MT mt = new MT(Data);
                    this.MTs().Add(mt, null, null, null);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                this.Errors().Add("Error decoding block in .m file at file position:" + Conversions.ToString((int) hstPosition) + ", type:" + Conversions.ToString((int) type) + ", Size:" + Conversions.ToString((int) Size), null, null, null);
                ProjectData.ClearProjectError();
            }
        Label_0375:
            hstPosition = (hstPosition + 2) + Size;
        }

        public Collection Salvage()
        {
            return this.xSalvage;
        }

        public Collection Scores()
        {
            return this.xScores;
        }

        public Collection ShipDesigns()
        {
            return this.xShipDesigns;
        }

        public Collection StarbaseDesigns()
        {
            return this.xStarbaseDesigns;
        }

        public Collection WormHoles()
        {
            return this.xWormholes;
        }

        [DispId(15)]
        public string AtlantisSoftware.StarsPlayerEditor._StarsPlayerEditor.GameName
        {
            get
            {
                return this.xGameName;
            }
        }

        [DispId(13)]
        public int AtlantisSoftware.StarsPlayerEditor._StarsPlayerEditor.PlanetCount
        {
            get
            {
                return this.xPlanetCount;
            }
        }

        [DispId(14)]
        public int AtlantisSoftware.StarsPlayerEditor._StarsPlayerEditor.PlayerCount
        {
            get
            {
                return this.xPlayerCount;
            }
        }

        [DispId(0x10)]
        public int AtlantisSoftware.StarsPlayerEditor._StarsPlayerEditor.TurnNo
        {
            get
            {
                return this.xTurnNo;
            }
        }

        public string GameName
        {
            get
            {
                return this.xGameName;
            }
        }

        public int PlanetCount
        {
            get
            {
                return this.xPlanetCount;
            }
        }

        public int PlayerCount
        {
            get
            {
                return this.xPlayerCount;
            }
        }

        public int TurnNo
        {
            get
            {
                return this.xTurnNo;
            }
        }

        [ComVisible(true)]
        public interface _StarsPlayerEditor
        {
            [DispId(7)]
            Collection Enemyfleets();
            [DispId(11)]
            Collection Errors();
            [DispId(10)]
            Collection Fleets();
            [DispId(1)]
            long Load(string Filename);
            [DispId(5)]
            Collection MineFields();
            [DispId(6)]
            Collection MTs();
            [DispId(2)]
            Collection Planets();
            [DispId(12)]
            Collection Salvage();
            [DispId(3)]
            Collection Scores();
            [DispId(9)]
            Collection ShipDesigns();
            [DispId(8)]
            Collection StarbaseDesigns();
            [DispId(4)]
            Collection WormHoles();

            [DispId(15)]
            string GameName { [DispId(15)] get; }

            [DispId(13)]
            int PlanetCount { [DispId(13)] get; }

            [DispId(14)]
            int PlayerCount { [DispId(14)] get; }

            [DispId(0x10)]
            int TurnNo { [DispId(0x10)] get; }
        }
    }
}

