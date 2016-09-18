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
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            var lusers = _context.Lusers.ToList();

        }

        // GET: api/Users/5
        [ResponseType(typeof(Luser))]
        public IHttpActionResult GetUser(int id)
        {
            Luser luser = db.Lusers.Find(id);
            if (luser == null)
            {
                return NotFound();
            }

            return Ok(luser);
        }

        // PUT: api/Users/5

        [HttpPut]
        public IHttpActionResult PutUser(int id, Luser luser)
        {
            luser.LuserId = id;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var luserInDb = db.Lusers.SingleOrDefault(l => l.LuserId == id);
            luserInDb.FirstName = luser.FirstName;
            luserInDb.LastName = luser.LastName;
            luserInDb.Email = luser.Email;
            luserInDb.FeloniesCommitted = luser.FeloniesCommitted;
            luserInDb.AboutMe = luser.AboutMe;
            luserInDb.City = luser.City;
            luserInDb.Skill1 = luser.Skill1;
            luserInDb.Skill2 = luser.Skill2;
            luserInDb.Skill3 = luser.Skill3;
            luserInDb.State = luser.State;

            if (luserInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.SaveChanges();
            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        public IHttpActionResult PostUser(Luser luser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lusers.Add(luser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = luser.LuserId }, luser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Luser))]
        public IHttpActionResult DeleteUser(int id)
        {
            Luser luser = db.Lusers.Find(id);
            if (luser == null)
            {
                return NotFound();
            }

            db.Lusers.Remove(luser);
            db.SaveChanges();

            return Ok(luser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Lusers.Count(e => e.LuserId == id) > 0;
        }
    }
}