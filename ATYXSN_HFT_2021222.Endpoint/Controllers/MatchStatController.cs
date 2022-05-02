using ATYXSN_HFT_2021222.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static ATYXSN_HFT_2021222.Logic.MatchLogic;
using static ATYXSN_HFT_2021222.Models.Match;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MatchStatController : ControllerBase
    {
        IMatchLogic logic;

        public MatchStatController(IMatchLogic matchLogic)
        {
            this.logic = matchLogic;
        }

        [HttpGet]
        public IEnumerable<OddsInfo> AverageOddsByBookmaker()
        {
            return this.logic.AverageOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<MatchInfo> MatchOffersByBookmaker()
        {
            return this.logic.MatchOffersByBookmaker();
        }

        [HttpGet]
        public IEnumerable<BiggestOdds> BiggestOddsByBookmaker()
        {
            return this.logic.BiggestOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<DrawInfo> NumberOfDrawsByBookmaker()
        {
            return this.logic.NumberOfDrawsByBookmaker();
        }
    }
}
