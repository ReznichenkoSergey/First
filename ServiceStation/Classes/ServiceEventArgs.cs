using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public class OnServiceEventArgs : EventArgs
    {
        /// <summary>
        /// Код заявки
        /// </summary>
        public Guid Code { get; private set; }

        /// <summary>
        /// Тип работ
        /// </summary>
        public WorkType WorkType { get; set; }

        public OnServiceEventArgs(WorkType workType, Guid code)
        {
            Code = code;
            WorkType = workType;
        }
    }
}
