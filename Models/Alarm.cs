using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNotCoreMachineHistory.Models
{
    public  class AlarmModel
    { 
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Group { get; set; }
        public string Message {get;set;}
        public int Type { get; set; }
        public DateTime Created { get; set; }
    }
}