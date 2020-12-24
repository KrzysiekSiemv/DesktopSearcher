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
using IWshRuntimeLibrary;
using Shell32;
using System.IO;

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
            textBox1.Text = "Szukaj w " + Properties.Settings.Default.DefaultSearch + "...";
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.Enter)
            {
                if (Properties.Settings.Default.DefaultSearch == "Google")
                    Process.Start("https://google.com/search?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "DuckDuckGo")
                    Process.Start("https://duckduckgo.com/?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "Bing")
                    Process.Start("https://www.bing.com/search?q=" + textBox1.Text);
                else if (Properties.Settings.Default.DefaultSearch == "Yahoo")
                    Process.Start("https://search.yahoo.com/search?p=" + textBox1.Text);

                this.Close();
            }
        }

        private void closeIt(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }

        private void addToAutostart(object sender, RoutedEventArgs e)
        {
            IWshShell_Class wshShell = new IWshShell_Class();
            IWshShortcut shortcut;
            string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            // Create the shortcut
            shortcut = (IWshShortcut)wshShell.CreateShortcut(startup + "\\" + "DesktopSearcher.lnk");

            shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            shortcut.Description = "Uruchom DesktopSearcher";
            shortcut.IconLocation = AppDomain.CurrentDomain.BaseDirectory + @"\icon.ico";
            shortcut.Save();

            MessageBox.Show("Plik dodano do autostartu! Aby jednak usunąć plik z autostartu, wejdź do: " + startup + " i usuń plik: DesktopSearcher.lnk", "Pomyślnie dodano!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void checkedGoogle(object sender, RoutedEventArgs e)
        {
            duckduckgo.IsChecked = false;
            bing.IsChecked = false;
            yahoo.IsChecked = false;
            textBox1.Text = "Szukaj w Google";
            Properties.Settings.Default.DefaultSearch = "Google";
            Properties.Settings.Default.Save();
        }

        private void checkedDuckDuckGo(object sender, RoutedEventArgs e)
        {
            google.IsChecked = false;
            bing.IsChecked = false;
            yahoo.IsChecked = false;
            textBox1.Text = "Szukaj w DuckDuckGo";
            Properties.Settings.Default.DefaultSearch = "DuckDuckGo";
            Properties.Settings.Default.Save();
        }

        private void checkedBing(object sender, RoutedEventArgs e)
        {
            duckduckgo.IsChecked = false;
            google.IsChecked = false;
            yahoo.IsChecked = false;
            textBox1.Text = "Szukaj w Bing";
            Properties.Settings.Default.DefaultSearch = "Bing";
            Properties.Settings.Default.Save();
        }

        private void checkedYahoo(object sender, RoutedEventArgs e)
        {
            google.IsChecked = false;
            bing.IsChecked = false;
            duckduckgo.IsChecked = false;
            textBox1.Text = "Szukaj w Yahoo";
            Properties.Settings.Default.DefaultSearch = "Yahoo";
            Properties.Settings.Default.Save();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) { Process.Start("https://github.com/KrzysiekSiemv"); }
    }
}
