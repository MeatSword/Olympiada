using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CredirCalculator
{
    public partial class MainCalcul : Form
    {
        public MainCalcul()
        {
            InitializeComponent();

            cmb_Date.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Date.SelectedIndex = 0;

            cmb_Com.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Com.SelectedIndex = 0;

            cmb_Summ.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Summ.SelectedIndex = 0;

            cmb_Proc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Proc.SelectedIndex = 0;

            cmb_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Type.SelectedIndex = 0;

        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            double sum=Convert.ToDouble(txt_Summ.Text), proc = Convert.ToDouble(txt_Proc.Text);
            int date= Convert.ToInt32(txt_Date.Text);

            if(cmb_Summ.SelectedIndex == 1) {
                sum *= 60;
            }
            if (cmb_Date.SelectedIndex == 1)
            {
                date *= 12;
            }
            
                Conclusion fr = new Conclusion(sum, proc, date,cmb_Type.SelectedIndex);
            fr.Show();
        }
    }
}
