using ATYXSN_HFT_2021222.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<KeyValuePair<string, int>> BetsByBookmaker()
        {
            return this.logic.BetsByBookmaker();
        }
    }
}