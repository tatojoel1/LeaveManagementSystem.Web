using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Models.Periods;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.Periods
{
    public class PeriodsService(ApplicationDbContext _context, IMapper _mapper) : IPeriodsService
    {
        /// <summary>
        /// Get all information about periods data
        /// </summary>
        /// <returns>Data returned from DB</returns>
        public async Task<List<PeriodsReadOnlyVM>> GetAll()
        {
            //Get the databa from DB
            var data = await _context.Periods.ToListAsync();

            //Convert the datamodel into a View Model - Using AutoMapper
            var viewData = _mapper.Map<List<PeriodsReadOnlyVM>>(data);
            return viewData;
        }

        /// <summary>
        /// Generic method to get info from specific table, model or entity from database
        /// </summary>
        /// <typeparam name="T">Table, Model, Entity</typeparam>
        /// <param name="id">Id to consult</param>
        /// <returns>Data returned from DB</returns>
        public async Task<T?> Get<T>(int id) where T : class
        {
            var data = await _context.Periods.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var viewData = _mapper.Map<T>(data);
            return viewData;
        }

        /// <summary>
        /// Remove method to delete an specific register from DB
        /// </summary>
        /// <param name="id">Id to delete</param>
        /// <returns>In case of error, return an error, if everything its ok, return like 201 HTTP status</returns>
        public async Task Remove(int id)
        {
            var data = await _context.Periods.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Periods.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Method to edit a period register
        /// </summary>
        /// <param name="model">Entity properties to edit, normally comes from client side</param>
        /// <returns>OK response, in case of error: error entity</returns>
        public async Task Edit(PeriodEditVM model)
        {
            var period = _mapper.Map<Period>(model);
            _context.Update(period);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to create period register
        /// </summary>
        /// <param name="model">Entity properties necessary to create a period register</param>
        /// <returns>OK response, in case of error: error entity</returns>
        public async Task Create(PeriodCreateVM model)
        {
            var period = _mapper.Map<Period>(model);
            _context.Add(period);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Check if an specific period with the Id, exist in the DB
        /// </summary>
        /// <param name="id">Id of register</param>
        /// <returns>OK response, in case of error: error entity</returns>
        public bool PeriodExists(int id)
        {
            return _context.Periods.Any(e => e.Id == id);
        }
    }
}
