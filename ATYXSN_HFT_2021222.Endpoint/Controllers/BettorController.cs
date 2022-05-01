using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettorController : ControllerBase
    {
        IBettorLogic logic;

        public BettorController(IBettorLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Bettor value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
