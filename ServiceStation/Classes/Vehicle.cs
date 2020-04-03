using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public class Vehicle: IServiceProc
    {
        public string Name { get; private set; }

        public List<ServiceStationUnit> ServiceStationUnits { get; private set; }

        public Vehicle(string name)
        {
            this.Name = name;
            this.ServiceStationUnits = new List<ServiceStationUnit>();
        }

        
        public void AddService(ServiceStationUnit serviceStationUnits)
        {
            serviceStationUnits.ReadyToWork += ServiceStation_ReadyToWork;
            this.ServiceStationUnits.Add(serviceStationUnits);
        }

        public void CanIService(ServiceStationUnit serviceStationUnit)
        {
            serviceStationUnit.CarServe();
        }

        public void Subscribe(ServiceStationUnit serviceStation)
        {
            serviceStation.ReadyToWork += ServiceStation_ReadyToWork;
        }

        private void ServiceStation_ReadyToWork(object sender, OnServiceEventArgs e)
        {
            Console.WriteLine($"The station {e.StationType} is {e.IsReady}");
        }
    }
}
