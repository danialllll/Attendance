using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class rule
    {
        public int id { get; set; }
       
        [Required(ErrorMessage = "فیلد ساعت کاری روزانه اجباری است"), Display(Name = "ساعت کاری روزانه")]
        public int workingHour { get; set; }

        [Required(ErrorMessage = "فیلد شروع ساعت کاری روزانه اجباری است"), Display(Name = "شروع ساعت کاری")]
        public int startWorkTime { get; set; }

        [Required(ErrorMessage = "فیلد پایان ساعت کاری روزانه اجباری است"), Display(Name = "پایان ساعت کاری")]
        public int endWorkTime { get; set; }

        [Required(ErrorMessage = "فیلد ضریب اضافه کاری روزانه اجباری است"), Display(Name = "ضریب اضافه کاری")]
        public int overWorkRate { get; set; }

        [Required(ErrorMessage = "فیلد ضریب ماموریت روزانه اجباری است"), Display(Name = "ضریب اضافه ماموریت")]
        public int sendOutRate { get; set; }

        [Required(ErrorMessage = "فیلد ضریب تاخیر روزانه اجباری است"), Display(Name = "ضریب تاخیر")]
        public int delayRate { get; set; }

        [Required(ErrorMessage = "فیلد تعداد ساعت مرخصی مجاز ماهانه روزانه اجباری است"), Display(Name = "مرخصی مجاز ماهانه به ساعت")]
        public int restLimit { get; set; }
    }
}