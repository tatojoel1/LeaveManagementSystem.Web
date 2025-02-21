using LeaveManagementSystem.Web.Models.Periods;

namespace LeaveManagementSystem.Web.Services.Periods
{
    public interface IPeriodsService
    {
        Task Create(PeriodCreateVM model);
        Task Edit(PeriodEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<PeriodsReadOnlyVM>> GetAll();
        bool PeriodExists(int id);
        Task Remove(int id);
    }
}