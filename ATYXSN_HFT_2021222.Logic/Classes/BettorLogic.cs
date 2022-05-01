using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Logic
{
    public class BettorLogic : IBettorLogic
    {
        IRepository<Bettor> repo;

        public BettorLogic(IRepository<Bettor> repo)
        {
            this.repo = repo;
        }

        public void Create(Bettor item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Bettor Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Bettor> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Bettor item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<Bettor> BettorsByOutcome(char outcome)
        {
            return from x in this.repo.ReadAll()
                   where x.Match.Outcome == char.Parse(outcome.ToString().ToUpper())
                   select x;
        }

        public IEnumerable<BookmakerInfo> MostPopularBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Match.Bookmaker into g
                   select new BookmakerInfo()
                   {
                       BookmakerName = g.Key.BookmakerName,
                       BetsPlaced = g.Count()
                   };
        }

        public class BookmakerInfo
        {
            public string BookmakerName { get; set; }
            public int BetsPlaced { get; set; }
        }
    }
}
