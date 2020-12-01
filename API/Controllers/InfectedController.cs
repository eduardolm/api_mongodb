using System;
using API.Data;
using API.Data.Collection;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        private MongoDb _mongoDb;

        private IMongoCollection<Infected> _infectedCollection;

        public InfectedController(MongoDb mongoDb)
        {
            _mongoDb = mongoDb;
            _infectedCollection = _mongoDb.Db.GetCollection<Infected>(nameof(Infected).ToLower());
        }
        
        [HttpGet]
        public ActionResult GetAll()
        {
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infected);
        }

        [HttpPost]
        public ActionResult Create([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.Birthday, dto.Gender, dto.Latitude, dto.Longitude);
            
            _infectedCollection.InsertOne(infected);

            return StatusCode(201, "Infected successfully added to DB.");
        }

        [HttpPut]
        public ActionResult Update([FromBody] InfectedDto dto)
        {
            _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.Birthday == dto.Birthday),
                Builders<Infected>.Update.Set("Gender", dto.Gender));
            
            return Ok("Document successfully updated.");
        }
        
        [HttpDelete("{birthday}")]
        public ActionResult Delete(DateTime birthday)
        {
            _infectedCollection.DeleteOne(Builders<Infected>.Filter.Where(_ => _.Birthday == birthday));
            
            return Ok("Document successfully deleted.");
        }
    }
}