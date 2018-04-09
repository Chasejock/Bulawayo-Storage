using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulawayo_Storage
{
    public partial class GenerateInvoiceBasedOnCriteria : Form
    {
        public GenerateInvoiceBasedOnCriteria()
        {
            InitializeComponent();
        }

        private void GenerateInvoiceBasedOnCriteria_Load(object sender, EventArgs e)
        {
            DateTime start = new DateTime(2016, 1, 1);
            string[] month = {"April","August","December" };
            cbx_BasedOn.Items.Add("--Select One--");
            cbx_BasedOn.Items.Add("Storage and Washing");
            cbx_BasedOn.Items.Add("Storage");
            cbx_BasedOn.Items.Add("Cash");
            cbx_BasedOn.Items.Add("Ecocash");
            cbx_BasedOn.Items.Add("Bank Transfer");
            cbx_BasedOn.Items.Add("student account");
            cbx_BasedOn.Items.Add("Storage Period");

            cbx_ToPeriod.Items.Add("--Select One--");
            cbx_FromPeriod.Items.Add("-Select One-");
            for (DateTime Current = start; Current < DateTime.Now; Current = Current.AddMonths(1))
            {
                if (Current.Month == 4 || Current.Month == 8 || Current.Month == 12)
                {
                    if (Current.Month == 4)
                    {
                        cbx_FromPeriod.Items.Add(Current.Year + " " + month[0]);
                        cbx_ToPeriod.Items.Add(Current.Year + " " + month[0]);
                    }
                    else if (Current.Month == 8)
                    {
                        cbx_FromPeriod.Items.Add(Current.Year + " " + month[1]);
                        cbx_ToPeriod.Items.Add(Current.Year + " " + month[1]);
                    }
                    else if (Current.Month == 12)
                    {
                        cbx_FromPeriod.Items.Add(Current.Year + " " + month[2]);
                        cbx_ToPeriod.Items.Add(Current.Year + " " + month[2]);
                    }
                }
            }
        }

        private void btn_GenInvBack_Click(object sender, EventArgs e)
        {
            SearchDataBase SearDb = new SearchDataBase();
            SearDb.Show();
            this.Hide();
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {
            int Imonth;
            Parent BillerInfo = new Parent();
            DataTable DT = new DataTable();
            SearchDataBase searcDB = new SearchDataBase();

            if (tbx_NameBillerInfo.Text == "" || tbx_SurnameBillerInfo.Text == "" || tbx_EmailBillerInfo.Text == "" || tbx_NumberBillerInfo.Text == "" || cbx_BasedOn.SelectedItem == null || cbx_FromPeriod.SelectedItem == null || cbx_ToPeriod.SelectedItem == null)
            {
                string Caption = "Information Required";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("You have to complete all the information", Caption, Button, icon);

            }
            else
            {
                string toperiod = cbx_ToPeriod.SelectedItem.ToString();
                toperiod = toperiod.ToLower();
                if (toperiod.Contains("april"))
                {
                    Imonth = 4;
                }
                else if (toperiod.Contains("august"))
                {
                    Imonth = 8;
                }
                else
                {
                    Imonth = 12;
                }
                string year = toperiod.Remove(4);
                int Iyear = Convert.ToInt32(year);
                int day = 1;
                DateTime ToPeriod = new DateTime(Iyear, Imonth, day);


                string fromperiod = cbx_FromPeriod.SelectedItem.ToString();

                fromperiod = fromperiod.ToLower();
                if (fromperiod.Contains("april"))
                {
                    Imonth = 4;
                }
                else if (fromperiod.Contains("august"))
                {
                    Imonth = 8;
                }
                else
                {
                    Imonth = 12;
                }

                year = fromperiod.Remove(4);
                Iyear = Convert.ToInt32(year);

                DateTime FromPeriod = new DateTime(Iyear, Imonth, day);

                BillerInfo.StoragePeriod = ToPeriod;
                BillerInfo.Name = tbx_NameBillerInfo.Text.ToString();
                BillerInfo.Surname = tbx_SurnameBillerInfo.Text.ToString();
                BillerInfo.Email = tbx_EmailBillerInfo.Text.ToString();
                BillerInfo.GaurdianNumber = tbx_NumberBillerInfo.Text.ToString();

                switch (cbx_BasedOn.SelectedIndex)
                {
                    case 0:
                        string Caption = "Information Required";
                        MessageBoxButtons Button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show("Please Select a Basis to search on", Caption, Button, icon);
                        break;
                    case 1:
                        DT = searcDB.SortBasedOn(StorageOption.StorageAndWashing, FromPeriod, ToPeriod);
                        BillerInfo.Option = StorageOption.StorageAndWashing;
                        break;
                    case 2:
                        DT = searcDB.SortBasedOn(StorageOption.Storage, FromPeriod, ToPeriod);
                        BillerInfo.Option = StorageOption.Storage;
                        break;
                    case 3:
                        DT = searcDB.SortBasedOn(MethodOfPayment.Cash, FromPeriod, ToPeriod);
                        BillerInfo.MethodOfPayment = MethodOfPayment.Cash;
                        break;
                    case 4:
                        DT = searcDB.SortBasedOn(MethodOfPayment.EcoCash, FromPeriod, ToPeriod);
                        BillerInfo.MethodOfPayment = MethodOfPayment.EcoCash;
                        break;
                    case 5:
                        DT = searcDB.SortBasedOn(MethodOfPayment.BankTransfer, FromPeriod, ToPeriod);
                        BillerInfo.MethodOfPayment = MethodOfPayment.StudentAccount;
                        break;
                    case 6:
                        DT = searcDB.SortBasedOn(MethodOfPayment.StudentAccount, FromPeriod, ToPeriod);
                        BillerInfo.MethodOfPayment = MethodOfPayment.StudentAccount;
                        break;
                    case 7:
                        DT = searcDB.SortBasedOn(FromPeriod, ToPeriod);
                        break;
                    default:
                        throw new Exception("Error while selcting a basis to search on");
                }


                Parent[] StudentArray = new Parent[DT.Rows.Count];

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    StudentArray[i] = SearchDataBase.SortDataGridVeiwToParentClass(DT.Rows[i]);
                }
                PDF.PopulateInvoice(BillerInfo, StudentArray, FromPeriod, ToPeriod);

                this.Hide();

            }
        }

        private void GenerateInvoiceBasedOnCriteria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
