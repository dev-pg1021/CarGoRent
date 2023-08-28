using CarGoRent.Entity;
using CarGoRent.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarGoRent.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /*
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST api/<LoginController>
        [Route("/register")]
        [HttpPost]
        public Customer Post([FromBody] Customer value)
        {
            Customer customer = null;

            try {
                customer = Service.LoginService.register(value);
            }
            catch (Exception e) { 
                if(e.Equals("409")) { 
                    HttpContext.Response.StatusCode = 409;
                    return customer;
                }
                throw e;
            }
            return customer;
        }

        /*

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
