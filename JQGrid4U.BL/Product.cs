using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace JQGrid4U.BL
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double StockLevel { get; set; }
        public double ReOrderLevel { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class ProductBusinessLogic
    {
        string conStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public IEnumerable<Product> Products
        {
            get
            {
                List<Product> Products = new List<Product>();
                using(SqlConnection conObj=new SqlConnection(conStr))
                {
                    SqlCommand cmdObj = new SqlCommand("uspSelectProduct", conObj);
                    conObj.Open();
                    SqlDataReader readerObj = cmdObj.ExecuteReader();

                    while(readerObj.Read())
                    {
                        Product Product = new Product();
                        Product.ProductID = Convert.ToInt32( readerObj["ProductID"]);
                        Product.ProductName = readerObj["ProductName"].ToString();
                        Product.ProductCode = readerObj["ProductCode"].ToString();
                        Product.StockLevel = Convert.ToDouble(readerObj["StockLevel"]);
                        Product.ReOrderLevel = Convert.ToDouble(readerObj["ReOrderLevel"]);
                        Product.CostPrice = Convert.ToDecimal(readerObj["CostPrice"]);
                        Product.SellingPrice = Convert.ToDecimal(readerObj["SellingPrice"]);
                        Product.ExpiryDate = Convert.ToDateTime(readerObj["ExpiryDate"]);

                        Products.Add(Product);
                    }
                }
                return Products;
            }
        }

        public int InsertProduct(Product Product)
        {
            using (SqlConnection conObj = new SqlConnection(conStr))
            {
                SqlCommand cmdObj = new SqlCommand("uspInsertProduct", conObj);
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", Product.ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", Product.ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevel", Product.StockLevel));
                cmdObj.Parameters.Add(new SqlParameter("@ReOrderLevel", Product.ReOrderLevel));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", Product.CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPrice", Product.SellingPrice));
                cmdObj.Parameters.Add(new SqlParameter("@ExpiryDate", Product.ExpiryDate));
                conObj.Open();
                return Convert.ToInt32(cmdObj.ExecuteScalar());
            }
        }

        public int UpdateProduct(Product Product)
        {
            using (SqlConnection conObj = new SqlConnection(conStr))
            {
                SqlCommand cmdObj = new SqlCommand("uspUpdateProduct", conObj);
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", Product.ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", Product.ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", Product.ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevel", Product.StockLevel));
                cmdObj.Parameters.Add(new SqlParameter("@ReOrderLevel", Product.ReOrderLevel));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", Product.CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPrice", Product.SellingPrice));
                cmdObj.Parameters.Add(new SqlParameter("@ExpiryDate", Product.ExpiryDate));
                conObj.Open();
                return Convert.ToInt32(cmdObj.ExecuteScalar());
            }
        }

        public int DeleteProduct(int ProductID)
        {
            using (SqlConnection conObj = new SqlConnection(conStr))
            {
                SqlCommand cmdObj = new SqlCommand("uspDeleteProduct", conObj);
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                conObj.Open();
                return Convert.ToInt32(cmdObj.ExecuteScalar());
            }
        }
    }
}
