using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public class OnServiceEventArgs : EventArgs
    {
        public bool IsReady { get; set; }

        public StationType StationType { get; set; }

        public OnServiceEventArgs(StationType stationType, bool isReady)
        {
            this.IsReady = isReady;
            this.StationType = stationType;
        }
    }
}
