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
                var query = from c in context.ALERTs
                            orderby c.Username
                            select c;



                foreach (var item in query)
                {
                    int votedPostId;
                    int downvote = 0;
                    int upvote = 0;

                    votedPostId = Convert.ToInt32(item.POST_ID);

                    var queryVoteDownCount = from a in context.VOTEDOWN_VIEW
                                             where a.POST_ID == votedPostId
                                             orderby a.POST_ID
                                             select a;
                    foreach (var voteDownItem in queryVoteDownCount)
                    {
                        downvote++;
                    }

                    var queryVoteUpCount = from a in context.VOTEUP_VIEW
                                           where a.POST_ID == votedPostId
                                           orderby a.POST_ID
                                           select a;

                    foreach (var voteUpItem in queryVoteUpCount)
                    {
                        upvote++;
                    }

                    var q = item.Username + "\n" + item.POST_TIME + "\n" + item.DETAILS;

                 

       


                    Label lblAlert = new Label();
                    lblAlert.Content = q;
                    lblAlert.FontSize = 20;




                    listBox.Items.Add(lblAlert);



                }
            }

        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
