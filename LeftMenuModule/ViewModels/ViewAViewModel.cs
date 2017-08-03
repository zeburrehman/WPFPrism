using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPlayground.Infrastructure.Events;
using System.Collections;
using System.Collections.Concurrent;
using System.Windows.Controls;
using Prism.Interactivity.InteractionRequest;

namespace LeftMenuModule.ViewModels
{
    [Export]
    public class ViewAViewModel : BindableBase
    {
        #region Private Members
        private readonly IEventAggregator eventAggregator;
        //private ErrorsContainer<ValidationResult> errorsContainer = new ErrorsContainer<ValidationResult>(pn => RaiseErrorsChanged(pn));

        //private void RaiseErrorsChanged(string propertyName)
        //{
        //    var handler = ErrorsChanged;
        //    if(handler != null)
        //    {
        //        handler(this, new DataErrorsChangedEventArgs(propertyName));
        //    }
        //}

        private string _message;
        private ICommand _addMessage;
        private InteractionRequest<INotification> _notificationRequestPopup;
        private ICommand _notifiationCommand;

        #endregion

        #region Public Members
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ICommand AddMessage
        {
            get { return _addMessage; }
            set { _addMessage = value; }
        }
        public ICommand NotificationCommand
        {
            get { return this._notifiationCommand; }
            set { SetProperty(ref _notifiationCommand, value); }
        }
        public InteractionRequest<INotification> NotificationRequestPopup
        {
            get { return this._notificationRequestPopup; }
            set { SetProperty(ref _notificationRequestPopup, value); }
        }
        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        //public bool HasErrors => throw new NotImplementedException();

        //public ErrorsContainer<ValidationResult> ErrorsContainer { get => errorsContainer; set => errorsContainer = value; }
        #endregion

        #region Constructors
        [ImportingConstructor]
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            AddMessage = new DelegateCommand(AddMessageToListBox, CanAddMessageToListBox).ObservesProperty(() => Message);
            NotificationCommand = new DelegateCommand(ShowNotificationWindow);
            NotificationRequestPopup = new InteractionRequest<INotification>();
            this.eventAggregator = eventAggregator;
        }

        private void ShowNotificationWindow()
        {
            NotificationRequestPopup.Raise(new Notification { Title = "Request Confirmation", Content = "Notificaiton Message" });
        }
        #endregion

        #region Methods
        private bool CanAddMessageToListBox()
        {
            return !String.IsNullOrEmpty(Message);
        }

        private void AddMessageToListBox()
        {
            eventAggregator.GetEvent<AddMessageEvent>().Publish(Message);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
