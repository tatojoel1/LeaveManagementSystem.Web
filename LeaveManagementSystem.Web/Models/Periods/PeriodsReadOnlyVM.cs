namespace LeaveManagementSystem.Web.Models.Periods
{
    public class PeriodsReadOnlyVM : BasePeriodsTypeVM
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
