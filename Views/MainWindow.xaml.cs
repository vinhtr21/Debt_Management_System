using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;
using Debt_Management.DAO;
using Debt_Management.Models;
using Debt_Management.Views;

namespace Debt_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int memberId = -1;
        public static bool isAdmin = false;
        MenuWindow menu = new MenuWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;
            if (AdminCheck(username, password))
            {
                isAdmin = true;
                MessageBox.Show("admin login successful", "Login");
                menu.Show();
                this.Close();

            }
            else if (LoginMember(username, password))
            {
                isAdmin = false;
                MessageBox.Show("login successful" +
                    "", "Login");
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("incorrect username or password", "Error");
            }
        }

        private bool AdminCheck(string username, string password)
        {
            return AdminLogin(username, password);
        }

        private Boolean AdminLogin(string username, string password)
        {
            var admin = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build().GetSection("Admin");
            if (!admin["Username"].Equals(username) || !admin["Password"].Equals(password))
            {
                return false;
            }
            return true;
        }

        private bool LoginMember(string username, string password)
        {
            Account member = null;
            var members = AccountDAO.Instance.GetAccounts();
            var auth = members.FirstOrDefault(
                member => !string.IsNullOrEmpty(member.Username) &&
                !string.IsNullOrEmpty(member.Password) &&
                member.Username.Equals(username) &&
                member.Password.Equals(password));
            if (auth != null)
            {
                memberId = auth.Id;
                return true;
            }
            return false;
        }
    }
}
