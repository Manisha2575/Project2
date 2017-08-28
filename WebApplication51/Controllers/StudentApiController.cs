using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication51.Dtos;
using WebApplication51.Models;

namespace WebApplication51.Controllers
{
    public class StudentApiController : ApiController
    {
        private Context  _context;

        public StudentApiController()
        {
            _context = new Context();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.studentes
                .Include(c => c.studentdetails);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.FirstName.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Studente, StudenteDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var stud = _context.studentes.SingleOrDefault(c => c.Id == id);

            if (stud == null)
                return NotFound();

            return Ok(Mapper.Map<Studente, StudenteDto>(stud));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(StudenteDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudenteDto, Studente>(studentDto);
            _context.studentes.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;
            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, StudenteDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentInDb = _context.studentes.SingleOrDefault(c => c.Id == id);

            if (studentInDb == null)
                return NotFound();

            Mapper.Map(studentDto, studentInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var studentInDb = _context.studentes.SingleOrDefault(c => c.Id == id);

            if (studentInDb == null)
                return NotFound();

            _context.studentes.Remove(studentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
