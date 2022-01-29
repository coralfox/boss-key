namespace BossKey
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_bosskey = new System.Windows.Forms.TextBox();
            this.btn_hiden = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.cb_bosskey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_appkey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_process = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "老板键";
            // 
            // txt_bosskey
            // 
            this.txt_bosskey.BackColor = System.Drawing.Color.White;
            this.txt_bosskey.Location = new System.Drawing.Point(349, 8);
            this.txt_bosskey.Margin = new System.Windows.Forms.Padding(4);
            this.txt_bosskey.Name = "txt_bosskey";
            this.txt_bosskey.ReadOnly = true;
            this.txt_bosskey.Size = new System.Drawing.Size(147, 25);
            this.txt_bosskey.TabIndex = 2;
            this.txt_bosskey.Enter += new System.EventHandler(this.txt_bosskey_Enter);
            this.txt_bosskey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bosskey_KeyDown);
            // 
            // btn_hiden
            // 
            this.btn_hiden.Location = new System.Drawing.Point(407, 76);
            this.btn_hiden.Margin = new System.Windows.Forms.Padding(4);
            this.btn_hiden.Name = "btn_hiden";
            this.btn_hiden.Size = new System.Drawing.Size(160, 41);
            this.btn_hiden.TabIndex = 6;
            this.btn_hiden.Text = "隐藏/显示（测试）";
            this.btn_hiden.UseVisualStyleBackColor = true;
            this.btn_hiden.Click += new System.EventHandler(this.btn_hiden_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(281, 76);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(117, 41);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.cb_bosskey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_appkey);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_hiden);
            this.panel1.Controls.Add(this.txt_bosskey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 132);
            this.panel1.TabIndex = 6;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(4, 4);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(117, 41);
            this.btn_refresh.TabIndex = 1;
            this.btn_refresh.Text = "刷新进程列表";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // cb_bosskey
            // 
            this.cb_bosskey.AutoSize = true;
            this.cb_bosskey.Location = new System.Drawing.Point(524, 44);
            this.cb_bosskey.Margin = new System.Windows.Forms.Padding(4);
            this.cb_bosskey.Name = "cb_bosskey";
            this.cb_bosskey.Size = new System.Drawing.Size(89, 19);
            this.cb_bosskey.TabIndex = 4;
            this.cb_bosskey.Text = "同老板键";
            this.cb_bosskey.UseVisualStyleBackColor = true;
            this.cb_bosskey.CheckedChanged += new System.EventHandler(this.cb_bosskey_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "程序本身隐藏快捷键";
            // 
            // txt_appkey
            // 
            this.txt_appkey.BackColor = System.Drawing.Color.White;
            this.txt_appkey.Location = new System.Drawing.Point(349, 41);
            this.txt_appkey.Margin = new System.Windows.Forms.Padding(4);
            this.txt_appkey.Name = "txt_appkey";
            this.txt_appkey.ReadOnly = true;
            this.txt_appkey.Size = new System.Drawing.Size(147, 25);
            this.txt_appkey.TabIndex = 3;
            this.txt_appkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bosskey_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_process);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(976, 430);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进程列表";
            // 
            // list_process
            // 
            this.list_process.CheckBoxes = true;
            this.list_process.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.list_process.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_process.FullRowSelect = true;
            this.list_process.GridLines = true;
            this.list_process.HideSelection = false;
            this.list_process.Location = new System.Drawing.Point(4, 22);
            this.list_process.Name = "list_process";
            this.list_process.Size = new System.Drawing.Size(968, 404);
            this.list_process.SmallImageList = this.imageList1;
            this.list_process.TabIndex = 7;
            this.list_process.UseCompatibleStateImageBehavior = false;
            this.list_process.View = System.Windows.Forms.View.Details;
            this.list_process.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.list_process_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "进程";
            this.columnHeader1.Width = 600;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "窗体名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PID";
            this.columnHeader3.Width = 70;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "老板来了[吾爱破解]";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_show,
            this.toolStripMenuItem1,
            this.menu_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 58);
            // 
            // menu_show
            // 
            this.menu_show.Name = "menu_show";
            this.menu_show.Size = new System.Drawing.Size(153, 24);
            this.menu_show.Text = "显示主屏幕";
            this.menu_show.Click += new System.EventHandler(this.menu_show_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // menu_exit
            // 
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(153, 24);
            this.menu_exit.Text = "退出";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "老板来了[吾爱破解]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bosskey;
        private System.Windows.Forms.Button btn_hiden;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_bosskey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_appkey;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_show;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_exit;
        private System.Windows.Forms.ListView list_process;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
    }
}

