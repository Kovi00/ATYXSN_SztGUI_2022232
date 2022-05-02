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

        public IEnumerable<KeyValuePair<string, int>> BetsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Match.Bookmaker.BookmakerName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }
    }
}
