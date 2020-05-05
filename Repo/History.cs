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
    public class HistoryRepo : IHistory
    {
        //private readonly IHttpContextAccessor mHttpContextAccessor;
        //private readonly IWebHostEnvironment mWebHostEnvironment;
        public DataBaseContext mContext { get;}
        public HistoryRepo (DataBaseContext context)
        {
            //this.mHttpContextAccessor = httpContextAccessor;
            //this.mWebHostEnvironment  = webHostEnvironment;
            this.mContext = context;
        }
        public HistoryModel AddHistory(HistoryModel history)
        {           
            this.mContext.History.Add(history);
            this.mContext.SaveChanges();
            return history;
        }
        public bool DeleteHistory(int id)
        {
            var result = GetHistoryById(id);
            if(result == null)
              return false;
            this.mContext.History.Remove(result);
            this.mContext.SaveChanges();
            return true;
        }
        public HistoryModel GetHistoryById(int id)
        {
            return this.mContext.History.SingleOrDefault(h=>h.Id == id);
        }
 
        public HistoryModel EditHistory(HistoryModel history, int id)
        {
            var result =  GetHistoryById(id);
            if(result != null)
            {
                result.Code = history.Code;
                result.Created = history.Created;
                result.Message = history.Message;
                result.Type = history.Type;
                this.mContext.History.Update(result);
                this.mContext.SaveChanges();

            }
            return result;
        }

        public IEnumerable<HistoryModel> GetHistory()
        {
            return this.mContext.History.ToList();
        }

    }
}