using StdApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StdApp.Controllers
{
    public class StudentsController:Controller
    {
        public IActionResult List()
        {
            string conStr="User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
            SqlConnection con=new SqlConnection(conStr);
            SqlCommand cmd=new SqlCommand("select * from students",con);
            con.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            DataTable stdTable=new DataTable();
            stdTable.Load(reader);
            //con.Close();
            return View(stdTable);

        }

    }
}
