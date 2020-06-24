using System;
using System.Collections.Generic;
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

namespace QuizMyNumber
{
    /// <summary>
    /// Interaction logic for WindowNewName.xaml
    /// </summary>
    public partial class WindowNewName : Window
    {
        public WindowNewName()
        {
            InitializeComponent();
            TextBlockName.Focus();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NewName = TextBlockName.Text;
            this.Close();
        }
    }
}
