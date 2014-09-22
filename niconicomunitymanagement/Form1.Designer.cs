namespace niconicomunitymanagement
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxurl = new System.Windows.Forms.TextBox();
            this.dataGridViewnyu = new System.Windows.Forms.DataGridView();
            this.n_u_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.n_u_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewtai = new System.Windows.Forms.DataGridView();
            this.t_u_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.t_u_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewcom = new System.Windows.Forms.DataGridView();
            this.c_num = new System.Windows.Forms.DataGridViewLinkColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ninzu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelpath = new System.Windows.Forms.Label();
            this.textBoxhelp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewnyu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxurl
            // 
            this.textBoxurl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxurl.Enabled = false;
            this.textBoxurl.Location = new System.Drawing.Point(215, 24);
            this.textBoxurl.Name = "textBoxurl";
            this.textBoxurl.Size = new System.Drawing.Size(206, 19);
            this.textBoxurl.TabIndex = 1;
            this.textBoxurl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxurl_KeyPress);
            // 
            // dataGridViewnyu
            // 
            this.dataGridViewnyu.AllowUserToAddRows = false;
            this.dataGridViewnyu.AllowUserToDeleteRows = false;
            this.dataGridViewnyu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewnyu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n_u_id,
            this.n_u_name});
            this.dataGridViewnyu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewnyu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewnyu.Name = "dataGridViewnyu";
            this.dataGridViewnyu.ReadOnly = true;
            this.dataGridViewnyu.RowTemplate.Height = 21;
            this.dataGridViewnyu.Size = new System.Drawing.Size(253, 239);
            this.dataGridViewnyu.TabIndex = 2;
            this.dataGridViewnyu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewnyu_CellClick);
            // 
            // n_u_id
            // 
            this.n_u_id.HeaderText = "ユーザID";
            this.n_u_id.Name = "n_u_id";
            this.n_u_id.ReadOnly = true;
            this.n_u_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.n_u_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.n_u_id.Width = 71;
            // 
            // n_u_name
            // 
            this.n_u_name.HeaderText = "ユーザ名";
            this.n_u_name.Name = "n_u_name";
            this.n_u_name.ReadOnly = true;
            this.n_u_name.Width = 72;
            // 
            // dataGridViewtai
            // 
            this.dataGridViewtai.AllowUserToAddRows = false;
            this.dataGridViewtai.AllowUserToDeleteRows = false;
            this.dataGridViewtai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewtai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.t_u_id,
            this.t_u_name});
            this.dataGridViewtai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewtai.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewtai.Name = "dataGridViewtai";
            this.dataGridViewtai.ReadOnly = true;
            this.dataGridViewtai.RowTemplate.Height = 21;
            this.dataGridViewtai.Size = new System.Drawing.Size(254, 239);
            this.dataGridViewtai.TabIndex = 3;
            this.dataGridViewtai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewtai_CellClick);
            // 
            // t_u_id
            // 
            this.t_u_id.HeaderText = "ユーザID";
            this.t_u_id.Name = "t_u_id";
            this.t_u_id.ReadOnly = true;
            this.t_u_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.t_u_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.t_u_id.Width = 71;
            // 
            // t_u_name
            // 
            this.t_u_name.HeaderText = "ユーザ名";
            this.t_u_name.Name = "t_u_name";
            this.t_u_name.ReadOnly = true;
            this.t_u_name.Width = 72;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(427, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "管理開始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ブラウザ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "コミュニティページ";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(427, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "保存場所";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewcom
            // 
            this.dataGridViewcom.AllowUserToAddRows = false;
            this.dataGridViewcom.AllowUserToDeleteRows = false;
            this.dataGridViewcom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewcom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_num,
            this.c_name,
            this.c_ninzu,
            this.c_last});
            this.dataGridViewcom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewcom.Enabled = false;
            this.dataGridViewcom.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewcom.MultiSelect = false;
            this.dataGridViewcom.Name = "dataGridViewcom";
            this.dataGridViewcom.ReadOnly = true;
            this.dataGridViewcom.RowTemplate.Height = 21;
            this.dataGridViewcom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewcom.Size = new System.Drawing.Size(511, 261);
            this.dataGridViewcom.TabIndex = 9;
            this.dataGridViewcom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewcom_CellClick);
            this.dataGridViewcom.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewcom_CellMouseDown);
            // 
            // c_num
            // 
            this.c_num.HeaderText = "コミュニティ番号";
            this.c_num.Name = "c_num";
            this.c_num.ReadOnly = true;
            this.c_num.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // c_name
            // 
            this.c_name.HeaderText = "コミュニティ名";
            this.c_name.Name = "c_name";
            this.c_name.ReadOnly = true;
            // 
            // c_ninzu
            // 
            this.c_ninzu.HeaderText = "人数";
            this.c_ninzu.Name = "c_ninzu";
            this.c_ninzu.ReadOnly = true;
            // 
            // c_last
            // 
            this.c_last.HeaderText = "最終確認日時";
            this.c_last.Name = "c_last";
            this.c_last.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 115);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewcom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(511, 504);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewnyu);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewtai);
            this.splitContainer2.Size = new System.Drawing.Size(511, 239);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(427, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "コミュ追加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "管理開始";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "削除";
            // 
            // labelpath
            // 
            this.labelpath.AutoSize = true;
            this.labelpath.Location = new System.Drawing.Point(10, 53);
            this.labelpath.Name = "labelpath";
            this.labelpath.Size = new System.Drawing.Size(0, 12);
            this.labelpath.TabIndex = 13;
            // 
            // textBoxhelp
            // 
            this.textBoxhelp.Location = new System.Drawing.Point(12, 77);
            this.textBoxhelp.Multiline = true;
            this.textBoxhelp.Name = "textBoxhelp";
            this.textBoxhelp.ReadOnly = true;
            this.textBoxhelp.Size = new System.Drawing.Size(409, 32);
            this.textBoxhelp.TabIndex = 14;
            this.textBoxhelp.Text = "ブラウザを選択して下さい。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 619);
            this.Controls.Add(this.textBoxhelp);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxurl);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelpath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NCM ニコニコミュニティマネジメント";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewnyu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcom)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxurl;
        private System.Windows.Forms.DataGridView dataGridViewnyu;
        private System.Windows.Forms.DataGridView dataGridViewtai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewcom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewLinkColumn n_u_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn n_u_name;
        private System.Windows.Forms.DataGridViewLinkColumn t_u_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_u_name;
        private System.Windows.Forms.Label labelpath;
        private System.Windows.Forms.TextBox textBoxhelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridViewLinkColumn c_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ninzu;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_last;
    }
}

