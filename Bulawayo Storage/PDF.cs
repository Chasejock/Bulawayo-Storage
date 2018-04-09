using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.Data;

namespace Bulawayo_Storage
{
    class PDF
    {
        // Generate Invoice(studnet); this will only be for one student

        // Generate Invoice(payment method);

        // generate invoice(storage period);

        // generate invoice(student, studnet[]); so we can add a range of studnets

        // Generate statement(Date begin, date End); statement for the date ranges


        private static BaseFont f_times = BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        private static BaseFont f_timesb = BaseFont.CreateFont(@"C:\Windows\Fonts\timesbd.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);



        public static void PopulateInvoice(Parent SelectedStudent)
        {

            string InvoiceName = SelectedStudent.Name.ToString() +" "+ SelectedStudent.Surname.ToString() +" "+ SelectedStudent.StoragePeriod.Month.ToString() + SelectedStudent.StoragePeriod.Year.ToString();
            if (File.Exists(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName))
            {
                string Caption = "Already Exists";
                MessageBoxButtons Button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Error;

                if (MessageBox.Show("The Invoice already exists, would you like to view the invoice?", Caption, Button, icon) == DialogResult.Yes)
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName);
                    Process.Start(startinfo);
                }

            }
            else
            {
                FileStream fs = new FileStream(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter pWriter = PdfWriter.GetInstance(document, fs);
                

                document.Open();
                PdfContentByte pContentByte = pWriter.DirectContent;

                PDF.GernerteInvoicePageTemplate(SelectedStudent, pContentByte);
                PDF.WriteLineToTemplate(SelectedStudent, pContentByte, 0);
                PDF.InsertTotalToTemplate(pContentByte, PDF.CalculateTotal(SelectedStudent));

                document.Close();
                pWriter.Close();
                fs.Close();

                string Caption = "Success!";
                MessageBoxButtons Button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;

                if (MessageBox.Show("PDF Succesfully created, would you like to view the PDF?", Caption, Button, icon) == DialogResult.Yes)
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName);
                    Process.Start(startinfo);
                }
            }
        }

        public static void PopulateInvoice(Parent BillerInformation,Parent[] SelectedStudent, DateTime start, DateTime end)
        {
            string InvoiceName;

            InvoiceName = BillerInformation.Name.ToString() + " " + BillerInformation.Surname.ToString() + " " + BillerInformation.MethodOfPayment.ToString() + " " + start.Year.ToString() + " " + start.Month.ToString() + "-" + end.Year.ToString() + " " + end.Month.ToString();

            if (File.Exists(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName))
            {
                string Caption = "Already Exists";
                MessageBoxButtons Button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Error;

                if (MessageBox.Show("The Invoice already exists, would you like to view the invoice?", Caption, Button, icon) == DialogResult.Yes)
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName);
                    Process.Start(startinfo);
                }

            }
            else
            {
                FileStream fs = new FileStream(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter pWriter = PdfWriter.GetInstance(document, fs);


                document.Open();
                PdfContentByte pContentByte = pWriter.DirectContent;

                PDF.GernerteInvoicePageTemplate(BillerInformation, pContentByte);
                int Count = 0;
                foreach (Parent Std in SelectedStudent)
                {
                    if (Count > 32)
                    {
                        document.NewPage();
                        PDF.GernerteInvoicePageTemplate(BillerInformation, pContentByte);
                        Count = 0;
                    }
                    PDF.WriteLineToTemplate(Std, pContentByte, Count);
                    Count++;
                }
                PDF.InsertTotalToTemplate(pContentByte, PDF.CalculateTotal(SelectedStudent));

                document.Close();
                pWriter.Close();
                fs.Close();

                string Caption = "Success!";
                MessageBoxButtons Button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;

                if (MessageBox.Show("PDF Succesfully created, would you like to view the PDF?", Caption, Button, icon) == DialogResult.Yes)
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo(@"C:\Users\Chase charsley\Documents\Visual Studio 2017\Projects\Bulawayo Storage\Bulawayo Storage\Invoices\" + InvoiceName);
                    Process.Start(startinfo);
                }
            }
        }


        private static void WriteLineToTemplate(Parent Pstudent,PdfContentByte Pcb, int Count)
        {
            string Description = Pstudent.Option.ToString() + ", " + Pstudent.Name.ToString() + " " + Pstudent.Surname.ToString() + "," + Pstudent.StoragePeriod.Day.ToString() +"/"+ Pstudent.StoragePeriod.Month.ToString() + "/" + Pstudent.StoragePeriod.Year.ToString();
            string amount;
            Pcb.BeginText();

            // we have to add in a check to see whether the string is too long and exceed the boundry from 40 - 400 which is where amount starts
            if (Count > 32)
            {
                Pcb.EndText();
                throw new IndexOutOfRangeException("The Count is out of range, you need to begin a new page");
            }
            else
            {
                //Description
                Pcb.ShowTextAligned(0, Description, 40, (605 - (Count * 15)), 0);

                //amount 
                if (Pstudent.Option == StorageOption.StorageAndWashing)
                {
                    amount = "$40";
                }
                else
                {
                    amount = "$25";
                }
                Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, amount, 480, (605 - (Count * 15)), 0);
            }

            Pcb.EndText();
        }

        private static void GernerteInvoicePageTemplate(Parent Biller, PdfContentByte Pcb)
        {
            try
            {

                PDF.GenerateHorizontalLines(Pcb);
                PDF.GenerateVirticalLines(Pcb);
                PDF.GenerateTextTemplate(Pcb, Biller);
                PDF.GenerateFooterTemplate(Pcb);

                //Invoice and date
                Pcb.SetFontAndSize(f_times, 12);

                Pcb.BeginText();
                Pcb.SetTextMatrix(385, 735);
                Pcb.ShowText("DATE:" + Biller.StoragePeriod.Day.ToString()+"/"+Biller.StoragePeriod.Month.ToString()+"/"+ Biller.StoragePeriod.Year.ToString());// we will add the date time of the period in a string

                // billing info
                Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "BILLING", 395, 705, 0);
                Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "INFO", 395, 693, 0);

                Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.Name.ToString() + " " + Biller.Surname.ToString(), 405, 705, 0);
                Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.Email.ToString(), 405, 690, 0);

                if (Biller.GaurdianNumber != "")
                {
                    Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.GaurdianNumber.ToString(), 405, 675, 0);
                }
                else if (Biller.Number != "")
                {
                    Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.Number.ToString(), 405, 675, 0);
                }
                else
                {
                    Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.House.ToString(), 405, 675, 0);
                }

                //Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Biller.House.ToString(), 405, 660, 0);

                Pcb.EndText();
            }
            catch (Exception Ex)
            {
                string Caption = "Error";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("Unable to generate Invoice", Caption, Button, icon);
            }
        }

        private static void GenerateTextTemplate(PdfContentByte Pcb,Parent STD)
        {
            Pcb.BeginText();

            Image Logo = Image.GetInstance(@"C:\Users\Chase charsley\Documents\Chase\BULAWAYO STORAGE\logo2.png");
            Logo.ScaleAbsolute(160, 70);
            Logo.SetAbsolutePosition(70, 760);
            Pcb.AddImage(Logo);

            // Top Heading
            Pcb.SetTextMatrix(485, 790);
            Pcb.SetFontAndSize(f_times, 16);
            Pcb.ShowText("INVOICE");
            Pcb.SetFontAndSize(f_times, 12);
            Pcb.ShowTextAligned(2, "INVOICE #: " +STD.Id.ToString(), 160, 735, 0);//  here we will enter the pCode for this student
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "MAILING", 155, 705, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "INFO", 155, 693, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "17 HOLDENGARDE AVE", 165, 705, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HILSIDE", 165, 690, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BULAWAYO", 165, 675, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "+263 (77) 228 2579", 165, 660, 0);
            Pcb.SetFontAndSize(f_times, 16);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESCRIPTION", 180, 625, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "AMOUNT", 495, 625, 0);
            Pcb.EndText();
        }

        private static void GenerateVirticalLines(PdfContentByte Pcb)
        {
            Pcb.SetLineWidth(0.75);
            Pcb.MoveTo(160, 720);
            Pcb.LineTo(160, 650);
            Pcb.Stroke();

            Pcb.SetLineWidth(0.75);
            Pcb.MoveTo(400, 720);
            Pcb.LineTo(400, 650);
            Pcb.Stroke();

            Pcb.SetLineWidth(0.5);
            Pcb.MoveTo(400, 620);
            Pcb.LineTo(400, 53);
            Pcb.Stroke();
        }

        private static void GenerateHorizontalLines(PdfContentByte Pcb)
        {
            Pcb.SetLineWidth(0.5);
            Pcb.MoveTo(30, 750);
            Pcb.LineTo(565, 750);
            Pcb.Stroke();

            Pcb.MoveTo(30, 620);
            Pcb.LineTo(565, 620);
            Pcb.Stroke();

            Pcb.MoveTo(30, 100);
            Pcb.LineTo(565, 100);
            Pcb.Stroke();
        }

        private static void GenerateFooterTemplate(PdfContentByte Pcb)
        {
            Pcb.BeginText();
            Pcb.SetFontAndSize(f_times, 10);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BANK:\t NEDBANK", 50, 88, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ACC:\t 71016020159", 50, 76, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BRANCH:\t 18305", 50, 64, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SWIFT:\t MBCAZWHX", 50, 52, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ECOCASH:\t+263 77 228 2579", 50, 28, 0);
            Pcb.EndText();
        }

        private static void InsertTotalToTemplate(PdfContentByte Pcb, double total)
        {// because we do not want to insert it in every page.
            Pcb.BeginText();
            Pcb.SetFontAndSize(f_timesb, 12);
            Pcb.ShowTextAligned(2, "SUBTOTAL:", 400, 88, 0);
            Pcb.ShowTextAligned(2, "TAXES:", 400, 72, 0);
            Pcb.ShowTextAligned(2, "TOTAL:", 400, 55, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$"+ total.ToString("0.00"), 480, 88, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0.00 %", 480, 72, 0);
            Pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$"+total.ToString("0.00"), 480, 55, 0);
            Pcb.EndText();

            Pcb.SetLineDash(5, 2.5);
            Pcb.MoveTo(400, 83);
            Pcb.LineTo(565, 83);
            Pcb.Stroke();

            Pcb.MoveTo(400, 68);
            Pcb.LineTo(565, 68);
            Pcb.Stroke();

            Pcb.MoveTo(400, 53);
            Pcb.LineTo(565, 53);
            Pcb.Stroke();
        }


        private static double CalculateTotal(Parent sto)
        {
            int total = 0;

            if (sto.Option == StorageOption.Storage)
            {
                total = 25;
            }
            else
            {
                total = 40;
            }
            return total;
        }

        private static double CalculateTotal(Parent[] StudentArray)
        {// when we have mutiple students
            int total = 0;

            foreach (Parent st in StudentArray)
            {
                if (st.Option == StorageOption.Storage)
                {
                    total += 25;
                }
                else
                {
                    total += 40;
                }

            }

            return total;
        }





    }
}
