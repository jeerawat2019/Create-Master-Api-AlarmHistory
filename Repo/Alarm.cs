using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using AspNotCoreMachineHistory.Models;
using AspNotCoreMachineHistory.Repo.InfBase;
using AspNotCoreMachineHistory.DataBase;

namespace AspNotCoreMachineHistory.Repo 
{
    public class AlarmRepo : IAlarm
    {
        private readonly IHttpContextAccessor mHttpContextAccessor;
        private readonly IWebHostEnvironment mWebHostEnvironment;
        public DataBaseContext mContext { get;}
        public AlarmRepo (DataBaseContext context,IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
            this.mHttpContextAccessor = httpContextAccessor;
            this.mWebHostEnvironment  = webHostEnvironment;
            this.mContext = context;
        }
        public async Task<AlarmModel> AddAlarm(AlarmModel alarms)
        {
            this.mContext.Alarm.Add(alarms);
            this.mContext.SaveChanges();
            return alarms;
        }

        public bool DeleteAlarm(int id)
        {
            var result = GetProduct(id);
            if(result != null)
              return false;
            this.mContext.Alarm.Remove(result);
            this.mContext.SaveChanges();
            return true;
        }
        private AlarmModel GetProduct(int id)
        {
            return this.mContext.Alarm.SingleOrDefault(a=>a.Id == id);
        }
        public async Task<AlarmModel> EditAlarm(AlarmModel alarm, int id)
        {
            var result = GetProduct(id);
            if(result != null)
            {
                result.Code = alarm.Code;
                result.Description = alarm.Description;
                result.Created = alarm.Created;

                this.mContext.Alarm.Update(result);
                this.mContext.SaveChanges();

            }
            return result;
        }

        public AlarmModel GetAlarm(int id)
        {
            return this.mContext.Alarm.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<AlarmModel> GetAlarms()
        {
            return this.mContext.Alarm.ToList();
        }
    }
}