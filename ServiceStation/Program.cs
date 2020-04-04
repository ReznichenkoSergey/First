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
            Vehicle vehicle = new Vehicle("Mazda", "CX5");
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

            Vehicle vehicle2 = new Vehicle("Toyota", "Camri");
            try
            {
                vehicle2.SelectStation(service);
                vehicle2.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.CarWash, vehicle),
                    new WorkRequest(WorkType.CheckEngine, vehicle),
                    new WorkRequest(WorkType.CheckAcceleration, vehicle)
                });
                vehicle2.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle2.GetFullName()} {ex.Message}");
            }

            Console.WriteLine();
            Vehicle vehicle3 = new Vehicle("Nissan", "Almera");
            try
            {
                vehicle3.SelectStation(service);
                vehicle3.AddRangeWorkRequest(new List<WorkRequest>
                {
                    new WorkRequest(WorkType.ChangeOil, vehicle)
                });
                vehicle3.StartWorking();
            }
            catch (Exception ex)
            {
                PrintToConsole($"Ошибка: {vehicle2.GetFullName()} {ex.Message}");
            }

            //Выставляем счета для клиента
            PrintToConsole($"Перечень работ по {vehicle.GetFullName()}",false, ConsoleColor.Green);
            PrintVehicleReport(vehicle);
            Console.WriteLine();

            PrintToConsole($"Перечень работ по {vehicle2.GetFullName()}", false, ConsoleColor.Green);
            PrintVehicleReport(vehicle2);
            Console.WriteLine();

            PrintToConsole($"Перечень работ по {vehicle3.GetFullName()}", false, ConsoleColor.Green);
            PrintVehicleReport(vehicle3);
            Console.WriteLine();

            //Подводим итог работы СТО
            PrintToConsole($"Перечень всех выполненных работ СТО", false, ConsoleColor.Green);
            PrintToConsole($"{"Услуга".PadRight(20)}\t| {"Кол-во".PadRight(8)}\t| {"Начислено".PadRight(8)}\t| {"Скидка(%)".PadRight(8)}\t| ИТОГО", false, ConsoleColor.Cyan);
            var serviceRequestList = service.GetWorkRequestListDone()
                .GroupBy(x => x.WorkType)
                .Select(x => new { WorkTypeCipher = x.Key, Count = x.Count(), Sum = x.Sum(y => y.GetWorkSum()), DiscontPercent = x.Sum(y => y.GetPercentDiscount()) })
                .ToList();
            serviceRequestList
                .ForEach(x => PrintToConsole($"{x.WorkTypeCipher.ToString().PadRight(20)}\t| {x.Count.ToString().PadRight(8)}\t| {x.Sum.ToString("F2").PadRight(8)}\t| {Math.Round(x.Sum * x.DiscontPercent / 100, 2).ToString("F2").PadRight(8)}\t| {(x.Sum - Math.Round(x.Sum * x.DiscontPercent / 100, 2)).ToString("F2")}"));
            var sum = serviceRequestList
                .Sum(x => x.Sum - Math.Round(x.Sum * x.DiscontPercent / 100, 2));
            PrintToConsole($"{"ИТОГО".PadRight(20)}\t  {"".PadRight(8)}\t  {"".PadRight(8)}\t  {"".PadRight(8)}\t  {sum.ToString("F2")}", true, ConsoleColor.Yellow);

            Console.ReadLine();
        }

        private static void PrintVehicleReport(Vehicle vehicle)
        {
            PrintToConsole($"{"Услуга".PadRight(8)}\t| {"Начислено".PadRight(8)}\t| {"Скидка(%)".PadRight(8)}\t| ИТОГО", false, ConsoleColor.Cyan);
            vehicle.WorkRequestCodeList
                .Select(x => vehicle.ServiceStation.GetWorkRequestValues(x))
                .ToList()
                .ForEach(x => PrintToConsole($"{x.WorkType.ToString().PadRight(8)}\t| {x.GetWorkSum().ToString("F2").PadRight(8)}\t| {x.GetPercentDiscount().ToString("F2").PadRight(8)}\t| {Math.Round(x.GetWorkSum() - (x.GetWorkSum() * x.GetPercentDiscount() / 100), 2).ToString("F2").PadRight(8)}"));
            var sum = vehicle.WorkRequestCodeList
                .Select(x => vehicle.ServiceStation.GetWorkRequestValues(x))
                .ToList()
                .Sum(x => (Math.Round(x.GetWorkSum() - (x.GetWorkSum() * x.GetPercentDiscount() / 100), 2)));
            PrintToConsole($"{"ИТОГО".PadRight(8)}\t  {"".PadRight(8)}\t  {"".PadRight(8)}\t  {sum.ToString("F2")}", true, ConsoleColor.Yellow);
        }

        private void PrintRequestLine(WorkRequest x)
        {
            //PrintToConsole($"{x.WorkType} | {x.GetWorkSum()} | {x.GetPercentDiscount()} | {Math.Round(x.GetWorkSum() - (x.GetWorkSum() * x.GetPercentDiscount() / 100), 2)}");
            PrintToConsole($"{x.WorkType} | S | % | A");
        }

    }
}
