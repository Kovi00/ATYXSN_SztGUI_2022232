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
    public class BookmakerController : ControllerBase
    {
        IBookmakerLogic logic;
        IHubContext<SignalRHub> hub;

        public BookmakerController(IBookmakerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Bookmaker> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Bookmaker Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Bookmaker value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BookmakerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Bookmaker value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BookmakerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookmakerToDelete = this.logic.Read(id);
            foreach (var match in logic.Read(id).Matches)
            {
                logic.Read(id).Matches.Remove(match);
                this.hub.Clients.All.SendAsync("MatchDeleted", match);
            }
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BookmakerDeleted", bookmakerToDelete);
        }
    }
}
