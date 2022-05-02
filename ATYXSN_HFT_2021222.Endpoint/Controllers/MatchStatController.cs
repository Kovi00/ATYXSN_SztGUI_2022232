using ATYXSN_HFT_2021222.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<KeyValuePair<string, double>> AverageOddsByBookmaker()
        {
            return this.logic.AverageOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> MatchOffersByBookmaker()
        {
            return this.logic.MatchOffersByBookmaker();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> BiggestOddsByBookmaker()
        {
            return this.logic.BiggestOddsByBookmaker();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfDrawsByBookmaker()
        {
            return this.logic.NumberOfDrawsByBookmaker();
        }
    }
}
