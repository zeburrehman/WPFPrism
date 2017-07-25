using System.ComponentModel.Composition;
using System.Windows;

namespace WpfPlayground
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
    }
}
