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

namespace CredirCalculator
{
    public partial class Conclusion : Form
    {

        double creditAmm = 0;
        ForCalculate fr;
        public Conclusion(double creditAmount, double creditRate, int creditPeriod, int type)
        {
            InitializeComponent();

            dtg_Main.Columns[0].DefaultCellStyle.Format = String.Format("### ### ### ##0.#0");
            dtg_Main.Columns[1].DefaultCellStyle.Format = String.Format("### ### ### ##0.#0");
            dtg_Main.Columns[2].DefaultCellStyle.Format = String.Format("### ### ### ##0.#0");
            dtg_Main.Columns[3].DefaultCellStyle.Format = String.Format("### ### ### ##0.#0");
            dtg_Main.Columns[4].DefaultCellStyle.Format = String.Format("### ### ### ##0.#0");

            creditAmm = creditAmount;

            fr = new ForCalculate(creditAmount, creditRate, creditPeriod);

            if(type == 0)
            {
                fr.ANNUT(dtg_Main);
            }
            else
            {
                fr.DIFF(dtg_Main);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
               Export( dtg_Main);
        }
        void Export( DataGridView dataTable)
        {
            SaveFileDialog saveTableAsCSV = new SaveFileDialog();
            saveTableAsCSV.Filter = "Документ CSV (*.csv) |*.csv";
            saveTableAsCSV.Title = "Сохранить результат расчетов";
            if (saveTableAsCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(saveTableAsCSV.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(file, Encoding.Default);

                    for (int i = 0; i < dataTable.RowCount; i++)
                    {
                        for (int j = 0; j < dataTable.ColumnCount; j++)
                        {
                            sw.Write(Convert.ToDouble(dataTable.Rows[i].Cells[j].Value));
                            if (j < dataTable.ColumnCount - 1)
                                sw.Write(";");
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Уже есть");
                }
            }

        }
        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add();
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
    }
}
