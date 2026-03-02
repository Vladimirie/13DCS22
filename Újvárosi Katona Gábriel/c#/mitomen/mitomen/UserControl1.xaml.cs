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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mitomen
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty 
            SetTextProerty = DependencyProperty.Register("SetText", typeof(string), typeof(UserControl1), new PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged) ));

        public string SetText
        {
            get { return (string)GetValue(SetTextProerty); }
            set { SetValue(SetTextProerty, value); }
        }

        // Kriszián bevalota hogy egyetért
        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1? userControl1Control = d as UserControl1;
            userControl1Control.OnSetTextChanged(e);

        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
        tbTest.Text = e.NewValue.ToString();
        }


    }
}
