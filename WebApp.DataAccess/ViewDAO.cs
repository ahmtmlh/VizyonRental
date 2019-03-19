using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class ViewDAO
    {
        public static DataSet getReservationViewDataSet()
        {
            string sqlCommand = "SELECT * FROM View_ReservationInfo";
            return generateDataSet(sqlCommand, "View_ReservationInfo");
        }
        public static DataSet getRentViewDataSet()
        {
            string sqlCommand = "SELECT * FROM View_RentInfo";
            return generateDataSet(sqlCommand, "View_RentInfo");
        }
        public static DataSet getCustomerViewDataSet()
        {
            string sqlCommand = "SELECT * FROM View_CustomerLoginInfo";
            return generateDataSet(sqlCommand, "View_CustomerLoginInfo");
            
        }
        public static DataSet getManagerViewDataSet()
        {
            string sqlCommand = "SELECT * FROM View_ManagerLoginInfo";
            return generateDataSet(sqlCommand, "View_ManagerLoginInfo");
        }
        public static DataSet getBillViewDataSet()
        {
            string sqlCommand = "SELECT * FROM View_BillInfo";
            return generateDataSet(sqlCommand, "View_BillInfo");
        }
        /**
         * This function is created due to reuse purposes, since this code is happening for every view
         * It is packed into one private function. 
         */
        private static DataSet generateDataSet(string sqlCommand, string view_name)
        {
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataAdapter db = new SqlDataAdapter(com);
            DataSet data = new DataSet();
            db.Fill(data, view_name);
            com.Dispose();
            com.Connection.Close();
            return data;
        }
    }
}
