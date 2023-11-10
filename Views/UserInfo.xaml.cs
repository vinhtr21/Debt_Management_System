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
	/// Interaction logic for UserInfo.xaml
	/// </summary>
	public partial class UserInfo : Window
	{

		public UserInfo()
		{
			InitializeComponent();
			LoadInfor();
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menu = new MenuWindow();
			this.Close();
			menu.Show();
		}

		private void LoadInfor()
		{
			try
			{
				using (DebtCompanyContext db = new DebtCompanyContext())
				{
					var user = AccountDAO.Instance.GetAccountByID(MainWindow.memberId);
					if (user != null)
					{
						txtAddress.Text = user.Address;
						txtName.Text = user.Name;
						txtPhone.Text = user.Phone;
						txtDob.Text = user.Dob.ToString();
						txtAvailable.Text = user.Available.ToString();
						txtDebt.Text = user.Debt.ToString();
					}
					else throw new Exception();
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}

		}

        private void btnEditInfo_Click(object sender, RoutedEventArgs e)
        {
			UserReInputPassword user = new UserReInputPassword();
			user.Show();
        }
    }
}
