namespace RuProject
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cbHeadless = new System.Windows.Forms.CheckBox();
            this.btnPaused = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lvPortable = new System.Windows.Forms.ListView();
            this.stt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.link = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numbIsRun = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numbIsRun)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHeadless
            // 
            this.cbHeadless.AutoSize = true;
            this.cbHeadless.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbHeadless.Location = new System.Drawing.Point(614, 182);
            this.cbHeadless.Name = "cbHeadless";
            this.cbHeadless.Size = new System.Drawing.Size(106, 18);
            this.cbHeadless.TabIndex = 27;
            this.cbHeadless.Text = "Ẩn trình duyệt";
            this.cbHeadless.UseVisualStyleBackColor = true;
            // 
            // btnPaused
            // 
            this.btnPaused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPaused.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPaused.Enabled = false;
            this.btnPaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaused.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPaused.Location = new System.Drawing.Point(426, 494);
            this.btnPaused.Name = "btnPaused";
            this.btnPaused.Size = new System.Drawing.Size(139, 40);
            this.btnPaused.TabIndex = 22;
            this.btnPaused.Text = "Tạm Dừng";
            this.btnPaused.UseVisualStyleBackColor = false;
            this.btnPaused.Click += new System.EventHandler(this.btnPaused_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(10, 494);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(401, 40);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "Bất Đầu";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(208, 182);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 25);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Xóa Danh Sách";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(13, 182);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(188, 25);
            this.btnInput.TabIndex = 23;
            this.btnInput.Text = "Nhập Dữ Liệu Account";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Firebrick;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStop.Location = new System.Drawing.Point(571, 494);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 40);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "Dừng";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lvPortable
            // 
            this.lvPortable.BackColor = System.Drawing.SystemColors.Window;
            this.lvPortable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvPortable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stt,
            this.link,
            this.status});
            this.lvPortable.HideSelection = false;
            this.lvPortable.Location = new System.Drawing.Point(14, 13);
            this.lvPortable.Name = "lvPortable";
            this.lvPortable.Size = new System.Drawing.Size(708, 160);
            this.lvPortable.TabIndex = 29;
            this.lvPortable.UseCompatibleStateImageBehavior = false;
            this.lvPortable.View = System.Windows.Forms.View.Details;
            this.lvPortable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvPortable_KeyDown);
            // 
            // stt
            // 
            this.stt.Text = "#";
            this.stt.Width = 33;
            // 
            // link
            // 
            this.link.Text = "Link Quét";
            this.link.Width = 510;
            // 
            // status
            // 
            this.status.Text = "";
            this.status.Width = 162;
            // 
            // numbIsRun
            // 
            this.numbIsRun.Location = new System.Drawing.Point(665, 206);
            this.numbIsRun.Name = "numbIsRun";
            this.numbIsRun.Size = new System.Drawing.Size(54, 22);
            this.numbIsRun.TabIndex = 5;
            this.numbIsRun.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(600, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Số Luồng";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 234);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(709, 254);
            this.txtLog.TabIndex = 30;
            this.txtLog.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 31;
            this.button1.Text = "Xuất Danh sách Link Quét";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(14, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 36);
            this.button2.TabIndex = 32;
            this.button2.Text = "Xuất file Quét";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(418, 552);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 22);
            this.textBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tên file xuất :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cbHeadless);
            this.Controls.Add(this.lvPortable);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnPaused);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numbIsRun);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Name";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numbIsRun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPaused;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cbHeadless;
        private System.Windows.Forms.ListView lvPortable;
        private System.Windows.Forms.ColumnHeader stt;
        private System.Windows.Forms.ColumnHeader link;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.NumericUpDown numbIsRun;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

