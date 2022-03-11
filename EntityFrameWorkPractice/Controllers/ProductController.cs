using EntityFrameWorkPractice.Config;
using EntityFrameWorkPractice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameWorkPractice.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            return View(new Product { Id=0});
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            //string insertSql = "INSERT INTO Products(Name,Price,Supplier) VALUES('" + product.Name + "','" + product.Price + "','" + product.Supplier + "')";
            //string updateSql = "UPDATE Products SET Name='" + product.Name + "',Price='" + product.Price + "',Supplier='" + product.Supplier + "' where Id='"+product.Id+"'";
            if(ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand("Product_SaveOrUpdate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", product.Id);
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("Create",product);
            }
            
        }
        public ActionResult Search(string search)
        {
            List<Product> products = GetProducts("Products_SearchProduct",search);
            return View("GetAll",products);
        }
        public List<Product> GetProducts(string stored_procedure,string search)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand command = new SqlCommand(stored_procedure, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (search != null)
                        command.Parameters.AddWithValue("@Filter", search);
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    DataTable datatable = new DataTable();
                    datatable.Load(sqlDataReader);
                    foreach (DataRow dataRow in datatable.Rows)
                    {
                        products.Add(
                            new Product
                            {
                                Id = Convert.ToInt32(dataRow["ID"]),
                                Name = dataRow["Name"].ToString(),
                                Price = Convert.ToDecimal(dataRow["Price"]),
                                Supplier = dataRow["Supplier"].ToString()
                            });
                    }
                }
            }
            return products;
        }
        public ActionResult GetAll()
        {
            List<Product> products = GetProducts("Products_GetAllProduct", null);
           
            return View(products);
        }
        public ActionResult Delete(int id)
        {
            if(id<0)
                return HttpNotFound();
            using(SqlConnection con=new SqlConnection(StoreConnection.GetConnection()))
            {
                using(SqlCommand command=new SqlCommand("Product_DeleteById", con))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    if(con.State != System.Data.ConnectionState.Open)   
                        con.Open();
                    command.ExecuteNonQuery();
                }
            }
            return  RedirectToAction("GetAll");
        }
        public ActionResult Edit(int id)
        {
            if (id < 0)
                return HttpNotFound();
            var _product = new Product();
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand command = new SqlCommand("Product_GetById", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable table = new DataTable();
                    if(reader.HasRows)
                    {
                        table.Load(reader);
                        DataRow row = table.Rows[0];
                        _product.Id=Convert.ToInt32(row["ID"]);
                        _product.Name=row["Name"].ToString();
                        _product.Price = Convert.ToDecimal(row["Price"]);
                        _product.Supplier = row["Supplier"].ToString();
                        return View("Create", _product);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            
        }
      
    }
}