using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLKhachSan.Models;

namespace QLKhachSan.Controllers
{
    public class RoomReservationsController : Controller
    {
        private NOBLESSEDatabase db = new NOBLESSEDatabase();

        public ActionResult Bill(int id)
        {
            var roomReservations = db.RoomReservations.Where(r => r.DateEnded == null);
            ViewBag.BillId = id;
            return View(roomReservations.ToList());
        }

        public ActionResult AddToBill(int id, int reservation)
        {
            var billObj = db.Bills.FirstOrDefault(p => p.Id == id);
            var resObj = db.RoomReservations.FirstOrDefault(p => p.Id == reservation);

            if (billObj == null || resObj == null)
                return HttpNotFound();

            resObj.BillId = id;
            db.Entry(resObj).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details", "Bills", new { id = id });
        }

        // GET: RoomReservations
        public ActionResult Index()
        {
            return View(db.RoomReservations.ToList());
        }

        // GET: RoomReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            return View(roomReservation);
        }

        // GET: RoomReservations/Create
        public ActionResult Create(int? id)
        {
            if (id == null || db.Rooms.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id.ToString();
            return View();
        }

        // POST: RoomReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomReservation roomReservation)
        {
            //if (ModelState.IsValid)
            //{
                roomReservation.DateCreated = DateTime.Today;
                db.RoomReservations.Add(roomReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", roomReservation.RoomId);
            return View(roomReservation);
        }

        // GET: RoomReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            return View(roomReservation);
        }

        // POST: RoomReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateCreated,DateEnded")] RoomReservation roomReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomReservation);
        }

        // GET: RoomReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            return View(roomReservation);
        }

        // POST: RoomReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            db.RoomReservations.Remove(roomReservation);
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
