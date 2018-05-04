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
    public class CustomersController : Controller
    {
        private NOBLESSEDatabase db = new NOBLESSEDatabase();
        public int m_roomReservationId;
        // GET: Customers

        public ActionResult AddToReservation(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var customers = db.Customers.Include(c => c.CustomerType);
            ViewBag.RoomReservationId = id;
            return View(customers.ToList());
        }


        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CustomerType);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create(int id)
        {
            var roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
                return HttpNotFound();

            ViewBag.RoomReservationId = id;
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                var roomReservationDetail = new RoomReservationDetail();
                roomReservationDetail.CustomerId = customer.Id;
                roomReservationDetail.RoomReservationId = id;
                db.RoomReservationDetails.Add(roomReservationDetail);
                db.SaveChanges();

                return RedirectToAction("Details", "RoomReservations", new { id = id });
            }

            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        public ActionResult MoveOutReservation(int reservation, int details)
        {
            var roomDetail = db.RoomReservationDetails.Find(details);
            db.RoomReservationDetails.Remove(roomDetail);
            db.SaveChanges();

            return RedirectToAction("Details", "RoomReservations", new { id = reservation });
        }

        public ActionResult Add(int reservation, int id)
        {
            var customer = db.Customers.Find(id);

            if (customer == null)
                return HttpNotFound();

            var roomReservationDetail = new RoomReservationDetail();
            roomReservationDetail.CustomerId = customer.Id;
            roomReservationDetail.RoomReservationId = reservation;

            db.RoomReservationDetails.Add(roomReservationDetail);
            db.SaveChanges();

            return RedirectToAction("Details", "RoomReservations", new { id = reservation });
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CMND,Add,CustomerTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
