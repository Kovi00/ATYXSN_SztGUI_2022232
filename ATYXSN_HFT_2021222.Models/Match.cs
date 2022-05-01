using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ATYXSN_HFT_2021222.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        [Required]
        [StringLength(50)]
        public string HomeTeam { get; set; }

        [Required]
        [StringLength(50)]
        public string AwayTeam { get; set; }

        public char Outcome { get; set; }

        [Range(1.00,199.99)]
        public double Odds { get; set; }

        [ForeignKey(nameof(Bookmaker))]
        public int BookmakerId { get; set; }

        [JsonIgnore]
        public virtual Bookmaker Bookmaker { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bettor> Bettors { get; set; }

        public Match()
        {

        }

        public Match(string input)
        {
            string[] split = input.Split('#');
            MatchId = int.Parse(split[0]);
            HomeTeam = split[1];
            AwayTeam = split[2];
            Outcome = char.Parse(split[3]);
            Odds = double.Parse(split[4]);
            BookmakerId = int.Parse(split[5]);
            Bettors = new HashSet<Bettor>();
        }
    }
}
