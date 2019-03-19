using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class Card_InfoEntityBase
    {
        public string card_Number { get; set; }
        public DateTime expression_date { get; set; }
        public string card_user_name { get; set; }
        public string type { get; set; }
    }
    public class Card_InfoEntity : Card_InfoEntityBase
    {
        public string getCardInfo()
        {
            return "Card Number: " + card_Number + " Expr. Date: " + expression_date.ToString("dddd.MM.yy") + " Card user: " + card_user_name;
        }
        public bool isValidCard()
        {
            //Compare the card exression date and current date to get if the card is valid or not.
            return expression_date.CompareTo(DateTime.Now) > 0;
        }
        public bool isSame(string card_number, DateTime date, string username, string type)
        {
            return card_Number.Equals(card_number) && (expression_date.Year == date.Year && expression_date.Month == date.Month) && card_user_name.Equals(username) && this.type.Equals(type);
        }
    }
}
