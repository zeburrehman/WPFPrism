﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPlayground.Views
{
    /// <summary>
    /// Interaction logic for InteractionWindow.xaml
    /// </summary>
    [Export]
    public partial class InteractionWindow : Window
    {
        public InteractionWindow()
        {
            InitializeComponent();
        }
    }
}
