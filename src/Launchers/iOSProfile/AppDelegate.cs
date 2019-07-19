namespace XamarinForms3DCarSample
{
    using Foundation;
    using UIKit;

    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
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
