using System;
using System.Collections.Generic;
using WebApp.DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Business
{
    public class Card_Info
    {
        public static List<Card_InfoEntity> getAllCards()
        {
            return Card_InfoDAO.getAllCards();
        }
        public static Card_InfoEntity getCardByNumber(string card_Number)
        {
            return Card_InfoDAO.getCardByNumber(card_Number);
        }

        public static int addCard(string card_Number, DateTime expression_date, string card_user_name, string type)
        {
            int result = Card_InfoDAO.addCard(card_Number, expression_date, card_user_name, type);
            return result;
        }
        public static string deleteCard(string card_Number)
        {
            int res = Card_InfoDAO.deleteCard(card_Number);
            if (res == 0)
            {
                return "Office is not found. Deletion is not succesful";
            }
            else
            {
                return "Succesful";
            }
        }
    }
}
