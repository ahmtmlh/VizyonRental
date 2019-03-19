using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class View
    {
        public static DataSet getReservationViewDataSet()
        {
            return ViewDAO.getReservationViewDataSet();
        }
        public static DataSet getRentViewDataSet()
        {
            return ViewDAO.getRentViewDataSet();
        }
        public static DataSet getCustomerViewDataSet()
        {
            return ViewDAO.getCustomerViewDataSet();
        }
        public static DataSet getManagerViewDataSet()
        {
            return ViewDAO.getManagerViewDataSet();
        }
        public static DataSet getBillViewDataSet()
        {
            return ViewDAO.getBillViewDataSet();
        }
    }
}
