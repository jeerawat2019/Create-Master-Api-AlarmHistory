using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNotCoreMachineHistory.Models
{
    public class HistoryModel 
    {
        [Key]
        public int? Id { get; set; }
        public DateTime Created { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Message {get;set;}        
       
       
    }
}