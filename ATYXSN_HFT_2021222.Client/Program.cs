using ATYXSN_HFT_2021222.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;

namespace ATYXSN_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:48810/", "match");
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var matchSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Match>())
                .Add("Create", () => crud.Create<Match>())
                .Add("Delete", () => crud.Delete<Match>())
                .Add("Update", () => crud.Update<Match>())
                .Add("Exit", ConsoleMenu.Close);

            var bettorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Bettor>())
                .Add("Create", () => crud.Create<Bettor>())
                .Add("Delete", () => crud.Delete<Bettor>())
                .Add("Update", () => crud.Update<Bettor>())
                .Add("Exit", ConsoleMenu.Close);

            var bookmakerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Bookmaker>())
                .Add("Create", () => crud.Create<Bookmaker>())
                .Add("Delete", () => crud.Delete<Bookmaker>())
                .Add("Update", () => crud.Update<Bookmaker>())
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AverageOddsByBookmaker", () => nonCrud.AverageOddsByBookmaker())
                .Add("MatchOffersByBookmaker", () => nonCrud.MatchOffersByBookmaker())
                .Add("BiggestOddsByBookmaker", () => nonCrud.BiggestOddsByBookmaker())
                .Add("NumberOfDrawsByBookmaker", () => nonCrud.NumberOfDrawsByBookmaker())
                .Add("BetsByBookmaker", () => nonCrud.BetsByBookmaker())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Matches", () => matchSubMenu.Show())
                .Add("Bettors", () => bettorSubMenu.Show())
                .Add("Bookmakers", () => bookmakerSubMenu.Show())
                .Add("Stats", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
