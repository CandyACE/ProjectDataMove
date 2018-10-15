using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMoveTool.Interface;

namespace DataMoveTool
{
    public partial class Form1 : Form, ItfMain
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.FromArgb(255, 255, 255);
            Color TColor = Color.FromArgb(221, 221, 221);
            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            g.FillRectangle(b, this.ClientRectangle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += this.ProductVersion;

            //创建插件目录
            if (!Directory.Exists(Application.StartupPath + "\\plugins\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\plugins\\");

            //读取插件内容
            try
            {
                PluginLoader.LoadAllPlugins(this);
            }
            catch (Exception ext)
            {
                if (ext.Message.Contains("超出了数组界限"))
                {
                    MessageBox.Show("未找到插件！请将插件移动到plugins文件夹");
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Multiselect = false;
                    fileDialog.Filter = "*.Dll|*.dll";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(fileDialog.FileName,
                            Application.StartupPath + "\\plugins\\" + Path.GetFileName(fileDialog.FileName));
                    }
                    Form1_Load(null, null);
                }
            }

            InitPlugin();
        }

        /// <summary>
        /// 运行插件内容
        /// </summary>
        private void InitPlugin()
        {
            foreach (Iplugin plugin in PluginLoader.plugins)
            {
                //实现插件
                plugin.StartMove(this);
            }
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Multiselect = false;
            openFile.CheckPathExists = true;
            openFile.Filter = "项目文件（*.exe）|*.exe";
            openFile.Title = "选择被转移项目";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtTemp.Text = openFile.FileName;
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Multiselect = false;
            openFile.CheckPathExists = true;
            openFile.Filter = "项目文件（*.exe）|*.exe";
            openFile.Title = "选择目标项目";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = openFile.FileName;
            }
        }

        #region 属性
        public string oldPath
        {
            get { return txtTemp.Text; }
        }

        public string newPath
        {
            get { return txtTarget.Text; }
        }

        public Label runLog
        {
            get { return labLog; }
            set { labLog = value; }
        }

        public ProgressBar mprogressBar1
        {
            get { return progressBar1; }
            set { progressBar1 = value; }
        }

        public Button mbtnStart
        {
            get { return btnStart; }
            set { btnStart = value; }
        }

        public Button mbtnRef
        {
            get { return btnRef; ;}
            set { btnRef = value; }
        }

        public Button mbtnQusetion
        {
            get { return btnQusetion; }
            set { btnQusetion = value; }
        }

        public bool mbreakUpChecked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        #endregion
    }
}
