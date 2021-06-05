using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace ProjectTimes
{
    public partial class Form1 : Form
    {
        private readonly ILogger<Form1> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Form1(ILogger<Form1> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.Disposed += OnFormDisposed;
        }

        private void OnFormDisposed(object? sender, EventArgs e)
        {
            _logger.LogInformation("Application end.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Form1 {BusinessLayerEvent} at {dateTime}", "Started", DateTime.UtcNow);

                // Perform Business Logic here 
                // _business.PerformBusiness();

                MessageBox.Show("Hello .NET Core 3.0 . This is First Forms app in .NET Core");

                _logger.LogInformation("Form1 {BusinessLayerEvent} at {dateTime}", "Ended", DateTime.UtcNow);

            }
            catch (Exception ex)
            {
                //Log technical exception 
                _logger.LogError(ex.Message);
                //Return exception repsponse here
                throw;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
