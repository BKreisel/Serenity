using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Serenity.ViewModels;

namespace Serenity.Views
{
    public sealed partial class GeneralSettingsView : Page
    {
        public GeneralSettingsView()
        {
            this.InitializeComponent();
            this.DataContext =  Ioc.Default.GetRequiredService<GeneralSettingsViewModel>();
    }
        public GeneralSettingsViewModel ViewModel => (GeneralSettingsViewModel)DataContext;
    }
}
