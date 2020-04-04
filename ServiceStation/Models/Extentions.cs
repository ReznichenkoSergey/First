using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public static class Extentions
    {
        public static void PrintToConsole(object obj, bool printNewLineAfter = false, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj);
            if (printNewLineAfter)
                Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Расценки на виды услуг
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal GetPercentDiscount(this WorkRequest workRequest)
        {
            switch (workRequest.WorkType)
            {
                case WorkType.CarWash:
                    return 2;
                case WorkType.ChangeOil:
                    return 5;
                case WorkType.CheckAcceleration:
                    return 5;
                case WorkType.CheckEngine:
                    return 7;
                default:
                    return 0;
            }
        }

        public static decimal GetWorkSum(this WorkRequest workRequest)
        {
            switch (workRequest.WorkType)
            {
                case WorkType.CarWash:
                    return 100;
                case WorkType.ChangeOil:
                    return 500;
                case WorkType.CheckAcceleration:
                    return 700;
                case WorkType.CheckEngine:
                    return 1000;
                default:
                    return 0;
            }
        }

    }

}
