using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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
                            string[] values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
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

                        // 獲取表格中的行數
                        CountRows();

                        // DeBUG用，如要用請新増 richTextBox1 組件
                        // richTextBox1.Text = File.ReadAllText(filePath, encoding);

                        // 設定 DataGridView 的字體
                        //SetDataGridViewFont(encoding);

                        // 瀏覽 CSV 的文件位置
                        btnBrowseCSV.Visible = true;

                        // 當前 CSV 文件路徑
                        Filelist_label.Visible = true;
                        Filelist_label.Text = "文件位置 : " + filePath;

                        statusBar.Text = "目前文件編碼格式為 : " + encoding.EncodingName;

                        // 顯示編碼格式
                        MessageBox.Show("文件已讀取成功！\r\n\r\n當前 CSV 編碼格式為：" + encoding.EncodingName, "提示 :");
                    }
                }
                catch (Exception ex)
                {
                    statusBar.Text = "讀取 CSV 文件時出現異常 : " + ex.Message;

                    MessageBox.Show("讀取 CSV 文件時出現異常：\r\n\r\n" + ex.Message, "提示 :");
                }
            }
        }

        private Encoding GetEncoding(string filename)
        {
            // 預設為 BIG5
            Encoding encoding = Encoding.GetEncoding("big5");

            // 讀取文件前三個字節判斷編碼格式
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // 讀取文件前三個字節判斷編碼格式
                byte[] bom = new byte[3];
                fs.Read(bom, 0, 3);

                // 檢測 BOM UTF8
                if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
                {
                    encoding = new UTF8Encoding(true);
                }
                else
                {
                    // 不是 BOM UTF8，重新讀取文件開頭判斷編碼格式
                    fs.Seek(0, SeekOrigin.Begin);

                    byte[] buffer = new byte[1000];
                    int bytesRead = fs.Read(buffer, 0, buffer.Length);

                    // 判斷 UTF-8 編碼
                    if (bytesRead >= 3 && buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
                    {
                        encoding = new UTF8Encoding(false);
                    }
                    else
                    {
                        bool isUtf8 = true;
                        for (int i = 0; i < bytesRead; i++)
                        {
                            byte b = buffer[i];
                            if (b <= 0x7f)
                            {
                                // ASCII 字符
                                continue;
                            }
                            else if (b >= 0xc2 && b <= 0xdf)
                            {
                                // 2 字節 UTF-8
                                if (i + 1 >= bytesRead || (buffer[i + 1] & 0xc0) != 0x80)
                                {
                                    isUtf8 = false;
                                    break;
                                }
                                i++;
                            }
                            else if (b >= 0xe0 && b <= 0xef)
                            {
                                // 3 字節 UTF-8
                                if (i + 2 >= bytesRead || (buffer[i + 1] & 0xc0) != 0x80 || (buffer[i + 2] & 0xc0) != 0x80)
                                {
                                    isUtf8 = false;
                                    break;
                                }
                                i += 2;
                            }
                            else
                            {
                                // 不是 UTF-8
                                isUtf8 = false;
                                break;
                            }
                        }
                        if (isUtf8)
                        {
                            encoding = new UTF8Encoding(false);
                        }
                    }
                }
            }

            return encoding;
        }

        // 在讀取完 CSV 文件後，設定 DataGridView 的字體
        private void SetDataGridViewFont(Encoding encoding)
        {
            switch (encoding.EncodingName.ToUpper())
            {
                case "UTF-8":
                    dataGridView1.Font = new Font("Microsoft JhengHei UI", 9);
                    break;
                case "BIGENDIANUNICODE":
                case "UNICODE":
                    dataGridView1.Font = new Font("Microsoft JhengHei UI", 10);
                    break;
                default:
                    dataGridView1.Font = new Font("Microsoft JhengHei UI", 12);
                    break;
            }
        }

        // 獲取表格中的行數
        private void CountRows()
        {
            int rowCount = dataGridView1.RowCount - 1;

            Rowlist_label.Visible = true;
            SelectedRowCountLabel.Visible = true;

            SelectedRowCountLabel.Text = "選中筆數 : 1";

            Rowlist_label.Text = "總列筆數 : " + rowCount;
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
                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.GetEncoding(950)))
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

                                // 寫入 CSV 文件
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

                        statusBar.Text = "目前文件編碼格式為 : 繁體中文 (Big5)";

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

        private void btnBrowseCSV_Click(object sender, EventArgs e)
        {
            // 檢查是否已讀取 CSV 文件
            if (string.IsNullOrEmpty(Filelist_label.Text))
            {
                MessageBox.Show("請先讀取 CSV 文件！", "提示 :");
                return;
            }

            // 取得 CSV 文件所在的文件夾位置
            string folderPath = Path.GetDirectoryName(Filelist_label.Text.Replace("文件位置 : ", ""));

            // 打開文件夾
            Process.Start(folderPath);
        }

        private void Pastebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {

                // 顯示提示框，詢問用戶是否確認清空數據
                DialogResult dialogResult = MessageBox.Show("貼上數據會清空當前數據，確認空數據嗎？", "確認清空數據", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // 用戶選擇了確認貼上數據，執行數據貼上的操作

                    // 先保存當前數據狀態，用來記錄回退數據用。
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
                            if (i < dataTable.Columns.Count)
                            {
                                row[i] = values[i];
                            }
                            else
                            {
                                dataTable.Columns.Add("Column " + i);
                                row[i] = values[i];
                            }
                        }
                        dataTable.Rows.Add(row);
                    }

                    // 將DataTable賦值給dataGridView1的DataSource
                    dataGridView1.DataSource = dataTable;

                    MessageBox.Show("數據貼上成功");
                }

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

        private void btnConvertToUTF8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                StringBuilder sb = new StringBuilder();

                // 生成 CSV 文件的表頭
                foreach (DataColumn column in dataTable.Columns)
                {
                    sb.Append(column.ColumnName + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(Environment.NewLine);

                // 生成 CSV 文件的數據行
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sb.Append(row[column].ToString() + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(Environment.NewLine);
                }

                // 將數據寫入 UTF-8 格式的文件
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("已經成功將數據轉換為 UTF-8 格式 \r\n\r\n 保存地址為 : " + saveFileDialog.FileName + " 文件");
                }
            }
            else
            {
                MessageBox.Show("沒有可以保存的數據");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowNumber = e.RowIndex + 1;
                int columnNumber = e.ColumnIndex + 1;
                SelectedRowCountLabel.Text = string.Format("選中筆數 : 第 {0} 列中的第 {1} 行", rowNumber, columnNumber);
            }
        }

    }
}