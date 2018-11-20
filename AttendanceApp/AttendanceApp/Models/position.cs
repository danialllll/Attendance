using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class position
    {
        public int Id { get; set; }
        public string  positionName { get; set; }
        public double salary { get; set; }
        public ICollection<ApplicationUser> person { get; set; }
    }
}