using QueFirstWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueFirstWebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> pd = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "select * from Products";
            try
            {
                SqlDataReader dr = cmdshow.ExecuteReader();
                while (dr.Read())
                {
                    //pd.Add( new Product { ProductId = (Int32)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (Decimal)dr["Rate"], Description = dr["Description"].ToString() });
                    pd.Add(new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3),CategoryName = dr.GetString(4)});
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(pd);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "select * from Products where ProductId = @id";
            cmdshow.Parameters.AddWithValue("@id", id);
            Product pd = null;
            try
            {
                SqlDataReader dr = cmdshow.ExecuteReader();
                while (dr.Read())
                {
                    //pd.Add( new Product { ProductId = (Int32)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (Decimal)dr["Rate"], Description = dr["Description"].ToString() });
                    pd = new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(pd);

        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "insert into Products values(@ProductName,@Rate,@Description,@CategoryName)";
            cmdshow.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmdshow.Parameters.AddWithValue("@Rate", pd.Rate);
            cmdshow.Parameters.AddWithValue("@Description", pd.Description);
            cmdshow.Parameters.AddWithValue("@CategoryName", pd.CategoryName);
            try
            {
                // TODO: Add insert logic here
                cmdshow.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "select * from Products where ProductId = @id";
            cmdshow.Parameters.AddWithValue("@id", id);
            Product pd = null;
            try
            {
                SqlDataReader dr = cmdshow.ExecuteReader();
                while (dr.Read())
                {
                    //pd.Add( new Product { ProductId = (Int32)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (Decimal)dr["Rate"], Description = dr["Description"].ToString() });
                    pd = new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(pd);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "Update Products Set  ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where  where ProductId = @id";
            cmdshow.Parameters.AddWithValue("@id", (Int32)id);
            cmdshow.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmdshow.Parameters.AddWithValue("@Rate", pd.Rate);
            cmdshow.Parameters.AddWithValue("@Description", pd.Description);
            cmdshow.Parameters.AddWithValue("@CategoryName", pd.CategoryName);
            try
            {
                // TODO: Add insert logic here
                cmdshow.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "select * from Products where ProductId = @id";
            cmdshow.Parameters.AddWithValue("@id", id);
            Product pd = null;
            try
            {
                SqlDataReader dr = cmdshow.ExecuteReader();
                while (dr.Read())
                {
                    //pd.Add( new Product { ProductId = (Int32)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (Decimal)dr["Rate"], Description = dr["Description"].ToString() });
                    pd = new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(pd);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExamQue1; Integrated Security = True;";
            cn.Open();
            SqlCommand cmdshow = new SqlCommand();
            cmdshow.Connection = cn;
            cmdshow.CommandType = System.Data.CommandType.Text;
            cmdshow.CommandText = "delete from Products where ProductId = @id";
            cmdshow.Parameters.AddWithValue("@id", id);
            try
            {
                // TODO: Add delete logic here
                cmdshow.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }

          
        }
    }
}
