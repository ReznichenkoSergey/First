using ServiceStation.Classes;
using ServiceStation.Models;
using System.Linq;

namespace ServiceStation
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceStationUnit CarWash = new ServiceStationUnit(StationType.CarWash);
            ServiceStationUnit Oil = new ServiceStationUnit(StationType.ServiceOil);
            ServiceStationUnit Engine = new ServiceStationUnit(StationType.ServiceEngine);

            //
            Vehicle vehicle = new Vehicle("Mazda");
            vehicle.AddService(CarWash);
            vehicle.Subscribe(CarWash);

            vehicle.AddService(Oil);
            vehicle.Subscribe(Oil);

            //
            Vehicle vehicle2 = new Vehicle("Kia");
            vehicle.AddService(CarWash);
            vehicle.Subscribe(CarWash);

            vehicle.AddService(Engine);
            vehicle.Subscribe(Engine);

            //

            var tem = vehicle.ServiceStationUnits
                .Select(x=> new { TypeCipher = x.StationType.ToString()});


        }

        
    }
}
