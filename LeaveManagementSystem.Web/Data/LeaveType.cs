﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType : BaseEntity
    {
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
        public List<LeaveAllocation>? LeaveAllocations { get; set; }


    }
}
