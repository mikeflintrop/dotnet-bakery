using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        // all db fields need getter and setter
        // id is special - EF already knows primary key and serial
        public int id { get; set; }

        // this field is NOT NULL in db, aka required
        // automatically sends back 400 if missing in request body
        [Required]
        public string name { get; set; }
    }
}
