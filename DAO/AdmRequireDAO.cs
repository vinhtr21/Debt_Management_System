using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Debt_Management.DAO
{
	public class AdmRequireDAO
	{
		private DebtCompanyContext context = new DebtCompanyContext();
		private static AdmRequireDAO instance = null;
		private static readonly object instanceLock = new object();
		private AdmRequireDAO() { }

		public static AdmRequireDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new AdmRequireDAO();
					}
					return instance;
				}
			}
		}
		
		public IEnumerable<AdminRequire> GetAdminRequires()
		{
			List<AdminRequire> requires;
			try
			{
				requires = context.AdminRequires.ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return requires;
		}

		public void AddRequire(AdminRequire require)
		{
			DebtCompanyContext myDB = new DebtCompanyContext();
			try
			{
				myDB.AdminRequires.Add(require);
				myDB.SaveChanges();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
