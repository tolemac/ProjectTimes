using System;
using System.Linq;
using System.Windows.Forms;
using ProjectTimes.Domain;
using ScopedInvocation;

namespace ProjectTimes
{
    public partial class StartWorkingForm : Form
    {
        private readonly IScopedInvocation<IProjectTimesEntriesService> _serviceInvocation;
        private readonly WorkDescriptionForm _workDescriptionForm;

        public WorkStarterResult WorkStarterResult = null!;

        public StartWorkingForm(IScopedInvocation<IProjectTimesEntriesService> serviceInvocation,
            WorkDescriptionForm workDescriptionForm)
        {
            InitializeComponent();
            _serviceInvocation = serviceInvocation;
            _workDescriptionForm = workDescriptionForm;

#if !DEBUG
            this.TopMost = true;
#endif
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            WorkStarterResult = WorkStarterResult.CreateContinueWorkObject();
            DialogResult = DialogResult.Yes;
        }

        private void btnStartWorkingOn_Click(object sender, EventArgs e)
        {
            StartNewWork(tbxNewProjectName.Text);
        }

        private void lstLatestProjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstLatestProjects.SelectedItem is not null)
            {
                StartNewWork(lstLatestProjects.SelectedItem.ToString()!);
            }
        }

        private void StartNewWork(string projectName)
        {
            if (_workDescriptionForm.ShowDialog(projectName) == DialogResult.OK)
            {
                WorkStarterResult = WorkStarterResult.CreateNewWorkObject(projectName, _workDescriptionForm.WorkDescription);
                DialogResult = DialogResult.Yes;
            }
        }

        private void lstLatestProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstLatestProjects.SelectedItem is not null)
            {
                StartNewWork(lstLatestProjects.SelectedItem.ToString()!);
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
            WorkStarterResult = WorkStarterResult.CreateTimeToRestObject();
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
                    tbxLastProjectName.Text = $@"{last.ProjectName} - {last.Description}";
                }
                var projectNames = await service.GetProjectNamesAsync();                
                lstLatestProjects.Items.AddRange(projectNames.Cast<object>().ToArray());
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
