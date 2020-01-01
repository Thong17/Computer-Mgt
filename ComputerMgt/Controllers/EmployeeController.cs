using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComMgt;

namespace ComputerMgt.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            AppDbContext dbContext = new AppDbContext();
            IEnumerable<Employee> employees = dbContext.Employees;

            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                AppDbContext dbContext = new AppDbContext();
                employee.CreateDate = DateTime.Now;

                dbContext.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Details(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            Employee employee = dbContext.Employees.Single(e => e.Id == id);

            return View(employee);
        }
    }
}