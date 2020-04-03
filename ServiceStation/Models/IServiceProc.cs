using ServiceStation.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Models
{
    public interface IServiceProc
    {
        void CanIService(ServiceStationUnit serviceStationUnit);
    }
}
