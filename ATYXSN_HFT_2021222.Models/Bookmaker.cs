using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Models
{
    public class Bookmaker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookmakerId { get; set; }
        
        [Required]
        [StringLength(20)]
        public string BookmakerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Match> Matches { get; set; }

        public Bookmaker()
        {

        }

        public Bookmaker(string input)
        {
            string[] split = input.Split('#');
            BookmakerId = int.Parse(split[0]);
            BookmakerName = split[1];
            Matches = new HashSet<Match>();
        }
    }
}
