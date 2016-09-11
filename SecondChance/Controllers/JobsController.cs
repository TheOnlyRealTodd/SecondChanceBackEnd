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
    public class JobsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Jobs
        public IQueryable<Job> GetJobs()
        {
            return db.Jobs;
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult GetJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJob(int id, Job job)
        {
            job.JobId = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobInDb = db.Jobs.Include("Employer").SingleOrDefault();
            AutoMapper.Mapper.Map(job, jobInDb);

            if (jobInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.SaveChanges();
            return Ok();

        }

        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public IHttpActionResult PostJob(Job job)
        {
       //     var employer = (Employer)db.Employers.Where(e => e.EmployerId == job.Employer.EmployerId);
         //   job.Employer = employer;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Jobs.Add(job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = job.JobId }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult DeleteJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            db.Jobs.Remove(job);
            db.SaveChanges();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.JobId == id) > 0;
        }
    }
}