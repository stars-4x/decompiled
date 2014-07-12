namespace AtlantisSoftware
{
    using System;

    public class WayPointTask
    {
        private byte[] xData;

        public WayPointTask(byte[] Data)
        {
            this.WaypointTaskData = Data;
        }

        public byte[] WaypointTaskData
        {
            get
            {
                return this.xData;
            }
            set
            {
                this.xData = value;
            }
        }
    }
}

