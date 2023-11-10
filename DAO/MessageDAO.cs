using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Management.DAO
{
    public class MessageDAO
    {
        private DebtCompanyContext context = new DebtCompanyContext();
        private static MessageDAO instance = null;
        private static readonly object instanceLock = new object();
        private MessageDAO() { }
        public static MessageDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MessageDAO();
                    }
                    return instance;
                }
            }
        }


    }
}
