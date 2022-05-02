using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATYXSN_HFT_2021222.Models.Match;

namespace ATYXSN_HFT_2021222.Logic
{
    public class MatchLogic : IMatchLogic
    {
        IRepository<Match> repo;

        public MatchLogic(IRepository<Match> repo)
        {
            this.repo = repo;
        }

        public void Create(Match item)
        {
            if (item.Outcome != 'X' && item.Outcome != 'H' && item.Outcome != 'A')
            {
                throw new FormatException();
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Match Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Match> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Match item)
        {
            if (item.Outcome != 'X' && item.Outcome != 'H' && item.Outcome != 'A')
            {
                throw new FormatException();
            }
            this.repo.Update(item);
        }

        public IEnumerable<OddsInfo> AverageOddsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new OddsInfo()
                   {
                       Name = g.Key,
                       Odds = g.Average(t => t.Odds)
                   };
        }

        public IEnumerable<MatchInfo> MatchOffersByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new MatchInfo()
                   {
                       Name = g.Key,
                       Matches = g.Count()
                   };
        }

        public IEnumerable<BiggestOdds> BiggestOddsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new BiggestOdds()
                   {
                       Name = g.Key,
                       Odds = g.Max(t => t.Odds)
                   };
        }

        public IEnumerable<DrawInfo> NumberOfDrawsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   where x.Outcome == 'X'
                   group x by x.Bookmaker.BookmakerName into g
                   select new DrawInfo()
                   {
                       Name = g.Key,
                       Draws = g.Count()
                   };
        }
    }
}
