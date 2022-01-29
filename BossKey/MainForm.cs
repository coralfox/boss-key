using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BossKey
{
    public partial class MainForm : Form
    {
        string _shortcutkey_boss;
        string _shortcutkey_app;
        public SystemConfig Config = new SystemConfig();
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, int extraData);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);

        public delegate bool CallBack(IntPtr hwnd, int lParam);

        bool EnumChildWindowCallBack(IntPtr hWnd, int lParam)
        {
            int dwPid = 0;
            GetWindowThreadProcessId(hWnd, out dwPid); // 获得找到窗口所属的进程
            if (dwPid == lParam) // 判断是否是目标进程的窗口
            {
                if (IsWindowVisible(hWnd)) phandle.Add(hWnd);
                EnumChildWindows(hWnd, EnumChildWindowCallBack, lParam);    // 递归查找子窗口
            }
            return true;

        }

        bool EnumWindowCallBack(IntPtr hWnd, int lParam)
        {
            int dwPid = 0;
            GetWindowThreadProcessId(hWnd, out dwPid); // 获得找到窗口所属的进程
            if (dwPid == lParam) // 判断是否是目标进程的窗口
            {
                if (IsWindowVisible(hWnd)) phandle.Add(hWnd);
                //EnumChildWindows(hWnd, EnumChildWindowCallBack, lParam);    // 继续查找子窗口
            }
            return true;
        }


        [DllImport("shell32.dll")]
        public static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        int GetICON(string appPath)
        {
            imageList1.Images.Add(Icon.ExtractAssociatedIcon(appPath));
            return imageList1.Images.Count - 1;
        }


        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void GetALLProcesses()
        {
            new Task(() =>
            {
                imageList1.Images.Clear();
                list_process.Items.Clear();
                //GetICON("%SystemRoot%\\system32\\shell32.dll");
                Process[] processes = Process.GetProcesses();
                list_process.BeginUpdate();
                foreach (Process p in processes.OrderBy(m => m.ProcessName))
                {
                    try
                    {
                        //var x = new ListViewItem(Text)
                        var x = new ListViewItem(p.MainModule.FileName);
                        x.ImageIndex = GetICON(p.MainModule.FileName);
                        x.SubItems.Add(p.MainWindowTitle);
                        x.SubItems.Add(p.Id.ToString());
                        //x.SubItems.Add(p.MainModule.FileName);
                        if (Config.AppPaths.Contains(p.MainModule.FileName)) x.Checked = true;
                        list_process.Items.Add(x);
                    }
                    catch
                    {
                        //if(list_process.Items.Count!=0) list_process.Items.RemoveAt(list_process.Items.Count - 1);
                    }
                }
                list_process.EndUpdate();

            }).Start();
        }

        private void txt_bosskey_KeyDown(object sender, KeyEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.Text = "";
            if (e.Alt)
            {
                obj.Text += "Alt";
            }
            if (e.Control)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += "Ctrl";
            }
            if (e.Shift)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += "Shift";
            }
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += e.KeyCode;
            }


            if (e.KeyCode == Keys.Escape)
            {
                switch (obj.Name)
                {
                    case "txt_bosskey": obj.Text = _shortcutkey_boss; break;
                    case "txt_appkey": obj.Text = _shortcutkey_app; break;
                }
            }
        }
        List<string> process = new List<string>();
        List<int> process_id = new List<int>();
        List<IntPtr> phandle = new List<IntPtr>();
        bool isshow = true;
        private void btn_hiden_Click(object sender, EventArgs e)
        {

            if (isshow)
            {
                phandle.Clear();
                process_id.Clear();
                Process[] processes = Process.GetProcesses();

                for (var i = 0; i < process.Count; i++)
                {
                    var pname = process[i];
                    pname = pname.Substring(pname.LastIndexOf('\\') + 1);
                    pname = pname.Substring(0, pname.LastIndexOf("."));
                    Process[] ps = Process.GetProcessesByName(pname);
                    foreach (var p in ps)
                    {
                        try
                        {
                            if (p.MainModule.FileName == process[i]) process_id.Add(p.Id);
                        }
                        catch
                        {

                        }
                    }
                }
                foreach (var id in process_id)
                {
                    EnumWindows(EnumWindowCallBack, id);
                }

                foreach (var h in phandle)
                {
                    ShowWindow(h, 0);
                }
                NotifyIconHide.SetNotifyIconVisiable(process, false);
                isshow = false;
            }
            else
            {
                foreach (var h in phandle)
                {
                    ShowWindow(h, 1);
                }
                NotifyIconHide.SetNotifyIconVisiable(process, true);
                isshow = true;
            }


        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            process.Clear();

            for (var i = 0; i < list_process.CheckedItems.Count; i++)
            {
                if (list_process.CheckedItems[i].Checked)
                {
                    process.Add(list_process.CheckedItems[i].SubItems[0].Text);
                }
            }
            Config.AppPaths = process;
            SaveShortcutKeyConfig(txt_bosskey.Text, cb_bosskey.Checked ? txt_bosskey.Text : txt_appkey.Text);
            UnRegisterShortcutKeyConfig();
            RegisterShortcutKeyConfig();
        }


        private void RegisterHotKey(string KeyName, string Keys, int KeyId)
        {
            var x = "";
            if (Keys.IndexOf("Alt") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            if (Keys.IndexOf("Ctrl") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            if (Keys.IndexOf("Shift") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            x += Keys.Replace("Alt", "").Replace("Ctrl", "").Replace("Shift", "").Replace(" ", "").Replace("+", "");
            var keys = x.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length == 4)
            {
                try
                {
                    HotKey.RegisterHotKey(Handle, KeyId, (keys[0] == "1" ? HotKey.KeyModifiers.Alt : HotKey.KeyModifiers.None) | (keys[1] == "1" ? HotKey.KeyModifiers.Ctrl : HotKey.KeyModifiers.None) | (keys[2] == "1" ? HotKey.KeyModifiers.Shift : HotKey.KeyModifiers.None), (Keys)Enum.Parse(typeof(Keys), keys[3]));
                }
                catch
                {
                    MessageBox.Show(this, KeyName + " 注册失败！");
                }
            }
        }
        private bool RegisterHotKey(Keys KeyCode, string Keys)
        {

            bool result = false;
            System.Windows.Forms.Keys x = System.Windows.Forms.Keys.None;
            if (Keys.IndexOf("Alt") != -1)
                x |= System.Windows.Forms.Keys.Alt;
            if (Keys.IndexOf("Ctrl") != -1)
                x |= System.Windows.Forms.Keys.Control;
            if (Keys.IndexOf("Shift") != -1)
                x |= System.Windows.Forms.Keys.Shift;
            Keys = Keys.Replace("Alt", "").Replace("Ctrl", "").Replace("Shift", "").Replace(" ", "").Replace("+", "");

            try
            {
                //HotKey.RegisterHotKey(Handle, KeyId, (keys[0] == "1" ? HotKey.KeyModifiers.Alt : HotKey.KeyModifiers.None) | (keys[1] == "1" ? HotKey.KeyModifiers.Ctrl : HotKey.KeyModifiers.None) | (keys[2] == "1" ? HotKey.KeyModifiers.Shift : HotKey.KeyModifiers.None), (Keys)Enum.Parse(typeof(Keys), keys[3]));
                x |= (Keys)Enum.Parse(typeof(Keys), Keys);
                result = KeyCode == x;
            }
            catch
            {
                // MessageBox.Show(this, "快捷键 " + KeyName + " 注册失败！");
            }
            return result;
        }

        const int BaseValue = 830301;
        /// <summary>
        /// 注册热键
        /// </summary>
        private void RegisterShortcutKeyConfig()
        {
            RegisterHotKey("老板键", Config.ShortcutKey_Boss, BaseValue + 0);
            RegisterHotKey("APP键", Config.ShortcutKey_App, BaseValue + 1);
        }
        //注销热键
        private void UnRegisterShortcutKeyConfig()
        {
            HotKey.UnregisterHotKey(Handle, BaseValue + 0);
            HotKey.UnregisterHotKey(Handle, BaseValue + 1);
        }
        private void SaveShortcutKeyConfig(string ShortcutKey_Boss, string ShortcutKey_App)
        {
            Config.ShortcutKey_Boss = ShortcutKey_Boss;
            Config.ShortcutKey_App = ShortcutKey_App;
            string s = XmlUtil.Serializer(typeof(SystemConfig), Config);
            File.WriteAllText(Application.StartupPath + "\\BossKey.config", s);
        }
        protected override void WndProc(ref Message m)
        {

            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case BaseValue:
                            if (Config.ShortcutKey_App == Config.ShortcutKey_Boss)
                            {
                                if (this.Visible)
                                {
                                    this.Hide();
                                    this.notifyIcon1.Visible = false;
                                }
                                else
                                {
                                    this.Show();
                                    this.Activate();
                                    this.notifyIcon1.Visible = true;
                                }
                            }
                            btn_hiden_Click(null, null);
                            break;
                        case BaseValue + 1:
                            if (this.Visible)
                            {
                                this.Hide();
                                this.notifyIcon1.Visible = false;
                            }
                            else
                            {
                                this.Show();
                                this.Activate();
                                this.notifyIcon1.Visible = true;
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*if (RegisterHotKey(keyData, Config.ShortcutKey_App))
            {
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.Activate();
                }
            }*/
            return false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GetALLProcesses();
        }

        private void cb_bosskey_CheckedChanged(object sender, EventArgs e)
        {
            txt_appkey.Enabled = !cb_bosskey.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Config.AppPaths = new List<string>();
            if (File.Exists(Application.StartupPath + "\\BossKey.config"))
            {
                XmlDocument Xml = new XmlDocument();
                Xml.Load(Application.StartupPath + "\\BossKey.config");
                Config = (SystemConfig)XmlUtil.Deserialize(typeof(SystemConfig), Xml.InnerXml);
                txt_appkey.Text = Config.ShortcutKey_App;
                txt_bosskey.Text = Config.ShortcutKey_Boss;
                _shortcutkey_app = Config.ShortcutKey_App;
                _shortcutkey_boss = Config.ShortcutKey_Boss;
                cb_bosskey.Checked = txt_appkey.Text == txt_bosskey.Text;
                process = Config.AppPaths;
                RegisterShortcutKeyConfig();
            }
            GetALLProcesses();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isshow)
            {
                btn_hiden_Click(null, null);
            }
            UnRegisterShortcutKeyConfig();
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void menu_show_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void txt_bosskey_Enter(object sender, EventArgs e)
        {
            UnRegisterShortcutKeyConfig();
        }
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private void list_process_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 2)
                lvwColumnSorter.IsNumber = true;
            else
                lvwColumnSorter.IsNumber = false;
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            list_process.ListViewItemSorter = lvwColumnSorter;
            // 用新的排序方法对ListView排序
            this.list_process.Sort();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }
    }





}
