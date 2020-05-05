using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNotCoreMachineHistory.Models;

namespace AspNotCoreMachineHistory.DataBase
{
    public class DataBaseContext : DbContext
    {
        public  DbSet<HistoryModel> History {get;set;}
        public  DbSet<AlarmModel> Alarm {get;set;}
        public DataBaseContext()
        {
        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
    }

}