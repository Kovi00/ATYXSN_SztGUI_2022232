using ATYXSN_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ATYXSN_HFT_2021222_WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Match> Matches { get; set; }

        public RestCollection<Bettor> Bettors { get; set; }

        public RestCollection<Bookmaker> Bookmakers { get; set; }

        private Match selectedMatch;

        private Bettor selectedBettor;

        private Bookmaker selectedBookmaker;

        public Match SelectedMatch
        {
            get { return selectedMatch; }
            set 
            {
                if (value != null)
                {
                    selectedMatch = new Match()
                    {
                        HomeTeam = value.HomeTeam,
                        AwayTeam = value.AwayTeam,
                        MatchId = value.MatchId,
                        Outcome = value.Outcome,
                        Odds = value.Odds,
                        BookmakerId = value.BookmakerId
                    };
                    OnPropertyChanged();
                    (DeleteMatchCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Bettor SelectedBettor
        {
            get { return selectedBettor; }
            set
            {
                if (value != null)
                {
                    selectedBettor = new Bettor()
                    {
                        BettorId = value.BettorId,
                        BettorName = value.BettorName,
                        MatchId = value.MatchId
                    };
                    OnPropertyChanged();
                    (DeleteBettorCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public Bookmaker SelectedBookmaker
        {
            get { return selectedBookmaker; }
            set
            {
                if (value != null)
                {
                    selectedBookmaker = new Bookmaker()
                    {
                        BookmakerId = value.BookmakerId,
                        BookmakerName = value.BookmakerName,
                    };
                    OnPropertyChanged();
                    (DeleteBookmakerCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public ICommand CreateMatchCommand { get; set; }

        public ICommand DeleteMatchCommand { get; set; }

        public ICommand UpdateMatchCommand { get; set; }

        public ICommand CreateBettorCommand { get; set; }

        public ICommand DeleteBettorCommand { get; set; }

        public ICommand UpdateBettorCommand { get; set; }

        public ICommand CreateBookmakerCommand { get; set; }

        public ICommand DeleteBookmakerCommand { get; set; }

        public ICommand UpdateBookmakerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Matches = new RestCollection<Match>("http://localhost:48810/", "match", "hub");
                CreateMatchCommand = new RelayCommand(() =>
                {
                    Matches.Add(new Match()
                    {
                        HomeTeam = SelectedMatch.HomeTeam,
                        AwayTeam = SelectedMatch.AwayTeam,
                        Outcome = SelectedMatch.Outcome,
                        Odds = SelectedMatch.Odds,
                        BookmakerId = SelectedMatch.BookmakerId
                    });
                });

                UpdateMatchCommand = new RelayCommand(() =>
                {
                    Matches.Update(SelectedMatch);
                }
                );

                DeleteMatchCommand = new RelayCommand(() =>
                {
                    Matches.Delete(SelectedMatch.MatchId);
                },
                () =>
                {
                    return SelectedMatch != null;
                });
                SelectedMatch = new Match();

                Bettors = new RestCollection<Bettor>("http://localhost:48810/", "bettor", "hub");
                CreateBettorCommand = new RelayCommand(() =>
                {
                    Bettors.Add(new Bettor()
                    {
                        BettorName = SelectedBettor.BettorName,
                        MatchId = SelectedBettor.MatchId
                    });
                });

                UpdateBettorCommand = new RelayCommand(() =>
                {
                    Bettors.Update(SelectedBettor);
                }
                );

                DeleteBettorCommand = new RelayCommand(() =>
                {
                    Bettors.Delete(SelectedBettor.BettorId);
                },
                () =>
                {
                    return SelectedBettor != null;
                });
                SelectedBettor = new Bettor();

                Bookmakers = new RestCollection<Bookmaker>("http://localhost:48810/", "bookmaker", "hub");
                CreateBookmakerCommand = new RelayCommand(() =>
                {
                    Bookmakers.Add(new Bookmaker()
                    {
                        BookmakerName = SelectedBookmaker.BookmakerName,
                    });
                });

                UpdateBookmakerCommand = new RelayCommand(() =>
                {
                    Bookmakers.Update(SelectedBookmaker);
                }
                );

                DeleteBookmakerCommand = new RelayCommand(() =>
                {
                    Bookmakers.Delete(SelectedBookmaker.BookmakerId);
                },
                () =>
                {
                    return SelectedBettor != null;
                });
                SelectedBookmaker = new Bookmaker();
            }
        }
    }
}
