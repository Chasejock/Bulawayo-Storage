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
using ExcelDataReader;

namespace Bulawayo_Storage
{
    public partial class AddStudent : Form
    {
        

        public AddStudent()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime start = new DateTime(2016, 1, 1);
            cbx_House.Items.Add("--Select One--");
            foreach (var item in Enum.GetValues(typeof(FalconCollegeHouse)))
            {
                cbx_House.Items.Add(item);
            }

            cbx_StorageOption.Items.Add("--Select One--");
            foreach (var option in Enum.GetValues(typeof(StorageOption)))
            {
                cbx_StorageOption.Items.Add(option);
            }

            cbx_MethodPayment.Items.Add("--Select One--");
            foreach (var Method in Enum.GetValues(typeof(MethodOfPayment)))
            {
                cbx_MethodPayment.Items.Add(Method);
            }

            cbx_Month.Items.Add("--Select One--");
            cbx_Month.Items.Add("April");
            cbx_Month.Items.Add("August");
            cbx_Month.Items.Add("December");

            for (DateTime Current = start; Current < DateTime.Now; Current = Current.AddYears(1))
            {
                cbx_Year.Items.Add(Current.Year);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_Name.Text == "" || tbx_Surname.Text == "" || tbx_Email.Text == "" || tbx_NumTrunks.Text == "" || cbx_Year.Text == "" || cbx_Month.Text == ""||cbx_Year.Text.Equals("--Select One--")||cbx_Year.Text.Equals("--Select One--"))
                {
                    throw new ArgumentNullException("Please complete all the details!");
                }
                else if (cbx_House.SelectedItem == null || cbx_MethodPayment.SelectedItem == null || cbx_StorageOption.SelectedItem == null || cbx_House.SelectedItem.Equals("--Select One--") || cbx_MethodPayment.SelectedItem.Equals("--Select One--") || cbx_StorageOption.SelectedItem.Equals("--Select One--"))
                {
                    throw new ArgumentNullException("Please complete all the details!");
                }
                else
                {
                    Parent FalconCollegeStudent = new Parent();
                    int month = 0;

                    if (cbx_Month.SelectedIndex == 1)
                    {
                        month = 4;  
                    }
                    else if (cbx_Month.SelectedIndex == 2)
                    {
                        month = 8;
                    }
                    else if (cbx_Month.SelectedIndex == 3)
                    {
                        month = 12;
                    }
                    DateTime Period = new DateTime(Convert.ToInt32(cbx_Year.SelectedItem), month, 1);

                    // have to add an exception for if tryparse fails for the trunks because this number is added by the user
                    try
                    {
                        FalconCollegeStudent.Name = tbx_Name.Text;
                        FalconCollegeStudent.Surname = tbx_Surname.Text;
                        FalconCollegeStudent.House = (FalconCollegeHouse)cbx_House.SelectedIndex - 1;
                        FalconCollegeStudent.Email = tbx_Email.Text;
                        FalconCollegeStudent.Number = tbx_Number.Text.ToString();
                        FalconCollegeStudent.GaurdianNumber = tbx_GaurdianNumber.Text.ToString();
                        FalconCollegeStudent.Trunks = Convert.ToInt32(tbx_NumTrunks.Text);
                        // there is an issue with the index here, we have to figure out how to read it in properly
                        FalconCollegeStudent.Option = (StorageOption)cbx_StorageOption.SelectedIndex - 1;
                        FalconCollegeStudent.MethodOfPayment = (MethodOfPayment)cbx_MethodPayment.SelectedIndex - 1;
                        FalconCollegeStudent.StoragePeriod = Period;

                        DAL Data = new DAL();
                        Data.QInsertStudent(FalconCollegeStudent);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                        throw new Exception("Unable to complete subject data error in information", ex.InnerException);
                    }

                    string Caption = "Success";
                    MessageBoxButtons Button = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.None;
                    MessageBox.Show("Student Successfully Added To Database!", Caption, Button, icon);

                    ClearDisplayBoxes();
                }


            } catch (Exception ArgNullException)
            {
                string Caption = "Information Required";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(ArgNullException.Message, Caption, Button, icon);
            }
        }

        private void AddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_SerDbBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ClearDisplayBoxes()
        {
            tbx_Name.Clear();
            tbx_Surname.Clear();
            tbx_Number.Clear();
            tbx_Email.Clear();
            tbx_GaurdianNumber.Clear();
            tbx_NumTrunks.Clear();
            cbx_House.SelectedItem = -1;
            cbx_MethodPayment.SelectedItem = -1;
            cbx_Month.SelectedItem = -1;
            cbx_StorageOption.SelectedItem = -1;
            cbx_Year.SelectedItem = -1;
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OPFD = new OpenFileDialog();
                if (OPFD.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(OPFD.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader ExcelReader;
                    var file = new FileInfo(OPFD.FileName);
                    if (file.Extension.Equals(".xls"))
                    {
                        ExcelReader = ExcelReaderFactory.CreateBinaryReader(fs);
                    }
                    else if (file.Extension.Equals(".xlsx"))
                    {
                        ExcelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    }
                    else
                    {
                        throw new Exception("Invalid File Name");
                    }
                    var Config = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }

                    };

                    DataSet ds = ExcelReader.AsDataSet(Config);
                    ExcelReader.Close();
                    ExcelReader.Dispose();
                    fs.Close();
                    fs.Dispose();
                    OPFD.Dispose();
                    foreach (DataTable ThisTable in ds.Tables)
                    {
                        foreach (DataRow row in ThisTable.Rows)
                        {
                            // here we create the student object becaue this is where we will 
                            object[] StudentInfo_Excel = row.ItemArray;
                            SortDataFromExcelForStudent(StudentInfo_Excel);
                            // then we will add the students to the database.
                        }
                    }
                    string Caption = "Success";
                    MessageBoxButtons Button = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.None;
                    MessageBox.Show("Students Successfully Added To Database!", Caption, Button, icon);
                }
            }
            catch (Exception ex)
            {
                string caption = "File Not Found";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(ex.Message, caption, Button, icon);
            }
        }



        private void SortDataFromExcelForStudent(object[] StudentInfo_ExcelRow)
        {
            Parent addedStudent = new Parent();
            DAL Data = new DAL();

            try
            {
                DateTime strSubmittedTime = (DateTime)StudentInfo_ExcelRow[0];
                string strName = (string)StudentInfo_ExcelRow[1];
                string strSurName = (string)StudentInfo_ExcelRow[2];
                string strGuardianNumber = StudentInfo_ExcelRow[3].ToString();
                string stringNumTrunks = (string)StudentInfo_ExcelRow[4];
                string strStorageOption = (string)StudentInfo_ExcelRow[5];
                string strPaymentMethod = (string)StudentInfo_ExcelRow[6];
                string strHouse = (string)StudentInfo_ExcelRow[7];
                string strNumber = StudentInfo_ExcelRow[8].ToString();
                string strEmail = (string)StudentInfo_ExcelRow[9];

                // sorted date time
                if (strSubmittedTime.Month <= 4)
                {
                    DateTime SubmitedTime = new DateTime(strSubmittedTime.Year, 4, 1);
                    addedStudent.StoragePeriod = SubmitedTime;
                }
                else if (strSubmittedTime.Month <= 8)
                {
                    DateTime SubmitedTime = new DateTime(strSubmittedTime.Year, 8, 1);
                    addedStudent.StoragePeriod = SubmitedTime;
                }
                else if (strSubmittedTime.Month <= 12)
                {
                    DateTime SubmitedTime = new DateTime(strSubmittedTime.Year, 12, 1);
                    addedStudent.StoragePeriod = SubmitedTime;
                }

                //Name check for &
                if (strName.Contains("&"))
                {
                    strName = strName.Replace(" ","");
                    int index = strName.IndexOf("&");
                    string FirtPerson = strName.Remove(index);

                    string ExtraPerson = strName.Remove(0, index + 1);

                    object[] NewPerson = { strSubmittedTime, ExtraPerson, strSurName, strGuardianNumber, stringNumTrunks, strStorageOption, strPaymentMethod, strHouse, strNumber, strEmail };
                    SortDataFromExcelForStudent(NewPerson);
                    addedStudent.Name = FirtPerson;
                }
                else
                {
                    addedStudent.Name = strName;
                }


                //Number of trunks
                stringNumTrunks = stringNumTrunks.Remove(1);// removing any excess information 
                int NumTrunks = Convert.ToInt32(stringNumTrunks);


                //stroage option convertion 
                strStorageOption = strStorageOption.ToLower();
                if (strStorageOption.Contains("washing"))
                {
                    StorageOption StorageOpt = StorageOption.StorageAndWashing;
                    addedStudent.Option = StorageOpt;
                }
                else if (strStorageOption.Contains("only"))
                {
                    StorageOption StorageOpt = StorageOption.Storage;
                    addedStudent.Option = StorageOpt;
                }

                //payment Method
                strPaymentMethod = strPaymentMethod.ToLower();
                if (strPaymentMethod.Contains("cash"))
                {
                    MethodOfPayment PaymentMethod = MethodOfPayment.Cash;
                    addedStudent.MethodOfPayment = PaymentMethod;
                }
                else if (strPaymentMethod.Contains("eco"))
                {
                    MethodOfPayment PaymentMethod = MethodOfPayment.EcoCash;
                    addedStudent.MethodOfPayment = PaymentMethod;
                }
                else if (strPaymentMethod.Contains("student"))
                {
                    MethodOfPayment PaymentMethod = MethodOfPayment.StudentAccount;
                    addedStudent.MethodOfPayment = PaymentMethod;
                }
                else if (strPaymentMethod.Contains("bank"))
                {
                    MethodOfPayment PaymentMethod = MethodOfPayment.BankTransfer;
                    addedStudent.MethodOfPayment = PaymentMethod;
                }

                //student house

                strHouse = strHouse.ToLower();
                if (strHouse.Contains("founders"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.Founders;
                    addedStudent.House = House;
                }
                else if (strHouse.Contains("george"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.GeorgeGrey;
                    addedStudent.House = House;
                }
                else if (strHouse.Contains("hervey"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.Hervey;
                    addedStudent.House = House;
                }
                else if (strHouse.Contains("oates"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.Oates;
                    addedStudent.House = House;
                }
                else if (strHouse.Contains("tredgold"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.Tredgold;
                    addedStudent.House = House;
                }
                else if (strHouse.Contains("chubb"))
                {
                    FalconCollegeHouse House = FalconCollegeHouse.Chubb;
                    addedStudent.House = House;
                }

                addedStudent.Email = strEmail;
                addedStudent.Trunks = NumTrunks;
                addedStudent.Number = strNumber;
                addedStudent.GaurdianNumber = strGuardianNumber;
                addedStudent.Surname = strSurName;
            }
            catch (Exception ex)
            {
                string caption = "Error Adding Student";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(ex.Message, caption, Button, icon);
            }

            
            Data.QInsertStudent(addedStudent);

        }

    }
}
