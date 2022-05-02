using ATYXSN_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace ATYXSN_HFT_2021222.Logic
{
    public interface IMatchLogic
    {
        void Create(Match item);
        void Delete(int id);
        Match Read(int id);
        IQueryable<Match> ReadAll();
        void Update(Match item);
        IEnumerable<KeyValuePair<string, double>> AverageOddsByBookmaker();
        IEnumerable<KeyValuePair<string, int>> MatchOffersByBookmaker();
        IEnumerable<KeyValuePair<string, double>> BiggestOddsByBookmaker();
        IEnumerable<KeyValuePair<string, int>> NumberOfDrawsByBookmaker();
    }
}