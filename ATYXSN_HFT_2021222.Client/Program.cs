using ConsoleTools;
using System;

namespace ATYXSN_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Create(string entity)
            {
                Console.WriteLine(entity + " create");
                Console.ReadLine();
            }
            static void List(string entity)
            {
                if (entity == "Actor")
                {

                }
                Console.ReadLine();
            }
            static void Update(string entity)
            {
                Console.WriteLine(entity + " update");
                Console.ReadLine();
            }
            static void Delete(string entity)
            {
                Console.WriteLine(entity + " delete");
                Console.ReadLine();
            }

            static void Main(string[] args)
            {
                var matchSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Match"))
                    .Add("Create", () => Create("Match"))
                    .Add("Delete", () => Delete("Match"))
                    .Add("Update", () => Update("Match"))
                    .Add("Exit", ConsoleMenu.Close);

                var bettorSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Bettor"))
                    .Add("Create", () => Create("Bettor"))
                    .Add("Delete", () => Delete("Bettor"))
                    .Add("Update", () => Update("Bettor"))
                    .Add("Exit", ConsoleMenu.Close);

                var bookmakerSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Bookmaker"))
                    .Add("Create", () => Create("Bookmaker"))
                    .Add("Delete", () => Delete("Bookmaker"))
                    .Add("Update", () => Update("Bookmaker"))
                    .Add("Exit", ConsoleMenu.Close);

                var menu = new ConsoleMenu(args, level: 0)
                    .Add("Matches", () => matchSubMenu.Show())
                    .Add("Bettors", () => bettorSubMenu.Show())
                    .Add("Bookmakers", () => bookmakerSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);

                menu.Show();
            }
        }
    }
}
