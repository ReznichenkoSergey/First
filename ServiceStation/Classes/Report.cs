using System;
using System.Linq;
using static ServiceStation.Classes.Extentions;

namespace ServiceStation.Classes
{
    /// <summary>
    /// Отчет по работам
    /// </summary>
    public static class Report
    {
        /// <summary>
        /// Отчет по проведенным работам над авто
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vehicle"></param>
        public static void PrintVehicleReport<T>(T vehicle)
            where T : Vehicle
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

        /// <summary>
        /// Отчет по итогу работы СТО
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public static void PrintStationReport<T>(T service)
            where T : ServiceStationUnit
        {
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
        }
    }
}
