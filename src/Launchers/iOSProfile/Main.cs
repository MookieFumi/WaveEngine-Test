using System;
using UIKit;
using WaveEngine.Common;
using Xamarin.Forms;
using XamarinForms3DCarSample.Helpers;

namespace XamarinForms3DCarSample
{
    public class Application : WaveEngine.Adapter.Application
    {
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        private IGame game;

        public override void Initialize()
        {
            MessagingCenter.Subscribe<MyScene>(this, MessengerKeys.SceneInitialized, OnSceneLoaded);

            this.game = new XamarinForms3DCarSample.Game();
            this.game.Initialize(this);
        }

        public override void Update(TimeSpan elapsedTime)
        {
            this.game.UpdateFrame(elapsedTime);
        }

        public override void Draw(TimeSpan elapsedTime)
        {
            this.game.DrawFrame(elapsedTime);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (this.game != null)
            {
                this.game.OnActivated();
            }
        }

        public override void ViewWillUnload()
        {
            base.ViewWillUnload();

            this.game.OnDeactivated();
        }

        public void OnSceneLoaded(MyScene scene)
        {
            WaveEngineFacade.Initialize(scene);
        }
    }
}