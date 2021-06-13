using System.Linq;
using System.Security.Cryptography;
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
        public WorkStarterResult StartToWork()
        {
            if (!Application.OpenForms.OfType<StartWorkingForm>().Any())
            {
                var result = _form.ShowDialog();
                return _form.WorkStarterResult;
            }
            return WorkStarterResult.CreateTimeToRestObject();
        }
    }
}
