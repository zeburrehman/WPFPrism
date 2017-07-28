using System;
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
            //changeTheme();
        }

        private void changeTheme()
        {
            var app = (App)Application.Current;
            app.ChangeTheme(new Uri("pack://application:,,,/WpfPlayground.Infrastructure;component/Style/Themes/DarkColors.xaml"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeTheme();
        }

    }
}
