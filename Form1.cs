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

namespace csv_format_conversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 是一個私有的 DataTable 變數，用來儲存上一次的 dataGridView1 資料。
        // 這樣在進行撤銷操作時，可以將前一次的資料再次賦值給 dataGridView1，達到復原的目的。
        private DataTable previousData;

        private void btnReadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // 檢測 CSV 文件的編碼格式
                    Encoding encoding = GetEncoding(filePath);

                    // 讀取 CSV 文件
                    using (StreamReader reader = new StreamReader(filePath, encoding))
                    {
                        DataTable dataTable = new DataTable();
                        bool isFirstRow = true;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] values = line.Split(',');
                            if (isFirstRow)
                            {
                                foreach (string value in values)
                                {
                                    dataTable.Columns.Add(value.Trim());
                                }
                                isFirstRow = false;
                            }
                            else
                            {
                                DataRow row = dataTable.NewRow();
                                for (int i = 0; i < values.Length; i++)
                                {
                                    row[i] = values[i].Trim();
                                }
                                dataTable.Rows.Add(row);
                            }
                        }
                        dataGridView1.DataSource = dataTable;

                        // 顯示編碼格式
                        statusBar.Text = "目前文件編碼格式為 : " + encoding.EncodingName;

                        MessageBox.Show("文件已讀取，編碼格式為：" + encoding.EncodingName);
                    }
                }
                catch (Exception ex)
                {
                    statusBar.Text = "讀取CSV文件時出現異常 : " + ex.Message;

                    MessageBox.Show("讀取CSV文件時出現異常：" + ex.Message);
                }
            }
        }

        private Encoding GetEncoding(string filePath)
        {
            // 檢測文件的編碼格式
            byte[] bytes = new byte[4];
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Read(bytes, 0, 4);
            }

            if (bytes[0] == 0xef && bytes[1] == 0xbb && bytes[2] == 0xbf)
            {
                return Encoding.UTF8;
            }
            else if (bytes[0] == 0xfe && bytes[1] == 0xff)
            {
                return Encoding.Unicode;
            }
            else if (bytes[0] == 0xff && bytes[1] == 0xfe)
            {
                return Encoding.BigEndianUnicode;
            }
            else
            {
                return Encoding.Default;
            }
        }


        private void btnSaveUTF8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    try
                    {
                        // 將數據寫入CSV文件
                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // 寫入列名
                            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                            {
                                writer.Write(dataGridView1.Columns[i].HeaderText);
                                if (i < dataGridView1.ColumnCount - 1)
                                {
                                    writer.Write(",");
                                }
                            }
                            writer.WriteLine();

                            // 寫入數據
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                if (dataGridView1.Rows[i].IsNewRow)
                                {
                                    continue;
                                }

                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    // 檢查單元格是否為空
                                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                                    {
                                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                    }
                                    else
                                    {
                                        writer.Write("");
                                    }
                                    if (j < dataGridView1.ColumnCount - 1)
                                    {
                                        writer.Write(",");
                                    }
                                }
                                writer.WriteLine();
                            }

                        }

                        MessageBox.Show("文件已保存");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存CSV文件時出現異常：" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可以保存的數據");
            }
        }

        private void Pastebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                // 保存當前數據狀態
                previousData = ((DataTable)dataGridView1.DataSource).Copy();

                // 讀取剪貼板中的數據
                string clipboardText = Clipboard.GetText();
                string[] lines = clipboardText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // 創建DataTable對象
                DataTable dataTable = new DataTable();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataTable.Columns.Add(dataGridView1.Columns[i].HeaderText);
                }

                // 添加數據
                foreach (string line in lines)
                {
                    DataRow row = dataTable.NewRow();
                    string[] values = line.Split('\t');
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = values[i];
                    }
                    dataTable.Rows.Add(row);
                }

                // 將DataTable賦值給dataGridView1的DataSource
                dataGridView1.DataSource = dataTable;

                MessageBox.Show("數據貼上成功");
            }
            else
            {
                MessageBox.Show("沒有可以貼上的數據");
            }
        }

        // 定義一個棧，用於記錄操作歷史
        Stack<DataGridViewCell> cellStack = new Stack<DataGridViewCell>();

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cellStack.Push(cell);
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (previousData != null)
            {
                dataGridView1.DataSource = previousData;
                MessageBox.Show("撤銷操作成功，當前數據已恢復到之前的狀態");
            }
            else
            {
                MessageBox.Show("沒有可以撤銷的數據");
            }
        }
    }
}