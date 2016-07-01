using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDbConnection _connection;

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            _connection = new NpgsqlConnection("User ID=postgres;Host=localhost;Port=5432;Database=test;");
            _connection.Open();
            var employess = _connection.Query<Employee>("SELECT * FROM films");
            _connection.Close();
            return employess;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Employee
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }
}
