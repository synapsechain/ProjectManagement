using System;
using System.ComponentModel;

namespace ProjectManagement.Api.Models
{
    public class ExcelRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Description("Project code/Task description")]
        public string Description { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
