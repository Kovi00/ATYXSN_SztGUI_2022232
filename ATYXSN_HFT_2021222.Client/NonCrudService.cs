using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var items = rest.Get<KeyValuePair<string, double>>("MatchStat/AverageOddsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }

        public void MatchOffersByBookmaker()
        {
            var items = rest.Get<KeyValuePair<string, int>>("MatchStat/MatchOffersByBookmaker");
            Console.WriteLine("Bookmaker\tMatches");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }

        public void BiggestOddsByBookmaker()
        {
            var items = rest.Get<KeyValuePair<string, double>>("MatchStat/BiggestOddsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }

        public void NumberOfDrawsByBookmaker()
        {
            var items = rest.Get<KeyValuePair<string, int>>("MatchStat/NumberOfDrawsByBookmaker");
            Console.WriteLine("Bookmaker\tDraws");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }

        public void BetsByBookmaker()
        {
            var items = rest.Get<KeyValuePair<string, int>>("BettorStat/BetsByBookmaker");
            Console.WriteLine("Bookmaker\tOdds");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
    }
}
