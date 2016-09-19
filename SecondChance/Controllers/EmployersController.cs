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
using SecondChance.BindingModels;
using SecondChance.Dtos;
using SecondChance.Models;

namespace SecondChance.Controllers
{
    public class EmployersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Employers
        [HttpGet]
        public IHttpActionResult GetEmployers()
        {
           // List<Employer> employers = _context.Employers.ToList();
          //  var employersDtos = Mapper.Map<List<Employer>,List<EmployerDto>>(employers);
          var employers = _context.Employers.ToList();
            var employersDtos = Mapper.Map<List<Employer>,List<EmployerDto>>(employers);
            return Ok(employersDtos);
        }

        // GET: api/Employers/5
        [HttpGet]
        public IHttpActionResult GetEmployer(int id)
        {
            var employer = _context.Employers.SingleOrDefault(e => e.EmployerId == id);
            
            if (employer == null)
            {
                return NotFound();
            }
            var employerDto = Mapper.Map<Employer, EmployerDto>(employer);

            return Ok(employerDto);
        }

        // PUT: api/Employers/5
        [HttpPut]
        public IHttpActionResult PutEmployer(int id, EmployerBindingModel employerBindingModel)
        {

            employerBindingModel.EmployerId = id;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var employerInDb = _context.Employers.SingleOrDefault(e => e.EmployerId == id);

            Mapper.Map<EmployerBindingModel, Employer>(employerBindingModel, employerInDb);

            if (employerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.SaveChanges();
            return Ok();
        }
        

        // POST: api/Employers
        [HttpPost]
        public IHttpActionResult PostEmployer(Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employers.Add(employer);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employer.EmployerId }, employer);
        }

        // DELETE: api/Employers/5
        [HttpDelete]
        public IHttpActionResult DeleteEmployer(int id)
        {
            Employer employer = _context.Employers.SingleOrDefault(e => e.EmployerId == id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(employer);
            _context.SaveChanges();

            return Ok(employer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerExists(int id)
        {
            return _context.Employers.Count(e => e.EmployerId == id) > 0;
        }
    }
}