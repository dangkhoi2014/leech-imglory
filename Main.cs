using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace RuProject
{
    public delegate void SendMessage(String value);
    public partial class Main : Form
    {
        public delegate void SendMessage(String value);
        Dictionary<string, string> Setting;
        string titleForm = "Quét Album LOMASFLOW";
        public Main()
        {
            InitializeComponent();
        }

        public Main(string tForm)
        {
            InitializeComponent();
            this.titleForm = tForm;            
        }
        
        private void Main_Load(object sender, EventArgs e)
        {       
            Setting = RuLib.GetSetting();
            this.Text = this.titleForm;
            
            lvPortable.Scrollable = true;
            lvPortable.MultiSelect = true;
            lvPortable.View = View.Details;
            getConfig();
            //chạy đa luồng
            TaskRun.callback += Complete;
            //#Chạy đa luồng
        }

        //chạy đa luồng
        private object thislock = new object();
        bool isPaused = false;
        bool isStop = false;
        int isRun = 0;
        private int isNumberRun = 1;

        private List<TaskRun> listTaskRun = new List<TaskRun>();
        System.Threading.CancellationTokenSource source = new System.Threading.CancellationTokenSource();
        System.Threading.CancellationToken cancelToken;
        public int rest3g = 0;//doi G

        public void Complete(ClsReturn clsReturn, int index = 0)
        {
            lock (thislock)
            {
                
                if (clsReturn.status == "End")
                {
                    this.SendLog(clsReturn, index, true);
                    isRun--;
                    next();
                }
                else
                {
                    this.SendLog(clsReturn, index, false);
                }
            }
        }


        public void SendLog(ClsReturn clsr, int index, bool end)
        {
            lvPortable.Invoke((MethodInvoker)(() => {
                if (end)
                {
                    lvPortable.Items[index].BackColor = Color.LightGreen;
                }
                else
                {
                    lvPortable.Items[index].BackColor = Color.Yellow;
                }
                
                lvPortable.Items[index].SubItems[2].Text = clsr.msg;
            }));

            txtLog.Invoke((MethodInvoker)(() => {
                if (!string.IsNullOrEmpty(clsr.data))
                {
                    txtLog.Text = txtLog.Text + Environment.NewLine + clsr.data;
                }
            }));            
        }

        public async void next()
        {            
            for (int i = listTaskRun.Count - 1; i >= 0; i--)
            {
                while (isPaused)
                {
                    System.Threading.Thread.Sleep(100);
                }

                if (isRun < isNumberRun)
                {
                    listTaskRun[0].Run(cancelToken);
                    listTaskRun.Remove(listTaskRun[0]);
                    isRun++;
                }
                else
                    break;
            }
            if (listTaskRun.Count == 0)
            {
                EventBtnHoanThanh();
            }
        }

        
        public void EventBtnHoanThanh()
        {
            RuLib.RunScript("taskkill /IM \"chromedriver.exe\" /F");

            btnInput.Invoke((MethodInvoker)(() => {
                btnInput.Enabled = true;
            }));
            btnClear.Invoke((MethodInvoker)(() => {
                btnClear.Enabled = true;
            }));
            btnStart.Invoke((MethodInvoker)(() => {
                btnStart.Enabled = false;
            }));
            btnPaused.Invoke((MethodInvoker)(() => {
                btnPaused.Enabled = false;
            }));
            btnPaused.Invoke((MethodInvoker)(() => {
                btnPaused.Enabled = false;
            }));
            btnStop.Invoke((MethodInvoker)(() => {
                btnStop.Enabled = false;
            }));
            
        }
        //#Chạy đa luồng
        private void btnInput_Click(object sender, EventArgs e)
        {
            frmImportData frmID = new frmImportData(SetValue);
       
            frmID.StartPosition = FormStartPosition.CenterParent;
            frmID.ShowDialog();

            btnClear.Enabled = true;
            btnStart.Enabled = true;
        }

        private void SetValue(String value)
        {
            string[] array_user = System.Text.RegularExpressions.Regex.Split(value.Trim(), "\n");
            int i = 1;
            foreach (var item in array_user)
            {
                
                ListViewItem fag1 = new ListViewItem(i.ToString());
                ListViewItem.ListViewSubItem fag2 = new ListViewItem.ListViewSubItem(fag1, item);
                fag1.SubItems.Add(fag2);

                fag2 = new ListViewItem.ListViewSubItem(fag1, "");
                fag1.SubItems.Add(fag2);

                lvPortable.Items.Add(fag1);

                i++;
            }
            btnClear.Enabled = true;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStop = false;
            setConfig();
            Setting = RuLib.GetSetting();
            cancelToken = source.Token;//dữ liệu để stop luồng
            if (cancelToken.IsCancellationRequested)
            {
                source.Dispose();
                source = new System.Threading.CancellationTokenSource(); // "Reset" the cancellation token source...
                cancelToken = source.Token;//dữ liệu để stop luồng
            }

            if (isStop == false)
            {
                isNumberRun = Int32.Parse(numbIsRun.Value.ToString());//số luồng thực thi
                isRun = 0;
                listTaskRun.Clear();

                int ic = lvPortable.Items.Count - 1;

                for (int i = 0; i <= ic; i++)
                {
                    TaskRun taskRun = new TaskRun();
                    taskRun.index_row = i;//cột trả về
                    taskRun.Setting = Setting;
                    taskRun.link = lvPortable.Items[i].SubItems[1].Text;
                    listTaskRun.Add(taskRun);
                }
                for (int i = listTaskRun.Count - 1; i >= 0; i--)
                {
                    if (isRun < isNumberRun)
                    {
                        listTaskRun[0].Run(cancelToken);
                        listTaskRun.Remove(listTaskRun[0]);
                        isRun++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                if (source != null)
                {
                    source.Cancel();
                }
            }
            btnStart.Enabled = false;
            btnInput.Enabled = false;
            btnClear.Enabled = false;
            btnPaused.Enabled = true;
            btnStop.Enabled = true;
        }        

        private void btnPaused_Click(object sender, EventArgs e)
        {
            if (btnPaused.Text == "Tạm Dừng")
            {
                isPaused = true;
                btnPaused.Text = "Tiếp Tục";
            }
            else
            {
                isPaused = false;
                btnPaused.Text = "Tạm Dừng";
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            isStop = false;
            isRun = 0;
            if (source != null)
            {
                source.Cancel();
            }
            lvPortable.Items.Clear();
            btnClear.Enabled = false;
            btnStart.Enabled = false;
        }

        public void getConfig()
        {
            Dictionary<string, string> Setting = RuLib.GetSetting();
            numbIsRun.Text = Setting["numbIsRun"];
            cbHeadless.Checked = Boolean.Parse(Setting["cbHeadless"]);
            cbHeadless.Checked = Boolean.Parse(Setting["cbHeadless"]);
        }
        public void setConfig()
        {
            Dictionary<string, string> Setting = RuLib.GetSetting();

            if (numbIsRun.Text != Setting["numbIsRun"])
            {
                RuLib.SetSetting("numbIsRun", Int32.Parse(numbIsRun.Text).ToString());
            }                 
            if (cbHeadless.Checked.ToString() != Setting["cbHeadless"])
            {
                RuLib.SetSetting("cbHeadless", cbHeadless.Checked.ToString());
            } 
        }

        private void btnImportText_Click(object sender, EventArgs e)
        {
            frmImportData frmi = new frmImportData(SetDataText);
            frmi.ShowDialog();
        }
        private void SetDataText(String value)
        {
            string[] array_user = System.Text.RegularExpressions.Regex.Split(value.Trim(), "\n");
            int i = 1;
            foreach (var item in array_user)
            {                
                ListViewItem fag1 = new ListViewItem(i.ToString());
                ListViewItem.ListViewSubItem fag2 = new ListViewItem.ListViewSubItem(fag1, item);
                fag1.SubItems.Add(fag2);
                fag2 = new ListViewItem.ListViewSubItem(fag1, "");
                fag1.SubItems.Add(fag2);

                lvPortable.Items.Add(fag1);
            }
            btnClear.Enabled = true;
            btnStart.Enabled = true;
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            isStop = true;
            isRun = 0;
            if (source != null)
            {
                source.Cancel();
            }
            btnStart.Enabled = false;
            btnInput.Enabled = true;
            btnClear.Enabled = true;
            btnStop.Enabled = true;
            btnPaused.Enabled = false;
        }

        private void lvPortable_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != lvPortable) return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                RuLib.CopySelectedValuesToClipboard(lvPortable);
            }

            if (e.KeyCode == Keys.Delete)
                RuLib.DelSelectedValuesToClipboard(lvPortable);

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                {
                    SetDataText(Clipboard.GetText());
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Append), Encoding.UTF8))
                    {
                        foreach (ListViewItem item in lvPortable.Items)
                        {
                            await tw.WriteLineAsync(item.SubItems[0].Text + "\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text);
                        }
                        MessageBox.Show("Đã xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(textBox1.Text, txtLog.Text);
            MessageBox.Show("Đã xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
