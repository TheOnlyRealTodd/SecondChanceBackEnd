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
    public class EmployersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employers
        public IQueryable<Employer> GetEmployers()
        {
            return db.Employers;
        }

        // GET: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult GetEmployer(int id)
        {
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // PUT: api/Employers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployer(int id, Employer employer)
        {

            employer.EmployerId = id;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var employerInDb = db.Employers.SingleOrDefault(e => e.EmployerId == id);

            employerInDb.Name = employer.Name;
            employerInDb.City = employer.Name;
            employerInDb.Description = employer.Description;
            employerInDb.ContactEmail = employer.ContactEmail;
            employerInDb.ContactName = employer.ContactName;
            employerInDb.ContactPhone = employer.ContactPhone;
            employerInDb.State = employer.State;
            employerInDb.Jobs = employer.Jobs;

            if (employerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.SaveChanges();
            return Ok();
        }
        

        // POST: api/Employers
        [ResponseType(typeof(Employer))]
        public IHttpActionResult PostEmployer(Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employers.Add(employer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employer.EmployerId }, employer);
        }

        // DELETE: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult DeleteEmployer(int id)
        {
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            db.Employers.Remove(employer);
            db.SaveChanges();

            return Ok(employer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerExists(int id)
        {
            return db.Employers.Count(e => e.EmployerId == id) > 0;
        }
    }
}