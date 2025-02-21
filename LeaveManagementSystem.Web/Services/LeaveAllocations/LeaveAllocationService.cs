using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationService(ApplicationDbContext _context, IMapper _mapper, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager) : ILeaveAllocationService
    {
        public async Task AllocateLeave(string employeeId)
        {
            //get all the leave types
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId ==  employeeId))
                .ToListAsync();

            //get the current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            var monthsRemaining = period.EndDate.Month - currentDate.Month;

            //foreach leave type, create an allocation entry
            //calculate leave based on number of months left in the period
            foreach (var leaveType in leaveTypes)
            {
                //Works, but it is not the best practice to implement
                //var allocationsExists = await AllocationExist(employeeId, period.Id, leaveType.Id);
                //if (allocationsExists)
                //{
                //    continue;
                //}
                var acurralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var daysCalculations = (int)Math.Ceiling(acurralRate * monthsRemaining);
                var leaveAllocation = new LeaveAllocation()
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = daysCalculations
                };

                _context.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
                : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(user?.Id);
            var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();
            
            var employeeVm = new EmployeeAllocationVM()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count
            };

            return employeeVm;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());
            return employees;
        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {
            //string? employeeId = string.Empty;
            //if (string.IsNullOrEmpty(userId))
            //{
            //    employeeId = userId;
            //}
            //else
            //{
            //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            //    employeeId = user?.Id;
            //}

            var currentDate = DateTime.Now;
            var leaveAllocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocation;
        }

        private async Task<bool> AllocationExist(string? userId, int periodId, int leaveTypeId)
        {
            var exist = await _context.LeaveAllocations.AnyAsync(
                q => q.EmployeeId == userId
                && q.LeaveTypeId == leaveTypeId
                && q.PeriodId == periodId
            );
            return exist;
        }
    }
}
