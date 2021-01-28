using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wyklad3.Models;
using Wyklad3.Services;

namespace Wyklad3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService service)
        {
            _dbService = service;
        }

        //2. QueryString
        [HttpGet]

        public string GetStudent(String orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie = {orderBy}";
        }
        public IActionResult GetStudents([FromServices]IDbService service, [FromQuery]string orderBy)
        {
            if (orderBy == "lastname")
            {
                return Ok(_dbService.GetStudents().OrderBy(s => s.LastName));
            }

            return Ok(_dbService.GetStudents());
        }

        //[FromRoute], [FromBody], [FromQuery]
        //1. URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute]int id)
        {
            if (id == 1)
            {
                return Ok("Jan");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Student was not found");
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student student)
        {
            student.IndexNumber=$"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id == student.IdStudent)
            {
                student.IndexNumber = student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            }
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id, Student student)
        {
            if (student.IdStudent == id)
            {
                student = null;
            }
            return Ok("Usuwanie ukończone");
        }


    }
}