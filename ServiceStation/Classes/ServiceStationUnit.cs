using System;
using System.Collections.Generic;
using System.Text;
using ServiceStation.Models;

namespace ServiceStation.Classes
{
    public delegate void ReadyToWork(object sender, OnServiceEventArgs e);

    public delegate void CanIServe();

    /// <summary>
    /// Точка обслуживания
    /// </summary>
    public class ServiceStationUnit : BaseStation
    {
        public List<StationWorkType> WorkTypes { get; private set; }

        public event ReadyToWork ReadyToWork;

        bool IsReady;

        public ServiceStationUnit(StationType stationType) : base(stationType)
        {
            WorkTypes = new List<StationWorkType>();
        }

        public void AddWorkType(StationWorkType stationWorkType)
        {
            if (this.WorkTypes.Contains(stationWorkType))
                this.WorkTypes.Add(stationWorkType);
        }

        public void CarServe()
        {
            ReadyToWork?.Invoke(this, new OnServiceEventArgs(this.StationType, this.IsReady));
        }


    }
}
