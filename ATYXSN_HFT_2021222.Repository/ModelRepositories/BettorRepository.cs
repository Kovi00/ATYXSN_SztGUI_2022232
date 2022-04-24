using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Repository
{
    public class BettorRepository : Repository<Bettor>, IRepository<Bettor>
    {
        public BettorRepository(MatchDbContext ctx) : base(ctx)
        {
        }

        public override Bettor Read(int id)
        {
            return ctx.Bettors.FirstOrDefault(x => x.BettorId == id);
        }

        public override void Update(Bettor item)
        {
            var old = Read(item.BettorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
