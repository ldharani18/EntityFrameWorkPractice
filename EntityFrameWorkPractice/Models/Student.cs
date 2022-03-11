using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameWorkPractice.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public int Marks { get; set; }

    }
}