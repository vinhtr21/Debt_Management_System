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
	/// Interaction logic for PaymentAdminWindow.xaml
	/// </summary>
	public partial class PaymentAdminWindow : Window
	{   
		public PaymentAdminWindow()
		{
			InitializeComponent();
			LoadRequire();
            LoadAvailable();
		}
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            this.Close();
            menu.Show();
        }

		private void LoadRequire()
		{
            listRequireAdmin.ItemsSource = AdmRequireDAO.Instance.GetAdminRequires();
        }

        private void LoadAvailable()
        {
            txtAvailable.Text = AdminDAO.Instance.GetAdminInfor().Available.ToString();
            txtDebt.Text = AdminDAO.Instance.GetAdminInfor().Debt.ToString();
        }
        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            Payment();
        }

        private void Payment()
        {
            var selected = (AdminRequire)listRequireAdmin.SelectedItem;
            if(selected != null)
            {
                Admin admin = AdminDAO.Instance.GetAdminInfor();
                Account supplier = AccountDAO.Instance.GetAccountByID(selected.SupplierId);
                admin.Available -= selected.Cost;
                admin.Debt -= selected.Cost;
                supplier.Available += selected.Cost;
                supplier.Debt -= selected.Cost;
                selected.Status = "Paid";
                AdmRequireDAO.Instance.UpdateRequire(selected);
                AdminDAO.Instance.UpdateAdmin();
                AccountDAO.Instance.UpdateAccount(supplier);
                LoadAvailable();
                LoadRequire();
            }
            else
            {
                MessageBox.Show("no requirement is selected. please select a requirement", "Error");
            }
            
        }
        
        private void btnPay_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                AdminRequire require = button.DataContext as AdminRequire;
                if (require.Status.Equals("Pending") || require.Status.Equals("Paid") || require.Status.Equals("Rejected"))
                {
                    button.IsEnabled = false;
                }
            }
        }
    }
}
