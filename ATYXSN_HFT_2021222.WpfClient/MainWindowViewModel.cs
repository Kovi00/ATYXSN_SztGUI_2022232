using ATYXSN_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Match> Matches { get; set; }

        public MainWindowViewModel()
        {
            Matches = new RestCollection<Match>("http://localhost:48810/", "match");
        }
    }
}
