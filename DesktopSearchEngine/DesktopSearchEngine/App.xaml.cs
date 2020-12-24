using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Reflection;

namespace DesktopSearchEngine
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
        
        public App()
        {
            nIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().ManifestModule.Name);
            nIcon.Text = "Włącz wyszukiwarkę";
            nIcon.Visible = true;
            nIcon.Click += nIcon_Click;
        }

        void nIcon_Click(object sender, EventArgs e)
        {
            search search = new search();
            search.Show();
        }
    }
}
