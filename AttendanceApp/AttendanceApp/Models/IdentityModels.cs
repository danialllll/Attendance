using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AttendanceApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [MaxLength(20, ErrorMessage = "حداکثر طول نام کاربر 2۰ کاراکتر است"), Required(ErrorMessage = "فیلد نام اجباری است"), Display(Name = "نام کارمند")]
        public string name { get; set; }

        [MaxLength(40, ErrorMessage = "حداکثر طول فامیلی 4۰ کاراکتر است"), Required(ErrorMessage = "فیلد فامیلی اجباری است"), Display(Name = "فامیلی کارمند")]
        public string lastName { get; set; }

        [MaxLength(30 , ErrorMessage = "حداکثر طول سمت 3۰ کاراکتر است")]
        [Required(ErrorMessage = "فیلد سمت اجباری است"),Display(Name = "نام سمت")]
        public string positionName { get; set; }

        [MaxLength(500 , ErrorMessage = "حداکثر طول آدرس ۰۰ 5 کاراکتر است")]
        [Required(ErrorMessage = "فیلد آدرس اجباری است"), Display(Name = "آدرس")]
        public string address { get; set; }

        [Required, RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل با فرمت صحیح وارد نشده است"), Display(Name = "موبایل")]
        //[Index(IsUnique = true)]
        public string cellPhone { get; set; }

        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage = "فیلد تاریخ تولد اجباری است"), Display(Name = "تاریخ تولد")]
        public DateTime  birthDate  { get; set; }

        [MaxLength(1)]
        [Required(ErrorMessage = "فیلد جنسیت اجباری است"), Display(Name = "جنسیت")]
        public string gender { get; set; }

        [MaxLength(200)]
        [Display(Name = "جنسیت")]
        public string picPath { get; set; }

        public ApplicationUser Manager { get; set; }
        public int ManagerId { get; set; }
        public ICollection<ApplicationUser> Employees { get; set; }

        public position position  { get; set; }
        public int positionId { get; set; }

        public ICollection<rest> rest { get; set; }
        public ICollection<inout> inout { get; set; }

    }

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("AppDbConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<rule> rules { get; set; }
        public virtual DbSet<position> Positions { get; set; }
        public virtual DbSet<rest> Rests { get; set; }
        public virtual DbSet<inout> Inouts { get; set; }
       

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(u => u.Manager)
                .WithMany(u => u.Employees);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(i => i.inout)
                .WithMany(u => u.person);

            modelBuilder.Entity<rest>()
                .HasMany(u => u.persons)
                .WithMany(r => r.rest);

            modelBuilder.Entity<position>()
                .HasMany(u => u.person);
        }
    }
}