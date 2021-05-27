using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        
        [StringLength(25)]
        public string Name { get; set; }
    }
}
