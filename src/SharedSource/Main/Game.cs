using WaveEngine.Common;
using WaveEngine.Framework.Services;

namespace XamarinForms3DCarSample
{
    public class Game : WaveEngine.Framework.Game
    {
        public override void Initialize(IApplication application)
        {
            base.Initialize(application);

            Load(WaveContent.GameInfo);
            
            var screenContext = new ScreenContext(new MyScene());
            WaveServices.ScreenContextManager.To(screenContext);
        }
    }
}