using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.System;
using Microsoft.Phone.Tasks;

namespace Simangkot
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "FAQ:SIMANGKOT";
            emailComposeTask.Body = "FAQ:";
            emailComposeTask.To = "arify@outlook.co.id";

            emailComposeTask.Show();
        }

        }
    }