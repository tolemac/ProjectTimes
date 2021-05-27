using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace ProjectTimes
{
    public partial class Form1 : Form
    {
        private readonly ILogger<Form1> _logger;

        public Form1(ILogger<Form1> logger)
        {
            _logger = logger;
            InitializeComponent();
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
    }
}
