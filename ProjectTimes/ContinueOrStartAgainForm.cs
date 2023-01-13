using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTimes
{
    public partial class ContinueOrStartAgainForm : Form
    {
        public ContinueOrStartAgainForm()
        {
            InitializeComponent();
#if !DEBUG
            this.TopMost = true;
#endif
        }
    }
}
