using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ServiceStation.Classes.Extentions;

namespace ServiceStation.Classes
{
    public class Vehicle : Autocar, IServiceProcedure
    {        
        /// <summary>
        /// Коды заявок
        /// </summary>
        public List<Guid> WorkRequestCodeList;

        /// <summary>
        /// Выбранное СТО
        /// </summary>
        public ServiceStationUnit ServiceStation { get; private set; }

        public Vehicle(string manufacturedCompany, string modelCipher, EngineTypes engineTypes) :base(manufacturedCompany, modelCipher, EngineTypes engineTypes)
        {
            WorkRequestCodeList = new List<Guid>();
        }

        /// <summary>
        /// Добавить СТО
        /// </summary>
        /// <param name="serviceStation"></param>
        public void SelectStation(ServiceStationUnit serviceStation)
        {
            ServiceStation = serviceStation;
            ServiceStation.WorkDone += ServiceStation_WorkDone;
            ServiceStation.RequestDone += ServiceStation_RequestDone;
        }

        private void ServiceStation_RequestDone(object sender, OnServiceEventArgs e)
        {
            if (WorkRequestCodeList.Contains(e.Code))
            {
                WorkRequest workRequest = ServiceStation.GetWorkRequestValues(e.Code);
                PrintToConsole($"Клиент: заявка {workRequest.WorkType} обработана!");
            }
        }

        private void ServiceStation_WorkDone(Vehicle vehicle)
        {
            if(vehicle.Equals(this))
                PrintToConsole($"СТО: Ваши работы выполнены!", true);
        }

        /// <summary>
        /// Добавить заявку
        /// </summary>
        /// <param name="workRequest"></param>
        public void AddWorkRequest(WorkRequest workRequest)
        {
            if (ServiceStation != null)
            {
                if (!ServiceStation.WorkRequestExists(workRequest.WorkType, this))
                {
                    ServiceStation.AddWorkRequest(workRequest);
                    //
                    this.WorkRequestCodeList.Add(workRequest.Code);
                }
                else
                    PrintToConsole($"Заявка {workRequest.WorkType} существует!", true);
            }
            else
                throw new NullReferenceException("СТО не выбрано!");
        }

        /// <summary>
        /// Добавить список заявок
        /// </summary>
        /// <param name="workRequest"></param>
        public void AddRangeWorkRequest(List<WorkRequest> workRequest)
        {
            ServiceStation.AddRangeWorkRequest(workRequest);
            //
            this.WorkRequestCodeList.AddRange(workRequest.Select(x => x.Code));
        }

        /// <summary>
        /// Начать выполнение работ
        /// </summary>
        public void StartWorking()
        {
            ServiceStation.ExecuteWorkRequests(WorkRequestCodeList);
        }

    }
}
