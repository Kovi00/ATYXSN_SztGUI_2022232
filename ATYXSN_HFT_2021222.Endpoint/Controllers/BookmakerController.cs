using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookmakerController : ControllerBase
    {
        IBookmakerLogic logic;

        public BookmakerController(IBookmakerLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Bookmaker value)
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
