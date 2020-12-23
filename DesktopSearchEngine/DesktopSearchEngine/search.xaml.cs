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
using System.Diagnostics;

namespace DesktopSearchEngine
{
    /// <summary>
    /// Logika interakcji dla klasy search.xaml
    /// </summary>
    public partial class search : Window
    {
        public search()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                if (Properties.Settings.Default.DefaultSearch == "google")
                    Process.Start("https://google.com/search?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "duckduckgo")
                    Process.Start("https://duckduckgo.com/?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "bing")
                    Process.Start("https://www.bing.com/search?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "yahoo")
                    Process.Start("https://search.yahoo.com/search?p=" + textBox1.Text);

                this.Close();
            }
        }
    }
}
