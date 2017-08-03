using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfPlayground.ViewModels
{
    [Export]
    public class MainShellViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        
        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get { return _submitCommand; }
            set { SetProperty(ref _submitCommand, value); }
        }

        private bool _canSubmitCommand;

        public bool CanSubmitCommand
        {
            get { return _canSubmitCommand; }
            set { SetProperty(ref _canSubmitCommand, value); }
        }


        public MainShellViewModel()
        {
            Message = "Hello World";
            SubmitCommand = new DelegateCommand<string>(Submit, CanSubmit).ObservesProperty(() => CanSubmitCommand);
            CanSubmitCommand = false;

            ListOfItems = new ObservableCollection<string>() { "One", "Two", "Three", "Four", "Five" };
            SelectCommand = new DelegateCommand<object>(SetSelectedItem);
        }

        private bool CanSubmit(string name)
        {
            return CanSubmitCommand;
        }

        private void Submit(string name)
        {
            Message = $"Changed World by {name}";
        }


        public ObservableCollection<string> ListOfItems { get; set; }
        public ICommand SelectCommand { get; set; }
        private string _selectedItem = string.Empty;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty<string>(ref _selectedItem, value); }
        }
        
        private void SetSelectedItem(object listOfItems)
        {
            //if (listOfItems != null && listOfItems.Count() > 0)
            //{ SelectedItem = listOfItems.FirstOrDefault().ToString(); }
        }
    }
}
