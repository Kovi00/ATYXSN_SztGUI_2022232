using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATYXSN_HFT_2021222.Models.Bettor;
using static ATYXSN_HFT_2021222.Models.Match;

namespace ATYXSN_HFT_2021222.Client
{
    public class NonCrudService
    {
        RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void AverageOddsByBookmaker()
        {
            var items = rest.Get<OddsInfo>("MatchStat/AverageOddsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Odds}");
            }
            Console.ReadLine();
        }

        public void MatchOffersByBookmaker()
        {
            var items = rest.Get<MatchInfo>("MatchStat/MatchOffersByBookmaker");
            Console.WriteLine("Bookmaker\tMatches");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Matches}");
            }
            Console.ReadLine();
        }

        public void BiggestOddsByBookmaker()
        {
            var items = rest.Get<BiggestOdds>("MatchStat/BiggestOddsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Odds}");
            }
            Console.ReadLine();
        }

        public void NumberOfDrawsByBookmaker()
        {
            var items = rest.Get<DrawInfo>("MatchStat/NumberOfDrawsByBookmaker");
            Console.WriteLine("Bookmaker\tDraws");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Draws}");
            }
            Console.ReadLine();
        }

        public void BetsByBookmaker()
        {
            var items = rest.Get<BetInfo>("BettorStat/BetsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Count}");
            }
            Console.ReadLine();
        }
    }
}
