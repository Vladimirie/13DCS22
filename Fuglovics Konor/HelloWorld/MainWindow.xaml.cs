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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			/*StackPanel stack = new();
			this.Content = stack;
			Button btn = new();
			btn.Content = "Click here!";
			btn.HorizontalAlignment = HorizontalAlignment.Left;
			btn.Margin = new Thickness(150);
			btn.VerticalAlignment = VerticalAlignment.Top;
			btn.Width = 75;
			stack.Children.Add(btn);*/
        }
    }
}