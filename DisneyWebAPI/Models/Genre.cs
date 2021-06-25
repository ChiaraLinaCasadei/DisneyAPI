using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyWebAPI.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreID { get; set; }
        public string GenreName { get; set; }
        public string GenreImage { get; set; }
        public List<Multimedia> GenreMult { get; set; }
    }
}
