using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMoveTool.Interface
{
    public interface Iplugin
    {
        /// <summary>
        /// 开始转移
        /// </summary>
        /// <param name="fm"></param>
        void StartMove(ItfMain fm);
    }
}
