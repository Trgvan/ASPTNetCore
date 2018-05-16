using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyNetCoreAPI
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string strAuthorization = Request.Headers["Authorization"];
            if (strAuthorization != "Basic ABCD") return Unauthorized();
            return Ok(new MyValue() { id = id, text = "TrungOut" });
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]MyValue value)
        {
            return CreatedAtAction("Get", value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class MyValue
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}
