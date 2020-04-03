using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public abstract class BaseStation
    {
        public StationType StationType { get; private set; }

        public BaseStation(StationType stationType)
        {
            StationType = stationType;
        }
    }
}
