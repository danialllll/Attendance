using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class position
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "فیلد سمت اجباری است"), Display(Name = "نام سمت")]
        public string  positionName { get; set; }

        [Required(ErrorMessage = "فیلد حقوق تولد اجباری است"), Display(Name = "حقوق ماهانه به تومان")]
        public double salary { get; set; }
        public ICollection<ApplicationUser> person { get; set; }
    }
}