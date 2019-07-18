using System.Windows.Input;
using XamarinForms3DCarSample.Helpers;
using Xamarin.Forms;
using XamarinForms3DCarSampleXamarinForms.ViewModels.Base;
using Prism.Navigation;
using Prism.Services;
using System;

namespace XamarinForms3DCarSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isPanelExpanded;
        private GridLength _columnWidth;

        public MainViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            IsPanelExpanded = false;
            ColumnWidth = new GridLength(1, GridUnitType.Star);

            WaveEngineFacade.Initialized += OnInitialized;
            //WaveEngineFacade.AnimationCompleted += OnAnimationCompleted;
        }

        private void OnInitialized(object sender, EventArgs e)
        {            
        }

        public GridLength ColumnWidth
        {
            get { return _columnWidth; }
            set { SetProperty(ref _columnWidth, value); }
        }

        public bool IsPanelExpanded
        {
            get { return _isPanelExpanded; }
            set { SetProperty(ref _isPanelExpanded, value); }
        }

        public ICommand ChangeAnimationCommand => new Command<string>(ChangeAnimation);

        public ICommand ExpandPanelCommand => new Command(ExpandPanel);

        private void ExpandPanel()
        {
            if (IsPanelExpanded)
            {
                ColumnWidth = new GridLength(1, GridUnitType.Star); 
            }
            else
            {
                ColumnWidth = new GridLength(0);
            }

            IsPanelExpanded = !IsPanelExpanded;
        }

        private void ChangeAnimation(string animation)
        {
            WaveEngineFacade.PlayAnimation(animation);
        }
    }
}
