using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Serenity.Models
{
    /// <summary>
    /// Settings related to the application
    /// </summary>
    public class GeneralSettings : ObservableObject
    {
        private bool isEnabled;
        private TimeSpan interval;

        /// <summary>
        ///  Represents the state of the wallpaper switching behavior
        /// </summary>
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        /// <summary>
        /// How often the wallpaper cycles
        /// </summary>
        public TimeSpan Interval
        {
            get => interval;
            set => SetProperty(ref interval, value);
        }
    }
}
