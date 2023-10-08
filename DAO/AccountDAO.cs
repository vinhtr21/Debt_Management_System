using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Management.Models;
namespace Debt_Management.DAO
{
    public class AccountDAO
    {
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
                var context = new DebtCompanyContext();
                accounts = context.Accounts.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
            return accounts;
        }


    }
}
