namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ComClass]
    public class Score : Score._Score
    {
        private int xCapitalShips = -1;
        private int xEscortShips = -1;
        private int xPlanets = -1;
        private object xPlayerID = -1;
        private int xRank = -1;
        private int xResources = -1;
        private int xScore = -1;
        private int xStarbases = -1;
        private int xTechLevels = -1;
        private int xUnarmedShips = -1;
        private object xYearNo = -1;

        public Score(byte[] Data)
        {
            int start = 0;
            object objectValue = RuntimeHelpers.GetObjectValue(functions.GetBytes(Data, ref start, 2));
            this.xPlayerID = Operators.AndObject(objectValue, 15);
            this.xRank = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xScore = Conversions.ToInteger(functions.GetBytes(Data, ref start, 4));
            this.xResources = Conversions.ToInteger(functions.GetBytes(Data, ref start, 4));
            this.xPlanets = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xStarbases = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xUnarmedShips = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xEscortShips = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xCapitalShips = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
            this.xTechLevels = Conversions.ToInteger(functions.GetBytes(Data, ref start, 2));
        }

        [DispId(1)]
        public int AtlantisSoftware.Score._Score.YearNo
        {
            get
            {
                return Conversions.ToInteger(this.xYearNo);
            }
        }

        public int YearNo
        {
            get
            {
                return Conversions.ToInteger(this.xYearNo);
            }
            internal set
            {
                this.xYearNo = value;
            }
        }

        [ComVisible(true)]
        public interface _Score
        {
            [DispId(1)]
            int YearNo { [DispId(1)] get; }
        }
    }
}

