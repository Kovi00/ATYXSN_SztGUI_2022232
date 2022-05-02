using ATYXSN_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;
using static ATYXSN_HFT_2021222.Logic.MatchLogic;
using static ATYXSN_HFT_2021222.Models.Match;

namespace ATYXSN_HFT_2021222.Logic
{
    public interface IMatchLogic
    {
        void Create(Match item);
        void Delete(int id);
        Match Read(int id);
        IQueryable<Match> ReadAll();
        void Update(Match item);
        IEnumerable<OddsInfo> AverageOddsByBookmaker();
        IEnumerable<MatchInfo> MatchOffersByBookmaker();
        IEnumerable<BiggestOdds> BiggestOddsByBookmaker();
        IEnumerable<DrawInfo> NumberOfDrawsByBookmaker();
    }
}