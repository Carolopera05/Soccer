﻿using Prism;
using Prism.Ioc;
using Soccer.Common.Helpers;
using Soccer.Common.Services;
using Soccer.Prism.ViewModels;
using Soccer.Prism.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Soccer.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjIwNDM2QDMxMzcyZTM0MmUzMEU3bnlkamdEeE1aQTBRZGJpUFd0UkdKNTFxbkJxNjd5b3hyS3NFa09KT0U9");
            InitializeComponent();

            await NavigationService.NavigateAsync("/SoccerMasterDetailPage/NavigationPage/TournamentsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<ITransformHelper, TransformHelper>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TournamentsPage, TournamentsPageViewModel>();
            containerRegistry.RegisterForNavigation<GroupsPage, GroupsPageViewModel>();
            containerRegistry.RegisterForNavigation<MatchesPage, MatchesPageViewModel>();
            containerRegistry.RegisterForNavigation<ClosedMatchesPage, ClosedMatchesPageViewModel>();
            containerRegistry.RegisterForNavigation<TournamentTabbedPage, TournamentTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SoccerMasterDetailPage, SoccerMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MyPredictionsPage, MyPredictionsPageViewModel>();
            containerRegistry.RegisterForNavigation<MyPositionsPage, MyPositionsPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
