using ServiceStation.Classes;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using static ServiceStation.Classes.Extentions;

namespace ServiceStation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Workroom> workrooms = new List<Workroom>
            {
                new Workroom(WorkType.CarWash),
                new Workroom(WorkType.ChangeOil),
                new Workroom(WorkType.CheckAcceleration),
                new Workroom(WorkType.CheckEngine)
            };
            ServiceStationUnit service = new ServiceStationUnit(workrooms);

            Console.WriteLine();
            Vehicle vehicle = new Vehicle("Mazda", "CX5", EngineTypes.Diesel, 2m);
            try
            {
                vehicle.SelectStation(service);
                vehicle.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.CarWash, vehicle),
                    new WorkRequest(WorkType.ChangeOil, vehicle)
                });
                vehicle.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle.GetFullName()} {ex.Message}");
            }

            Vehicle vehicle2 = new Vehicle("Toyota", "Camri", EngineTypes.Gas, 3.5m);
            try
            {
                vehicle2.SelectStation(service);
                vehicle2.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.CarWash, vehicle2),
                    new WorkRequest(WorkType.CheckEngine, vehicle2),
                    new WorkRequest(WorkType.CheckAcceleration, vehicle2)
                });
                vehicle2.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle2.GetFullName()} {ex.Message}");
            }

            Console.WriteLine();
            Vehicle vehicle3 = new Vehicle("Nissan", "Almera", EngineTypes.Gas, 1.5m);
            try
            {
                vehicle3.SelectStation(service);
                vehicle3.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.ChangeOil, vehicle3)
                });
                vehicle3.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle2.GetFullName()} {ex.Message}");
            }

            Console.WriteLine();
            Vehicle vehicle4 = new Vehicle("Suzuki", "Vitara", EngineTypes.Gas, 2.0m);
            try
            {
                vehicle4.SelectStation(service);
                vehicle4.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.ChangeOil, vehicle4),
                    new WorkRequest(WorkType.CheckEngine, vehicle4),
                    new WorkRequest(WorkType.CheckAcceleration, vehicle4)
                });
                vehicle4.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle2.GetFullName()} {ex.Message}");
            }

            //Выставляем счета для клиента
            PrintToConsole($"Перечень работ по {vehicle.GetFullName()}",false, ConsoleColor.Green);
            Report.PrintVehicleReport(vehicle);
            Console.WriteLine();

            PrintToConsole($"Перечень работ по {vehicle2.GetFullName()}", false, ConsoleColor.Green);
            Report.PrintVehicleReport(vehicle2);
            Console.WriteLine();

            PrintToConsole($"Перечень работ по {vehicle3.GetFullName()}", false, ConsoleColor.Green);
            Report.PrintVehicleReport(vehicle3);
            Console.WriteLine();

            PrintToConsole($"Перечень работ по {vehicle4.GetFullName()}", false, ConsoleColor.Green);
            Report.PrintVehicleReport(vehicle4);
            Console.WriteLine();

            //Подводим итог работы СТО
            PrintToConsole($"Перечень всех выполненных работ СТО", false, ConsoleColor.Green);
            Report.PrintStationReport(service);

            Console.ReadLine();
        }

    }
}
