using System;
using System.ComponentModel;

namespace ProjectManagement.Data.Models
{
    public class ExcelRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Description("Project code/Task description")]
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
