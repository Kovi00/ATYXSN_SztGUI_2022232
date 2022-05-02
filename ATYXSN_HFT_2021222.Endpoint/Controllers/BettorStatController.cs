using ATYXSN_HFT_2021222.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static ATYXSN_HFT_2021222.Logic.BettorLogic;
using static ATYXSN_HFT_2021222.Models.Bettor;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BettorStatController : ControllerBase
    {
        IBettorLogic logic;

        public BettorStatController(IBettorLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<BetInfo> BetsByBookmaker()
        {
            return this.logic.BetsByBookmaker();
        }
    }
}