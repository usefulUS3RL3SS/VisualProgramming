using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

using System.Text;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<League> Leagues { get; set; }
        public ObservableCollection<Result> Results { get; set; }

        public MainWindowViewModel()
        {
            Players = new ObservableCollection<Player>();
            Countries = new ObservableCollection<Country>();
            Teams = new ObservableCollection<Team>();
            Leagues = new ObservableCollection<League>();
            Results = new ObservableCollection<Result>();

            using (var db = new data_baseContext())
            {
                foreach (var record in db.Players) Players.Add(record);
                foreach (var record in db.Countries) Countries.Add(record);
                foreach (var record in db.Teams) Teams.Add(record);
                foreach (var record in db.Leagues) Leagues.Add(record);
                foreach (var record in db.Results) Results.Add(record);
            }

            Content = new DataBaseViewModel();
        }
    }
}
