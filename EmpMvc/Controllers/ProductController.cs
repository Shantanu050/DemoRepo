using Microsoft.AspNetCore.Mvc;
using EmpMvc.Models;
using System.Data;
using System.Data.SqlClient;
namespace EmpMvc.Controllers{

public class ProductController:Controller
{
  public IActionResult Display(int id)
  {
      string constr="User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
      SqlConnection con=new SqlConnection(constr);
      SqlCommand cmd=new SqlCommand("Find",con);
      cmd.CommandType=CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@id",id);
      con.Open();
      SqlDataReader rd=cmd.ExecuteReader();
      DataTable prodTable=new DataTable();
      prodTable.Load(rd);
    return View(prodTable);
  }
      public IActionResult List()
      {
        string constr=;
         
        SqlConnection con=new SqlConnection(constr);
        SqlCommand cmd=new SqlCommand("select * from product",con);
        con.Open();
        SqlDataReader rd=cmd.ExecuteReader();
        DataTable prodTable=new DataTable();
        prodTable.Load(rd);
        return View(prodTable);

        
      }
      public IActionResult Create()
      {
        return View();

      }

      [HttpPost]
      public IActionResult Create(int id, string name,int price, int stock)
      {
        if(ModelState.IsValid)
        {
         string constr="User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
         
          SqlConnection con=new SqlConnection(constr);
          SqlCommand cmd=new SqlCommand("addproduct",con);
          cmd.CommandType=CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@id",id);
          cmd.Parameters.AddWithValue("@name",name);
          cmd.Parameters.AddWithValue("@price",price);
          cmd.Parameters.AddWithValue("@stock",stock);
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
          return RedirectToAction("List");
        }
           return View();
      }
}
}