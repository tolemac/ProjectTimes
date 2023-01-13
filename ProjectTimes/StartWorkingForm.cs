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
        private readonly ContinueOrStartAgainForm _continueOrStartAgainForm;
        public WorkStarterResult WorkStarterResult = null!;
        private ProjectTimeEntry? _lastEntry;

        public StartWorkingForm(IScopedInvocation<IProjectTimesEntriesService> serviceInvocation,
            WorkDescriptionForm workDescriptionForm, ContinueOrStartAgainForm continueOrStartAgainForm)
        {
            InitializeComponent();
            _serviceInvocation = serviceInvocation;
            _workDescriptionForm = workDescriptionForm;
            _continueOrStartAgainForm = continueOrStartAgainForm;

#if !DEBUG
            this.TopMost = true;
#endif
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            var continueWork = true;

            if (_lastEntry is not null 
                && (DateTime.Now - _lastEntry.EndTime) > TimeSpan.FromMinutes(60))
            {
                continueWork = false;
                var frmResult = _continueOrStartAgainForm.ShowDialog();
                if (frmResult == DialogResult.TryAgain)
                {
                    CreateNewWorkObject(_lastEntry.ProjectName, _lastEntry.Description);
                } else if (frmResult == DialogResult.Continue)
                {
                    continueWork = true;
                }
            }

            if (continueWork) {
                WorkStarterResult = WorkStarterResult.CreateContinueWorkObject();
                DialogResult = DialogResult.Yes;
            }
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
                CreateNewWorkObject(projectName, _workDescriptionForm.WorkDescription);
            }
        }

        private void CreateNewWorkObject(string projectName, string description)
        {
            WorkStarterResult = WorkStarterResult.CreateNewWorkObject(projectName, description);
            DialogResult = DialogResult.Yes;
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
                _lastEntry = await service.GetLastEntryAsync();
                if (_lastEntry is not null)
                {
                    tbxLastProjectName.Text = $@"{_lastEntry.ProjectName} - {_lastEntry.Description}";
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
