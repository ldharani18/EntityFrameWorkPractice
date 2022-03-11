using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameWorkPractice.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }

    }
}