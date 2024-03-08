using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PercobaanApi1.Models
{
    public class Person
    {
        public int id_person { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string email { get; set; }

    }

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly List<Person> persons = new List<Person>()
        {
            new Person() { id_person = 1, nama = "Budi", alamat = "JEmber", email = "Budi@gmail.com" },
            new Person() { id_person = 2, nama = "Iwan", alamat = "Banyuwangi", email = "iwan@gmail.com" },
            new Person() { id_person = 3, nama = "Wati", alamat = "Lumajang", email = "wati@gmail.com" }
        };

        [HttpGet("{id_person}")]
        public ActionResult Get(int id_person)
        {
            var person = persons.Find(p => p.id_person == id_person);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }



}
