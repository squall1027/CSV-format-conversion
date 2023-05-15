namespace csv_format_conversion
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnReadCSV = new System.Windows.Forms.Button();
            this.btnSaveUTF8 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.Pastebutton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.Version_label = new System.Windows.Forms.Label();
            this.Filelist_label = new System.Windows.Forms.Label();
            this.ConvertToUTF8 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseCSV = new System.Windows.Forms.Button();
            this.SelectedRowCountLabel = new System.Windows.Forms.Label();
            this.Rowlist_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReadCSV
            // 
            this.btnReadCSV.Location = new System.Drawing.Point(524, 15);
            this.btnReadCSV.Name = "btnReadCSV";
            this.btnReadCSV.Size = new System.Drawing.Size(140, 23);
            this.btnReadCSV.TabIndex = 0;
            this.btnReadCSV.Text = "Open CSV";
            this.btnReadCSV.UseVisualStyleBackColor = true;
            this.btnReadCSV.Click += new System.EventHandler(this.btnReadCSV_Click);
            // 
            // btnSaveUTF8
            // 
            this.btnSaveUTF8.Location = new System.Drawing.Point(708, 15);
            this.btnSaveUTF8.Name = "btnSaveUTF8";
            this.btnSaveUTF8.Size = new System.Drawing.Size(140, 23);
            this.btnSaveUTF8.TabIndex = 1;
            this.btnSaveUTF8.Text = "Save CSV (BIG5)";
            this.btnSaveUTF8.UseVisualStyleBackColor = true;
            this.btnSaveUTF8.Click += new System.EventHandler(this.btnSaveUTF8_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 389);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 528);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1051, 25);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 56;
            this.statusBar.Text = "Welcome!";
            // 
            // Pastebutton
            // 
            this.Pastebutton.Location = new System.Drawing.Point(896, 15);
            this.Pastebutton.Name = "Pastebutton";
            this.Pastebutton.Size = new System.Drawing.Size(140, 23);
            this.Pastebutton.TabIndex = 57;
            this.Pastebutton.Text = "貼上數據";
            this.Pastebutton.UseVisualStyleBackColor = true;
            this.Pastebutton.Click += new System.EventHandler(this.Pastebutton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(896, 52);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(140, 23);
            this.UndoButton.TabIndex = 58;
            this.UndoButton.Text = "撤銷貼上數據";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // Version_label
            // 
            this.Version_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Version_label.AutoSize = true;
            this.Version_label.Location = new System.Drawing.Point(993, 5);
            this.Version_label.Name = "Version_label";
            this.Version_label.Size = new System.Drawing.Size(46, 12);
            this.Version_label.TabIndex = 59;
            this.Version_label.Text = "Ver : 1.5";
            // 
            // Filelist_label
            // 
            this.Filelist_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Filelist_label.AutoSize = true;
            this.Filelist_label.Location = new System.Drawing.Point(2, 88);
            this.Filelist_label.Name = "Filelist_label";
            this.Filelist_label.Size = new System.Drawing.Size(62, 12);
            this.Filelist_label.TabIndex = 60;
            this.Filelist_label.Text = "文件位置 : ";
            this.Filelist_label.Visible = false;
            // 
            // ConvertToUTF8
            // 
            this.ConvertToUTF8.Location = new System.Drawing.Point(708, 52);
            this.ConvertToUTF8.Name = "ConvertToUTF8";
            this.ConvertToUTF8.Size = new System.Drawing.Size(140, 23);
            this.ConvertToUTF8.TabIndex = 62;
            this.ConvertToUTF8.Text = "轉儲 CSV (BOM UTF8)";
            this.ConvertToUTF8.UseVisualStyleBackColor = true;
            this.ConvertToUTF8.Click += new System.EventHandler(this.btnConvertToUTF8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseCSV);
            this.groupBox1.Controls.Add(this.SelectedRowCountLabel);
            this.groupBox1.Controls.Add(this.Rowlist_label);
            this.groupBox1.Controls.Add(this.Filelist_label);
            this.groupBox1.Controls.Add(this.btnReadCSV);
            this.groupBox1.Controls.Add(this.ConvertToUTF8);
            this.groupBox1.Controls.Add(this.Pastebutton);
            this.groupBox1.Controls.Add(this.btnSaveUTF8);
            this.groupBox1.Controls.Add(this.UndoButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1051, 110);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // btnBrowseCSV
            // 
            this.btnBrowseCSV.Location = new System.Drawing.Point(524, 52);
            this.btnBrowseCSV.Name = "btnBrowseCSV";
            this.btnBrowseCSV.Size = new System.Drawing.Size(140, 23);
            this.btnBrowseCSV.TabIndex = 65;
            this.btnBrowseCSV.Text = "Browse CSV";
            this.btnBrowseCSV.UseVisualStyleBackColor = true;
            this.btnBrowseCSV.Visible = false;
            this.btnBrowseCSV.Click += new System.EventHandler(this.btnBrowseCSV_Click);
            // 
            // SelectedRowCountLabel
            // 
            this.SelectedRowCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedRowCountLabel.AutoSize = true;
            this.SelectedRowCountLabel.Location = new System.Drawing.Point(2, 22);
            this.SelectedRowCountLabel.Name = "SelectedRowCountLabel";
            this.SelectedRowCountLabel.Size = new System.Drawing.Size(62, 12);
            this.SelectedRowCountLabel.TabIndex = 64;
            this.SelectedRowCountLabel.Text = "選中筆數 : ";
            this.SelectedRowCountLabel.Visible = false;
            // 
            // Rowlist_label
            // 
            this.Rowlist_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rowlist_label.AutoSize = true;
            this.Rowlist_label.Location = new System.Drawing.Point(2, 55);
            this.Rowlist_label.Name = "Rowlist_label";
            this.Rowlist_label.Size = new System.Drawing.Size(62, 12);
            this.Rowlist_label.TabIndex = 63;
            this.Rowlist_label.Text = "總列筆數 : ";
            this.Rowlist_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1051, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Version_label);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Format Conversion - By:Seifer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadCSV;
        private System.Windows.Forms.Button btnSaveUTF8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button Pastebutton;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Label Version_label;
        private System.Windows.Forms.Label Filelist_label;
        private System.Windows.Forms.Button ConvertToUTF8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Rowlist_label;
        private System.Windows.Forms.Label SelectedRowCountLabel;
        private System.Windows.Forms.Button btnBrowseCSV;
    }
}

