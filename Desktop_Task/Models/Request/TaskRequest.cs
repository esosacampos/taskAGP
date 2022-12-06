using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Task.Models.Request
{
    public class TaskRequest
    {
        public int idTask { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime end_date { get; set; }
        public DateTime start_date { get; set; }
        public string priority_level { get; set; }
    }
}
