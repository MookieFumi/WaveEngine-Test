using Prism.Ioc;
using XamarinForms3DCarSample.ViewModels;
using XamarinForms3DCarSample.Views;

namespace XamarinForms3DCarSampleXamarinForms.Extensions
{
    public static class IContainerRegistryExtensions
    {
        public static void AddViews(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
        }

        public static void AddServices(this IContainerRegistry containerRegistry)
        {           
        }
    }
}
