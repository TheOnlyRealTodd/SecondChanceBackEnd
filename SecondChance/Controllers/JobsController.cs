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
using AutoMapper;
using SecondChance.Dtos;
using SecondChance.Models;

namespace SecondChance.Controllers
{
    public class JobsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Jobs
        [HttpGet]
        public IHttpActionResult GetJobs()
        {
            var jobs = _context.Jobs.Include("Employer").ToList();
            return Ok(jobs);
        }

        // GET: api/Jobs/5
        [HttpGet]
        public IHttpActionResult GetJob(int id)
        {
            var job = _context.Jobs.Include("Employer").SingleOrDefault(j => j.JobId == id);
            if (job == null)
            {
                return BadRequest("Cannot locate job");
            }
            var jobDto = Mapper.Map<Job, JobDto>(job);
            return Ok(jobDto);
        }

        // PUT: api/Jobs/5
        [HttpPut]
        public IHttpActionResult PutJob(int id, Job job)
        {
            job.JobId = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobInDb = _context.Jobs.Include("Employer").SingleOrDefault(j => j.JobId == id);
            AutoMapper.Mapper.Map(job, jobInDb);

            if (jobInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.SaveChanges();
            return Ok();

        }

        // POST: api/Jobs
        [HttpPost]
        public IHttpActionResult PostJob(Job job)
        {
            var employer = (Employer)_context.Employers.Where(e => e.EmployerId == job.Employer.EmployerId);
            job.Employer = employer;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Jobs.Add(job);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = job.JobId }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete]
        public IHttpActionResult DeleteJob(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Count(e => e.JobId == id) > 0;
        }
    }
}