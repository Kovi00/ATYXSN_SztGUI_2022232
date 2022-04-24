using ATYXSN_HFT_2021222.Models;
using System.Linq;

namespace ATYXSN_HFT_2021222.Logic
{
    public interface IBookmakerLogic
    {
        void Create(Bookmaker item);
        void Delete(int id);
        Bookmaker Read(int id);
        IQueryable<Bookmaker> ReadAll();
        void Update(Bookmaker item);
    }
}