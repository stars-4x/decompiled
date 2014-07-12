namespace StarsSumpremacyHost
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using StarsSupremacyHostDLL;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class Form1 : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("txtFilename")]
        private TextBox _txtFilename;
        private IContainer components;

        [DebuggerNonUserCode]
        public Form1()
        {
            base.Load += new EventHandler(this.Form1_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StarsSupremacyHostDLL.StarsSupremacyHostDLL tdll = new StarsSupremacyHostDLL.StarsSupremacyHostDLL();
            string prompt = Conversions.ToString(tdll.CheckXFile(this.txtFilename.Text));
            if (prompt == "")
            {
                Interaction.MsgBox("File was OK", MsgBoxStyle.ApplicationModal, null);
            }
            else
            {
                Interaction.MsgBox(prompt, MsgBoxStyle.ApplicationModal, null);
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
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.Label1 = new Label();
            this.txtFilename = new TextBox();
            this.Button1 = new Button();
            this.SuspendLayout();
            this.Label1.AutoSize = true;
            Point point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size(0x31, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Filename";
            point = new Point(0x43, 6);
            this.txtFilename.Location = point;
            this.txtFilename.Name = "txtFilename";
            size = new Size(0x197, 20);
            this.txtFilename.Size = size;
            this.txtFilename.TabIndex = 1;
            this.txtFilename.Text = @"c:\stars\test\game.x1";
            point = new Point(15, 0x20);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x4b, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Check X File";
            this.Button1.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x1dd, 0x85);
            this.ClientSize = size;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
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
                EventHandler handler = new EventHandler(this.Button1_Click);
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

        internal virtual TextBox txtFilename
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtFilename;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtFilename = value;
            }
        }
    }
}

