using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interface;

namespace Plugin.Abstaract
{
    public abstract class AbstractOption : ItfOption
    {
        List<string> _filePathList = new List<string>();
        bool _showQuestion = false;
        /// <summary>
        /// 要迁移的文件名称数组
        /// </summary>
        public List<string> filePathList
        {
            get{return _filePathList;}
            set { _filePathList = value; }
        }
        /// <summary>
        /// 是否显示帮助按钮，显示的话请编辑帮助窗口
        /// </summary>
        public bool showQusetion
        {
            get{return _showQuestion;}
            set { _showQuestion = value; }
        }
    }
}
