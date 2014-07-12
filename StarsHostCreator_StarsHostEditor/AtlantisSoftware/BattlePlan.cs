namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class BattlePlan
    {
        private int xAttackWho;
        private int xBattlePlanNo;
        private string xName;
        private int xPrimaryTarget;
        private int xRaceID;
        private int xSecondaryTarget;
        private int xTactic;

        public BattlePlan()
        {
            this.xRaceID = 0;
            this.xBattlePlanNo = 0;
            this.xTactic = 0;
            this.xPrimaryTarget = 0;
            this.xSecondaryTarget = 0;
            this.xAttackWho = 0;
            this.xName = "Default";
        }

        public BattlePlan(byte[] data)
        {
            this.xRaceID = 0;
            this.xBattlePlanNo = 0;
            this.xTactic = 0;
            this.xPrimaryTarget = 0;
            this.xSecondaryTarget = 0;
            this.xAttackWho = 0;
            this.xName = "Default";
            this.BattlePlanData = data;
        }

        public BattlePlan(string RaceID)
        {
            this.xRaceID = 0;
            this.xBattlePlanNo = 0;
            this.xTactic = 0;
            this.xPrimaryTarget = 0;
            this.xSecondaryTarget = 0;
            this.xAttackWho = 0;
            this.xName = "Default";
            this.RaceID = Conversions.ToInteger(RaceID);
        }

        public int AttackWho
        {
            get
            {
                return this.xAttackWho;
            }
            set
            {
                if ((value >= 0) & (value <= 15))
                {
                    this.xAttackWho = value;
                }
            }
        }

        public byte[] BattlePlanData
        {
            get
            {
                byte[] buffer3 = new byte[0x3e9];
                buffer3[0] = (byte) (this.xRaceID + (this.xBattlePlanNo * 0x10));
                buffer3[1] = (byte) this.xTactic;
                buffer3[2] = (byte) (this.xPrimaryTarget + (this.xSecondaryTarget * 0x10));
                buffer3[3] = (byte) this.xAttackWho;
                byte[] buffer2 = functions.EncodeText(this.xName);
                buffer3[4] = (byte) buffer2.Length;
                int num2 = buffer2.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    buffer3[5 + i] = buffer2[i];
                }
                return (byte[]) Utils.CopyArray((Array) buffer3, new byte[(4 + buffer2.Length) + 1]);
            }
            set
            {
                this.xRaceID = value[0] & 15;
                this.xBattlePlanNo = (int) Math.Round(Conversion.Int((double) (((double) value[0]) / 16.0)));
                this.xTactic = value[1];
                this.xPrimaryTarget = value[2] & 15;
                this.xSecondaryTarget = (int) Math.Round(Conversion.Int((double) (((double) value[2]) / 16.0)));
                this.xAttackWho = value[3];
                this.xName = Conversions.ToString(functions.DecodeText(value, 5, value[4]));
            }
        }

        public int BattlePlanNo
        {
            get
            {
                return this.xBattlePlanNo;
            }
            set
            {
                if ((value >= 0) & (value <= 15))
                {
                    this.xBattlePlanNo = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return this.xName;
            }
            set
            {
                this.xName = value;
            }
        }

        public int PrimaryTarget
        {
            get
            {
                return this.xPrimaryTarget;
            }
            set
            {
                if ((value >= 0) & (value <= 15))
                {
                    this.xPrimaryTarget = value;
                }
            }
        }

        public int RaceID
        {
            get
            {
                return this.xRaceID;
            }
            set
            {
                if ((value >= 0) & (value <= 15))
                {
                    this.xRaceID = value;
                }
            }
        }

        public int SecondaryTarget
        {
            get
            {
                return this.xSecondaryTarget;
            }
            set
            {
                if ((value >= 0) & (value <= 15))
                {
                    this.xSecondaryTarget = value;
                }
            }
        }

        public int Tactic
        {
            get
            {
                return this.xTactic;
            }
            set
            {
                if ((value >= 0) & (value <= 0xff))
                {
                    this.xTactic = value;
                }
            }
        }
    }
}

