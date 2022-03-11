using EntityFrameWorkPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameWorkPractice.View_Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}