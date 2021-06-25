using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyWebAPI.Models
{
    public class Multimedia
    {
        [Key]
        public Guid MultId { get; set; }
        public string MultImage { get; set; }
        public string MultTitle { get; set; }
        public DateTime MultDate { get; set; }
        public int MultRate { get; set; }
        public List<Character> MultCast { get; set; }

    }
}
