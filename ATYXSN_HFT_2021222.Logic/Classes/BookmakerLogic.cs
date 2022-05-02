using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Logic
{
    public class BookmakerLogic : IBookmakerLogic
    {
        IRepository<Bookmaker> repo;

        public BookmakerLogic(IRepository<Bookmaker> repo)
        {
            this.repo = repo;
        }

        public void Create(Bookmaker item)
        {
            if (item.BookmakerName.Length < 5)
            {
                throw new ArgumentException();
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Bookmaker Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Bookmaker> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Bookmaker item)
        {
            if (item.BookmakerName.Length < 5)
            {
                throw new ArgumentException();
            }
            this.repo.Update(item);
        }
    }
}
