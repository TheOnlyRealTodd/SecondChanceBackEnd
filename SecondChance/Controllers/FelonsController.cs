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
using SecondChance.Models;

namespace SecondChance.Controllers
{
    public class FelonsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Felons
        public IQueryable<Felon> GetFelons()
        {
            return db.Felons;
        }

        // GET: api/Felons/5
        [ResponseType(typeof(Felon))]
        public IHttpActionResult GetFelon(int id)
        {
            Felon felon = db.Felons.Find(id);
            if (felon == null)
            {
                return NotFound();
            }

            return Ok(felon);
        }

        // PUT: api/Felons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFelon(int id, Felon felon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != felon.FelonId)
            {
                return BadRequest();
            }

            db.Entry(felon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelonExists(id))
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

        // POST: api/Felons
        [ResponseType(typeof(Felon))]
        public IHttpActionResult PostFelon(Felon felon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Felons.Add(felon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = felon.FelonId }, felon);
        }

        // DELETE: api/Felons/5
        [ResponseType(typeof(Felon))]
        public IHttpActionResult DeleteFelon(int id)
        {
            Felon felon = db.Felons.Find(id);
            if (felon == null)
            {
                return NotFound();
            }

            db.Felons.Remove(felon);
            db.SaveChanges();

            return Ok(felon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FelonExists(int id)
        {
            return db.Felons.Count(e => e.FelonId == id) > 0;
        }
    }
}