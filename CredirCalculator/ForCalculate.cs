using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CredirCalculator
{
    public class ForCalculate
    {
        double creddAmm;
        int credPeiod;
        public double credRated
        {
            get
            {
                return _credYear * 100;
            }
            set
            {
                _credYear = value / 100;
                _credMonth = value / 100 / 12;
            }
        }

        public ForCalculate(double creditAmount, double creditRate, int creditPeriod)
        {
            creddAmm = creditAmount;
            credRated = creditRate;
            credPeiod = creditPeriod;

        }

        private double _credYear;
        private double _credMonth;

        private string _sumMonthPay;
        private string _sumCredAmount;
        private string _sumOverPay; // ДЛЯ ДИФФ

        public DataGridView ANNUT(DataGridView dtg)
        {
            DataGridView dtgOver = dtg;

            double monthPay = creddAmm * (_credMonth / (1 - Math.Pow(1 + _credMonth, -credPeiod))); 
            double sumCredAm = monthPay * credPeiod; 
            double tempCreditAmount = creddAmm;
            double tempSummaryCreditAmount = sumCredAm;
            double tempItogPlus = 0;

            for (int i = 1; i <= credPeiod; i++)
            {

                double percent = tempCreditAmount * _credMonth;
                tempCreditAmount -= monthPay - percent;
                tempSummaryCreditAmount -= monthPay;

                if (i == credPeiod) tempItogPlus = tempCreditAmount;
                dtgOver.Rows.Add(i, monthPay, monthPay - percent, percent, tempCreditAmount);
            }

            
            return dtgOver;
        }
        public DataGridView DIFF(DataGridView dtg)
        {
            DataGridView dtgOver = dtg;

            double mainPayment = creddAmm / credPeiod;
            double sumcred = 0;
            double sumover = 0;
            double tmpcredam = creddAmm;
            double itogPlus = 0;

            for (int i = 1; i <= credPeiod; i++)
            {
               
                double percent = tmpcredam * _credMonth;
                double monthlyPayment = mainPayment + percent;
                sumcred += monthlyPayment;
                sumover += percent;
                tmpcredam -= mainPayment;

                dtgOver.Rows.Add(i, monthlyPayment, mainPayment, percent, tmpcredam);

                if (i == 1) _sumMonthPay = monthlyPayment.ToString();
                if (i == credPeiod)
                {
                    _sumMonthPay += monthlyPayment.ToString();
                    itogPlus += tmpcredam;
                }
            }

            _sumCredAmount = sumcred.ToString();
            _sumOverPay = (sumover + itogPlus).ToString();




            return dtgOver;
        }

    }
}

