using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Try3.Data;
using Try3.Models;

namespace Try3.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _conext;
        public StudentsController(ApplicationDbContext context)
        {
            _conext = context;
        }

        public IActionResult Index()
        {
            var result = _conext.Student.Include(x=> x.Department)
                                        .OrderBy(x => x.studentName)
                                        .ToList();
            return View(result);
        }

        public IActionResult Create() // To go to Create page
        {
            ViewBag.Department = _conext.Department.OrderBy(x => x.departmentName)
                                                  .ToList(); //bring it orgnized 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model) // to send the creation to the list 
        {
            if(ModelState.IsValid)
            {
                _conext.Student.Add(model); //add it to the model
                _conext.SaveChanges();
                return RedirectToAction(nameof(Index));  // Go to this page after adding seccussfully
            }
            ViewBag.Department = _conext.Department.OrderBy(x => x.departmentName)
                                                           .ToList(); //bring it orgnized
            return View();
        }

     
        public IActionResult Edit(int? Id) 
        {
            ViewBag.Department = _conext.Department.OrderBy(x => x.departmentName)
                                                        .ToList(); //bring it orgnized
            var Result = _conext.Student.Find(Id);

            return View("Create",Result); // Go to Create view with this data Same AS GP1
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                _conext.Student.Update(model); //update this model
                _conext.SaveChanges();
                return RedirectToAction(nameof(Index));  // Go to this page after adding seccussfully
            }
            ViewBag.Department = _conext.Department.OrderBy(x => x.departmentName)
                                                           .ToList(); //bring it orgnized
            return View(model);
        }


        public IActionResult Delete(int? Id) 
        {
            var Result = _conext.Student.Find(Id);
            if(Result != null)
            {
                _conext.Student.Remove(Result); 
                _conext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

