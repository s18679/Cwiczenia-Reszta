using System;
using System.Data.SqlClient;
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

        [HttpGet]
        public IActionResult GetStudent()
        {
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18780;Integrated Security=True "))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select Student.FirstName, Student.LastName, Student.BirthDate, Studies.Name, Enrollment.Semester " +
                    "from Student inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment " +
                    "inner join Studies on Enrollment.IdStudy = Studies.IdStudy"; ;
                connection.Open();
                var dataReader = command.ExecuteReader();
                String students = "";
                while (dataReader.Read())
                {
                    var student = new Student();
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.LastName = dataReader["LastName"].ToString();
                    student.IndexNumber = dataReader["BirthDate"].ToString();
                    student.FirstName = dataReader["Name"].ToString();
                    student.Semester = dataReader["Semester"].ToString();

                    students += student.ToString() + "\n";
                }
                return Ok(students);
            }
        }

        //[FromRoute], [FromBody], [FromQuery]
        //1. URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute]int id)
        {
            string myId = "s1234";
            string SqlID = "'" + id + "'";
            using (var client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18780;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "select enrollment.IdEnrollment, semester, Enrollment.IdStudy, StartDate" +
                    " from studies inner join enrollment on studies.IdStudy=enrollment.IdStudy "
                    + "inner join Student on Enrollment.IdEnrollment=Student.IdEnrollment where IndexNumber = " + SqlID;
                com.Parameters.AddWithValue("id", myId);

                client.Open();
                var dr = com.ExecuteReader();
                String student = "";
                while (dr.Read())
                {
                    var st = new Student();
                    st.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                    st.Semester = dr["Semester"].ToString() + " semestr";
                    st.IdStudent = Int32.Parse(dr["IdStudy"].ToString());
                }
                return Ok(student);
            }
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