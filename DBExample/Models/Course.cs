using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Teacher Teacher { get; set; }
        public List< Student> Students { get; set; }
    }
}