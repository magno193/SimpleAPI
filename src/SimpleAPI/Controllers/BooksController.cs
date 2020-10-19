using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {

    // GET api/books
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/books/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "Alex";
    }

    // POST api/books
    [HttpPost]
    public void Post([FromBody] string value) { }

    // PUT api/books/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    // DELETE api/books/5
    [HttpDelete("{id}")]
    public void Delete(int id) { }
  }
}
