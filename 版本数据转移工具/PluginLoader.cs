using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMoveTool.Interface;

namespace DataMoveTool
{
    public static class PluginLoader
    {
        public static List<Iplugin> plugins = new List<Iplugin>();

        /// <summary>
        /// 判断DLL中是否继承了Iplugin接口
        /// </summary> <param name="t"></param>
        /// <returns></returns>
        private static bool IsValidPlugin(Type t)
        {
            bool ret = false;
            Type[] interfaces = t.GetInterfaces();
            foreach (Type @Interface in interfaces)
            {
                if (@Interface.FullName == "DataMoveTool.Interface.Iplugin")
                {
                    ret = true;
                    break;
                }
            }
            return ret;}

        /// <summary>
        /// 读取并且实现插件内容
        /// </summary>
        public static void LoadAllPlugins(ItfMain fm)
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\plugins\\");

            string file = null;
            if (files.Count() > 1)
            {
                FrmSelectPlugin fsp = new FrmSelectPlugin(files);
                if (fsp.ShowDialog() == DialogResult.Cancel)
                    System.Environment.Exit(0);
                file = fsp.returnFile;

                fm.runLog.Text = "已加载插件：" + Path.GetFileNameWithoutExtension(file);
            }
            else
            {
                file = files[0];
                fm.runLog.Text = "已加载插件：" + Path.GetFileNameWithoutExtension(file);
            }

            string ext = Path.GetExtension(file);
            if (ext == ".dll")
                try
                {
                    Assembly tmp = Assembly.LoadFile(file);
                    Type[] types = tmp.GetTypes();
                    bool ok = false;
                    foreach (Type t in types)
                        if (IsValidPlugin(t))
                        {
                            Iplugin plugin = (Iplugin)tmp.CreateInstance(t.FullName);
                            plugins.Add(plugin);
                            ok = true;
                            if (ok) break;
                        }
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
    }
}
