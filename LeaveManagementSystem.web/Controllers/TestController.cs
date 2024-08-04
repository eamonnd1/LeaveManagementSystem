using LeaveManagementSystem.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Eamonn"
            };
            return View(data);
        }
    }
}
