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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        ListBox posts = new ListBox();
        String username;

        public Dashboard(String username)
        {
            InitializeComponent();
            LoadPosts();
            listBox.Items.Add("Gearoid");
            this.username = username;
            lblHeader.Content = "Welcome " + username;
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        public void LoadPosts()
        {
            using (var context = new Entities())
            {
                var query = from c in context.POST_VIEW
                            orderby c.Username
                            select c;

                foreach(var item in query)
                {
                    Decimal votedPostId;
                    int downvote = 0;
                    int upvote = 0;

                    votedPostId = item.POST_ID;

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

                     Button btnUpVote = new Button();
                    btnUpVote.Content = "Up Votes";
                    //btnUpVote.Click += new RoutedEventHandler(btnUpVote_Click);
                    btnUpVote.Click += (sender, EventArgs) => { btnUpVote_Click(sender, EventArgs, item.POST_ID); };


                    Label lblUpvote = new Label();
                    lblUpvote.Content = upvote;

                    Button btnDownVote = new Button();
                    btnDownVote.Content = "Down Votes";
                    //btnDownVote.Click += new RoutedEventHandler(btnDownVote_Click);

                    btnDownVote.Click += (sender, EventArgs) => { btnDownVote_Click(sender, EventArgs, item.POST_ID); };



                    Label lblDownvote = new Label();
                    lblDownvote.Content = downvote;


                    listBox.Items.Add(q);
                    listBox.Items.Add(btnUpVote);
                    listBox.Items.Add(lblUpvote);
                    listBox.Items.Add(btnDownVote);
                    listBox.Items.Add(lblDownvote);

                }
            }

        }

        void btnUpVote_Click(object sender, RoutedEventArgs e, Decimal id)
        {

            Button buttonThatWasClicked = (Button)sender;
            MessageBox.Show("Up Vote Button pressed " + id + "\n" +  this.username
                );

        }

        void btnDownVote_Click(object sender, RoutedEventArgs e, Decimal id)
        {

            Button buttonThatWasClicked = (Button)sender;
            MessageBox.Show("Down Vote Button pressed. The post id is  " + id + "\n" + this.username);

        }


    }
}
