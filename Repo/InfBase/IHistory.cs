

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNotCoreMachineHistory.Models;

namespace AspNotCoreMachineHistory.Repo.InfBase
{
    public interface IHistory 
    {
        IEnumerable<HistoryModel> GetHistory();
        //HistoryModel GetHistory(int id);
        HistoryModel GetHistoryById(int id);
        HistoryModel AddHistory(HistoryModel history);
        HistoryModel EditHistory(HistoryModel history,int id);
        bool DeleteHistory(int id);

    }
}