using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        // _context is instance of ApplicationContext class
        // we use _context to query db
        // _context is kinda like pool.query
        private readonly ApplicationContext _context;

        // this is our constructor function
        // our ApplicationContext is automatically passed as an argument by .NET
        public BakersController(ApplicationContext context) {
            _context = context;
        }

        // [HttpGet] attribute defines this method as out GET
        // this method returns IEnumerable<Baker> object,
        // which is .NET's way of saying a list of baker objects
        [HttpGet]
        public IEnumerable<Baker> GetAll() 
        {
            // no SQL query necessary
            // find all records from Bakers table
            return _context.Bakers;
        }

        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id) 
        {
            Baker baker = _context.Bakers.SingleOrDefault(baker => baker.id == id);

            // return 404 if not found or baker doesnt exist
            if (baker is null) {
                return NotFound();
            }

            return baker;
        }

        //POST  to /api/bakers
        [HttpPost]
        public Baker Post(Baker baker)
        {
            _context.Add(baker);
            _context.SaveChanges();
            
            return baker;
        }
    }
}
