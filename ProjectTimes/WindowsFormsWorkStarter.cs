using System.Linq;
using System.Windows.Forms;
using ProjectTimes.Domain;

namespace ProjectTimes
{
    public class WindowsFormsWorkStarter : IWorkStarter
    {
        private readonly StartWorkingForm _form;

        public WindowsFormsWorkStarter(StartWorkingForm form)
        {
            _form = form;
        }
        public bool StartToWork()
        {
            if (!Application.OpenForms.OfType<StartWorkingForm>().Any())
            {
                var result = _form.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
