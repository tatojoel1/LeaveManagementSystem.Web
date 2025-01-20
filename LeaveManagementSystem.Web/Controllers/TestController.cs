using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel()
            {
                Name = "Joel Hernandez",
                DateOfBirth = new DateTime(1992, 06, 11)
            };
            return View(data);
        }
    }
}
