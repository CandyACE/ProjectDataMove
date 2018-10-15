using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMoveTool.Interface
{
    public interface ItfMain
    {
        string oldPath { get; }
        string newPath { get; }
        Label runLog { get; set; }
        ProgressBar mprogressBar1 { get; set; }
        Button mbtnStart { get; set; }
        Button mbtnRef { get; set; }
        Button mbtnQusetion { get; set; }
        bool mbreakUpChecked { get; set; }
    }
}
