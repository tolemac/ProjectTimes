using ProjectTimes.Domain;
using ScopedInvocation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectTimes
{
    public partial class WorkDescriptionForm : Form
    {
        public string WorkDescription { get; set; } = null!;
        private string _projectName = null!;

        private readonly IScopedInvocation<IProjectTimesEntriesService> _serviceInvocation;

        public WorkDescriptionForm(IScopedInvocation<IProjectTimesEntriesService> serviceInvocation)
        {
            InitializeComponent();
            _serviceInvocation = serviceInvocation;
#if !DEBUG
            this.TopMost = true;
#endif
        }
        
        public DialogResult ShowDialog(string projectName)
        {
            _projectName = projectName;
            lblProjectName.Text = $@"Last works on project '{projectName}'";
            var result = ShowDialog();
            return result;
        }

        private void lstLastDescriptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LstLastDescriptionSelected();
        }

        private void LstLastDescriptionSelected()
        {
            if (lstLastDescriptions.SelectedItem is not null)
            {
                WorkDescription = lstLastDescriptions.SelectedItem.ToString()!;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            WorkDescription = tbxWorkDescription.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WorkDescription = null!;
        }

        private void tbxWorkDescription_TextChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = !string.IsNullOrWhiteSpace(tbxWorkDescription.Text);
        }

        private void lstLastDescriptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LstLastDescriptionSelected();
            }
        }

        private async void WorkDescriptionForm_Load(object sender, EventArgs e)
        {
            tbxWorkDescription.Text = "";
            lstLastDescriptions.Items.Clear();            
            await _serviceInvocation.InvokeAsync(async (service, _) => 
            {
                var descriptions = await service.GetLastEntryDescriptionsOfProjectAsync(_projectName, 10);                
                lstLastDescriptions.Items.AddRange(descriptions.Cast<object>().ToArray());
            });
        }

        private void WorkDescriptionForm_Activated(object sender, EventArgs e)
        {
            tbxWorkDescription.Focus();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (tbxWorkDescription.ContainsFocus && btnAccept.Enabled)
                {
                    btnAccept.PerformClick();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
