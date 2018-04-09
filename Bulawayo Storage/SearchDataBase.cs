using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulawayo_Storage
{
    public partial class SearchDataBase : Form
    {
        public SearchDataBase()
        {
            InitializeComponent();
        }

        DAL data = new DAL();
        public static DataSet DS_QAllClients = new DataSet();

        private void SearchDataBase_Load(object sender, EventArgs e)
        {
            DS_QAllClients = data.QAllClients();
            dgv_Students.DataSource = DS_QAllClients.Tables[0];
        }

        private void btn_SerDbBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void SearchDataBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tbx_Search_KeyPress(object sender, EventArgs e)
        {
            DataView dv = DS_QAllClients.Tables[0].DefaultView;
            dv.RowFilter = string.Format("pStudentName like '%{0}%'", tbx_Search.Text);
            dgv_Students.DataSource = dv.ToTable();

            if (dgv_Students.Rows.Count == 0)
            {
                dv.RowFilter = string.Format("pStudentSurname like '%{0}%'", tbx_Search.Text);
                dgv_Students.DataSource = dv.ToTable();
                if (dgv_Students.Rows.Count == 0)
                {
                    dv.RowFilter = string.Format("pHouse like '%{0}%'", tbx_Search.Text);
                    dgv_Students.DataSource = dv.ToTable();
                    if (dgv_Students.Rows.Count == 0)
                    {
                        dv.RowFilter = string.Format("pOption like '%{0}%'", tbx_Search.Text);
                        dgv_Students.DataSource = dv.ToTable();

                        if (dgv_Students.Rows.Count == 0)
                        {
                            dv.RowFilter = string.Format("pPaymentMethod like '%{0}%'", tbx_Search.Text);
                            dgv_Students.DataSource = dv.ToTable();
                        }
                    }
                }
            }
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {
            GenerateInvoiceBasedOnCriteria GIBOC = new GenerateInvoiceBasedOnCriteria();
            GIBOC.Show();
            
            this.Hide();
        }

        private void dgv_Students_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Caption = "Attention";
            MessageBoxButtons Button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            string FullName = DS_QAllClients.Tables[0].Rows[e.RowIndex]["pStudentName"].ToString() + " "+ DS_QAllClients.Tables[0].Rows[e.RowIndex]["pStudentName"].ToString();

            if (MessageBox.Show("Would you like to create and invoive for " + FullName, Caption, Button, icon) == DialogResult.Yes)
            {
                DataRow Row = DS_QAllClients.Tables[0].Rows[e.RowIndex];
                Parent Student = new Parent();
                PDF.PopulateInvoice(SortDataGridVeiwToParentClass(Row));
            }
        }


        public static Parent SortDataGridVeiwToParentClass(DataRow Row)
        {
            Parent ConStudent = new Bulawayo_Storage.Parent();

            int strId = (int)Row.ItemArray[0];
            string strName = (string)Row.ItemArray[1];
            string strSurName = (string)Row.ItemArray[2];
            string strHouse = (string)Row.ItemArray[3];
            string strEmail = (string)Row.ItemArray[4];
            string strNumber = (string)Row.ItemArray[5];
            string strGuardianNumber = (string)Row.ItemArray[6];
            int stringNumTrunks = (int)Row.ItemArray[7];
            string strStorageOption = (string)Row.ItemArray[8];
            string strPaymentMethod = (string)Row.ItemArray[9];
            DateTime period = (DateTime)Row.ItemArray[10];

            ConStudent.Id = strId;
            ConStudent.Name = strName;
            ConStudent.Surname = strSurName;

            strHouse = strHouse.ToLower();
            if (strHouse.Contains("founders"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.Founders;
                ConStudent.House = House;
            }
            else if (strHouse.Contains("george"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.GeorgeGrey;
                ConStudent.House = House;
            }
            else if (strHouse.Contains("hervey"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.Hervey;
                ConStudent.House = House;
            }
            else if (strHouse.Contains("oates"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.Oates;
                ConStudent.House = House;
            }
            else if (strHouse.Contains("tredgold"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.Tredgold;
                ConStudent.House = House;
            }
            else if (strHouse.Contains("chubb"))
            {
                FalconCollegeHouse House = FalconCollegeHouse.Chubb;
                ConStudent.House = House;
            }

            ConStudent.Email = strEmail;
            ConStudent.Number = strNumber;
            ConStudent.GaurdianNumber = strGuardianNumber;
            ConStudent.Trunks = stringNumTrunks;

            strStorageOption = strStorageOption.ToLower();
            if (strStorageOption.Contains("washing"))
            {
                StorageOption StorageOpt = StorageOption.StorageAndWashing;
                ConStudent.Option = StorageOpt;
            }
            else if (strStorageOption.Contains("only"))
            {
                StorageOption StorageOpt = StorageOption.Storage;
                ConStudent.Option = StorageOpt;
            }

            strPaymentMethod = strPaymentMethod.ToLower();
            if (strPaymentMethod.Contains("cash"))
            {
                MethodOfPayment PaymentMethod = MethodOfPayment.Cash;
                ConStudent.MethodOfPayment = PaymentMethod;
            }
            else if (strPaymentMethod.Contains("eco"))
            {
                MethodOfPayment PaymentMethod = MethodOfPayment.EcoCash;
                ConStudent.MethodOfPayment = PaymentMethod;
            }
            else if (strPaymentMethod.Contains("student"))
            {
                MethodOfPayment PaymentMethod = MethodOfPayment.StudentAccount;
                ConStudent.MethodOfPayment = PaymentMethod;
            }
            else if (strPaymentMethod.Contains("bank"))
            {
                MethodOfPayment PaymentMethod = MethodOfPayment.BankTransfer;
                ConStudent.MethodOfPayment = PaymentMethod;
            }

            ConStudent.StoragePeriod = period;

            return ConStudent;
        }


        public DataTable SortBasedOn(MethodOfPayment MOP, DateTime start, DateTime end)
        {
            DataView dv_Period = DS_QAllClients.Tables[0].DefaultView;

            if (start <= end)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#' AND pPaymentMethod like '%{2}%' ", start.ToString(), end.ToString(), MOP.ToString());
            } else if (end <= start)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#' AND pPaymentMethod like '%{2}%' ", end.ToString(), start.ToString(), MOP.ToString());
            }
            DataTable DT = dv_Period.ToTable();

            return DT;
        }


        public DataTable SortBasedOn(StorageOption StoOp,DateTime start, DateTime end)
        {
            DataView dv_Period = DS_QAllClients.Tables[0].DefaultView;

            if (start <= end)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#' AND pOption like '%{2}%' ", start.ToString(), end.ToString(), StoOp.ToString());
            }
            else if (end <= start)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#' AND pOption like '%{2}%' ", end.ToString(), start.ToString(), StoOp.ToString());
            }
            DataTable DT = dv_Period.ToTable();

            return DT;
        }


        public DataTable SortBasedOn(DateTime start, DateTime end)
        {
            DataView dv_Period = DS_QAllClients.Tables[0].DefaultView;

            if (start <= end)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#'", start.ToString(), end.ToString());
            }
            else if (end <= start)
            {
                dv_Period.RowFilter = string.Format("pStoragePeriod >= '#{0}#' AND pStoragePeriod <= '#{1}#'", end.ToString(), start.ToString());
            }
            DataTable DT = dv_Period.ToTable();

            return DT;
        }
    }
}
