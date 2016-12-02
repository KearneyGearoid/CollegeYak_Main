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

namespace CollegeYak
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void btn_Signup_Click(object sender, RoutedEventArgs e)
        {
            using (Entities context = new Entities())
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string college = txtCollege.Text;
                Decimal age = Convert.ToDecimal(txtAge.Text);
                string email = txtEmail.Text;

                var signup = context.SIGNIN(username, email,college,password,age);

                MessageBox.Show("Success! You're signed up");


                Dashboard dash = new Dashboard(username);
                dash.Show();
                this.Hide();
            }
        }
    }
}
