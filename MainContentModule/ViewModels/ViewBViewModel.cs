using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPlayground.Infrastructure.Events;

namespace MainContentModule.ViewModels
{
    [Export]
    public class ViewBViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private ObservableCollection<string> _messages;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        [ImportingConstructor]
        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            Messages = new ObservableCollection<string>
            {
                "Zeb", "Waqas", "Hammad"
            };
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<AddMessageEvent>().Subscribe(AddMessageToCollection);
        }

        private void AddMessageToCollection(string message)
        {
            Messages.Add(message);
        }
    }
}
