using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Repository
{
    public class BookmakerRepository : Repository<Bookmaker>, IRepository<Bookmaker>
    {
        public BookmakerRepository(MatchDbContext ctx) : base(ctx)
        {
        }

        public override Bookmaker Read(int id)
        {
            return ctx.Bookmakers.FirstOrDefault(x => x.BookmakerId == id);
        }

        public override void Update(Bookmaker item)
        {
            var old = Read(item.BookmakerId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
