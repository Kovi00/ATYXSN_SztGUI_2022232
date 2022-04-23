using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Models
{
    public class Bettor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BettorId { get; set; }

        [Required]
        [StringLength(100)]
        public string BettorName { get; set; }

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public Bettor(string input)
        {
            string[] split = input.Split('#');
            BettorId = int.Parse(split[0]);
            BettorName = split[1];
            MatchId = int.Parse(split[2]);
        }
    }
}
