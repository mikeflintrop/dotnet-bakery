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
    }
}
