namespace Stars_Hst_Creator
{
    using AtlantisSoftware;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml;

    [DesignerGenerated]
    public class StarsHSTCreator : Form
    {
        [AccessedThroughProperty("btnCreateHST")]
        private Button _btnCreateHST;
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Button3")]
        private Button _Button3;
        [AccessedThroughProperty("cmbCategoryID")]
        private ComboBox _cmbCategoryID;
        [AccessedThroughProperty("cmbGamesList")]
        private ComboBox _cmbGamesList;
        [AccessedThroughProperty("cmbHull")]
        private ComboBox _cmbHull;
        [AccessedThroughProperty("cmbItem")]
        private ComboBox _cmbItem;
        [AccessedThroughProperty("cmbRaces")]
        private ComboBox _cmbRaces;
        [AccessedThroughProperty("cmbShipDesigns")]
        private ComboBox _cmbShipDesigns;
        [AccessedThroughProperty("cmbShipslot")]
        private ComboBox _cmbShipslot;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
        [AccessedThroughProperty("Label12")]
        private Label _Label12;
        [AccessedThroughProperty("Label13")]
        private Label _Label13;
        [AccessedThroughProperty("Label14")]
        private Label _Label14;
        [AccessedThroughProperty("Label15")]
        private Label _Label15;
        [AccessedThroughProperty("Label16")]
        private Label _Label16;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("txtBiology")]
        private TextBox _txtBiology;
        [AccessedThroughProperty("txtConstruction")]
        private TextBox _txtConstruction;
        [AccessedThroughProperty("txtElectronics")]
        private TextBox _txtElectronics;
        [AccessedThroughProperty("txtEnergy")]
        private TextBox _txtEnergy;
        [AccessedThroughProperty("txtPropulsion")]
        private TextBox _txtPropulsion;
        [AccessedThroughProperty("txtRaceFile")]
        private TextBox _txtRaceFile;
        [AccessedThroughProperty("txtWeapons")]
        private TextBox _txtWeapons;
        private string[] Categories;
        private IContainer components;
        private XmlDocument Gamedefs;
        private XmlNode GamesElement;
        private string[] HFiles;
        private string HSTFile;
        private string[] Items;
        private string[] MFiles;
        private string[] PFiles;
        private object[,] Players;
        private StarsHostEditor SHE;
        private Design[] ShipDesigns;
        private string[,] ShipSlots;
        private string XYFile;

