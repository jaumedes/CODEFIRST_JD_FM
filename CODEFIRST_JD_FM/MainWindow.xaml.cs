using CODEFIRST_JD_FM.DAO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CODEFIRST_JD_FM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyDBContext companydbc = new CompanyDBContext();
        private IDAOManager manager = null;

        public MainWindow()
        {
            InitializeComponent();
            manager = DAOManagerFactory.CreateDaoManager(companydbc);

            //OK
            //manager.ImportProductLines();
            //OK
            //manager.ImportProducts();
            //OK
            //manager.ImportOffices();
            //OK
            //manager.ImportEmployees();
            //OK
            //manager.ImportCustomers();            
            //OK
            //manager.ImportPayments();
            //OK
            //manager.ImportOrders();
            //OK
            //manager.ImportOrderDetails();
        }

        private void cbSelects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSelects.SelectedIndex == 0)
            {
                List<Object> customerList = manager.ListCustomers();
                dgList.ItemsSource = customerList;
            }
            else if (cbSelects.SelectedIndex == 1)
            {
                List<Object> customerPaymentList = manager.ListCustomersPayments();
                dgList.ItemsSource = customerPaymentList;
            }
            else if (cbSelects.SelectedIndex == 2)
            {
                List<Object> employeesFrance = manager.ListEmployeesFranceOffice();
                dgList.ItemsSource = employeesFrance;
            }
            else if (cbSelects.SelectedIndex == 3)
            {
                List<Object> customers1969Falcon = manager.ListCustomersBought1969FordFalcon();
                dgList.ItemsSource = customers1969Falcon;
            }
            else if (cbSelects.SelectedIndex == 4)
            {
                List<Object> customersCredit = manager.ListCustomersCredit();
                dgList.ItemsSource = customersCredit;
            }
            else if (cbSelects.SelectedIndex == 5)
            {
                List<Object> employeesHelicopter = manager.ListEmployeesSoldHelicopters();
                dgList.ItemsSource = employeesHelicopter;
            }
            else if (cbSelects.SelectedIndex == 6)
            {
                tbWarning.Visibility = Visibility.Visible;
                btnListCustomersByEmployeeNumber.Visibility = Visibility.Visible;
            }
            else if (cbSelects.SelectedIndex == 7)
            {
                List<Object> mostSoldProductLine = manager.ListMostSoldProductLine();
                dgList.ItemsSource = mostSoldProductLine;
            }
            else if (cbSelects.SelectedIndex == 8)
            {
                tbWarning.Visibility = Visibility.Visible;
                btnListProductsByProductLine.Visibility = Visibility.Visible;
            }
            else if (cbSelects.SelectedIndex == 9)
            {
                List<Object> totalSalesByOffice = manager.ListTotalSalesByOffice();
                dgList.ItemsSource = totalSalesByOffice;
            }
        }

        private void btnListCustomersByEmployeeNumber_Click(object sender, RoutedEventArgs e)
        {
            int employeeNumber = Convert.ToInt32(txtSelects.Text);
            List<Object> customersEmployee = manager.ListCustomersByEmployeeNumber(employeeNumber);
            dgList.ItemsSource = customersEmployee;
            btnListCustomersByEmployeeNumber.Visibility = Visibility.Hidden;
            txtSelects.Text = "";
            tbWarning.Visibility = Visibility.Hidden;
        }

        private void btnListProductsByProductLine_Click(object sender, RoutedEventArgs e)
        {
            string productLineName = txtSelects.Text;
            List<Object> mostSoldProductLine = manager.ListProductsByProductLine(productLineName);
            dgList.ItemsSource = mostSoldProductLine;    
            btnListProductsByProductLine.Visibility = Visibility.Hidden;
            txtSelects.Text = "";
            tbWarning.Visibility = Visibility.Hidden;
        }
    }
}