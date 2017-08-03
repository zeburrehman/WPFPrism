using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System.ComponentModel.Composition;

namespace WpfPlayground.ViewModels
{
    [Export]
    public class InteractionWindowViewModel : BindableBase
    {
        private string _notificationResult;

        public string NotificationResult
        {
            get { return _notificationResult; }
            set { SetProperty(ref _notificationResult, value); }
        }

        private ICommand _notificationCommand;
        public ICommand NotificationCommand
        {
            get { return _notificationCommand; }
            set { SetProperty(ref _notificationCommand, value); }
        }

        private ICommand _confirmationCommand;
        public ICommand ConfirmationCommand
        {
            get { return _confirmationCommand; }
            set { SetProperty(ref _confirmationCommand, value); }
        }

        private ICommand _customPopupCommand;
        public ICommand CustomPopupCommand
        {
            get { return _customPopupCommand; }
            set { SetProperty(ref _customPopupCommand, value); }
        }

        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public InteractionRequest<INotification> CustomPopupRequest { get; set; }

        public InteractionWindowViewModel()
        {
            NotificationRequest = new InteractionRequest<INotification>();
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            CustomPopupRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);
            CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);
        }

        private void RaiseCustomPopup()
        {
            this.CustomPopupRequest.Raise(new Notification { Title = "Hello Custom Popup", Content = "Zeb is a good guy." });
        }

        private void RaiseConfirmation()
        {
            this.ConfirmationRequest.Raise(new Confirmation { Title = "Hello Confirmation", Content = "This is Sparta" },
                (result) => {
                    NotificationResult = result.Confirmed ? "Confirmed" : "Not Confirmed";
                });
        }

        private void RaiseNotification()
        {
            this.NotificationRequest.Raise(new Notification { Title = "Hello Notification", Content = "This is Sparta" }, 
                (result) => {
                    NotificationResult = "Notified";
                });
        }
    }
}
