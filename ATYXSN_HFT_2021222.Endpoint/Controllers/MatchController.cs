using ATYXSN_HFT_2021222.Endpoint.Services;
using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchLogic logic;
        IHubContext<SignalRHub> hub;

        public MatchController(IMatchLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Match> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Match Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Match value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MatchCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Match value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("MatchUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var matchToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("MatchDeleted", matchToDelete);
        }
    }
}
