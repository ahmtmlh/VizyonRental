using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.DataAccess
{
    public class Card_InfoDAO
    {
        public static List<Card_InfoEntity> getAllCards()
        {
            string selectCards = "SELECT * FROM Card_Info";
            List<Card_InfoEntity> list = null;

            SqlCommand com = new SqlCommand(selectCards, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<Card_InfoEntity>();
                while (read.Read())
                {
                    list.Add(new Card_InfoEntity
                    {
                        card_Number = read["card_Number"].ToString(),
                        expression_date = Convert.ToDateTime(read["expression_date"]),
                        card_user_name = read["card_user_name"].ToString(),
                        type = read["type"].ToString()
                    });
                }
            }
            //Close current connection
            com.Dispose();
            com.Connection.Close();
            return list;
        }

        public static Card_InfoEntity getCardByNumber(string card_Number)
        {
            Card_InfoEntity result = null;
            string sqlCommand = "SELECT * FROM Card_Info WHERE card_Number = " + card_Number;

            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            //If customer is found in the table
            if (read.HasRows)
            {
                read.Read();
                //Fill the CustomerEntity object from the table
                result = new Card_InfoEntity
                {
                    card_Number = read["card_Number"].ToString(),
                    expression_date = Convert.ToDateTime(read["expression_date"]),
                    card_user_name = read["card_user_name"].ToString(),
                    type = read["type"].ToString()                    
                };
            }
            //Close connection and return found value. If no value found, return null
            com.Dispose();
            com.Connection.Close();
            return result;
        }

        public static int addCard(string card_Number, DateTime expression_date, string card_user_name, string type)
        {
            string sqlCommand = String.Format("INSERT INTO Card_Info(card_Number, expression_date, card_user_name, type) VALUES('{0}', '{1}', '{2}', '{3}')",
                                            card_Number, expression_date.ToString("yyyy-MM-dd"),card_user_name,type);
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            try
            {
                result = com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = -1;
            }
            finally
            {
                //Close connection
                com.Dispose();
                com.Connection.Close();
            }
            return result;
        }

        public static int deleteCard(string card_Number)
        {
            string sqlCommand = "DELETE FROM Card_Info WHERE card_Number = " + card_Number;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            //No error handling is required in case of deletion. 
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }

    }
}
