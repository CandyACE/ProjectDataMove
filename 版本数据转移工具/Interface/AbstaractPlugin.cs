using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMoveTool.Interface
{
    public abstract class AbstaractPlugin : Iplugin
    {
        public abstract void StartMove(ItfMain fm);
    }
}
