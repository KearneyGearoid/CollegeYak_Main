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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        String username;
        public EditProfile(String usernameMember)
        {
            InitializeComponent();
            this.username = usernameMember;
            LoadTextBoxes(username);
        }
        
        public void LoadTextBoxes(String usernameMember)
        {
            using (var context = new Entities())
            {
                var query = from c in context.MEMBERs
                            where c.USERNAME == username
                            select c;

                var q = "";

                foreach (var item in query)
                {

                    txtUsername.Text = item.USERNAME;
                    txtPassword.Text = item.PASSWORD;
                    txtEmail.Text = item.EMAIL;
                    txtCollege.Text = item.COLLEGE_NAME;
                    txtAge.Text = item.AGE.ToString();


                }

            }

        }
        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Dashboard back = new Dashboard(username);
            back.Show();
            this.Hide();
            
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Username " + txtUsername.Text + "\nPassword " + txtPassword.Text + "\nEmail + " + txtEmail.Text + "\nCollege " + txtCollege.Text + "\nAge " + txtAge.Text);

            using (Entities edit = new Entities())
            {

                try
                {
                    var editProfile = edit.UPDATEMEMBER(txtUsername.Text, txtEmail.Text, txtCollege.Text, txtPassword.Text, Convert.ToDecimal(txtAge.Text));
                    Dashboard backMain = new Dashboard(username);
                    backMain.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Your Profile was not changed");
                }
            }

        }
    }
}
