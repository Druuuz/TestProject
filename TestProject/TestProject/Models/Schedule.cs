using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Schedule
    {

        public int Id { get; set; }
        public Shop Shop { get; set; }
        public int Start_at { get; set; }
        public int Finish_at { get; set; }
        public string WorkDays { get; set; }
    }
}
