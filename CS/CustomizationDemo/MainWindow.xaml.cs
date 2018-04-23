using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;

namespace CustomizationDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnApplyEffectButtonClick(object sender, RoutedEventArgs e) {
            if(edit.ImageEffect == null)
                edit.ImageEffect = new GrayscaleEffect();
        }

        private void OnUndoEffectButtonClick(object sender, RoutedEventArgs e) {
            edit.ImageEffect = null;
        }
    }
}
