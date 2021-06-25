using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyWebAPI.Models
{
    public class Character
    {
        [Key]
        public Guid CharacterID { get; set; }
        public string CharacterImage { get; set; }
        public string CharacterName { get; set; }
        public int CharacterAge { get; set; }
        public int CharacterWeight { get; set; }
        public string CharacterStory { get; set; }
        public List<Multimedia> Filmography { get; set; }


    }
}
