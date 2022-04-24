using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
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
    }
}
