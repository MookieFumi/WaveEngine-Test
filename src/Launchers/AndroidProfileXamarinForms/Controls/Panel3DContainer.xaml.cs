using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms3DCarSample;

namespace XamarinForms3DCarSampleXamarinForms.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Panel3DContainer : ContentView
    {
        public Panel3DContainer()
        {
            InitializeComponent();

            //WaveEngineSurface.Game = App.Game;            
        }
    }
}