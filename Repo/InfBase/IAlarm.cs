
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNotCoreMachineHistory.Models;

namespace AspNotCoreMachineHistory.Repo.InfBase
{
    public interface IAlarm
    {
        IEnumerable<AlarmModel> GetAlarms();
        AlarmModel GetAlarm(int id);
        Task<AlarmModel> AddAlarm(AlarmModel alarms);
        Task<AlarmModel> EditAlarm(AlarmModel alarm,int id);
        bool DeleteAlarm(int id);
    }
}