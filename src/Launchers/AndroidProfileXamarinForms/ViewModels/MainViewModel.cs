using System.Windows.Input;
using XamarinForms3DCarSample.Helpers;
using Xamarin.Forms;
using System;
using XamarinForms3DCarSampleXamarinForms.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinForms3DCarSampleXamarinForms.ViewModels.Base;
using Prism.Navigation;
using Prism.Services;

namespace XamarinForms3DCarSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isPanelExpanded;
        private bool _isInit;
        private bool _isEnabled;
        private GridLength _columnWidth;

        public MainViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            IsPanelExpanded = false;
            IsInit = false;
            IsEnabled = true;
            ColumnWidth = new GridLength(1, GridUnitType.Star); 

            WaveEngineFacade.Initialized += OnInitialized;
            WaveEngineFacade.AnimationCompleted += OnAnimationCompleted;
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

        public bool IsInit
        {
            get { return _isInit; }
            set {
                SetProperty(ref _isInit, value);
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        public ICommand ChangeCameraCommand => new Command<string>(ChangeCamera);

        public ICommand OpenMenuCommand => new Command(OpenMenu);

        public ICommand CloseMenuCommand => new Command(CloseMenu);

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

        private void ChangeCamera(string camera)
        {
            IsEnabled = false;

            var cameraType = Enum.Parse(typeof(CameraType), camera);

            //IsCamera1 = false;
            //IsCamera2 = false;
            //IsCamera3 = false;

            //switch ((CameraType)cameraType)
            //{
            //    case CameraType.Camera1:
            //        //IsCamera1 = true;
            //        break;
            //    case CameraType.Camera2:
            //        IsCamera2 = true;
            //        break;
            //    case CameraType.Camera3:
            //        IsCamera3 = true;
            //        break;
            //}

            WaveEngineFacade.SetActiveCamera((int)cameraType);
        }

        private void OpenMenu()
        {
            MessagingCenter.Send(this, MessengerKeys.OpenColors);
        }

        private void CloseMenu()
        {
            MessagingCenter.Send(this, MessengerKeys.CloseColors);
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            IsInit = true;

            //foreach (var color in LoadColors())
            //{
            //    Colors.Add(color);
            //}
        }

        //private void ChooseColor(CustomColor color)
        //{
        //    MessagingCenter.Send(this, MessengerKeys.CloseColors);
        //    WaveEngineFacade.UpdateColor(color);
        //}

        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            IsEnabled = true;
        }
    }
}
