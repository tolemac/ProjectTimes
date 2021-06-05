using System;
using System.Windows.Forms;

namespace ProjectTimes
{
    public class ProjectTimesApplicationContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;

        public ProjectTimesApplicationContext()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Exit", null, (f, f2) => Exit(f!, f2));
                        
            // Initialize Tray Icon
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.favicon,
                ContextMenuStrip = menu,
                Visible = true
            };
        }        

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
