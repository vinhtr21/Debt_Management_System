using Debt_Management.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Debt_Management.Views
{
    /// <summary>
    /// Interaction logic for UserViewPaymentWindow.xaml
    /// </summary>
    public partial class UserViewPaymentWindow : Window
    {
        public UserViewPaymentWindow()
        {
            InitializeComponent();
            LoadRequires(MainWindow.memberId);
            LoadAvailable(MainWindow.memberId);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            this.Close();
            menu.Show();
        }
        private void LoadRequires(int userID)
        {
            listRequireUser.ItemsSource = AdmRequireDAO.Instance.GetReqBySupplierID(userID);
        }

        private void LoadAvailable(int userID)
        {
            txtAvailable.Text = AccountDAO.Instance.GetAccountByID(userID).Available.ToString();
            txtDebt.Text = AccountDAO.Instance.GetAccountByID(userID).Debt.ToString();
        }
    }
}
