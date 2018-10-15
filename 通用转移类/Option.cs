using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Abstaract;

namespace Plugin
{
    public class Option : AbstractOption
    {
        public Option ()
        {
            //是否显示帮助按钮
            showQusetion = false;
            //需要移动的文件
            filePathList.AddRange(new string[]
            {
                "\\Scene.gws",
                "\\MyPlace.kml",
                "\\MyPlace.ldl",
                "\\MyPlace.lgd",
                "\\Resource\\layers\\点云.ldl",
                "\\Resource\\layers\\点云.lgd",
                "\\Resource\\layers\\水工建筑物.ldl",
                "\\Resource\\layers\\水工建筑物.lgd"
            });
        }
    }
}
