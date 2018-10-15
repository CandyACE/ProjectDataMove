namespace DataMoveTool
{
    partial class FrmSelectPlugin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dgvPlugin = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlugin)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvPlugin
            // 
            this.dgvPlugin.AllowUserToAddRows = false;
            this.dgvPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlugin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlugin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlugin.Location = new System.Drawing.Point(22, 67);
            this.dgvPlugin.MultiSelect = false;
            this.dgvPlugin.Name = "dgvPlugin";
            this.dgvPlugin.ReadOnly = true;
            this.dgvPlugin.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPlugin.RowHeadersVisible = false;
            this.dgvPlugin.RowTemplate.Height = 23;
            this.dgvPlugin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlugin.Size = new System.Drawing.Size(475, 150);
            this.dgvPlugin.TabIndex = 1;
            this.dgvPlugin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlugin_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(114, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "获取到文件夹下有多个插件，请选择使用的插件！";
            // 
            // FrmSelectPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPlugin);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSelectPlugin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择插件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSelectPlugin_FormClosing);
            this.Load += new System.EventHandler(this.FrmSelectPlugin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmSelectPlugin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlugin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvPlugin;
        private System.Windows.Forms.Label label1;
    }
}