using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    /// <summary>
    /// Тип работ
    /// </summary>
    public enum WorkType
    {
        /// <summary>
        /// Замена масла
        /// </summary>
        ChangeOil,
        /// <summary>
        /// Мойка машины
        /// </summary>
        CarWash,
        /// <summary>
        /// Диагностика двигателя
        /// </summary>
        CheckEngine,
        /// <summary>
        /// Развал/схождение
        /// </summary>
        CheckAcceleration
    }
}
