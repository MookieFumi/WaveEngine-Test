using WaveEngine.Framework;
using Xamarin.Forms;

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

#if ANDROID || iOS
            MessagingCenter.Send(this, MessengerKeys.SceneInitialized);
#endif
        }
    }
}
