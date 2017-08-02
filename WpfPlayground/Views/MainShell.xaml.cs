using System.ComponentModel.Composition;
using System.Windows;

namespace WpfPlayground.Views
{
    /// <summary>
    /// Interaction logic for MainShell.xaml
    /// </summary>
    [Export]
    public partial class MainShell : Window
    {
        public MainShell()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
