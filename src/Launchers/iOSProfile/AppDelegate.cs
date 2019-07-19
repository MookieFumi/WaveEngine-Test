namespace XamarinForms3DCarSample
{
    using System;
    using Foundation;
    using UIKit;
    using WaveEngine.Common;
    using Xamarin.Forms;
    using XamarinForms3DCarSample.Helpers;

    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private IGame _game;
        //private UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //this.window = new UIWindow(UIScreen.MainScreen.Bounds);

            //var mainStoryboard = UIStoryboard.FromName("Main", null);
            //var mainController = (MainController)mainStoryboard.InstantiateViewController(typeof(MainController).Name);

            //this.window.RootViewController = mainController;
            //this.window.MakeKeyAndVisible();

            //return true;

            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
