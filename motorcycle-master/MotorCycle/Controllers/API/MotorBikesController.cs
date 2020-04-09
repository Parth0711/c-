using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MotorCycle.Models;

namespace MotorCycle.Controllers.API
{
    public class MotorBikesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MotorBikes
        public IQueryable<MotorBike> GetMotorBikes()
        {
            return db.MotorBikes;
        }

        // GET: api/MotorBikes/5
        [ResponseType(typeof(MotorBike))]
        public IHttpActionResult GetMotorBike(int id)
        {
            MotorBike motorBike = db.MotorBikes.Find(id);
            if (motorBike == null)
            {
                return NotFound();
            }

            return Ok(motorBike);
        }

        // PUT: api/MotorBikes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotorBike(int id, MotorBike motorBike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motorBike.Id)
            {
                return BadRequest();
            }

            db.Entry(motorBike).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorBikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MotorBikes
        [ResponseType(typeof(MotorBike))]
        public IHttpActionResult PostMotorBike(MotorBike motorBike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MotorBikes.Add(motorBike);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = motorBike.Id }, motorBike);
        }

        // DELETE: api/MotorBikes/5
        [ResponseType(typeof(MotorBike))]
        public IHttpActionResult DeleteMotorBike(int id)
        {
            MotorBike motorBike = db.MotorBikes.Find(id);
            if (motorBike == null)
            {
                return NotFound();
            }

            db.MotorBikes.Remove(motorBike);
            db.SaveChanges();

            return Ok(motorBike);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotorBikeExists(int id)
        {
            return db.MotorBikes.Count(e => e.Id == id) > 0;
        }
    }
}