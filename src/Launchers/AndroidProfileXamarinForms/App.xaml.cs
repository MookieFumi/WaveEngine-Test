using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using XamarinForms3DCarSampleXamarinForms.Extensions;
using Xamarin.Forms.Xaml;

namespace XamarinForms3DCarSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App
    {
        public static Game Game { get; private set; }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/MainView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.AddViews();
            containerRegistry.AddServices();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<LoginModule.LoginModule>(InitializationMode.WhenAvailable);

            //moduleCatalog.AddModule<LoginModule.LoginModule>(InitializationMode.OnDemand);
            //var moduleManager = Container.Resolve<IModuleManager>();
            //moduleManager.LoadModule(nameof(LoginModule.LoginModule));
        }

        #region App Events

        protected override void OnStart()
        {
            Game = new Game();

            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
        #endregion
    }
}