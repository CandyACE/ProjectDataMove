using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Interface
{
    public interface ItfOption
    {
        /// <summary>
        /// 要迁移的文件名称数组
        /// </summary>
        List<string> filePathList { get;set; } 
        /// <summary>
        /// 是否显示帮助按钮，显示的话请编辑帮助窗口
        /// </summary>
        bool showQusetion { get; set; }
    }
}
