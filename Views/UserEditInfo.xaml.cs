using Debt_Management.DAO;
using Debt_Management.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for UserEditInfo.xaml
    /// </summary>
    public partial class UserEditInfo : Window
    {
        public UserEditInfo()
        {
            InitializeComponent();
            LoadInfor();
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
                        txtPassword.Text = user.Password;
                    }
                    else throw new Exception();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        private Account GetAccountObject()
        {
            Account account = null;
            try
            {
                account = new Account
                {
                    //Id = MainWindow.memberId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Password = txtPassword.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get account");
            }
            return account;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Account a = GetAccountObject();
                AccountDAO.Instance.UpdateAccount(a);
                MessageBox.Show("success");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
