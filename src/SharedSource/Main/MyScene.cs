using WaveEngine.Framework;

namespace XamarinForms3DCarSample
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            this.Load(WaveContent.Scenes.MyScene);
        }

        protected override void Start()
        {
            base.Start();

#if ANDROID || IOS
            Xamarin.Forms.MessagingCenter.Send(this, MessengerKeys.SceneInitialized);
#endif
        }
    }
}
