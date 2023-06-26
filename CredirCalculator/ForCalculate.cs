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
        double CreditAmount;
        int CreditPeriod;
        public double CreditRate
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
            CreditAmount = creditAmount;
            CreditRate = creditRate;
            CreditPeriod = creditPeriod;

        }

        private double _credYear;
        private double _credMonth;

        private string _sumMonthPay;
        private string _sumCredAmount;
        private string _sumOverPay;

        public DataGridView ANNUT(DataGridView dtg)
        {
            DataGridView dtgOver = dtg;

            double monthPay = CreditAmount * (_credMonth / (1 - Math.Pow(1 + _credMonth, -CreditPeriod))); 
            double sumCredAm = monthPay * CreditPeriod; 

            _sumMonthPay = monthPay.ToString("N2"); 
            _sumCredAmount = sumCredAm.ToString("N2"); 

            double tempCreditAmount = CreditAmount;
            double tempSummaryCreditAmount = sumCredAm;
            double tempItogPlus = 0;

            for (int i = 1; i <= CreditPeriod; i++)
            {

                double percent = tempCreditAmount * _credMonth;
                tempCreditAmount -= monthPay - percent;
                tempSummaryCreditAmount -= monthPay;

                if (i == CreditPeriod) tempItogPlus = tempCreditAmount;
                dtgOver.Rows.Add(i, monthPay, monthPay - percent, percent, tempCreditAmount);
            }

            _sumOverPay = (sumCredAm - CreditAmount + tempItogPlus).ToString("N2"); 
            return dtgOver;
        }
        public DataGridView DIFF(DataGridView dtg)
        {
            DataGridView dtShedule = dtg;

            double mainPayment = CreditAmount / CreditPeriod;
            double summaryCreditAmount = 0;
            double summaryOverPayment = 0;
            double tempCreditAmount = CreditAmount;
            double itogPlus = 0;

            for (int i = 1; i <= CreditPeriod; i++)
            {
               
                double percent = tempCreditAmount * _credMonth;
                double monthlyPayment = mainPayment + percent;
                summaryCreditAmount += monthlyPayment;
                summaryOverPayment += percent;
                tempCreditAmount -= mainPayment;

                dtShedule.Rows.Add(i, monthlyPayment, mainPayment, percent, tempCreditAmount);

                if (i == 1) _sumMonthPay = monthlyPayment.ToString("N2") + "...";
                if (i == CreditPeriod)
                {
                    _sumMonthPay += monthlyPayment.ToString("N2");
                    itogPlus += tempCreditAmount;
                }
            }

            _sumCredAmount = summaryCreditAmount.ToString("N2");
            _sumOverPay = (summaryOverPayment + itogPlus).ToString("N2");




            return dtShedule;
        }

    }
}

