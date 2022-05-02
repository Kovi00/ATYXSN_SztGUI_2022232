using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATYXSN_HFT_2021222.Models.Bettor;
using static ATYXSN_HFT_2021222.Models.Match;

namespace ATYXSN_HFT_2021222.Test
{
    [TestFixture]
    public class Tester
    {
        MatchLogic matchLogic;
        BettorLogic bettorLogic;
        BookmakerLogic bookmakerLogic;
        Mock<IRepository<Models.Match>> mockMatchRepo;
        Mock<IRepository<Bettor>> mockBettorRepo;
        Mock<IRepository<Bookmaker>> mockBookmakerRepo;

        Models.Match match1;
        Models.Match match2;
        Models.Match match3;
        Bookmaker book1;
        Bookmaker book2;
        Bettor bettor1;
        Bettor bettor2;
        Bettor bettor3;

        [SetUp]
        public void Init()
        {
            book1 = new Bookmaker()
            {
                BookmakerId = 1,
                BookmakerName = "sportsBet"
            };

            book2 = new Bookmaker()
            {
                BookmakerId = 2,
                BookmakerName = "bookmakers.net"
            };
            mockBookmakerRepo = new Mock<IRepository<Bookmaker>>();
            mockBookmakerRepo.Setup(m => m.ReadAll()).Returns(new List<Bookmaker>()
            {
                book1, book2
            }.AsQueryable());
            bookmakerLogic = new BookmakerLogic(mockBookmakerRepo.Object);


            match1 = new Models.Match()
            {
                MatchId = 1,
                HomeTeam = "Real",
                AwayTeam = "Barcelona",
                Outcome = 'H',
                Odds = 2,
                BookmakerId = 1,
                Bookmaker = book1,
            };
            match2 = new Models.Match()
            {
                MatchId = 2,
                HomeTeam = "Inter",
                AwayTeam = "Juventus",
                Outcome = 'X',
                Odds = 3,
                BookmakerId = 2,
                Bookmaker = book2,
            };
            match3 = new Models.Match()
            {
                MatchId = 3,
                HomeTeam = "Dortmund",
                AwayTeam = "Bayern",
                Outcome = 'A',
                Odds = 4,
                BookmakerId = 1,
                Bookmaker = book1
            };
            mockMatchRepo = new Mock<IRepository<Models.Match>>();
            mockMatchRepo.Setup(m => m.ReadAll()).Returns(new List<Models.Match>()
            {
                match1, match2, match3
            }.AsQueryable());
            matchLogic = new MatchLogic(mockMatchRepo.Object);

            bettor1 = new Bettor()
            {
                BettorId = 1,
                BettorName = "Vinko Frans",
                MatchId = 1,
                Match = match1,
            };
            bettor2 = new Bettor()
            {
                BettorId = 2,
                BettorName = "Aili Sylvanus",
                MatchId = 2,
                Match = match2,
            };
            bettor3 = new Bettor()
            {
                BettorId = 3,
                BettorName = "Aira Madhav",
                MatchId = 3,
                Match = match3,
            };

            mockBettorRepo = new Mock<IRepository<Bettor>>();
            mockBettorRepo.Setup(m => m.ReadAll()).Returns(new List<Bettor>()
            {
                bettor1, bettor2, bettor3
            }.AsQueryable());
            bettorLogic = new BettorLogic(mockBettorRepo.Object);
        }


        [Test]
        public void AVGOddsTest()
        {
            var actual = matchLogic.AverageOddsByBookmaker().ToList();
            var expected = new List<OddsInfo>()
            {
                new OddsInfo() {Name = "sportsBet", Odds = 3},
                new OddsInfo() {Name = "bookmakers.net" ,Odds = 3}
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MatchOfferTest()
        {
            var actual = matchLogic.MatchOffersByBookmaker().ToList();
            var expected = new List<MatchInfo>()
            {
                new MatchInfo() { Name = "sportsBet", Matches = 2},
                new MatchInfo() { Name = "bookmakers.net", Matches = 1}
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BiggestOddsTest()
        {
            var actual = matchLogic.BiggestOddsByBookmaker().ToList();
            var expected = new List<BiggestOdds>()
            {
                new BiggestOdds() {Name = "sportsBet", Odds=4},
                new BiggestOdds() {Name = "bookmakers.net", Odds=3}
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NumberOfDrawsTest()
        {
            var actual = matchLogic.NumberOfDrawsByBookmaker().ToList();
            var expected = new List<DrawInfo>()
            {
                new DrawInfo() {Name = "bookmakers.net", Draws=1},
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BetsTest()
        {
            var actual = bettorLogic.BetsByBookmaker().ToList();
            var expected = new List<BetInfo>()
            {
                new BetInfo() {Name = "sportsBet", Count = 2},
                new BetInfo() {Name = "bookmakers.net", Count = 1},
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateMatchExceptionTest()
        {
            var match = new Models.Match() { Outcome = 'G' };
            try
            {
                matchLogic.Create(match);
            }
            catch
            {
            }

            mockMatchRepo.Verify(r => r.Create(match), Times.Never);
        }

        [Test]
        public void CreateBettorExceptionTest()
        {
            var bettor = new Bettor() { BettorName = "G" };
            try
            {
                bettorLogic.Create(bettor);
            }
            catch
            {
            }

            mockBettorRepo.Verify(r => r.Create(bettor), Times.Never);
        }

        [Test]
        public void CreateBookmakerExceptionTest()
        {
            var bookmaker = new Bookmaker() { BookmakerName = "bet" };
            try
            {
                bookmakerLogic.Create(bookmaker);
            }
            catch
            {
            }

            mockBookmakerRepo.Verify(r => r.Create(bookmaker), Times.Never);
        }

        [Test]
        public void CreateBookmakerTest()
        {
            var bookmaker = new Bookmaker() { BookmakerId = 3, BookmakerName = "Tippmix" };
            bookmakerLogic.Create(bookmaker);
            mockBookmakerRepo.Verify(r => r.Create(bookmaker), Times.Once);
        }

        [Test]
        public void CreateBettorTest()
        {
            var bettor = new Bettor() { BettorId = 4, BettorName = "Ferike", MatchId = 2, Match = match2};
            bettorLogic.Create(bettor);
            mockBettorRepo.Verify(r => r.Create(bettor), Times.Once);
        }

        [Test]
        public void CreateMatchTest()
        {
            var match = new Models.Match() { MatchId = 4, Outcome = 'H'};
            matchLogic.Create(match);
            mockMatchRepo.Verify(r => r.Create(match), Times.Once);
        }
    }
}
