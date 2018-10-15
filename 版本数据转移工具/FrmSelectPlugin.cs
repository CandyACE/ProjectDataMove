using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DataMoveTool
{
    public partial class FrmSelectPlugin : Form
    {
        private DataTable dt;
        private string[] files;
        public string returnFile;

        public FrmSelectPlugin(string[] files)
        {
            InitializeComponent();

            this.files = files;
        }

        private void FrmSelectPlugin_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("名称");
            dt.Columns.Add("版本");

            dgvPlugin.DataSource = dt;
            InitPlugin();

        }

        /// <summary>
        /// 遍历插件并且将信息显示在dgv中
        /// </summary>
        private void InitPlugin()
        {
            dt.Clear();

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if (ext != ".dll") continue;

                DataRow dr = dt.NewRow();
                string thisfile = Path.GetFileName(file);
                dr[0] = thisfile;
                dr[1] = FileVersionInfo.GetVersionInfo(file);
                //dr[1] = AssemblyName.GetAssemblyName(file).Version; //获取版本号
                dt.Rows.Add(dr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPlugin.CurrentRow.Index == null)
                return;

            returnFile = files[dgvPlugin.CurrentRow.Index];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmSelectPlugin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (returnFile == null)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void dgvPlugin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(null,null);
        }

        private void FrmSelectPlugin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.FromArgb(255, 255, 255);
            Color TColor = Color.FromArgb(221, 221, 221);
            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            g.FillRectangle(b, this.ClientRectangle);
        }
    }}
