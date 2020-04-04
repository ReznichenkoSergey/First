using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceStation.Classes
{
    public delegate void WorkDone(Vehicle vehicle);

    /// <summary>
    /// СТО
    /// </summary>
    public class ServiceStationUnit
    {
        /// <summary>
        /// Мастерские
        /// </summary>
        List<Workroom> WorkroomList;

        /// <summary>
        /// Заявки
        /// </summary>
        List<WorkRequest> WorkRequestList;

        /// <summary>
        /// Работа сделана
        /// </summary>
        public event WorkDone WorkDone;

        /// <summary>
        /// Завершения выполнения заявки
        /// </summary>
        public event RequestDone RequestDone;

        public ServiceStationUnit(List<Workroom> workrooms)
        {
            WorkroomList = new List<Workroom>();
            workrooms
                .ForEach(x => AddWorkrooms(x));
            //
            WorkRequestList = new List<WorkRequest>();
        }

        /// <summary>
        /// Добавляем новую мастерскую для обслуживания на СТО
        /// </summary>
        /// <param name="workroom"></param>
        public void AddWorkrooms(Workroom workroom)
        {
            workroom.RequestDone += Workroom_RequestDone;
            WorkroomList.Add(workroom);
        }

        private void Workroom_RequestDone(object sender, OnServiceEventArgs e)
        {
            var request = WorkRequestList
                .Where(x => x.Code.Equals(e.Code)).Single();
            request.IsDone();
            //
            Console.WriteLine($"СТО: {e.WorkType}, заявка {e.Code} обработана!");
            //
            RequestDone?.Invoke(this, new OnServiceEventArgs(e.WorkType, e.Code));

            //Проверка на выполнение всех работ
            if(!WorkRequestList
                .Any(x=>x.RequestStatus == RequestStatus.IsActive && x.Vehicle.Equals(request.Vehicle)))
            {
                WorkDone?.Invoke(request.Vehicle);
            }
        }

        /// <summary>
        /// Подача заявки на работы
        /// </summary>
        /// <param name="workRequest"></param>
        public void AddWorkRequest(WorkRequest workRequest)
        {
            this.WorkRequestList.Add(workRequest);
        }

        /// <summary>
        /// Подача заявки на работы
        /// </summary>
        /// <param name="workRequestList"></param>
        public void AddRangeWorkRequest(List<WorkRequest> workRequestList)
        {
            workRequestList
                .ForEach(x => { AddWorkRequest(x); });
        }

        /// <summary>
        /// Выполнить работы по коду
        /// </summary>
        public void ExecuteWorkRequests(List<Guid> workRequestCode)
        {
            this.WorkRequestList
                .Where(x => x.RequestStatus == RequestStatus.IsActive && workRequestCode.Contains(x.Code))
                .ToList()
                .ForEach(x=> ExecuteRequest(x));
        }

        private void ExecuteRequest(WorkRequest request)
        {
            var room = WorkroomList
               .Where(x => x.WorkType.Equals(request.WorkType))
               .Take(1)
               .ToList();
            if(room.Count > 0)
            {
                room[0].CarServe(request.Code);
            }
        }

        /// <summary>
        /// Получение данных заявки
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public WorkRequest GetWorkRequestValues(Guid code)
        {
            return WorkRequestList.Where(x => x.Code.Equals(code)).Single();
        }
        
        /// <summary>
        /// Наличие наряда в списке нарядов
        /// </summary>
        /// <param name="workType"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool WorkRequestExists(WorkType workType, Vehicle vehicle)
        {
            return WorkRequestList.Any(x=>x.Vehicle.Equals(vehicle) && x.WorkType.Equals(workType));
        }

        /// <summary>
        /// Получаем выполненные заявки
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WorkRequest> GetWorkRequestListDone()
        {
            return WorkRequestList.Where(x => x.RequestStatus == RequestStatus.IsDone);
        }
    }
}
