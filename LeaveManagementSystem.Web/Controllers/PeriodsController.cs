using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.Periods;
using LeaveManagementSystem.Web.Services.Periods;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class PeriodsController(IPeriodsService _periodsService) : Controller
    {
        // GET: Periods
        /// <summary>
        /// Index data, all the registers obtained from DB
        /// </summary>
        /// <returns>data returned from DB</returns>
        public async Task<IActionResult> Index()
        {
            var viewData = await _periodsService.GetAll();
            return View(viewData);
        }

        // GET: Periods/Details/5
        /// <summary>
        /// Obtain the detail of specific register
        /// </summary>
        /// <param name="id">Id of register</param>
        /// <returns>data returned from DB</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodsService.Get<PeriodsReadOnlyVM>(id.Value);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // GET: Periods/Create
        /// <summary>
        /// View method for Create Period
        /// </summary>
        /// <returns>data returned from DB</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periods/Create
        /// <summary>
        /// Method to create a Period register
        /// </summary>
        /// <param name="periodCreate">Entity with values from client side</param>
        /// <returns>OK Response, in case of error, error will be returned</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PeriodCreateVM periodCreate)
        {
            //TODO: (Create Period) If we want to validate if period exist, we need to add a logic to check if a period exist between two dates
            if (ModelState.IsValid)
            {
                await _periodsService.Create(periodCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(periodCreate);
        }

        // GET: Periods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodsService.Get<PeriodEditVM>(id.Value);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

        // POST: Periods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PeriodEditVM periodEdit)
        {
            if (id != periodEdit.Id)
            {
                return NotFound();
            }
            //TODO: (Create Period) If we want to validate if period exist, we need to add a logic to check if a period exist between two dates

            if (ModelState.IsValid)
            {
                try
                {
                    await _periodsService.Edit(periodEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_periodsService.PeriodExists(periodEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(periodEdit);
        }

        // GET: Periods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodsService.Get<PeriodsReadOnlyVM>(id.Value);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _periodsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
