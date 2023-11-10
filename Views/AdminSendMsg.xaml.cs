using Debt_Management.DAO;
using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AdminSendMsg.xaml
    /// </summary>
    public partial class AdminSendMsg : Window
    {
        //public ObservableCollection<string> Usernames { get; set; }
        public AdminSendMsg()
        {
            InitializeComponent();
            LoadUsernamesFromDatabase();
            //LoadOldMessages();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            this.Close();
            menu.Show();
        }

        private void LoadUsernamesFromDatabase()
        {
            // Assuming you have an Entity Framework context named 'YourDbContext'
            using (var dbContext = new DebtCompanyContext())
            {
                // Replace 'YourDbSet' with the appropriate DbSet in your DbContext
                var users = dbContext.Accounts.Select(u => u.Name).ToList();
                foreach (var username in users)
                {
                    MembersList.Items.Add(username);
                }
            }
        }

        private void LoadOldMessages(string username)
        {

        }

        private int FindIdByUserName(string username)
        {
            using (var db = new DebtCompanyContext())
            {
                int userID = db.Accounts
                    .Where(a => a.Name == username)
                    .Select(a => a.Id)
                    .FirstOrDefault();  

                return userID;
            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = AdminDAO.Instance.GetAdminInfor();
            string selectedUser = MembersList.SelectedItem.ToString();
            string message = MessageTextBox.Text;
            int selectedUserID = FindIdByUserName(selectedUser);
            //SendMessageToSpecificUser(selectedUserID, message);
            ChatDisplay.Items.Add($"{admin.Name} to {selectedUser}: {message}");
            MessageTextBox.Text = string.Empty;
        }

        //private void SendMessageToSpecificUser(int receiverId, string message)
        //{
        //    MessageBox.Show(message);
        //}
    }
}
