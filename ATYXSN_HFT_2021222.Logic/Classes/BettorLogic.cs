using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATYXSN_HFT_2021222.Models.Bettor;

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
            if (item.BettorName.Length < 2)
            {
                throw new ArgumentException();
            }
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
            if (item.BettorName.Length < 2)
            {
                throw new ArgumentException();
            }
            this.repo.Update(item);
        }

        public IEnumerable<BetInfo> BetsByBookmaker()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Match.Bookmaker.BookmakerName into g
                   select new BetInfo()
                   {
                       Name = g.Key,
                       Count = g.Count()
                   };
        }
    }
}
