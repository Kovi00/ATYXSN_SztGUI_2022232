using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            this.repo.Update(item);
        }

        public IEnumerable<KeyValuePair<string, double>> AverageOddsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Odds));
        }

        public IEnumerable<KeyValuePair<string, int>> MatchOffersByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }

        public IEnumerable<KeyValuePair<string, double>> BiggestOddsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Bookmaker.BookmakerName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Max(t => t.Odds));
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfDrawsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   where x.Outcome == 'X'
                   group x by x.Bookmaker.BookmakerName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }
    }
}