        public StarsHSTCreator()
        {
            base.Load += new EventHandler(this.Form1_Load);
            this.Gamedefs = new XmlDocument();
            this.ShipDesigns = new Design[0x1a0];
            this.Players = new object[0x10, 7];
            this.ShipSlots = new string[0x25, 2];
            this.Items = new string[13];
            this.Categories = new string[] { "", "Engines", "Scanners", "Shields", "Armor", "Beam Weapons", "Torpedoes", "Bombs", "Mining Robots", "Mine Layers", "Orbital", "Planetary?", "Electrical", "Mechanical" };
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int num15;
            try
            {
                object obj2;
                ProjectData.ClearProjectError();
                int num14 = 2;
                if (this.cmbGamesList.SelectedIndex >= 0)
                {
                    obj2 = "Error creating StarHostEditorObject";
                    this.SHE = new StarsHostEditor();
                    obj2 = "Error processing .xy file";
                    this.SHE.CreateHST(this.XYFile);
                    obj2 = "Error processing Race file";
                    int num6 = this.SHE.xPlayerCount - 1;
                    for (int i = 0; i <= num6; i++)
                    {
                        if (!Operators.ConditionalCompareObjectEqual(this.Players[i, 0], "", false))
                        {
                            obj2 = "Error importing Race file for player " + Conversions.ToString((int) (i + 1));
                            this.SHE.ImportRaceFile(Conversions.ToString(this.Players[i, 0]), i + 1);
                        }
                        obj2 = "Error processing Race file for player " + Conversions.ToString((int) (i + 1));
                        Race race = (Race) NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { i }, null);
                        race.xEnergyLevel = Conversions.ToInteger(this.Players[i, 1]);
                        race.xWeaponsLevel = Conversions.ToInteger(this.Players[i, 2]);
                        race.xPropulsionLevel = Conversions.ToInteger(this.Players[i, 3]);
                        race.xConstructionLevel = Conversions.ToInteger(this.Players[i, 4]);
                        race.xElectronicsLevel = Conversions.ToInteger(this.Players[i, 5]);
                        race.xBiologyLevel = Conversions.ToInteger(this.Players[i, 6]);
                    }
                    if (this.HFiles != null)
                    {
                        foreach (string str in this.HFiles)
                        {
                            obj2 = "Error processing H File (" + str + ")";
                            this.SHE.ImportMFile(str);
                        }
                    }
                    if (this.MFiles != null)
                    {
                        foreach (string str2 in this.MFiles)
                        {
                            obj2 = "Error processing M File (" + str2 + ")";
                            this.SHE.ImportMFile(str2);
                        }
                    }
                    if (this.PFiles != null)
                    {
                        foreach (string str3 in this.PFiles)
                        {
                            obj2 = "Error processing P File (" + str3 + ")";
                            this.SHE.ImportPFile(str3);
                        }
                    }
                    if (this.HFiles != null)
                    {
                        foreach (string str4 in this.HFiles)
                        {
                            obj2 = "Error processing H File (" + str4 + ")";
                            this.SHE.ImportMFile(str4);
                        }
                    }
                    if (this.MFiles != null)
                    {
                        foreach (string str5 in this.MFiles)
                        {
                            obj2 = "Error processing M File (" + str5 + ")";
                            this.SHE.ImportMFile(str5);
                        }
                    }
                    obj2 = "Error processing ship design changes";
                    int num2 = 0;
                    do
                    {
                        obj2 = "Error processing ship design changes for player " + Conversions.ToString((int) (num2 + 1));
                        int num3 = 0;
                        do
                        {
                            obj2 = "Error processing ship design for slot " + Conversions.ToString((int) (num3 + 1)) + " changes for player " + Conversions.ToString((int) (num2 + 1));
                            if (this.ShipDesigns[(num2 * 0x1a) + num3] != null)
                            {
                                Design design = this.ShipDesigns[(num2 * 0x1a) + num3];
                                NewLateBinding.LateSetComplex(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { num2 }, null), null, "xshipdesigns", new object[] { num3, design }, null, null, false, true);
                            }
                            num3++;
                        }
                        while (num3 <= 15);
                        num2++;
                    }
                    while (num2 <= 15);
                    obj2 = "Error processing starbase design changes";
                    int num4 = 0;
                    do
                    {
                        obj2 = "Error processing starbase design changes for player " + Conversions.ToString((int) (num4 + 1));
                        int num5 = 0;
                        do
                        {
                            obj2 = "Error processing starbase design for slot " + Conversions.ToString((int) (num5 + 1)) + " changes for player " + Conversions.ToString((int) (num4 + 1));
                            if (this.ShipDesigns[((num4 * 0x1a) + 0x10) + num5] != null)
                            {
                                Design design2 = this.ShipDesigns[((num4 * 0x1a) + 0x10) + num5];
                                NewLateBinding.LateSetComplex(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { num4 }, null), null, "xstarbasedesigns", new object[] { num5, design2 }, null, null, false, true);
                            }
                            num5++;
                        }
                        while (num5 <= 9);
                        num4++;
                    }
                    while (num4 <= 15);
                    obj2 = "Error checking for planets with starbases you no longer have designs for";
                    foreach (Planet planet in this.SHE.Planets())
                    {
                        if (((planet != null) && (planet.StarbaseSlotID >= 0)) && ((planet.OwnerID >= 0) & (planet.OwnerID <= 15)))
                        {
                            Race race2 = (Race) NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { planet.OwnerID }, null);
                            if (race2.xStarbaseDesigns[planet.StarbaseSlotID] == null)
                            {
                                planet.StarbaseSlotID = -1;
                            }
                        }
                    }
                    obj2 = "Error checking for AR planets without starbases";
                    IEnumerator enumerator = ((IEnumerable) this.SHE.Races()).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Race current = (Race) enumerator.Current;
                        if ((current != null) && (current.xPRT == 8))
                        {
                            if (current.xStarbaseDesigns[0] == null)
                            {
                                Design design3 = new Design();
                                design3.xShipHullID = 0x20;
                                current.xStarbaseDesigns[0] = design3;
                            }
                            foreach (Planet planet2 in this.SHE.Planets())
                            {
                                if (((planet2 != null) && (planet2.OwnerID == current.RaceID)) && (planet2.StarbaseSlotID < 0))
                                {
                                    planet2.StarbaseSlotID = 0;
                                }
                            }
                        }
                    }
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                    obj2 = "Error saving HST file or associated m files";
                    this.SHE.SaveHST(this.HSTFile);
                    Interaction.MsgBox("Complete", MsgBoxStyle.ApplicationModal, null);
                }
                else
                {
                    Interaction.MsgBox("You have not selected the game to create a .hst for", MsgBoxStyle.ApplicationModal, null);
                }
                goto Label_06A4;
            Label_064F:
                Interaction.MsgBox(RuntimeHelpers.GetObjectValue(obj2), MsgBoxStyle.ApplicationModal, null);
                goto Label_06A4;
            Label_065F:
                num15 = -1;
                switch (num14)
                {
                    case 0:
                    case 1:
                        goto Label_0699;

                    case 2:
                        goto Label_064F;
                }
            }
            catch (object obj1) when (?)
            {
                ProjectData.SetProjectError((Exception) obj1);
                goto Label_065F;
            }
        Label_0699:
            throw ProjectData.CreateProjectError(-2146828237);
        Label_06A4:
            if (num15 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            object obj4;
            object obj7;
            int right = 0;
            int num3 = 0;
            int num2 = 0;
            StreamWriter writer = File.CreateText(@"c:\stars\mttest\mttest.txt");
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj4, 100, 100.999, 0.001, ref obj7, ref obj4))
            {
                do
                {
                    object instance = new StarsHostEditor();
                    foreach (string str in Strings.Split("hst,m1,x1,xy", ",", -1, CompareMethod.Binary))
                    {
                        File.Copy(@"c:\stars\mttest\original\game." + str, @"c:\stars\mttest\game." + str, true);
                    }
                    NewLateBinding.LateCall(instance, null, "load", new object[] { @"c:\stars\mttest\game.hst" }, null, null, null, true);
                    Race race = (Race) NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, null, "races", new object[0], null, null, null)), new object[] { 0 }, null);
                    race.xMTItemBitmap = 0;
                    NewLateBinding.LateCall(instance, null, "save", new object[] { @"c:\stars\mttest\game.hst" }, null, null, null, true);
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.Arguments = @"-g c:\stars\mttest\game.hst";
                    startInfo.FileName = @"c:\stars\starsjrc4.exe";
                    startInfo.WorkingDirectory = @"c:\stars\mttest";
                    startInfo.ErrorDialog = true;
                    startInfo.CreateNoWindow = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(startInfo).WaitForExit(0xea60);
                    StarsHostEditor editor = new StarsHostEditor();
                    editor.Load(@"c:\stars\mttest\game.hst");
                    Race race2 = (Race) NewLateBinding.LateIndexGet(editor.Races(), new object[] { 0 }, null);
                    int left = ((((race2.xEnergyLevel + race2.xWeaponsLevel) + race2.xPropulsionLevel) + race2.xConstructionLevel) + race2.xElectronicsLevel) + race2.xBiologyLevel;
                    num2 |= race2.xMTItemBitmap;
                    writer.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, ","), Operators.SubtractObject(left, Conversion.Int(RuntimeHelpers.GetObjectValue(obj4)))), ","), race2.xMTItemBitmap));
                    if (race2.xMTItemBitmap != 0)
                    {
                        right++;
                    }
                    num3 = Conversions.ToInteger(Operators.SubtractObject(num3 + left, Conversion.Int(RuntimeHelpers.GetObjectValue(obj4))));
                    this.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.DivideObject(Conversion.Int(Operators.MultiplyObject(obj4, 0x3e8)), 0x3e8), ","), Operators.SubtractObject(left, Conversion.Int(RuntimeHelpers.GetObjectValue(obj4)))), ","), race2.xMTItemBitmap), ",TL"), num3), ",MTc"), right), ",MTi"), num2));
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj4, obj7, ref obj4));
            }
            writer.Close();
            Interaction.MsgBox("Done", MsgBoxStyle.ApplicationModal, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.cmbRaces.SelectedIndex >= 0)
            {
                new DesignEditor(this.cmbRaces.SelectedIndex, ref this.SHE).ShowDialog();
            }
            else
            {
                Interaction.MsgBox("You have not selected a race to edit the designs for", MsgBoxStyle.ApplicationModal, null);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StarsHostEditor editor = new StarsHostEditor();
            editor.Load(@"C:\openwar\Files\game.hst");
            editor.SwapPlanets(0x13, 0x16);
            editor.SwapPlanets(0x130, 40);
            editor.SwapPlanets(0x14e, 0x3b);
            editor.SwapPlanets(0x149, 0x2a);
            editor.SwapPlanets(0x8f, 0x131);
            editor.SwapPlanets(0x30, 320);
            editor.SwapPlanets(0xf5, 0x151);
            editor.SwapPlanets(0x13d, 0x129);
            editor.SwapPlanets(0x156, 10);
            editor.SwapPlanets(0x9a, 0x11);
            editor.SwapPlanets(0xf3, 30);
            editor.SwapPlanets(0x152, 0x2d);
            editor.SwapPlanets(0xc6, 0x160);
            editor.SwapPlanets(0x54, 0x15b);
            editor.SwapPlanets(50, 0x141);
            editor.SwapPlanets(11, 0x14b);
            editor.SaveHST(@"c:\openwar\files\game2.hst");
            editor.Save(@"C:\openwar\Files\game.hst", false);
            Interaction.Beep();
        }

        private void cmbCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Design design = this.ShipDesigns[(this.cmbRaces.SelectedIndex * 0x1a) + this.cmbShipDesigns.SelectedIndex];
            int xItemID = design.Slots[this.cmbShipslot.SelectedIndex].xItemID;
            int xItemCategory = design.Slots[this.cmbShipslot.SelectedIndex].xItemCategory;
            int xItemCount = design.Slots[this.cmbShipslot.SelectedIndex].xItemCount;
            if (design != null)
            {
                xItemID = design.Slots[this.cmbShipslot.SelectedIndex].xItemID;
                xItemCategory = design.Slots[this.cmbShipslot.SelectedIndex].xItemCategory;
                xItemCount = design.Slots[this.cmbShipslot.SelectedIndex].xItemCount;
            }
            this.cmbItem.Items.Clear();
            this.cmbItem.Items.Add("");
            if (this.cmbHull.SelectedIndex >= 0)
            {
                string str = Strings.Split(this.ShipSlots[this.cmbHull.SelectedIndex, 1], ",", -1, CompareMethod.Binary)[this.cmbShipslot.SelectedIndex];
                int num4 = 0;
                int index = 0;
                do
                {
                    if ((((long) Math.Round(Math.Pow(2.0, (double) index))) & Conversions.ToLong(str)) != 0L)
                    {
                        foreach (string str2 in Strings.Split(this.Items[index], ",", -1, CompareMethod.Binary))
                        {
                            this.cmbItem.Items.Add(str2);
                            num4++;
                        }
                    }
                    index++;
                }
                while (index <= 12);
            }
            if (design != null)
            {
                int num6 = design.Slots[this.cmbShipslot.SelectedIndex].xItemCategory;
                int num7 = design.Slots[this.cmbShipslot.SelectedIndex].xItemCount;
                if (num6 == 0)
                {
                    this.cmbItem.SelectedIndex = 0;
                }
                else
                {
                    this.cmbItem.SelectedIndex = design.Slots[this.cmbShipslot.SelectedIndex].xItemID + 1;
                }
            }
        }

        private void cmbGamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj2;
            this.cmbRaces.SelectedIndex = 0;
            this.PFiles = null;
            this.HFiles = null;
            this.MFiles = null;
            this.ShipDesigns = new Design[0x1a0];
            this.SHE = new StarsHostEditor();
            if (this.cmbGamesList.SelectedIndex >= 0)
            {
                IEnumerator enumerator;
                obj2 = "Error decoding xml file";
                int num2 = 0;
                do
                {
                    this.Players[num2, 0] = "";
                    this.Players[num2, 1] = 0x1a;
                    this.Players[num2, 2] = 0x1a;
                    this.Players[num2, 3] = 0x1a;
                    this.Players[num2, 4] = 0x1a;
                    this.Players[num2, 5] = 0x1a;
                    this.Players[num2, 6] = 0x1a;
                    num2++;
                }
                while (num2 <= 15);
                int selectedIndex = this.cmbGamesList.SelectedIndex;
                try
                {
                    enumerator = this.GamesElement.ChildNodes[selectedIndex].GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode current = (XmlNode) enumerator.Current;
                        string str8 = Strings.UCase(current.Name);
                        if (str8 == "XYFILE")
                        {
                            obj2 = "Error Processing xml file for XYFile";
                            this.XYFile = current.Attributes["file"].Value;
                        }
                        else
                        {
                            switch (str8)
                            {
                                case "HSTFILE":
                                    obj2 = "Error Processing xml file for HSTFile";
                                    this.HSTFile = current.Attributes["file"].Value;
                                    break;

                                case "PLAYER":
                                {
                                    IEnumerator enumerator2;
                                    obj2 = "Error Processing xml file for Player definition";
                                    string str = current.Attributes["no"].Value;
                                    try
                                    {
                                        enumerator2 = current.ChildNodes.GetEnumerator();
                                        while (enumerator2.MoveNext())
                                        {
                                            XmlNode node2 = (XmlNode) enumerator2.Current;
                                            switch (Strings.UCase(node2.Name))
                                            {
                                                case "RACEFILE":
                                                {
                                                    obj2 = "Error Processing xml file for Race file for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 0] = node2.Attributes["file"].Value;
                                                    continue;
                                                }
                                                case "ENERGY":
                                                {
                                                    obj2 = "Error Processing xml file for Energy Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 1] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "WEAPONS":
                                                {
                                                    obj2 = "Error Processing xml file for Weapons Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 2] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "PROPULSION":
                                                {
                                                    obj2 = "Error Processing xml file for Propulsion Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 3] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "CONSTRUCTION":
                                                {
                                                    obj2 = "Error Processing xml file for Construction Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 4] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "ELECTRONICS":
                                                {
                                                    obj2 = "Error Processing xml file for Electronics Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 5] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "BIOLOGY":
                                                {
                                                    obj2 = "Error Processing xml file for Biology Level for player " + str;
                                                    this.Players[(int) Math.Round((double) (Conversions.ToDouble(str) - 1.0)), 6] = node2.Attributes["value"].Value;
                                                    continue;
                                                }
                                                case "SHIPDESIGN":
                                                {
                                                    IEnumerator enumerator3;
                                                    obj2 = "Error Processing xml file for Ship Design for player " + str;
                                                    string str2 = node2.Attributes["value"].Value;
                                                    string str3 = node2.Attributes["slots"].Value;
                                                    Design design = new Design();
                                                    design.xDesignID = (int) Math.Round((double) (Conversions.ToDouble(str2) - 1.0));
                                                    design.Slots = new DesignSlot[((int) Math.Round((double) (Conversions.ToDouble(str3) - 1.0))) + 1];
                                                    try
                                                    {
                                                        enumerator3 = node2.ChildNodes.GetEnumerator();
                                                        while (enumerator3.MoveNext())
                                                        {
                                                            XmlNode node3 = (XmlNode) enumerator3.Current;
                                                            string str10 = Strings.UCase(node3.Name);
                                                            if (str10 == "SLOT")
                                                            {
                                                                string str4 = node3.Attributes["no"].Value;
                                                                DesignSlot slot = new DesignSlot();
                                                                slot.xItemCategory = Conversions.ToInteger(node3.Attributes["categoryid"].Value);
                                                                slot.xItemID = Conversions.ToInteger(node3.Attributes["itemid"].Value);
                                                                slot.xItemCount = Conversions.ToInteger(node3.Attributes["itemcount"].Value);
                                                                design.Slots[(int) Math.Round((double) (Conversions.ToDouble(str4) - 1.0))] = slot;
                                                            }
                                                            else
                                                            {
                                                                if (str10 == "HULL")
                                                                {
                                                                    design.xShipHullID = Conversions.ToInteger(node3.Attributes["value"].Value);
                                                                    continue;
                                                                }
                                                                if (str10 == "NAME")
                                                                {
                                                                    design.xName = node3.Attributes["value"].Value;
                                                                }
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
                                                    this.ShipDesigns[(int) Math.Round((double) ((((Conversions.ToDouble(str) - 1.0) * 26.0) + Conversions.ToDouble(str2)) - 1.0))] = design;
                                                    continue;
                                                }
                                                case "STARBASEDESIGN":
                                                {
                                                    IEnumerator enumerator4;
                                                    obj2 = "Error Processing xml file for Starbase Design for player " + str;
                                                    string str5 = node2.Attributes["value"].Value;
                                                    string str6 = node2.Attributes["slots"].Value;
                                                    Design design2 = new Design();
                                                    design2.xDesignID = (int) Math.Round((double) (Conversions.ToDouble(str5) - 1.0));
                                                    design2.Slots = new DesignSlot[((int) Math.Round((double) (Conversions.ToDouble(str6) - 1.0))) + 1];
                                                    try
                                                    {
                                                        enumerator4 = node2.ChildNodes.GetEnumerator();
                                                        while (enumerator4.MoveNext())
                                                        {
                                                            XmlNode node4 = (XmlNode) enumerator4.Current;
                                                            string str11 = Strings.UCase(node4.Name);
                                                            if (str11 == "SLOT")
                                                            {
                                                                string str7 = node4.Attributes["no"].Value;
                                                                DesignSlot slot2 = new DesignSlot();
                                                                slot2.xItemCategory = Conversions.ToInteger(node4.Attributes["categoryid"].Value);
                                                                slot2.xItemID = Conversions.ToInteger(node4.Attributes["itemid"].Value);
                                                                slot2.xItemCount = Conversions.ToInteger(node4.Attributes["itemcount"].Value);
                                                                design2.Slots[(int) Math.Round((double) (Conversions.ToDouble(str7) - 1.0))] = slot2;
                                                            }
                                                            else
                                                            {
                                                                if (str11 == "HULL")
                                                                {
                                                                    design2.xShipHullID = Conversions.ToInteger(node4.Attributes["value"].Value);
                                                                    continue;
                                                                }
                                                                if (str11 == "NAME")
                                                                {
                                                                    design2.xName = node4.Attributes["value"].Value;
                                                                }
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
                                                    this.ShipDesigns[(int) Math.Round((double) (((((Conversions.ToDouble(str) - 1.0) * 26.0) + 16.0) + Conversions.ToDouble(str5)) - 1.0))] = design2;
                                                    break;
                                                }
                                            }
                                        }
                                        continue;
                                    }
                                    finally
                                    {
                                        if (enumerator2 is IDisposable)
                                        {
                                            (enumerator2 as IDisposable).Dispose();
                                        }
                                    }
                                    break;
                                }
                                case "MFILE":
                                {
                                    obj2 = "Error Processing xml file for MFile";
                                    if (this.MFiles == null)
                                    {
                                        this.MFiles = new string[1];
                                    }
                                    else
                                    {
                                        this.MFiles = (string[]) Utils.CopyArray((Array) this.MFiles, new string[this.MFiles.Length + 1]);
                                    }
                                    this.MFiles[this.MFiles.Length - 1] = current.Attributes["file"].Value;
                                    continue;
                                }
                                case "HFILE":
                                {
                                    obj2 = "Error Processing xml file for HFile";
                                    if (this.HFiles == null)
                                    {
                                        this.HFiles = new string[1];
                                    }
                                    else
                                    {
                                        this.HFiles = (string[]) Utils.CopyArray((Array) this.HFiles, new string[this.HFiles.Length + 1]);
                                    }
                                    this.HFiles[this.HFiles.Length - 1] = current.Attributes["file"].Value;
                                    continue;
                                }
                                case "PFILE":
                                {
                                    obj2 = "Error Processing xml file for PFile";
                                    if (this.PFiles == null)
                                    {
                                        this.PFiles = new string[1];
                                    }
                                    else
                                    {
                                        this.PFiles = (string[]) Utils.CopyArray((Array) this.PFiles, new string[this.PFiles.Length + 1]);
                                    }
                                    this.PFiles[this.PFiles.Length - 1] = current.Attributes["file"].Value;
                                    continue;
                                }
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
            }
            obj2 = "Error creating StarHostEditorObject";
            this.SHE = new StarsHostEditor();
        }

        private void cmbHull_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbShipslot.Items.Clear();
            if (this.cmbHull.SelectedIndex >= 0)
            {
                foreach (string str in Strings.Split(this.ShipSlots[this.cmbHull.SelectedIndex, 0], "\r\n", -1, CompareMethod.Binary))
                {
                    this.cmbShipslot.Items.Add(str);
                }
            }
            this.cmbShipslot.SelectedIndex = 0;
        }

        private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtRaceFile.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 0]);
            this.txtEnergy.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 1]);
            this.txtWeapons.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 2]);
            this.txtPropulsion.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 3]);
            this.txtConstruction.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 4]);
            this.txtElectronics.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 5]);
            this.txtBiology.Text = Conversions.ToString(this.Players[this.cmbRaces.SelectedIndex, 6]);
            this.cmbShipDesigns.SelectedIndex = 0;
        }

        private void cmbShipDesigns_SelectedIndexChanged(object sender, EventArgs e)
        {
            Design design = this.ShipDesigns[(this.cmbRaces.SelectedIndex * 0x1a) + this.cmbShipDesigns.SelectedIndex];
            if (design == null)
            {
                this.cmbHull.SelectedIndex = -1;
            }
            else
            {
                this.cmbHull.SelectedIndex = design.xShipHullID;
            }
        }

        private void cmbShipslot_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCategoryID.Items.Clear();
            if (this.cmbHull.SelectedIndex >= 0)
            {
                string str = Strings.Split(this.ShipSlots[this.cmbHull.SelectedIndex, 1], ",", -1, CompareMethod.Binary)[this.cmbShipslot.SelectedIndex];
                int num = 0;
                do
                {
                    if ((((long) Math.Round(Math.Pow(2.0, (double) num))) & Conversions.ToLong(str)) != 0L)
                    {
                        this.cmbCategoryID.Items.Add(this.Categories[num + 1]);
                    }
                    num++;
                }
                while (num <= 12);
            }
            if (this.ShipDesigns[(this.cmbRaces.SelectedIndex * 0x1a) + this.cmbShipDesigns.SelectedIndex] == null)
            {
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerator enumerator;
            this.Gamedefs.Load(Application.StartupPath + @"\GameData.xml");
            this.GamesElement = this.Gamedefs.SelectSingleNode("Games");
            try
            {
                enumerator = this.GamesElement.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XmlNode current = (XmlNode) enumerator.Current;
                    this.cmbGamesList.Items.Add(current.Attributes["name"].Value);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.ShipSlots[5, 0] = "Engine (1)\r\nScanner (<=1)\r\nGeneral Purpose (<=3)\r\nShield or Armor (<=2)";
            this.ShipSlots[5, 1] = "1,2,6462,12";
            this.ShipSlots[14, 0] = "Engine (1)\r\nMechanical (<=1)";
            this.ShipSlots[15, 0] = "Engine (1)\r\nMechanical (<=1)";
            this.ShipSlots[0x10, 0] = "Engine (1)\r\nBomb (<=2)";
            this.ShipSlots[0x10, 1] = "1,64";
            this.ShipSlots[0x11, 0] = "Engine (2)\r\nBomb (<=4)\r\nBomb (<=4)\r\nScan/Elec/Mech (<=1)";
            this.ShipSlots[0x11, 1] = "1,64,64,6146";
            this.ShipSlots[0x12, 0] = "Engine (2)\r\nBomb (<=4)\r\nBomb (<=4)\r\nScan/Elec/Mech (<=1)\r\nElectrical (<=3)";
            this.ShipSlots[0x12, 1] = "1,64,64,6146,4096";
            this.Items[0] = "Settlers Delight,Quick Jump 5,Fuel Mizer,Long Jump 6,Daddy Long Legs 7,Alpha Drive 8,Trans Galactic Drive,Interspace 10,Enigma Pulsar,Trans Star 10,Radiating Hydro Ram Scoop,Sub Galactic Fuel Scoop, Trans Galactic Fuel Scoop, Trans Galactic Super Scoop, Trans Galactic Mizer Scoop,Galaxy Scoop";
            this.Items[1] = "Bat Scanner,Rhino Scanner,Mole Scanner,DNA Scanner,Possum Scanner,Pick Pocket Scanner,Chameleon Scanner,Ferret Scanner,Dolphin Scanner,Gazelle Scanner,RNA Scanner,Cheetah Scanner,Elephane Scanner,Eagle Eye Scanner,Robber Baron Scanner,Peerless Scanner";
            this.Items[2] = "Mole Skin Shield,Cow Hide Shield,Wolverine Shield,Croby Sharmor,Shadow Shield,Bear Neutrino Barrier,Gorilla Delagator,Elephant Hide Fortress,Complete Phase Shield";
            this.Items[3] = "Tritanium,Crobmnium,Carbonic Armor,Stobnium,Organic armor,Kelarium,Fielded Kelarium,Depleted Neutronium,Neutronium,Mega Poly Shell,Valanium,Superlatanium";
            this.Items[4] = "Laser,X-Ray Laser,Mini Gun,Yakimora Light Phaser,Blackjack,Phaser Bazooka,Pulsed Sapper,Colloidal Phaser,Gatling Gun,Mini Blaster,Bludgeon,,Mark IV Blaster,Phased Sapper,Heavy Blaster,Gatling Neutrino Cannon,Myopic Disruptor,Blunderbuss,Disruptor,Multi Contained Munition,Syncro Sapper,Mega Disruptor,Big Mutha Cannon,Streaming Pulzerizer,Anti-Matter Pulverizer";
            this.Items[5] = "Alpha torpedo,Beta torpedo,Delta Torpedo,Epsilon Torpedo,Rho Torpedo,Upsilon Torpedo,Omega Torpedo,Anti Matter Torpedo,Jihad Missile,Juggernaut Missile,Doomsday Missile,Armageddon Missile";
            this.Items[6] = "Lady finger Bomb,Black Cat Bomb,M-70 Bomb,M-80 Bomb,Cherry Bomb,LBU-17 Bomb,LBU-32 Bomb,LBU-74 Bomb,Hush A Boom, Retro Bomb, Smart Bomb, Neutron Bomb,enriched Neutron Bomb,Peerless Bomb,Annihilator Bomb";
            this.Items[7] = "Robo Midger Miner,Robo Mini Miner,Robo Miner,Robo Maxi Miner,Robo super Miner,Robo Ultra Miner,Alien Miner,Robo Ultra Miner";
            this.Items[8] = "Mine Dispenser 40,Mine Dispenser 50,Mine Dispenser 80,Mine Dispenser 130,Heavy Dispenser 50,Heavy Dispenser 110,Heavy Dispenser 200,Speed Trap 30,Speed Trap 30,Speed Trap 50";
            this.Items[9] = "Stargate 100/250,Stargate Any/300,Stargate 150/600,Stargate 300/500,Stargate 100/Any,Stargate Any/800,Stargate Any/Any,Mass Driver 5,Mass Driver 6,Mass Driver 7,Mass Driver 8,Mass Driver 9,Mass Driver 10,Mass Driver 11,Mass Driver 12,Mass Driver 13";
            this.Items[11] = "Transport Cloaking,Stealth Cloak,Super Stealth Cloak,Ultra Stealth Cloak,Multi Function Pod,Battle Computer,Battle Super Computer,Battle Nexus,Jammer 10,Jammer 20,Jammer 30,Jammer 50,Energy Capacitor,Flux Capacitor,Energy Dampener,Tachyon Detector,Anti Matter Generator";
            this.Items[12] = "Colonisation Module,Orbital Colonisation Module,Cargo Pod,Super Cargo Pod,Multi cargo Pod,Fuel Tank,Super Fuel Tank,Maneuvering Jet,Overthruster,Jumpgate,Beam Deflector";
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(StarsHSTCreator));
            this.cmbGamesList = new ComboBox();
            this.btnCreateHST = new Button();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.cmbRaces = new ComboBox();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.txtRaceFile = new TextBox();
            this.Label5 = new Label();
            this.Label6 = new Label();
            this.txtEnergy = new TextBox();
            this.txtWeapons = new TextBox();
            this.txtPropulsion = new TextBox();
            this.txtConstruction = new TextBox();
            this.txtElectronics = new TextBox();
            this.txtBiology = new TextBox();
            this.Label7 = new Label();
            this.Label8 = new Label();
            this.Label9 = new Label();
            this.Label10 = new Label();
            this.Label11 = new Label();
            this.Label12 = new Label();
            this.cmbShipDesigns = new ComboBox();
            this.cmbHull = new ComboBox();
            this.Label13 = new Label();
            this.cmbShipslot = new ComboBox();
            this.Label14 = new Label();
            this.Label15 = new Label();
            this.cmbItem = new ComboBox();
            this.Label16 = new Label();
            this.cmbCategoryID = new ComboBox();
            this.Button2 = new Button();
            this.Button1 = new Button();
            this.Button3 = new Button();
            this.SuspendLayout();
            this.cmbGamesList.FormattingEnabled = true;
            Point point = new Point(0x54, 12);
            this.cmbGamesList.Location = point;
            this.cmbGamesList.Name = "cmbGamesList";
            Size size = new Size(0x79, 0x15);
            this.cmbGamesList.Size = size;
            this.cmbGamesList.TabIndex = 0;
            point = new Point(0xd4, 12);
            this.btnCreateHST.Location = point;
            this.btnCreateHST.Name = "btnCreateHST";
            size = new Size(0x5b, 20);
            this.btnCreateHST.Size = size;
            this.btnCreateHST.TabIndex = 1;
            this.btnCreateHST.Text = "Create .hst";
            this.btnCreateHST.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            point = new Point(12, 0x2d);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x232, 0x4e);
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = manager.GetString("Label1.Text");
            this.Label2.AutoSize = true;
            point = new Point(12, 20);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x42, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Game Name";
            this.cmbRaces.FormattingEnabled = true;
            this.cmbRaces.Items.AddRange(new object[] { "Player 1", "Player 2", "Player 3", "Player 4", "Player 5", "Player 6", "Player 7", "Player 8", "Player 9", "Player 10", "Player 11", "Player 12", "Player 13", "Player 14", "Player 15", "Player 16" });
            point = new Point(0x54, 140);
            this.cmbRaces.Location = point;
            this.cmbRaces.Name = "cmbRaces";
            size = new Size(0xdb, 0x15);
            this.cmbRaces.Size = size;
            this.cmbRaces.TabIndex = 4;
            this.cmbRaces.Visible = false;
            this.Label3.AutoSize = true;
            point = new Point(6, 0x90);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x21, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Race";
            this.Label3.Visible = false;
            this.Label4.AutoSize = true;
            point = new Point(6, 0xb1);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x31, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "RaceFile";
            this.Label4.Visible = false;
            point = new Point(0x54, 0xa9);
            this.txtRaceFile.Location = point;
            this.txtRaceFile.Name = "txtRaceFile";
            size = new Size(0xdb, 20);
            this.txtRaceFile.Size = size;
            this.txtRaceFile.TabIndex = 7;
            this.txtRaceFile.Visible = false;
            this.Label5.AutoSize = true;
            point = new Point(0x51, 0xc0);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(40, 13);
            this.Label5.Size = size;
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Energy";
            this.Label5.Visible = false;
            this.Label6.AutoSize = true;
            point = new Point(0x98, 0xc1);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x35, 13);
            this.Label6.Size = size;
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Weapons";
            this.Label6.Visible = false;
            point = new Point(0x54, 0xd1);
            this.txtEnergy.Location = point;
            this.txtEnergy.Name = "txtEnergy";
            size = new Size(0x45, 20);
            this.txtEnergy.Size = size;
            this.txtEnergy.TabIndex = 10;
            this.txtEnergy.Visible = false;
            point = new Point(0x9b, 0xd1);
            this.txtWeapons.Location = point;
            this.txtWeapons.Name = "txtWeapons";
            size = new Size(0x45, 20);
            this.txtWeapons.Size = size;
            this.txtWeapons.TabIndex = 11;
            this.txtWeapons.Visible = false;
            point = new Point(0xe2, 0xd1);
            this.txtPropulsion.Location = point;
            this.txtPropulsion.Name = "txtPropulsion";
            size = new Size(0x45, 20);
            this.txtPropulsion.Size = size;
            this.txtPropulsion.TabIndex = 12;
            this.txtPropulsion.Visible = false;
            point = new Point(0x129, 0xd1);
            this.txtConstruction.Location = point;
            this.txtConstruction.Name = "txtConstruction";
            size = new Size(0x45, 20);
            this.txtConstruction.Size = size;
            this.txtConstruction.TabIndex = 13;
            this.txtConstruction.Visible = false;
            point = new Point(0x170, 0xd1);
            this.txtElectronics.Location = point;
            this.txtElectronics.Name = "txtElectronics";
            size = new Size(0x45, 20);
            this.txtElectronics.Size = size;
            this.txtElectronics.TabIndex = 14;
            this.txtElectronics.Visible = false;
            point = new Point(0x1b7, 0xd1);
            this.txtBiology.Location = point;
            this.txtBiology.Name = "txtBiology";
            size = new Size(0x45, 20);
            this.txtBiology.Size = size;
            this.txtBiology.TabIndex = 15;
            this.txtBiology.Visible = false;
            this.Label7.AutoSize = true;
            point = new Point(0xdf, 0xc1);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x38, 13);
            this.Label7.Size = size;
            this.Label7.TabIndex = 0x10;
            this.Label7.Text = "Propulsion";
            this.Label7.Visible = false;
            this.Label8.AutoSize = true;
            point = new Point(0x126, 0xc1);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0x42, 13);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x11;
            this.Label8.Text = "Construction";
            this.Label8.Visible = false;
            this.Label9.AutoSize = true;
            point = new Point(0x16d, 0xc0);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x3b, 13);
            this.Label9.Size = size;
            this.Label9.TabIndex = 0x12;
            this.Label9.Text = "Electronics";
            this.Label9.Visible = false;
            this.Label10.AutoSize = true;
            point = new Point(0x1b4, 0xc0);
            this.Label10.Location = point;
            this.Label10.Name = "Label10";
            size = new Size(0x29, 13);
            this.Label10.Size = size;
            this.Label10.TabIndex = 0x13;
            this.Label10.Text = "Biology";
            this.Label10.Visible = false;
            this.Label11.AutoSize = true;
            point = new Point(6, 0xd4);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(0x42, 13);
            this.Label11.Size = size;
            this.Label11.TabIndex = 20;
            this.Label11.Text = "Tech Levels";
            this.Label11.Visible = false;
            this.Label12.AutoSize = true;
            point = new Point(6, 0xee);
            this.Label12.Location = point;
            this.Label12.Name = "Label12";
            size = new Size(0x2d, 13);
            this.Label12.Size = size;
            this.Label12.TabIndex = 0x15;
            this.Label12.Text = "Designs";
            this.Label12.Visible = false;
            this.cmbShipDesigns.FormattingEnabled = true;
            this.cmbShipDesigns.Items.AddRange(new object[] { 
                "Ship Slot 1", "Ship Slot 2", "Ship Slot 3", "Ship Slot 4", "Ship Slot 5", "Ship Slot 6", "Ship Slot 7", "Ship Slot 8", "Ship Slot 9", "Ship Slot 10", "Ship Slot 11", "Ship Slot 12", "Ship Slot 13", "Ship Slot 14", "Ship Slot 15", "Ship Slot 16", 
                "Starbase Slot 1", "Starbase Slot 2", "Starbase Slot 3", "Starbase Slot 4", "Starbase Slot 5", "Starbase Slot 6", "starbase slot 7", "Starbase Slot 8", "Starbase Slot 9", "Starbase Slot 10"
             });
            point = new Point(0x54, 0xee);
            this.cmbShipDesigns.Location = point;
            this.cmbShipDesigns.Name = "cmbShipDesigns";
            size = new Size(0xdb, 0x15);
            this.cmbShipDesigns.Size = size;
            this.cmbShipDesigns.TabIndex = 0x16;
            this.cmbShipDesigns.Visible = false;
            this.cmbHull.FormattingEnabled = true;
            this.cmbHull.Items.AddRange(new object[] { 
                "Small Freighter", "Medium Freighter", "Large Freighter", "Super Freighter", "Scout", "Frigate", "Destroyer", "Cruiser", "Battle Cruiser", "Battleship", "Dreadnaught", "Privateer", "Rogue", "Galleon", "Mini Colony Ship", "Colony Ship", 
                "Mini Bomber", "B-17 Bomber", "Stealth Bomber", "B-52 Bomber", "Midget Miner", "Mini Miner", "Miner", "Maxi Miner", "Ultra Miner", "Fuel Transport", "Super Fuel Transport", "Mini Mine Layer", "Super Mine Layer", "Nubian", "Mini Morph", "Meta Morth", 
                "Orbital Fort", "Space Dock", "Space Station", "Ultra Station", "Death Star"
             });
            point = new Point(0x54, 0x109);
            this.cmbHull.Location = point;
            this.cmbHull.Name = "cmbHull";
            size = new Size(0xdb, 0x15);
            this.cmbHull.Size = size;
            this.cmbHull.TabIndex = 0x18;
            this.cmbHull.Visible = false;
            this.Label13.AutoSize = true;
            point = new Point(6, 0x109);
            this.Label13.Location = point;
            this.Label13.Name = "Label13";
            size = new Size(0x19, 13);
            this.Label13.Size = size;
            this.Label13.TabIndex = 0x17;
            this.Label13.Text = "Hull";
            this.Label13.Visible = false;
            this.cmbShipslot.FormattingEnabled = true;
            point = new Point(0x54, 0x125);
            this.cmbShipslot.Location = point;
            this.cmbShipslot.Name = "cmbShipslot";
            size = new Size(0xdb, 0x15);
            this.cmbShipslot.Size = size;
            this.cmbShipslot.TabIndex = 0x19;
            this.cmbShipslot.Visible = false;
            this.Label14.AutoSize = true;
            point = new Point(6, 0x128);
            this.Label14.Location = point;
            this.Label14.Name = "Label14";
            size = new Size(0x31, 13);
            this.Label14.Size = size;
            this.Label14.TabIndex = 0x1a;
            this.Label14.Text = "Ship Slot";
            this.Label14.Visible = false;
            this.Label15.AutoSize = true;
            point = new Point(6, 0x15c);
            this.Label15.Location = point;
            this.Label15.Name = "Label15";
            size = new Size(0x1b, 13);
            this.Label15.Size = size;
            this.Label15.TabIndex = 0x1c;
            this.Label15.Text = "Item";
            this.Label15.Visible = false;
            this.cmbItem.FormattingEnabled = true;
            point = new Point(0x54, 0x159);
            this.cmbItem.Location = point;
            this.cmbItem.Name = "cmbItem";
            size = new Size(0xdb, 0x15);
            this.cmbItem.Size = size;
            this.cmbItem.TabIndex = 0x1b;
            this.cmbItem.Visible = false;
            this.Label16.AutoSize = true;
            point = new Point(6, 0x141);
            this.Label16.Location = point;
            this.Label16.Name = "Label16";
            size = new Size(0x48, 13);
            this.Label16.Size = size;
            this.Label16.TabIndex = 30;
            this.Label16.Text = "Item Category";
            this.Label16.Visible = false;
            this.cmbCategoryID.FormattingEnabled = true;
            point = new Point(0x54, 0x13e);
            this.cmbCategoryID.Location = point;
            this.cmbCategoryID.Name = "cmbCategoryID";
            size = new Size(0xdb, 0x15);
            this.cmbCategoryID.Size = size;
            this.cmbCategoryID.TabIndex = 0x1d;
            this.cmbCategoryID.Visible = false;
            point = new Point(0x135, 0x8b);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x5b, 20);
            this.Button2.Size = size;
            this.Button2.TabIndex = 0x1f;
            this.Button2.Text = "Design Editor";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Visible = false;
            point = new Point(0x20a, 9);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x4b, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 0x20;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(0x1fd, 0x13b);
            this.Button3.Location = point;
            this.Button3.Name = "Button3";
            size = new Size(0x4b, 0x17);
            this.Button3.Size = size;
            this.Button3.TabIndex = 0x21;
            this.Button3.Text = "Button3";
            this.Button3.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x261, 0x1d9);
            this.ClientSize = size;
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.cmbCategoryID);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.cmbShipslot);
            this.Controls.Add(this.cmbHull);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.cmbShipDesigns);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtBiology);
            this.Controls.Add(this.txtElectronics);
            this.Controls.Add(this.txtConstruction);
            this.Controls.Add(this.txtPropulsion);
            this.Controls.Add(this.txtWeapons);
            this.Controls.Add(this.txtEnergy);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtRaceFile);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmbRaces);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCreateHST);
            this.Controls.Add(this.cmbGamesList);
            this.Name = "StarsHSTCreator";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal virtual Button btnCreateHST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnCreateHST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button1_Click);
                if (this._btnCreateHST != null)
                {
                    this._btnCreateHST.Click -= handler;
                }
                this._btnCreateHST = value;
                if (this._btnCreateHST != null)
                {
                    this._btnCreateHST.Click += handler;
                }
            }
        }

        internal virtual Button Button1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button1_Click_1);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= handler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += handler;
                }
            }
        }

        internal virtual Button Button2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button2_Click);
                if (this._Button2 != null)
                {
                    this._Button2.Click -= handler;
                }
                this._Button2 = value;
                if (this._Button2 != null)
                {
                    this._Button2.Click += handler;
                }
            }
        }

        internal virtual Button Button3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button3_Click);
                if (this._Button3 != null)
                {
                    this._Button3.Click -= handler;
                }
                this._Button3 = value;
                if (this._Button3 != null)
                {
                    this._Button3.Click += handler;
                }
            }
        }

        internal virtual ComboBox cmbCategoryID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbCategoryID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbCategoryID_SelectedIndexChanged);
                if (this._cmbCategoryID != null)
                {
                    this._cmbCategoryID.SelectedIndexChanged -= handler;
                }
                this._cmbCategoryID = value;
                if (this._cmbCategoryID != null)
                {
                    this._cmbCategoryID.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cmbGamesList
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbGamesList;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbGamesList_SelectedIndexChanged);
                if (this._cmbGamesList != null)
                {
                    this._cmbGamesList.SelectedIndexChanged -= handler;
                }
                this._cmbGamesList = value;
                if (this._cmbGamesList != null)
                {
                    this._cmbGamesList.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cmbHull
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbHull;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbHull_SelectedIndexChanged);
                if (this._cmbHull != null)
                {
                    this._cmbHull.SelectedIndexChanged -= handler;
                }
                this._cmbHull = value;
                if (this._cmbHull != null)
                {
                    this._cmbHull.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cmbItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._cmbItem = value;
            }
        }

        internal virtual ComboBox cmbRaces
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbRaces;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbRaces_SelectedIndexChanged);
                if (this._cmbRaces != null)
                {
                    this._cmbRaces.SelectedIndexChanged -= handler;
                }
                this._cmbRaces = value;
                if (this._cmbRaces != null)
                {
                    this._cmbRaces.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cmbShipDesigns
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbShipDesigns;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbShipDesigns_SelectedIndexChanged);
                if (this._cmbShipDesigns != null)
                {
                    this._cmbShipDesigns.SelectedIndexChanged -= handler;
                }
                this._cmbShipDesigns = value;
                if (this._cmbShipDesigns != null)
                {
                    this._cmbShipDesigns.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cmbShipslot
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbShipslot;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbShipslot_SelectedIndexChanged);
                if (this._cmbShipslot != null)
                {
                    this._cmbShipslot.SelectedIndexChanged -= handler;
                }
                this._cmbShipslot = value;
                if (this._cmbShipslot != null)
                {
                    this._cmbShipslot.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label1 = value;
            }
        }

        internal virtual Label Label10
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label10 = value;
            }
        }

        internal virtual Label Label11
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label11 = value;
            }
        }

        internal virtual Label Label12
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label12 = value;
            }
        }

        internal virtual Label Label13
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label13 = value;
            }
        }

        internal virtual Label Label14
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label14;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label14 = value;
            }
        }

        internal virtual Label Label15
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label15 = value;
            }
        }

        internal virtual Label Label16
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label16 = value;
            }
        }

        internal virtual Label Label2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label2 = value;
            }
        }

        internal virtual Label Label3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label3 = value;
            }
        }

        internal virtual Label Label4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label4 = value;
            }
        }

        internal virtual Label Label5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label5 = value;
            }
        }

        internal virtual Label Label6
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label6 = value;
            }
        }

        internal virtual Label Label7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label7 = value;
            }
        }

        internal virtual Label Label8
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label8 = value;
            }
        }

        internal virtual Label Label9
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label9 = value;
            }
        }

        internal virtual TextBox txtBiology
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtBiology;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtBiology = value;
            }
        }

        internal virtual TextBox txtConstruction
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtConstruction;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtConstruction = value;
            }
        }

        internal virtual TextBox txtElectronics
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtElectronics;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtElectronics = value;
            }
        }

        internal virtual TextBox txtEnergy
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtEnergy;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtEnergy = value;
            }
        }

        internal virtual TextBox txtPropulsion
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtPropulsion;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtPropulsion = value;
            }
        }

        internal virtual TextBox txtRaceFile
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtRaceFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtRaceFile = value;
            }
        }

        internal virtual TextBox txtWeapons
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtWeapons;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtWeapons = value;
            }
        }
    }
}

