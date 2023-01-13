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

            _trayIcon.DoubleClick += (_,_) => Show();

            _service = service;
            Application.Idle += Application_Idle;
        }

        private async void Application_Idle(object? sender, System.EventArgs e)
        {
            Application.Idle -= Application_Idle;
            await _service.StartToWork();
        }

        public async void Show()
        {
            await _service.StartToWork();
        }

        void Exit()
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
