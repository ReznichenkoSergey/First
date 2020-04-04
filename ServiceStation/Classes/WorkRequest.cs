using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class WorkRequest
    {
        /// <summary>
        /// Внутренний код
        /// </summary>
        public Guid Code { get; private set; }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// Тип работ
        /// </summary>
        public WorkType WorkType { get; private set; }

        /// <summary>
        /// Автомобиль
        /// </summary>
        public Vehicle Vehicle { get; private set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        public WorkRequest(WorkType workType, Vehicle vehicle)
        {
            Code = Guid.NewGuid();
            CreateDate = DateTime.Now;
            //
            WorkType = workType;
            Vehicle = vehicle;
            RequestStatus = RequestStatus.IsActive;
        }

        /// <summary>
        /// Заявка выполнена
        /// </summary>
        public void IsDone()
        {
            RequestStatus = RequestStatus.IsDone;
        }

    }
}
