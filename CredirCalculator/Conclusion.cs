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

        double creditAmm=0;
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
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Экспорт графика платежей";
            save.Filter = "*.CSV-файл с разделителями |*.csv";
            if (save.ShowDialog() == DialogResult.OK)
                Export(save.FileName, ToDataTable(dtg_Main), creditAmm.ToString());
        }
        void Export(string filename, DataTable dataTable,string creditAmount)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.Default);
                sw.WriteLine(String.Join(";", dataTable.Columns[0].Caption, dataTable.Columns[1].Caption, dataTable.Columns[2].Caption, dataTable.Columns[3].Caption, dataTable.Columns[4].Caption));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    sw.WriteLine(String.Join(";", dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4]));
                sw.WriteLine(String.Join(";", "Итого", creditAmount));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                sw?.Close();
                fs?.Close();
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
