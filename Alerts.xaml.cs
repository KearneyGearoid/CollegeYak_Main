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
    /// Interaction logic for Alerts.xaml
    /// </summary>
    public partial class Alerts : Window
    {
        String username;

        public Alerts(String username)
        {
            InitializeComponent();
            LoadAlerts();
            this.username = username;
        }


        public void LoadAlerts()
        {
            using (var context = new Entities())
            {
                var query = from c in context.VOTEs
                            select c;

                var q = "";

                foreach (var item in query)
                {


                     q = item.USERNAME_POSTER + "\n" + item.POST_ID + "\n" + item.USERNAME_VOTER;


                    



                    Label lblAlert = new Label();
                    lblAlert.Content = q;
                    lblAlert.FontSize = 20;




                    listBox.Items.Add(lblAlert);



                }
                MessageBox.Show("The alert is " + q);

            }

        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Dashboard back = new Dashboard(username);
            back.Show();
            this.Hide();
        }
    }
}
