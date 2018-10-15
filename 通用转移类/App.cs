using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMoveTool.Interface;

namespace Plugin
{
    public class App : AbstaractPlugin
    {
        private Option op;
        private string dataTempPath;
        private string oldPath;
        private string newPath;

        public override void StartMove(ItfMain fm)
        {
            op = new Option();
            fm.mbreakUpChecked = true;
            fm.mbtnQusetion.Visible = op.showQusetion;

            //开始按钮
            fm.mbtnStart.Click += (sender, e) =>
            {
                if (fm.oldPath == null || fm.newPath==null)
                {
                    MessageBox.Show("工程文件不能为空！");
                    return;
                }
                try
                {
                    //设定各种目录
                    oldPath = Path.GetDirectoryName(fm.oldPath);
                    newPath = Path.GetDirectoryName(fm.newPath);
                    dataTempPath = newPath + "\\DataTemp\\";

                    //窗口初始化
                    fm.mprogressBar1.Maximum = (op.filePathList.Count * 2 + 1) * 10;
                    fm.mprogressBar1.Minimum = 0;
                    fm.mprogressBar1.Value = 0;
                    fm.mprogressBar1.Step = 10;
                    fm.runLog.ForeColor = Color.Black;

                    if (fm.mbreakUpChecked)
                    {
                        fm.runLog.Text = "创建缓存文件夹...";

                        //创建缓存文件夹
                        if (!Directory.Exists(dataTempPath))
                            Directory.CreateDirectory(dataTempPath);
                        fm.mprogressBar1.PerformStep();

                        //遍历复制文件到缓存文件夹
                        foreach (string fileName in op.filePathList)
                        {
                            File.Copy(newPath + fileName, dataTempPath + Path.GetFileName(fileName), true);
                            fm.runLog.Text = fileName;
                            fm.mprogressBar1.PerformStep();
                        }
                        fm.runLog.Text = "缓存完毕，开始复制文件...";
                    }
                    
                    fm.runLog.Text = "开始复制文件...";
                    //复制旧文件到新文件夹
                    foreach (string fileName in op.filePathList)
                    {
                        File.Copy(oldPath + fileName, newPath + fileName, true);
                        fm.runLog.Text = fileName;
                        fm.mprogressBar1.PerformStep();
                    }
                    fm.mprogressBar1.Value = fm.mprogressBar1.Maximum;
                    fm.runLog.Text = "完成";
                }
                catch (Exception ext)
                {
                    fm.runLog.ForeColor = Color.Red;
                    fm.runLog.Text = ext.Message;
                    fm.mprogressBar1.Value = 0;
                }
            };

            //恢复按钮
            fm.mbtnRef.Click += (sender, e) =>
            {
                try
                {
                    fm.runLog.ForeColor = Color.Black;
                    newPath = Path.GetDirectoryName(fm.newPath);
                    dataTempPath = newPath + "\\DataTemp\\";

                    if (!Directory.Exists(dataTempPath))
                    {
                        fm.runLog.ForeColor = Color.Red;
                        fm.runLog.Text = "缓存文件不存在";
                        return;
                    }

                    string[] files = Directory.GetFiles(dataTempPath);

                    if (files.Count()==0)
                    {
                        fm.runLog.ForeColor = Color.Red;
                        fm.runLog.Text = "缓存文件不存在";
                        return;
                    }

                    fm.mprogressBar1.Maximum = files.Count();
                    fm.mprogressBar1.Minimum = 0;
                    fm.mprogressBar1.Value = 0;

                    fm.runLog.Text = "开始恢复...";
                    foreach (string file in files)
                    {
                        foreach (string path in op.filePathList)
                        {
                            if (Path.GetFileName(file) == Path.GetFileName(path))
                            {
                                File.Copy(file, newPath + path, true);
                                fm.mprogressBar1.Value += 1; fm.runLog.Text = Path.GetFileName(file);
                            }
                        }
                    }
                    fm.runLog.Text = "恢复成功！";
                }
                catch (Exception ext)
                {
                    fm.runLog.ForeColor = Color.Red;
                    fm.runLog.Text = ext.Message;
                    fm.mprogressBar1.Value = 0;
                }
                
            };
            //帮助按钮
            fm.mbtnQusetion.Click += (sender, e) =>
            {
                FrmQuestion fq = new FrmQuestion();
                fq.Show();
            };
        }
    }
}
