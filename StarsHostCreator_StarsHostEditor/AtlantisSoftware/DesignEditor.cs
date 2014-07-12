namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class DesignEditor : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Button3")]
        private Button _Button3;
        [AccessedThroughProperty("Cancel_Button")]
        private Button _Cancel_Button;
        [AccessedThroughProperty("cmbDesignList")]
        private ComboBox _cmbDesignList;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("OK_Button")]
        private Button _OK_Button;
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;
        [AccessedThroughProperty("radAvailableHullTypes")]
        private RadioButton _radAvailableHullTypes;
        [AccessedThroughProperty("radComponents")]
        private RadioButton _radComponents;
        [AccessedThroughProperty("radEnemyHulls")]
        private RadioButton _radEnemyHulls;
        [AccessedThroughProperty("radExistingDesigns")]
        private RadioButton _radExistingDesigns;
        [AccessedThroughProperty("radShips")]
        private RadioButton _radShips;
        [AccessedThroughProperty("radStarbases")]
        private RadioButton _radStarbases;
        [AccessedThroughProperty("TableLayoutPanel1")]
        private TableLayoutPanel _TableLayoutPanel1;
        private IContainer components;
        public int CurrentRaceID;
        private object[] Hulls;
        private StarsHostEditor SHE;

        public DesignEditor(int RaceID, ref StarsHostEditor obj)
        {
            base.Load += new EventHandler(this.DesignEditor_Load);
            this.Hulls = new object[0x24];
            this.InitializeComponent();
            this.CurrentRaceID = RaceID;
            this.SHE = obj;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbDesignList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Design design = new Design();
            design.xShipHullID = 2;
            if (this.radExistingDesigns.Checked)
            {
                int num = 0;
                if (this.radShips.Checked)
                {
                    int num2 = 0;
                    do
                    {
                        object[] arguments = new object[] { num2 };
                        bool[] copyBack = new bool[] { true };
                        if (copyBack[0])
                        {
                            num2 = (int) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(int));
                        }
                        if (NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null), null, "xshipdesigns", arguments, null, null, copyBack) != null)
                        {
                            num++;
                            if (num == (this.cmbDesignList.SelectedIndex + 1))
                            {
                                object[] objArray = new object[] { num2 };
                                copyBack = new bool[] { true };
                                if (copyBack[0])
                                {
                                    num2 = (int) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
                                }
                                design = (Design) NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null), null, "xshipdesigns", objArray, null, null, copyBack);
                            }
                        }
                        num2++;
                    }
                    while (num2 <= 15);
                }
                else
                {
                    int num3 = 0x10;
                    do
                    {
                        if (NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null), null, "xstarbasedesigns", new object[] { num3 - 0x10 }, null, null, null) != null)
                        {
                            num++;
                            if (num == (this.cmbDesignList.SelectedIndex + 1))
                            {
                                design = (Design) NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null), null, "xstarbasedesigns", new object[] { num3 - 0x10 }, null, null, null);
                            }
                        }
                        num3++;
                    }
                    while (num3 <= 0x19);
                }
            }
            for (int i = this.Controls.Count - 1; i >= 0; i += -1)
            {
                if ((this.Controls[i].GetType().Name == "Panel") && (this.Controls[i].Name.Substring(0, 4) == "Slot"))
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }
            string[] strArray = Strings.Split(Conversions.ToString(this.Hulls[design.xShipHullID]), ",", -1, CompareMethod.Binary);
            int num8 = (int) Math.Round((double) (Conversion.Int((double) (((double) (strArray.Length - 1)) / 6.0)) - 1.0));
            for (int j = 0; j <= num8; j++)
            {
                string str;
                Panel panel = new Panel();
                panel.BackColor = Color.Gray;
                Bitmap bitmap = new Bitmap(Conversions.ToInteger(strArray[(j * 6) + 5]), Conversions.ToInteger(strArray[(j * 6) + 6]), PixelFormat.Format24bppRgb);
                Image image = bitmap;
                Graphics graphics = Graphics.FromImage(image);
                Font font = new Font("Arial", 10f, FontStyle.Regular);
                graphics.Clear(Color.Gray);
                if (Conversions.ToDouble(strArray[(j * 6) + 1]) == 1.0)
                {
                    str = "Engine\r\n\r\n\r\n";
                    str = str + "Needs " + strArray[(j * 6) + 2];
                }
                else
                {
                    str = "";
                    int num6 = Conversions.ToInteger(strArray[(j * 6) + 1]);
                    switch (num6)
                    {
                        case -1:
                            str = "Cargo\r\n" + strArray[(j * 6) + 2] + "kT\r\n\r\n";
                            graphics.Clear(Color.White);
                            break;

                        case 0:
                            if (Conversions.ToDouble(strArray[(j * 6) + 2]) == 0.0)
                            {
                                str = "Unlimited\r\nSpace\r\nDock\r\n";
                            }
                            else
                            {
                                str = strArray[(j * 6) + 2] + "kT\r\nSpace\r\nDock\r\n";
                            }
                            graphics.Clear(Color.White);
                            break;

                        case 2:
                            str = "Scanner\r\n\r\n\r\n";
                            break;

                        case 4:
                            str = "Shield\r\n\r\n\r\n";
                            break;

                        case 8:
                            str = "Armor\r\n\r\n\r\n";
                            break;

                        case 12:
                            str = "Shield\r\nor\r\nArmor\r\n";
                            break;

                        case 0x10:
                            str = "Beam\r\n\r\n\r\n";
                            break;

                        case 0x20:
                            str = "Torpedo\r\n\r\n\r\n";
                            break;

                        case 0x30:
                            str = "Weapon\r\n\r\n\r\n";
                            break;

                        case 0x40:
                            str = "Bomb\r\n\r\n\r\n";
                            break;

                        case 0x80:
                            str = "Mining\r\nRobots\r\n\r\n";
                            break;

                        case 0x100:
                            str = "Mine\r\n\r\n\r\n";
                            break;

                        case 0x200:
                            str = "Orbital\r\n\r\n\r\n";
                            break;

                        case 0x800:
                            str = "Elect\r\n\r\n\r\n";
                            break;

                        case 0xa00:
                            str = "Orbital\r\nor\r\nElectrical\r\n";
                            break;

                        case 0x1000:
                            str = "Mech\r\n\r\n\r\n";
                            break;

                        case 0x1800:
                            str = "Elect\r\nMech\r\n\r\n";
                            break;

                        case 0x1802:
                            str = "Scanner\r\nElect\r\nMech\r\n";
                            break;

                        default:
                            str = "Unknown\r\nCat " + Conversions.ToString(num6) + "\r\n\r\n";
                            break;
                    }
                    if (num6 > 0)
                    {
                        str = str + "up to " + strArray[(j * 6) + 2];
                    }
                }
                string[] strArray2 = Strings.Split(str, "\r\n", -1, CompareMethod.Binary);
                int num10 = strArray2.Length - 1;
                for (int k = 0; k <= num10; k++)
                {
                    SizeF ef = graphics.MeasureString(strArray2[k], font, 0x40);
                    graphics.DrawString(strArray2[k], font, Brushes.Black, (float) ((Conversions.ToDouble(strArray[(j * 6) + 5]) - ef.Width) / 2.0), (float) (k * 15));
                }
                panel.BackgroundImage = image;
                panel.Left = (int) Math.Round((double) (235.0 + Conversions.ToDouble(strArray[(j * 6) + 3])));
                panel.Top = (int) Math.Round((double) (50.0 + Conversions.ToDouble(strArray[(j * 6) + 4])));
                panel.Width = Conversions.ToInteger(strArray[(j * 6) + 5]);
                panel.Height = Conversions.ToInteger(strArray[(j * 6) + 6]);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.AllowDrop = true;
                panel.Name = "Slot" + Conversions.ToString(j);
                this.Controls.Add(panel);
            }
        }

        private void DesignEditor_Load(object sender, EventArgs e)
        {
            this.SetDesignList();
            StreamReader reader = new StreamReader("hulls.txt");
            string expression = reader.ReadToEnd();
            reader.Close();
            this.Hulls = Strings.Split(expression, "\r\n", -1, CompareMethod.Binary);
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.TableLayoutPanel1 = new TableLayoutPanel();
            this.OK_Button = new Button();
            this.Cancel_Button = new Button();
            this.GroupBox1 = new GroupBox();
            this.radStarbases = new RadioButton();
            this.radShips = new RadioButton();
            this.GroupBox2 = new GroupBox();
            this.radComponents = new RadioButton();
            this.radEnemyHulls = new RadioButton();
            this.radAvailableHullTypes = new RadioButton();
            this.radExistingDesigns = new RadioButton();
            this.Button1 = new Button();
            this.cmbDesignList = new ComboBox();
            this.Button2 = new Button();
            this.Button3 = new Button();
            this.Panel1 = new Panel();
            this.TableLayoutPanel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            this.TableLayoutPanel1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            Point point = new Point(0x1af, 0x1e4);
            this.TableLayoutPanel1.Location = point;
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            Size size = new Size(0x92, 0x1d);
            this.TableLayoutPanel1.Size = size;
            this.TableLayoutPanel1.TabIndex = 0;
            this.OK_Button.Anchor = AnchorStyles.None;
            point = new Point(3, 3);
            this.OK_Button.Location = point;
            this.OK_Button.Name = "OK_Button";
            size = new Size(0x43, 0x17);
            this.OK_Button.Size = size;
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.Cancel_Button.Anchor = AnchorStyles.None;
            this.Cancel_Button.DialogResult = DialogResult.Cancel;
            point = new Point(0x4c, 3);
            this.Cancel_Button.Location = point;
            this.Cancel_Button.Name = "Cancel_Button";
            size = new Size(0x43, 0x17);
            this.Cancel_Button.Size = size;
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.GroupBox1.Controls.Add(this.radStarbases);
            this.GroupBox1.Controls.Add(this.radShips);
            point = new Point(13, 13);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(200, 0x47);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Design";
            this.radStarbases.AutoSize = true;
            point = new Point(15, 0x2a);
            this.radStarbases.Location = point;
            this.radStarbases.Name = "radStarbases";
            size = new Size(0x48, 0x11);
            this.radStarbases.Size = size;
            this.radStarbases.TabIndex = 1;
            this.radStarbases.Text = "Starbases";
            this.radStarbases.UseVisualStyleBackColor = true;
            this.radShips.AutoSize = true;
            this.radShips.Checked = true;
            point = new Point(15, 0x13);
            this.radShips.Location = point;
            this.radShips.Name = "radShips";
            size = new Size(0x33, 0x11);
            this.radShips.Size = size;
            this.radShips.TabIndex = 0;
            this.radShips.TabStop = true;
            this.radShips.Text = "Ships";
            this.radShips.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add(this.radComponents);
            this.GroupBox2.Controls.Add(this.radEnemyHulls);
            this.GroupBox2.Controls.Add(this.radAvailableHullTypes);
            this.GroupBox2.Controls.Add(this.radExistingDesigns);
            point = new Point(13, 100);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(200, 0x77);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "View";
            this.radComponents.AutoSize = true;
            point = new Point(0x10, 0x58);
            this.radComponents.Location = point;
            this.radComponents.Name = "radComponents";
            size = new Size(0x54, 0x11);
            this.radComponents.Size = size;
            this.radComponents.TabIndex = 5;
            this.radComponents.Text = "Components";
            this.radComponents.UseVisualStyleBackColor = true;
            this.radEnemyHulls.AutoSize = true;
            point = new Point(0x10, 0x41);
            this.radEnemyHulls.Location = point;
            this.radEnemyHulls.Name = "radEnemyHulls";
            size = new Size(0x53, 0x11);
            this.radEnemyHulls.Size = size;
            this.radEnemyHulls.TabIndex = 4;
            this.radEnemyHulls.Text = "Enemy Hulls";
            this.radEnemyHulls.UseVisualStyleBackColor = true;
            this.radAvailableHullTypes.AutoSize = true;
            point = new Point(0x10, 0x2a);
            this.radAvailableHullTypes.Location = point;
            this.radAvailableHullTypes.Name = "radAvailableHullTypes";
            size = new Size(0x79, 0x11);
            this.radAvailableHullTypes.Size = size;
            this.radAvailableHullTypes.TabIndex = 3;
            this.radAvailableHullTypes.Text = "Available Hull Types";
            this.radAvailableHullTypes.UseVisualStyleBackColor = true;
            this.radExistingDesigns.AutoSize = true;
            this.radExistingDesigns.Checked = true;
            point = new Point(0x10, 0x13);
            this.radExistingDesigns.Location = point;
            this.radExistingDesigns.Name = "radExistingDesigns";
            size = new Size(0x66, 0x11);
            this.radExistingDesigns.Size = size;
            this.radExistingDesigns.TabIndex = 2;
            this.radExistingDesigns.TabStop = true;
            this.radExistingDesigns.Text = "Existing Designs";
            this.radExistingDesigns.UseVisualStyleBackColor = true;
            point = new Point(13, 0xef);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x89, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 3;
            this.Button1.Text = "&Copy Selected Design";
            this.Button1.UseVisualStyleBackColor = true;
            this.cmbDesignList.FormattingEnabled = true;
            point = new Point(0x13b, 15);
            this.cmbDesignList.Location = point;
            this.cmbDesignList.Name = "cmbDesignList";
            size = new Size(240, 0x15);
            this.cmbDesignList.Size = size;
            this.cmbDesignList.TabIndex = 4;
            point = new Point(13, 0x10c);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x89, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 5;
            this.Button2.Text = "&Delete Selected Design";
            this.Button2.UseVisualStyleBackColor = true;
            point = new Point(13, 0x129);
            this.Button3.Location = point;
            this.Button3.Name = "Button3";
            size = new Size(0x89, 0x17);
            this.Button3.Size = size;
            this.Button3.TabIndex = 6;
            this.Button3.Text = "&Edit Selected Design";
            this.Button3.UseVisualStyleBackColor = true;
            this.Panel1.BackColor = Color.Red;
            this.Panel1.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(0xeb, 15);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new Size(0x40, 0x40);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 7;
            this.AcceptButton = this.OK_Button;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            size = new Size(0x24d, 0x20d);
            this.ClientSize = size;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.cmbDesignList);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesignEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "DesignEditor";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radShips_CheckedChanged(object sender, EventArgs e)
        {
            this.SetDesignList();
        }

        public object SetDesignList()
        {
            if (this.SHE != null)
            {
                if (this.radShips.Checked)
                {
                    this.cmbDesignList.Items.Clear();
                    Race race = (Race) NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null);
                    foreach (Design design in race.xShipDesigns)
                    {
                        if (design != null)
                        {
                            this.cmbDesignList.Items.Add(design.xName + " (" + Conversion.Hex(design.xDesignID) + ")");
                        }
                    }
                }
                else
                {
                    this.cmbDesignList.Items.Clear();
                    Race race2 = (Race) NewLateBinding.LateIndexGet(this.SHE.Races(), new object[] { this.CurrentRaceID }, null);
                    foreach (Design design2 in race2.xStarbaseDesigns)
                    {
                        if (design2 != null)
                        {
                            this.cmbDesignList.Items.Add(design2.xName + " (" + Conversion.Hex(design2.xDesignID) + ")");
                        }
                    }
                }
            }
            this.cmbDesignList.SelectedIndex = 0;
            return 0;
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
                this._Button1 = value;
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
                this._Button2 = value;
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
                this._Button3 = value;
            }
        }

        internal virtual Button Cancel_Button
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Cancel_Button;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Cancel_Button_Click);
                if (this._Cancel_Button != null)
                {
                    this._Cancel_Button.Click -= handler;
                }
                this._Cancel_Button = value;
                if (this._Cancel_Button != null)
                {
                    this._Cancel_Button.Click += handler;
                }
            }
        }

        internal virtual ComboBox cmbDesignList
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbDesignList;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cmbDesignList_SelectedIndexChanged);
                if (this._cmbDesignList != null)
                {
                    this._cmbDesignList.SelectedIndexChanged -= handler;
                }
                this._cmbDesignList = value;
                if (this._cmbDesignList != null)
                {
                    this._cmbDesignList.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual GroupBox GroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GroupBox1 = value;
            }
        }

        internal virtual GroupBox GroupBox2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GroupBox2 = value;
            }
        }

        internal virtual Button OK_Button
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OK_Button;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.OK_Button_Click);
                if (this._OK_Button != null)
                {
                    this._OK_Button.Click -= handler;
                }
                this._OK_Button = value;
                if (this._OK_Button != null)
                {
                    this._OK_Button.Click += handler;
                }
            }
        }

        internal virtual Panel Panel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Panel1 = value;
            }
        }

        internal virtual RadioButton radAvailableHullTypes
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radAvailableHullTypes;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._radAvailableHullTypes = value;
            }
        }

        internal virtual RadioButton radComponents
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radComponents;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._radComponents = value;
            }
        }

        internal virtual RadioButton radEnemyHulls
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radEnemyHulls;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._radEnemyHulls = value;
            }
        }

        internal virtual RadioButton radExistingDesigns
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radExistingDesigns;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._radExistingDesigns = value;
            }
        }

        internal virtual RadioButton radShips
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radShips;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.radShips_CheckedChanged);
                if (this._radShips != null)
                {
                    this._radShips.CheckedChanged -= handler;
                }
                this._radShips = value;
                if (this._radShips != null)
                {
                    this._radShips.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton radStarbases
        {
            [DebuggerNonUserCode]
            get
            {
                return this._radStarbases;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._radStarbases = value;
            }
        }

        internal virtual TableLayoutPanel TableLayoutPanel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TableLayoutPanel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TableLayoutPanel1 = value;
            }
        }
    }
}

