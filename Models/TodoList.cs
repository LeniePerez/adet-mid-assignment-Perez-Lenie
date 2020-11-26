using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adet_mid_assignment_Perez_Lenie.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string DateCreated { get; set; }
        public string DateStarted { get; set; }
        public string DateFinished { get; set; }
        public int Tot_Hours { get; set; }
        public string IsDone { get; set; }
    }
}
