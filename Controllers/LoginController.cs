using CarGoRent.Entity;
using CarGoRent.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarGoRent.Controllers
{
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
        [Route("/api/login/register")]
        [HttpPost]
        public IActionResult Post([FromBody] Customer value)
        {
            try
            {
                Customer customer = Service.LoginService.register(value);
                return Ok(customer); // Return a 200 OK response with the customer object
            }
            catch (DuplicateEmailException)
            {
                return Conflict("Duplicate entry"); // Return a 409 Conflict response
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Return a 500 Internal Server Error response
            }
        }



        [Route("/api/login")]
        [HttpPost]
        public IActionResult Post([FromBody] Login value)
        {
            Customer customer = null;
            try
            {
                customer = Service.LoginService.getCustByEmail(value.Email);

                if (customer == null)
                {
                    // Invalid email
                    return BadRequest(new { ErrorCode = "InvalidEmail", ErrorMessage = "The provided email is not valid." });
                }

                // Basic password validation (not recommended in practice)
                if (value.Password != customer.Password)
                {
                    // Invalid password
                    return BadRequest(new { ErrorCode = "InvalidPassword", ErrorMessage = "The provided password is incorrect." });
                }

                // Authentication successful
                return Ok(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Some issue");
                return StatusCode(500); // Internal Server Error
            }
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
