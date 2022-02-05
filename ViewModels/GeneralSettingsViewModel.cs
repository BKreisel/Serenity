using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Serenity.Models;
using Serenity.Services;

namespace Serenity.ViewModels
{
    public sealed class GeneralSettingsViewModel : ObservableObject
    {
        private readonly ISettingsService settingsService = Ioc.Default.GetRequiredService<ISettingsService>();

        private readonly string category = "general";

        private readonly GeneralSettings genSettings;

        public bool IsEnabled
        {
            get => genSettings.IsEnabled;
            set
            {
                genSettings.IsEnabled = value;
                settingsService.SetValue<bool>(category, "IsEnabled", value);
            }
        }

        public Int32 IntervalHours
        {
            get => genSettings.Interval.Hours;
            set
            {
                genSettings.Interval = new(value, genSettings.Interval.Minutes, genSettings.Interval.Seconds);
                settingsService.SetValue<TimeSpan>(category, "Interval", genSettings.Interval);
            }
        }

        public Int32 IntervalMinutes
        {
            get => genSettings.Interval.Minutes;
            set
            {
                genSettings.Interval = new(genSettings.Interval.Hours, value,  genSettings.Interval.Seconds);
                settingsService.SetValue<TimeSpan>(category, "Interval", genSettings.Interval);
            }
        }

        public Int32 IntervalSeconds
        {
            get => genSettings.Interval.Seconds;
            set
            {
                genSettings.Interval = new(genSettings.Interval.Hours, genSettings.Interval.Minutes, value);
                settingsService.SetValue<TimeSpan>(category, "Interval", genSettings.Interval);
            }
        }

        /// <summary>
        /// Read the model from storage or set defaults
        /// </summary>
        public GeneralSettingsViewModel()
        {
            genSettings = new GeneralSettings
            {
                IsEnabled = settingsService.GetValue<bool?>(category, "IsEnabled").GetValueOrDefault(false),
                Interval = settingsService.GetValue<TimeSpan?>(category, "Interval").GetValueOrDefault(TimeSpan.FromMinutes(1)),
            };
        }


    }
}
