namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using System;
    using System.Diagnostics;

    public class XFile
    {
        public Design[] Designs = new Design[0x1a];
        public int Filetype = 1;
        public int GameID = -1;
        public int PlayerID = -1;
        public int TurnNo = -1;

        public int AddObject(object obj)
        {
            int num;
            switch (Strings.UCase(obj.GetType().Name))
            {
                case "HEADER":
                {
                    Header header = (Header) obj;
                    this.GameID = (int) header.GameID;
                    this.PlayerID = header.PlayerID;
                    this.TurnNo = header.TurnNo;
                    this.Filetype = header.FileType;
                    return num;
                }
                case "DESIGN":
                {
                    Design design = (Design) obj;
                    if (design.DeletedDesign)
                    {
                        this.Designs[design.DesignID] = null;
                        return num;
                    }
                    this.Designs[design.DesignID] = design;
                    return num;
                }
            }
            Debug.Print(obj.GetType().Name);
            return num;
        }
    }
}

