using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MonkeyFestDemo.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyFestDemo.ViewModels
{
   public class SerieDetailsPageViewModel : ViewModelBase
    {
        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set { SetProperty(ref serie, value); }
        }

        public SerieDetailsPageViewModel(INavigationService navigationService):
            base(navigationService)
        {
            Title = "Details";
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Serie = (Serie)parameters["model"];

            //TODO: Add Analytics to track event with the Serie's data
            AppCenter.Start("a5cf44a9-a37b-4c72-b4b5-07092d4cf7ec",
                   typeof(Analytics), typeof(Crashes));
            Analytics.TrackEvent("List of series fetched from internet");
            var analyticsData = new Dictionary<string, string> { { "Name", Serie.Name } };
            Analytics.TrackEvent("Serie clicked", analyticsData);
            //TODO: Add fake crash if the name of the serie contains "Game of"

            AppCenter.Start("a5cf44a9-a37b-4c72-b4b5-07092d4cf7ec",
                               typeof(Analytics), typeof(Crashes));
            if (Serie.Name.Contains("Game of"))
            {
                Crashes.TrackError(new Exception("The winter is here!"));
            }

        }

    }
}
