using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using ProjectTimes.Domain;
using ScopedInvocation;

namespace ProjectTimes
{
    public partial class StartWorkingForm : Form
    {
        private readonly ILogger<StartWorkingForm> _logger;
        private readonly IScopedInvocation<IProjectTimesEntriesService> _serviceInvocation;
        private readonly WorkDescriptionForm _workDescriptionForm;

        public StartWorkingForm(ILogger<StartWorkingForm> logger, 
            IScopedInvocation<IProjectTimesEntriesService> serviceInvocation,
            WorkDescriptionForm workDescriptionForm)
        {
            InitializeComponent();
            _serviceInvocation = serviceInvocation;
            _logger = logger;
            _workDescriptionForm = workDescriptionForm;

#if !DEBUG
            this.TopMost = true;
#endif
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            await _serviceInvocation.InvokeAsync(async (service, _) =>
            {
                await service.FinishLastEntryAsync();
            });
            DialogResult = DialogResult.Yes;
        }

        private async void btnStartWorkingOn_Click(object sender, EventArgs e)
        {
            await StartNewWork(tbxNewProjectName.Text);
        }

        private async void lstLatestProjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstLatestProjects.SelectedItem is not null)
            {
                await StartNewWork(lstLatestProjects.SelectedItem.ToString()!);
            }
        }

        private async Task StartNewWork(string projectName)
        {
            if (_workDescriptionForm.ShowDialog(projectName) == DialogResult.OK)
            {
                await _serviceInvocation.InvokeAsync(async (service, _) =>
                {
                    await service.CreateEntryAsync(DateTime.Now, projectName, _workDescriptionForm.WorkDescription!);
                });
                DialogResult = DialogResult.Yes;
            }
        }

        private async void lstLatestProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstLatestProjects.SelectedItem is not null)
            {
                await StartNewWork(lstLatestProjects.SelectedItem.ToString()!);
            }

        }

        private void tbxNewProjectName_TextChanged(object sender, EventArgs e)
        {
            btnStartWorkingOn.Enabled = !string.IsNullOrWhiteSpace(tbxNewProjectName.Text);
        }

        private void tbxLastProjectName_TextChanged(object sender, EventArgs e)
        {
            btnContinue.Enabled = !string.IsNullOrWhiteSpace(tbxLastProjectName.Text);
        }

        private void btnNoWorking_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private async void StartWorkingForm_Load(object sender, EventArgs e)
        {
            tbxLastProjectName.Text = "";
            lstLatestProjects.Items.Clear();
            tbxNewProjectName.Text = "";            
            await _serviceInvocation.InvokeAsync(async (service, _) =>
            {
                var last = await service.GetLastEntryAsync();
                if (last is not null)
                {
                    tbxLastProjectName.Text = $"{last.ProjectName} - {last.Description}";
                }
                var projectNames = await service.GetProjectNamesAsync();                
                lstLatestProjects.Items.AddRange(projectNames.ToArray());
            });
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (pnlNewProject.ContainsFocus)
                {
                    btnStartWorkingOn.PerformClick();
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void StartWorkingForm_Activated(object sender, EventArgs e)
        {
            tbxNewProjectName.Focus();
        }
    }
}
