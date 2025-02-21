namespace LeaveManagementSystem.Web.Models.Periods
{
    public class PeriodEditVM : BasePeriodsTypeVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "This field must have minimum of 4 chars or maximum 150 chars, please fill out correctly")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Start Date must be filled, please select a start date")]
        public DateOnly StartDate { get; set; }
        [Required(ErrorMessage = "End Date must be filled, please select a end date")]
        public DateOnly EndDate { get; set; }
    }
}
