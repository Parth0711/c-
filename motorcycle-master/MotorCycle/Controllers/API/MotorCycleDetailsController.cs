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
    public class MotorCycleDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //motercycle controller
        // GET: api/MotorCycleDetails
        public IQueryable<MotorCycleDetail> GetMotorCycleDetails()
        {
            return db.MotorCycleDetails;
        }

        // GET: api/MotorCycleDetails/5
        [ResponseType(typeof(MotorCycleDetail))]
        public IHttpActionResult GetMotorCycleDetail(int id)
        {
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            if (motorCycleDetail == null)
            {
                return NotFound();
            }

            return Ok(motorCycleDetail);
        }

        // PUT: api/MotorCycleDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotorCycleDetail(int id, MotorCycleDetail motorCycleDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motorCycleDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(motorCycleDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorCycleDetailExists(id))
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

        // POST: api/MotorCycleDetails
        [ResponseType(typeof(MotorCycleDetail))]
        public IHttpActionResult PostMotorCycleDetail(MotorCycleDetail motorCycleDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MotorCycleDetails.Add(motorCycleDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = motorCycleDetail.Id }, motorCycleDetail);
        }

        // DELETE: api/MotorCycleDetails/5
        [ResponseType(typeof(MotorCycleDetail))]
        public IHttpActionResult DeleteMotorCycleDetail(int id)
        {
            MotorCycleDetail motorCycleDetail = db.MotorCycleDetails.Find(id);
            if (motorCycleDetail == null)
            {
                return NotFound();
            }

            db.MotorCycleDetails.Remove(motorCycleDetail);
            db.SaveChanges();

            return Ok(motorCycleDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotorCycleDetailExists(int id)
        {
            return db.MotorCycleDetails.Count(e => e.Id == id) > 0;
        }
    }
}