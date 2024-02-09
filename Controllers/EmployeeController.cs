using KendoUIAppNew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KendoUIAppNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
       // private EmployeeDbContext EmpDbContext { get; }
       private readonly EmployeeDbContext _dbContext;

    public EmployeeController(EmployeeDbContext EmpDbContext)
    {
            _dbContext = EmpDbContext; // Initialize your DbContext here
    }

    // GET: Employee/Index
    public ActionResult Index()
    {
        return View();
    }

    // GET: Employee/GetAllEmployees
    [HttpGet]
    public JsonResult GetAllEmployees()
    {
            var employees = _dbContext.Employees.ToList();
            return Json(employees);

        }

        // POST
    [HttpPost]
    public ActionResult SaveEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                // Map view model to entity
                var employee = new Employee
                {
                    EmpName = model.EmpName,
                    Address = model.Address,
                    Department = model.Department,
                    DateOfBirth = model.DateOfBirth,
                    Account = model.Account
                };

                // Save to database
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();

                return Json(new { success = true });
            }
            else
            {
                // Validation failed
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = "Validation failed" });
            }
        }

    }
}
