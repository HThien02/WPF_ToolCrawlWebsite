using System.Net;
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

namespace WPF_ToolCrawlWebsite
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string url = txtLink.Text.Trim();

            if (!string.IsNullOrEmpty(url) )
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string html = client.DownloadString(url);

                        DisplayHtmlInListView(html);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Please enter a valid website URL.");
            }
        }

        private void DisplayHtmlInListView(string html)
        {
            listView.Items.Clear();

            listView.Items.Add(html);
        }
    }
}