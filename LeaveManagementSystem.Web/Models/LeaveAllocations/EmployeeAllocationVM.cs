namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        public DateOnly DateOfBirth { get; set; }
        public bool IsCompletedAllocation { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
