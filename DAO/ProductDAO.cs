using Debt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Management.DAO
{
    public class ProductDAO
    {
		private DebtCompanyContext context = new DebtCompanyContext();
		private static ProductDAO instance = null;
		private static readonly object instanceLock = new object();
		private ProductDAO() { }

		public static ProductDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new ProductDAO();
					}
					return instance;
				}
			}
		}

		public IEnumerable<Product> GetProducts()
		{
			List<Product> products;
			try
			{
				products = context.Products.ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return products;
		}

        public void AddProduct(Product product)
        {
            DebtCompanyContext myDB = new DebtCompanyContext();
            try
            {
                myDB.Products.Add(product);
                myDB.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public Product GetProductByName(string name)
		{
            Product product = null;
            try
            {
                var myDB = new DebtCompanyContext();
                product = myDB.Products.SingleOrDefault(o => o.ProductName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
    }
}
