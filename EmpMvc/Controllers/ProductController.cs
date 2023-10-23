using Microsoft.AspNetCore.Mvc;
using EmpMvc.Models;
using System.Data;
using System.Data.SqlClient;
namespace EmpMvc.Controllers{

public class ProductController:Controller
{
      public IActionResult List()
      {
        string constr="User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
         
        SqlConnection con=new SqlConnection(constr);
        SqlCommand cmd=new SqlCommand("select * from product",con);
        con.Open();
        SqlDataReader rd=cmd.ExecuteReader();
        DataTable prodTable=new DataTable();
        prodTable.Load(rd);
        return View(prodTable);

        
      }
}
}