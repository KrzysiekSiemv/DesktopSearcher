using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace DesktopSearchEngine
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
        System.Windows.Forms.ContextMenu contextMenuStrip = new System.Windows.Forms.ContextMenu();
        public App()
        {
            nIcon.Icon = new Icon(@"icon.ico");
            nIcon.Visible = true;
            nIcon.ShowBalloonTip(5000, "Title", "Text", System.Windows.Forms.ToolTipIcon.Info);
            nIcon.Click += nIcon_Click;
            nIcon.ContextMenu = contextMenuStrip;
            contextMenuStrip.MenuItems.Add("Wybierz główną wyszukiwarkę");
            contextMenuStrip.MenuItems.Add("Google", setGoogle);
            contextMenuStrip.MenuItems.Add("DuckDuckGo", setDuckDuckGo);
            contextMenuStrip.MenuItems.Add("Bing", setBing);
            contextMenuStrip.MenuItems.Add("Yahoo", setYahoo);

        }

        void nIcon_Click(object sender, EventArgs e)
        {
            search search = new search();
            search.Show();
        }

        void setGoogle(object sender, EventArgs e) { DesktopSearchEngine.Properties.Settings.Default.DefaultSearch = "google"; }
        void setDuckDuckGo(object sender, EventArgs e) { DesktopSearchEngine.Properties.Settings.Default.DefaultSearch = "duckduckgo"; }
        void setBing(object sender, EventArgs e) { DesktopSearchEngine.Properties.Settings.Default.DefaultSearch = "bing"; }
        void setYahoo(object sender, EventArgs e) { DesktopSearchEngine.Properties.Settings.Default.DefaultSearch = "yahoo"; }
    }
}
