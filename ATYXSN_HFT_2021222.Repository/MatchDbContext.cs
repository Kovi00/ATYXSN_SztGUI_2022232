using System;
using ATYXSN_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;

namespace ATYXSN_HFT_2021222.Repository
{
    public class MatchDbContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bookmaker> Bookmakers { get; set; }
        public DbSet<Bettor> Bettors { get; set; }

        public MatchDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\match.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(match => match
                .HasOne(match => match.Bookmaker)
                .WithMany(bookmaker => bookmaker.Matches)
                .HasForeignKey(match => match.BookmakerId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Bettor>(bettor => bettor
                .HasOne(bettor => bettor.Match)
                .WithMany(match => match.Bettors)
                .HasForeignKey(bettor => bettor.MatchId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Bookmaker>()
                .HasMany(bookmaker => bookmaker.Matches)
                .WithOne(match => match.Bookmaker)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>().HasData(new Match[]
            {
                new Match("1#Arsenal#Manchester United#H#2,00#2"),
                new Match("2#Leicester#Aston Villa#X#3,30#3"),
                new Match("3#Manchester City#Watford#H#1,10#4"),
                new Match("4#Norwich#Newcastle#A#2,20#4"),
                new Match("5#Brentford#Tottenham#X#3,80#2"),
                new Match("6#Lyon#Montpellier#H#1,36#1"),
                new Match("7#St.Etienne#Monaco#A#1,72#3"),
                new Match("8#PSG#Lens#X#7,00#3"),
                new Match("9#Nijmegen#Ajax#A#1,20#2"),
                new Match("10#AZ Alkmaar#Heerenveen#H#1,40#3"),
                new Match("11#Waalwijk#Zwolle#A#2,60#3"),
                new Match("12#Cambuur#PSV Eindhoven#A#1,25#1"),
                new Match("13#Frankfurt#Hoffenheim#X#3,60#1"),
                new Match("14#Freiburg#Monchengladbach#X#4,00#2"),
                new Match("15#Furth#Leverkusen#A#1,28#4"),
                new Match("16#Koln#Bielefeld#H#1,40#4"),
                new Match("17#RB Leipzig#Union Berlin#A#5,75#4"),
                new Match("18#Bayern Munchen#Borussia Dortmund#H#1,30#2"),
                new Match("19#Torino#Spezia#H#1,57#1"),
                new Match("20#Venezia#Atalanta#A#1,44#2"),
                new Match("21#Inter#AS Roma#H#1,60#1"),
                new Match("22#Verona#Sampdoria#X#3,80#3"),
                new Match("23#Portimonense#Moreirense#H#2,30#2"),
                new Match("24#Benfica#Famalicao#X#4,75#1"),
                new Match("25#Santa Clara#Maritimo#X#3,20#3"),
                new Match("26#Gil Vicente#Ferreira#X#3,60#2"),
            });

            modelBuilder.Entity<Bookmaker>().HasData(new Bookmaker[]
            {
                new Bookmaker("1#TippmixPro"),
                new Bookmaker("2#bet365"),
                new Bookmaker("3#Unibet"),
                new Bookmaker("4#betWay"),
            });

            modelBuilder.Entity<Bettor>().HasData(new Bettor[]
            {
                new Bettor("1#Raul Knapp#17"),
                new Bettor("2#Hadley Dickson#24"),
                new Bettor("3#Kaylee Norton#18"),
                new Bettor("4#Taylor Rice#17"),
                new Bettor("5#Mikayla Irwin#7"),
                new Bettor("6#Luz Cervantes#17"),
                new Bettor("7#Jackson Johns#15"),
                new Bettor("8#Neveah Miller#1"),
                new Bettor("9#Kaliyah Hobbs#8"),
                new Bettor("10#Kamari Jimenez#12"),
                new Bettor("11#Tia Leach#17"),
                new Bettor("12#Audrey Pittman#22"),
                new Bettor("13#Simon Crane#14"),
                new Bettor("14#Rohan Rogers#1"),
                new Bettor("15#Vaughn Park#15"),
                new Bettor("16#Jadyn Kramer#24"),
                new Bettor("17#Mattie Arias#25"),
                new Bettor("18#Makenna Dodson#24"),
                new Bettor("19#Zavier Blackburn#19"),
                new Bettor("20#Morgan Barron#23"),
                new Bettor("21#Kaiya Carter#17"),
                new Bettor("22#Darien Gilbert#22"),
                new Bettor("23#Roderick Stanley#22"),
                new Bettor("24#Catherine Boyle#12"),
                new Bettor("25#Elisha Espinoza#24"),
                new Bettor("26#Sharon Garcia#10"),
                new Bettor("27#Aubree Lee#25"),
                new Bettor("28#Kathy Ruiz#26"),
                new Bettor("29#Teagan Shields#18"),
                new Bettor("30#Octavio Tapia#22"),
                new Bettor("31#Ryker Farley#25"),
                new Bettor("32#Aiyana Poole#5"),
                new Bettor("33#Rylee Crawford#16"),
                new Bettor("34#Morgan Riley#16"),
                new Bettor("35#Jasmin Morse#17"),
                new Bettor("36#Reagan Dunn#10"),
                new Bettor("37#Krista Ali#18"),
                new Bettor("38#Jacob Turner#1"),
                new Bettor("39#Tamia Mckee#8"),
                new Bettor("40#Darius Hester#9"),
                new Bettor("41#Anaya Oconnor#5"),
                new Bettor("42#Angelique Forbes#21"),
                new Bettor("43#Krista Wade#6"),
                new Bettor("44#Allie Lawson#17"),
                new Bettor("45#Samantha Gibson#23"),
                new Bettor("46#Arianna Olson#26"),
                new Bettor("47#Lennon Avila#18"),
                new Bettor("48#Blaine Randall#19"),
                new Bettor("49#Izabelle Mcfarland#9"),
                new Bettor("50#Beau Nguyen#18"),
                new Bettor("51#Lucia Frazier#11"),
                new Bettor("52#Kelton Patterson#19"),
                new Bettor("53#Maggie Carney#26"),
                new Bettor("54#Tabitha Mercado#11"),
                new Bettor("55#Talan Olsen#16"),
                new Bettor("56#Annie Hopkins#26"),
                new Bettor("57#Heather Nicholson#20"),
                new Bettor("58#Sharon Mclaughlin#17"),
                new Bettor("59#Bethany Merritt#21"),
                new Bettor("60#Zavier Lee#4"),
                new Bettor("61#Ty White#18"),
                new Bettor("62#Rayan Ortega#2"),
                new Bettor("63#Jax Deleon#8"),
                new Bettor("64#Kaylynn Steele#4"),
                new Bettor("65#Zion Donaldson#20"),
                new Bettor("66#Toby Hoffman#12"),
                new Bettor("67#Finnegan Wright#17"),
                new Bettor("68#Deacon Maddox#24"),
                new Bettor("69#Dax Ho#22"),
                new Bettor("70#Declan Glover#9"),
                new Bettor("71#Trey Mcpherson#16"),
                new Bettor("72#Kenneth Wallace#25"),
                new Bettor("73#Jaquan Ray#25"),
                new Bettor("74#Mike Wallace#9"),
                new Bettor("75#Elaine Hayden#15"),
                new Bettor("76#Will Hayden#24"),
                new Bettor("77#Noah Mcclain#13"),
                new Bettor("78#Haiden Wilkinson#3"),
                new Bettor("79#Jerome Lozano#23"),
                new Bettor("80#Adelyn Mejia#21"),
                new Bettor("81#Jarrett Castro#16"),
                new Bettor("82#Angela Fry#8"),
                new Bettor("83#Valentin Nicholson#21"),
            });
        }
    }
}
