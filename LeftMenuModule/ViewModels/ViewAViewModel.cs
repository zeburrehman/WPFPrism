using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPlayground.Infrastructure.Events;

namespace LeftMenuModule.ViewModels
{
    [Export]
    public class ViewAViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _addMessage;

        public DelegateCommand AddMessage
        {
            get { return _addMessage; }
            set { _addMessage = value; }
        }

        [ImportingConstructor]
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            AddMessage = new DelegateCommand(AddMessageToListBox, CanAddMessageToListBox).ObservesProperty(() => Message);
            this.eventAggregator = eventAggregator;
        }

        private bool CanAddMessageToListBox()
        {
            return !String.IsNullOrEmpty(Message);
        }

        private void AddMessageToListBox()
        {
            eventAggregator.GetEvent<AddMessageEvent>().Publish(Message);
        }
    }
}
