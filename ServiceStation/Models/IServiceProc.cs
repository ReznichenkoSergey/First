using ServiceStation.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Models
{
    public interface IServiceProcedure
    {
        void SelectStation(ServiceStationUnit serviceStation);

        void AddWorkRequest(WorkRequest workRequest);

        void AddRangeWorkRequest(List<WorkRequest> workRequest);
    }
}
