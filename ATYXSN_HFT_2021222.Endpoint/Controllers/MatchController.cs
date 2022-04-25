using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATYXSN_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchLogic iml;

        public MatchController(IMatchLogic iml)
        {
            this.iml = iml;
        }


        // GET: api/<MatchController>
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return iml.ReadAll();
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public Match Get(int id)
        {
            return iml.Read(id);
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] Match value)
        {
            iml.Create(value);
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Match value)
        {
            iml.Update(value);
        }

        // DELETE api/<MatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            iml.Delete(id);
        }
    }
}
