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

namespace CollegeYak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            using (Entities context = new Entities())
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                var login = context.LOGGINGIN(username, password);

      
                Dashboard dash = new Dashboard(username);
                dash.Show();
                this.Hide();
            }
        }

        private void btn_Signup_Click(object sender, RoutedEventArgs e)
        {
            Signup signUp = new Signup();
            signUp.Show();
            this.Hide();
        }
    }
}
