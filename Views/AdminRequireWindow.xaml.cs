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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Debt_Management.Views
{
    /// <summary>
    /// Interaction logic for AdminRequire.xaml
    /// </summary>
    public partial class AdminRequireWindow : Window
    {
        public AdminRequireWindow()
        {
            InitializeComponent();
			LoadCombo();
			LoadRequireList();
			LoadAvailable();
        }

		private void SubmitRequest_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtSupplierName.Text))
				{
					MessageBox.Show("Make sure everything is filled in.", "Error");
					return;
				}
				if (!float.TryParse(txtWeight.Text, out float weight) || float.Parse(txtWeight.Text) % 10 != 0)
				{
					MessageBox.Show("Weight should be a multiple of 10 number.", "Error");
					return;
				}
				AdminRequire require = getInfo();
				AdmRequireDAO.Instance.AddRequire(require);
				LoadRequireList();
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private float getCost()
		{
			var productName = txtProductName.Text;
			if(productName == "Grass")
			{
				return 10;
			}else if(productName == "Bran")
			{
				return 20;
			}
			else
			{
				return 30;
			}
		}

		

		private AdminRequire getInfo()
		{
			AdminRequire require = null;
			try
			{
				require = new AdminRequire()
				{
					SupplierName = txtSupplierName.Text,
					ProductName = txtProductName.Text,
					Weight = float.Parse(txtWeight.Text),
					Cost = getCost() * float.Parse(txtWeight.Text),
					Date = DateTime.Now.ToString("dd-MM-yyyy"),
					Status = "Pending",
				};
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
			return require;
		}

		private void LoadRequireList()
		{
			listRequireAdmin.ItemsSource = AdmRequireDAO.Instance.GetAdminRequires();
		}

		private void LoadAvailable()
		{
			txtAvailable.Text = AdminDAO.Instance.GetAdminInfor().Available.ToString();
		}

		private void LoadCombo()
		{
			txtProductName.ItemsSource = ProductDAO.Instance.GetProducts();
			txtProductName.DisplayMemberPath = "ProductName";
			txtProductName.SelectedValue = "ProductName";

			txtSupplierName.ItemsSource = AccountDAO.Instance.GetAccounts();
			txtSupplierName.DisplayMemberPath = "Name";
			txtSupplierName.SelectedValue = "Name";
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menu = new MenuWindow();
			this.Close();
			menu.Show();
		}
	}
}
