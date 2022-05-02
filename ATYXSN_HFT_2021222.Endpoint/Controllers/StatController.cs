using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static ATYXSN_HFT_2021222.Logic.BettorLogic;
using static ATYXSN_HFT_2021222.Logic.MatchLogic;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMatchLogic matchLogic;
        IBettorLogic bettorLogic;

        public StatController(IMatchLogic matchLogic)
        {
            this.matchLogic = matchLogic;
        }

        public StatController(IBettorLogic bettorLogic)
        {
            this.bettorLogic = bettorLogic;
        }

        [HttpGet]
        public IEnumerable<OddsInfo> AverageOddsByBookmaker()
        {
            return matchLogic.AverageOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<BiggestBookmaker> MostVariety()
        {
            return matchLogic.MostVariety();
        }

        [HttpGet]
        public IEnumerable<BiggestOdds> BiggestOddsByBookmaker()
        {
            return matchLogic.BiggestOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<Bettor> BettorsByOutcome(char outcome)
        {
            return bettorLogic.BettorsByOutcome(outcome);
        }

        [HttpGet]
        public IEnumerable<BookmakerInfo> MostPopularBookmaker()
        {
            return bettorLogic.MostPopularBookmaker();
        }
    }
}
