using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.DAO
{
    public interface IDAOManager
    {
        public bool ImportCustomers();
        public bool ImportOffices();
        public bool ImportEmployees();
        public bool ImportPayments();
        public bool ImportProductLines();
        public bool ImportProducts();
        public bool ImportOrders();
        public bool ImportOrderDetails();
        public List<Object> ListCustomers();
        public List<Object> ListCustomersPayments();
        public List<Object> ListEmployeesFranceOffice();
        public List<Object> ListCustomersBought1969FordFalcon();
        public List<Object> ListCustomersCredit();
        public List<Object> ListEmployeesSoldHelicopters();
        public List<Object> ListCustomersByEmployeeNumber(int employeeNumber);
        public List<Object> ListMostSoldProductLine();
        public List<Object> ListProductsByProductLine(string productLineName);
        public List<Object> ListTotalSalesByOffice();
        public List<Object> ListSellsPerProduct();
        public List<Object> ListInProcessORInPendingOrders();
    }
}
