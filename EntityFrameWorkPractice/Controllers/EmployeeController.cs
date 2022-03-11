using EntityFrameWorkPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameWorkPractice.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetEmployee()
        {
            var employees = new List<Employee>()
            {
                new Employee(){  EmployeeID =1065,EmployeeName = "Mark Antony",Salary=15000,DateOfJoining=new DateTime(2022,02,12) },
                new Employee(){  EmployeeID =1066,EmployeeName = "Henry Richard",Salary=10000,DateOfJoining=new DateTime(2022,01,01) },
                new Employee(){  EmployeeID =1067,EmployeeName = "Robert",Salary=18000,DateOfJoining=new DateTime(2021,12,24) },
                new Employee(){  EmployeeID =1068,EmployeeName = "Stephen",Salary=26000,DateOfJoining=new DateTime(2021,07,19) },
                new Employee(){  EmployeeID =1069,EmployeeName = "Princy",Salary=13000,DateOfJoining=new DateTime(2022,02,13) }
            };
            return View(employees);
        }
    }
}