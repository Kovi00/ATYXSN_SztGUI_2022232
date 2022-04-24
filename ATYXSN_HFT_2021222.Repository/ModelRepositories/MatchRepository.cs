using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Repository
{
    public class MatchRepository : Repository<Match>, IRepository<Match>
    {
        public MatchRepository(MatchDbContext ctx) : base(ctx)
        {
        }

        public override Match Read(int id)
        {
            return ctx.Matches.FirstOrDefault(x => x.MatchId == id);
        }

        public override void Update(Match item)
        {
            var old = Read(item.MatchId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
