﻿namespace csv_format_conversion
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadCSV
            // 
            this.btnReadCSV.Location = new System.Drawing.Point(41, 318);
            this.btnReadCSV.Name = "btnReadCSV";
            this.btnReadCSV.Size = new System.Drawing.Size(75, 23);
            this.btnReadCSV.TabIndex = 0;
            this.btnReadCSV.Text = "Read CSV";
            this.btnReadCSV.UseVisualStyleBackColor = true;
            this.btnReadCSV.Click += new System.EventHandler(this.btnReadCSV_Click);
            // 
            // btnSaveUTF8
            // 
            this.btnSaveUTF8.Location = new System.Drawing.Point(150, 318);
            this.btnSaveUTF8.Name = "btnSaveUTF8";
            this.btnSaveUTF8.Size = new System.Drawing.Size(104, 23);
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 290);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 370);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1060, 25);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 56;
            this.statusBar.Text = "Welcome!";
            // 
            // Pastebutton
            // 
            this.Pastebutton.Location = new System.Drawing.Point(333, 318);
            this.Pastebutton.Name = "Pastebutton";
            this.Pastebutton.Size = new System.Drawing.Size(75, 23);
            this.Pastebutton.TabIndex = 57;
            this.Pastebutton.Text = "貼上數據";
            this.Pastebutton.UseVisualStyleBackColor = true;
            this.Pastebutton.Click += new System.EventHandler(this.Pastebutton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(442, 318);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 58;
            this.UndoButton.Text = "撤銷貼上";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // Version_label
            // 
            this.Version_label.AutoSize = true;
            this.Version_label.Location = new System.Drawing.Point(1002, 4);
            this.Version_label.Name = "Version_label";
            this.Version_label.Size = new System.Drawing.Size(46, 12);
            this.Version_label.TabIndex = 59;
            this.Version_label.Text = "Ver : 1.4";
            // 
            // Filelist_label
            // 
            this.Filelist_label.AutoSize = true;
            this.Filelist_label.Location = new System.Drawing.Point(1, 354);
            this.Filelist_label.Name = "Filelist_label";
            this.Filelist_label.Size = new System.Drawing.Size(62, 12);
            this.Filelist_label.TabIndex = 60;
            this.Filelist_label.Text = "文件位置 : ";
            this.Filelist_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1060, 395);
            this.Controls.Add(this.Filelist_label);
            this.Controls.Add(this.Version_label);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.Pastebutton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSaveUTF8);
            this.Controls.Add(this.btnReadCSV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Format Conversion - By:Seifer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}

