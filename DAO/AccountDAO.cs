using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Debt_Management.Models;
namespace Debt_Management.DAO
{
    public class AccountDAO
    {
        private DebtCompanyContext context = new DebtCompanyContext();
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            List<Account> accounts;
            try
            {
                accounts = context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return accounts;
        }

        public Account GetAccountByID(int id)
        {
            Account acc = null;
            try
            {
                acc = context.Accounts.SingleOrDefault(acc => acc.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }


    }
}
