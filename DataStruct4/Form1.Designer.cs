namespace DataStruct4
{
    partial class Form1
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
            this.restore = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.TextBox();
            this.SortClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.random = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.heap = new System.Windows.Forms.Button();
            this.merge = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.Button();
            this.quick = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.shell = new System.Windows.Forms.Button();
            this.bubble = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SortNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reverse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // restore
            // 
            this.restore.Enabled = false;
            this.restore.Location = new System.Drawing.Point(1073, 19);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(95, 23);
            this.restore.TabIndex = 29;
            this.restore.Text = "恢复到排序前";
            this.restore.UseVisualStyleBackColor = true;
            this.restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // Time
            // 
            this.Time.Location = new System.Drawing.Point(17, 524);
            this.Time.Multiline = true;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Time.Size = new System.Drawing.Size(1050, 175);
            this.Time.TabIndex = 14;
            // 
            // SortClear
            // 
            this.SortClear.Location = new System.Drawing.Point(1073, 676);
            this.SortClear.Name = "SortClear";
            this.SortClear.Size = new System.Drawing.Size(75, 23);
            this.SortClear.TabIndex = 28;
            this.SortClear.Text = "清除文本框";
            this.SortClear.UseVisualStyleBackColor = true;
            this.SortClear.Click += new System.EventHandler(this.SortClear_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1073, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 64);
            this.label2.TabIndex = 27;
            this.label2.Text = "500及以下会演示.演示会比不演示慢，时间花在了绘图上";
            // 
            // random
            // 
            this.random.Location = new System.Drawing.Point(1073, 87);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(75, 23);
            this.random.TabIndex = 26;
            this.random.Text = "生成随机数";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.random_Click);
            // 
            // refresh
            // 
            this.refresh.Enabled = false;
            this.refresh.Location = new System.Drawing.Point(1073, 524);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 25;
            this.refresh.Text = "重新绘图";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // heap
            // 
            this.heap.Enabled = false;
            this.heap.Location = new System.Drawing.Point(1073, 441);
            this.heap.Name = "heap";
            this.heap.Size = new System.Drawing.Size(75, 23);
            this.heap.TabIndex = 19;
            this.heap.Text = "堆排序";
            this.heap.UseVisualStyleBackColor = true;
            this.heap.Click += new System.EventHandler(this.Heap_Click);
            // 
            // merge
            // 
            this.merge.Enabled = false;
            this.merge.Location = new System.Drawing.Point(1073, 398);
            this.merge.Name = "merge";
            this.merge.Size = new System.Drawing.Size(75, 23);
            this.merge.TabIndex = 24;
            this.merge.Text = "归并排序";
            this.merge.UseVisualStyleBackColor = true;
            this.merge.Click += new System.EventHandler(this.Merge_Click);
            // 
            // select
            // 
            this.select.Enabled = false;
            this.select.Location = new System.Drawing.Point(1073, 356);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 23;
            this.select.Text = "选择排序";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.Select_Click);
            // 
            // quick
            // 
            this.quick.Enabled = false;
            this.quick.Location = new System.Drawing.Point(1073, 314);
            this.quick.Name = "quick";
            this.quick.Size = new System.Drawing.Size(75, 23);
            this.quick.TabIndex = 22;
            this.quick.Text = "快速排序";
            this.quick.UseVisualStyleBackColor = true;
            this.quick.Click += new System.EventHandler(this.Quick_Click);
            // 
            // insert
            // 
            this.insert.Enabled = false;
            this.insert.Location = new System.Drawing.Point(1073, 271);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 21;
            this.insert.Text = "插入排序";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // shell
            // 
            this.shell.Enabled = false;
            this.shell.Location = new System.Drawing.Point(1073, 226);
            this.shell.Name = "shell";
            this.shell.Size = new System.Drawing.Size(75, 23);
            this.shell.TabIndex = 20;
            this.shell.Text = "希尔排序";
            this.shell.UseVisualStyleBackColor = true;
            this.shell.Click += new System.EventHandler(this.Shell_Click);
            // 
            // bubble
            // 
            this.bubble.Enabled = false;
            this.bubble.Location = new System.Drawing.Point(1073, 180);
            this.bubble.Name = "bubble";
            this.bubble.Size = new System.Drawing.Size(75, 23);
            this.bubble.TabIndex = 17;
            this.bubble.Text = "冒泡排序";
            this.bubble.UseVisualStyleBackColor = true;
            this.bubble.Click += new System.EventHandler(this.Bubble_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1073, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "数量（1-99999）";
            // 
            // SortNumber
            // 
            this.SortNumber.Location = new System.Drawing.Point(1073, 60);
            this.SortNumber.MaxLength = 5;
            this.SortNumber.Name = "SortNumber";
            this.SortNumber.Size = new System.Drawing.Size(95, 21);
            this.SortNumber.TabIndex = 15;
            this.SortNumber.Text = "500";
            this.SortNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SortNumber_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(17, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 500);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "演示";
            // 
            // reverse
            // 
            this.reverse.Enabled = false;
            this.reverse.Location = new System.Drawing.Point(1073, 553);
            this.reverse.Name = "reverse";
            this.reverse.Size = new System.Drawing.Size(75, 23);
            this.reverse.TabIndex = 30;
            this.reverse.Text = "把数组逆序";
            this.reverse.UseVisualStyleBackColor = true;
            this.reverse.Click += new System.EventHandler(this.Reverse_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1071, 579);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 64);
            this.label3.TabIndex = 31;
            this.label3.Text = "注：对有序数组使用快速排序会导致程序崩溃";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reverse);
            this.Controls.Add(this.restore);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.SortClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.random);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.heap);
            this.Controls.Add(this.merge);
            this.Controls.Add(this.select);
            this.Controls.Add(this.quick);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.shell);
            this.Controls.Add(this.bubble);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SortNumber);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 750);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "Form1";
            this.Text = "排序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button restore;
        private System.Windows.Forms.TextBox Time;
        private System.Windows.Forms.Button SortClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button heap;
        private System.Windows.Forms.Button merge;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button quick;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button shell;
        private System.Windows.Forms.Button bubble;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SortNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button reverse;
        private System.Windows.Forms.Label label3;
    }
}

