using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;

namespace PercobaanApi1.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;

        public PersonController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult index()
        {
            return View();
        }

        [HttpGet("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }

        [HttpPost("api/person_auth"), Authorize]
        public ActionResult<Person> ListPersonWithAuth()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }


    //    [HttpPost("api/murid/create")]
    //    public IActionResult CreatePerson([FromBody] murid person)
    //    {
    //        PersonContext context = new PersonContext(this.__constr);
    //        context.AddPerson(person);
    //        return Ok("Person added successfully.");
    //    }

    //    [HttpPut("api/murid/update/{id}")]
    //    public IActionResult UpdatePerson(int id, [FromBody] murid person)
    //    {
    //        person.id_person = id;
    //        PersonContext context = new PersonContext(this.__constr);
    //        context.UpdatePerson(person);
    //        return Ok("Person updated successfully.");
    //    }

    //    [HttpDelete("api/murid/delete/{id}")]
    //    public IActionResult DeletePerson(int id)
    //    {
    //        PersonContext context = new PersonContext(this.__constr);
    //        context.DeletePerson(id);
    //        return Ok("Person deleted successfully.");
    //    }
    }
}
