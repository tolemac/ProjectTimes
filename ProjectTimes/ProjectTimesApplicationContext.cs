using System.Windows.Forms;
using ProjectTimes.Domain;

namespace ProjectTimes
{
    public class ProjectTimesApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ProjectTimesService _service;

        public ProjectTimesApplicationContext(ProjectTimesService service)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Show", null, (_, _) => Show());
            menu.Items.Add("-");
            menu.Items.Add("Exit", null, (_, _) => Exit());
                        
            // Initialize Tray Icon
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.favicon,
                ContextMenuStrip = menu,
                Visible = true
            };
            
            _service = service;
            _service.StartToWork();
        }

        void Show()
        {
            _service.StartToWork();
        }

        void Exit()
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
