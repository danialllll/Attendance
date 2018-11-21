using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.Models;

namespace AttendanceApp.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            var applicationUsers = db.ApplicationUsers.Include(a => a.position);
            return View(applicationUsers.ToList());
        }

        // GET: Admin/Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Admin/Admin/Create
        public ActionResult Create()
        {
            ViewBag.positionId = new SelectList(db.positions, "Id", "positionName");
            return View();
        }

        // POST: Admin/Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,lastName,positionName,address,cellPhone,birthDate,gender,picPath,ManagerId,positionId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUsers.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.positionId = new SelectList(db.positions, "Id", "positionName", applicationUser.positionId);
            return View(applicationUser);
        }

        // GET: Admin/Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.positionId = new SelectList(db.positions, "Id", "positionName", applicationUser.positionId);
            return View(applicationUser);
        }

        // POST: Admin/Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,lastName,positionName,address,cellPhone,birthDate,gender,picPath,ManagerId,positionId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.positionId = new SelectList(db.positions, "Id", "positionName", applicationUser.positionId);
            return View(applicationUser);
        }

        // GET: Admin/Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
