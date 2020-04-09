using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotorCycle.Models;

namespace MotorCycle.Controllers
{

    public class MotorCycleDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MotorCycleDetails
        public ActionResult Index()
        {
            var motorCycleDetails = db.MotorCycleDetails.Include(m => m.MotorCycle);
            return View(motorCycleDetails.ToList());
        }

        // GET: MotorCycleDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            if (motorCycleDetail == null)
            {
                return HttpNotFound();
            }
            return View(motorCycleDetail);
        }

        // GET: MotorCycleDetails/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MotorCycleId = new SelectList(db.MotorBikes, "Id", "MotorName");
            return View();
        }

        // POST: MotorCycleDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MotorBrand,MotorModel,Country,MotorCycleId")] MotorCycleDetail motorCycleDetail)
        {
            if (ModelState.IsValid)
            {
                db.MotorCycleDetails.Add(motorCycleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MotorCycleId = new SelectList(db.MotorBikes, "Id", "MotorName", motorCycleDetail.MotorCycleId);
            return View(motorCycleDetail);
        }

        // GET: MotorCycleDetails/Edit/5

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            if (motorCycleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotorCycleId = new SelectList(db.MotorBikes, "Id", "MotorName", motorCycleDetail.MotorCycleId);
            return View(motorCycleDetail);
        }

        // POST: MotorCycleDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MotorBrand,MotorModel,Country,MotorCycleId")] MotorCycleDetail motorCycleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorCycleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotorCycleId = new SelectList(db.MotorBikes, "Id", "MotorName", motorCycleDetail.MotorCycleId);
            return View(motorCycleDetail);
        }

        // GET: MotorCycleDetails/Delete/5

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            if (motorCycleDetail == null)
            {
                return HttpNotFound();
            }
            return View(motorCycleDetail);
        }

        // POST: MotorCycleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            db.MotorCycleDetails.Remove(motorCycleDetail);
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
