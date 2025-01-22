using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
{
    /// <summary>
    /// Get all the Leave Type info from Database
    /// </summary>
    /// <returns>Data returned from DB</returns>
    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        //Partially move it to the var data to see what is the content of response server            
        var data = await _context.LeaveTypes.ToListAsync();

        //Convert the datamodel into a View Model - Using AutoMapper
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
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
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
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
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string? name)
    {
        var lowerCaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowerCaseName = leaveTypeEdit.Name?.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName) && q.Id != leaveTypeEdit.Id);
    }
}
