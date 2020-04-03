using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Models
{
    /// <summary>
    /// Тип станции
    /// </summary>
    public enum StationType
    {
        /// <summary>
        /// Масло
        /// </summary>
        ServiceOil,
        /// <summary>
        /// Мойка
        /// </summary>
        CarWash,
        /// <summary>
        /// Топливо
        /// </summary>
        ServiceEngine,
        /// <summary>
        /// Развал
        /// </summary>
        AccelerationService
    }
}
