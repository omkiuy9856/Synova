using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SynovaExpress.Models;

namespace SynovaExpress.Controllers
{
    public class DistributeCentersController : Controller
    {
        private SynovaExpressDataEntities db = new SynovaExpressDataEntities();

        // GET: DistributeCenters
        public ActionResult Index()
        {
            var distributeCenters = db.DistributeCenters.Include(d => d.Driver).Include(d => d.User).Include(d => d.Shipment);
            return View(distributeCenters.ToList());
        }

        // GET: DistributeCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributeCenter);
        }

        // GET: DistributeCenters/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "DriverId");
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserId");
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentNo", "ShipmentNo");
            return View();
        }

        // POST: DistributeCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShipmentID,UserID,DriverID")] DistributeCenter distributeCenter)
        {
            if (ModelState.IsValid)
            {
                db.DistributeCenters.Add(distributeCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "DriverId", distributeCenter.DriverID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserId", distributeCenter.UserID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentNo", "ShipmentNo", distributeCenter.ShipmentID);
            return View(distributeCenter);
        }

        // GET: DistributeCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "DriverId", distributeCenter.DriverID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserId", distributeCenter.UserID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentNo", "ShipmentNo", distributeCenter.ShipmentID);
            return View(distributeCenter);
        }

        // POST: DistributeCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShipmentID,UserID,DriverID")] DistributeCenter distributeCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributeCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "DriverId", distributeCenter.DriverID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserId", distributeCenter.UserID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentNo", "ShipmentNo", distributeCenter.ShipmentID);
            return View(distributeCenter);
        }

        // GET: DistributeCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributeCenter);
        }

        // POST: DistributeCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            db.DistributeCenters.Remove(distributeCenter);
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
