using Microsoft.AspNetCore.Mvc;
using Try3.Data;

namespace Try3.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _conext;
        public DepartmentsController(ApplicationDbContext context)
        {
            _conext=context;
        }
        public IActionResult Index()
        {
            var result = _conext.Department.ToList();       
            return View(result);
        }
    }
}
