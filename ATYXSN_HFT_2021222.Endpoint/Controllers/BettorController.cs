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
    public class BettorController : ControllerBase
    {
        IBettorLogic logic;
        IHubContext<SignalRHub> hub;

        public BettorController(IBettorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Bettor> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Bettor Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Bettor value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BettorCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Bettor value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BettorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bettorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BettorDeleted", bettorToDelete);
        }
    }
}
