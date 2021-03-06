﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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

        public Dashboard(String usernameMember)
        {
            InitializeComponent();
            LoadPosts();
            this.username = usernameMember;
            lblHeader.Content = "" + username;
  
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

                    Button btnUpVote = new Button();
                    btnUpVote.Content = "Up Votes   " + upvote;
                    btnUpVote.Background = new SolidColorBrush(Color.FromRgb(76, 175, 80));
                    btnUpVote.Foreground = Brushes.White;
                    btnUpVote.FontSize = 17;
                    //btnUpVote.Click += new RoutedEventHandler(btnUpVote_Click);
                    btnUpVote.Click += (sender, EventArgs) => { btnUpVote_Click(sender, EventArgs, this.username, item.Username, "U", votedPostId); };


                    Label lblUpvote = new Label();
                    lblUpvote.Content = upvote;

                    Button btnDownVote = new Button();
                    btnDownVote.Content = "Down Votes " + downvote;
                    btnDownVote.Background = new SolidColorBrush(Color.FromRgb(244, 67, 54));
                    btnDownVote.Foreground = Brushes.White;
                    btnDownVote.FontSize = 17;
                    //btnDownVote.Click += new RoutedEventHandler(btnDownVote_Click);

                    //Learned this here http://stackoverflow.com/a/36948090
                    btnDownVote.Click += (sender, EventArgs) => { btnDownVote_Click(sender, EventArgs, this.username, item.Username, "D", votedPostId); };



                    Label lblPost = new Label();
                    lblPost.Content = q;
                    lblPost.FontSize = 20;
                 

                   

                    listBox.Items.Add(lblPost);
                    listBox.Items.Add(btnUpVote);
                    // listBox.Items.Add(lblUpvote);
                    listBox.Items.Add(btnDownVote);
                    // listBox.Items.Add(lblDownvote);

                }
            }
         

        }

        void btnUpVote_Click(object sender, RoutedEventArgs e, String voter, String voted, String type, int id)
        {

            Button buttonThatWasClicked = (Button)sender;
            MessageBox.Show("Up Vote Button pressed " + "\n" + voter + "\n" + voted + "\n" + type + "\n" + id);
            using (Entities context = new Entities())
            {
                try
                {
                    var login = context.CHECKVOTE(type, voter, voted, id);

                    listBox.UpdateLayout();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException + "");
                }
            }
        }

        void btnDownVote_Click(object sender, RoutedEventArgs e, String voter, String voted, String type, int id)
        {

        

            Button buttonThatWasClicked = (Button)sender;
            MessageBox.Show("Down Vote Button pressed " + "\n" + voter + "\n" + voted + "\n" + type + "\n" + id);
            using (Entities context = new Entities())
            {
                try
                {
                    var login = context.CHECKVOTE(type, voter, voted, id);

                    listBox.UpdateLayout();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException + "");
                }
            }

        }

        private void btn_Post_Click(object sender, RoutedEventArgs e)
        {

            using (Entities posts = new Entities())
            {
                var query = from p in posts.MEMBERs
                            where p.USERNAME == username
                            select p;
                var college = "";
                var details = txtPost.Text;

                foreach (var user in query)
                {
                   college = user.COLLEGE_NAME;
                }

                MessageBox.Show("" + college + "      " + details);

                 
                    try
                    {
                    var login = posts.INSERTPOST(college, username, details);
                    listBox.UpdateLayout();
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException + "");
                    }
                }



            }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logout = new MainWindow();
            logout.Show();
            this.Hide();
        }

        private void btn_Alert_Click(object sender, RoutedEventArgs e)
        {
            Alerts alertWindow = new Alerts(username);
            this.Hide();
            alertWindow.Show();
            
        }

        private void lblHeader_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile(username);
            editProfile.Show();
            this.Hide();
        }
    }
    }



