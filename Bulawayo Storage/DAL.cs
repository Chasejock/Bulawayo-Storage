using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulawayo_Storage
{
    class DAL
    {
        SqlConnection conn = new SqlConnection("Server = (local)\\SQLEXPRESS; Database = BulawayoStorage; Trusted_Connection = True");

        public DataSet QAllClients()
        {
            DataSet DS = new DataSet();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "QAllClients";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(DS);
            conn.Close();
            conn.Dispose();
            return DS;
        }

        public void QInsertStudent(Parent FCS)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "QInsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;

                //Parameters
                cmd.Parameters.AddWithValue("@fcsStudentName", FCS.Name);
                cmd.Parameters.AddWithValue("@fcsStudentSurname", FCS.Surname);
                cmd.Parameters.AddWithValue("@fcsHouse", FCS.House.ToString());
                cmd.Parameters.AddWithValue("@fcsEmail", FCS.Email);
                cmd.Parameters.AddWithValue("@fcsNumber", FCS.Number);
                cmd.Parameters.AddWithValue("@fcsGuardianNumber", FCS.GaurdianNumber);
                cmd.Parameters.AddWithValue("@fcsNumberofTrunks", FCS.Trunks);
                cmd.Parameters.AddWithValue("@fcsOption", FCS.Option.ToString());
                cmd.Parameters.AddWithValue("@fcsPaymentMethod", FCS.MethodOfPayment.ToString());
                cmd.Parameters.AddWithValue("@fcsStoragePeriod", FCS.StoragePeriod);
                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private int getpcodevalue()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select max(pcode) from tfalconcollegestudent", conn);
                int fcscode = (int)cmd.ExecuteScalar();
                return fcscode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }











    }
}
