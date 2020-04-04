using System;

namespace ServiceStation.Classes
{
    public delegate void RequestDone(object sender, OnServiceEventArgs e);
    
    /// <summary>
    /// Точка обслуживания
    /// </summary>
    public class Workroom
    {
        /// <summary>
        /// Тип мастерской
        /// </summary>
        public WorkType WorkType { get; private set; }

        /// <summary>
        /// Завершение выполнения услуги
        /// </summary>
        public event RequestDone RequestDone;

        public Workroom(WorkType stationType)
        {
            WorkType = stationType;
        }
        
        public void CarServe(Guid guid)
        {
            Console.WriteLine($"Мастерская: {WorkType}, заявка {guid} обработана!");
            //
            RequestDone?.Invoke(this, new OnServiceEventArgs(WorkType, guid));
        }
    }
}
