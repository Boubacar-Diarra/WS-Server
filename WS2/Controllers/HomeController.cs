using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WS2.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WS2.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post(Person person)
        {
            var client = new MongoClient("mongodb+srv://bd36:J4pxAS.2mongo@ws.84jpc.mongodb.net/ws?retryWrites=true&w=majority");
            var database = client.GetDatabase("ws");
            var collection = database.GetCollection<BsonDocument>("ws");
            BsonDocument doc = new BsonDocument();
            doc.Add("prenom_nom", person.Prenom_Nom);
            doc.Add("status", person.Status);
            doc.Add("info", person.Info);
            doc.Add("formation", person.Formation);
            doc.Add("experience", person.Experience);
            doc.Add("licences_certification", person.Licences_Certification);
            doc.Add("competences", person.Competences);
            collection.InsertOne(doc);
            Console.WriteLine(person);
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
