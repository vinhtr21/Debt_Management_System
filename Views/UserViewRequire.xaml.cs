using Debt_Management.DAO;
using Debt_Management.Models;
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
    /// Interaction logic for UserViewRequire.xaml
    /// </summary>
    public partial class UserViewRequire : Window
    {
        DebtCompanyContext context = new DebtCompanyContext();

        public UserViewRequire()
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

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var selected = (AdminRequire)listRequireUser.SelectedItem;
            if (selected != null)
            {
                Admin admin = AdminDAO.Instance.GetAdminInfor();
                Account supplier = AccountDAO.Instance.GetAccountByID(selected.SupplierId);
                selected.Status = "Accepted";
                admin.Debt += selected.Cost;
                supplier.Debt += selected.Cost;
                AccountDAO.Instance.UpdateAccount(supplier);
                AdminDAO.Instance.UpdateAdmin();
                AdmRequireDAO.Instance.UpdateRequire(selected);
                LoadAvailable(MainWindow.memberId);
                LoadRequires(MainWindow.memberId);
            }
            else
            {
                MessageBox.Show("no requirement is selected. please select a requirement", "Error");
            }
        }

        private void btnAccept_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                AdminRequire require = button.DataContext as AdminRequire;
                if (require.Status.Equals("Rejected") || require.Status.Equals("Paid") || require.Status.Equals("Accepted"))
                {
                    button.IsEnabled = false;
                }
            }
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            var selected = (AdminRequire)listRequireUser.SelectedItem;
            if (selected != null)
            {
                selected.Status = "Rejected";
                AdmRequireDAO.Instance.UpdateRequire(selected);
                LoadRequires(MainWindow.memberId);
            }
            else
            {
                MessageBox.Show("no requirement is selected. please select a requirement", "Error");
            }


        }

        private void btnReject_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                AdminRequire require = button.DataContext as AdminRequire;
                if (require.Status.Equals("Rejected") || require.Status.Equals("Paid")|| require.Status.Equals("Accepted"))
                {
                    button.IsEnabled = false;
                }
            }
        }
    }
}
