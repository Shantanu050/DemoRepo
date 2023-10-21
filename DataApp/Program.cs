// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;
 string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
  SqlConnection con=new SqlConnection(connectionString);
Show();
//AddRcord();
//DeleteRecord();
void DeleteRecord()
{
  con.Open();
  int id=Convert.ToInt32(Console.ReadLine());
  SqlCommand cmd=new SqlCommand("delete from product where id=@id",con);
  cmd.Parameters.AddWithValue("@id",id);
  cmd.ExecuteNonQuery();
  Console.WriteLine("Deleted sucessfully");
}
void AddRcord()
{
    string cmdText="insert into product values(@id,@name,@price,@stock)";
    Console.WriteLine("Id");
    int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Name");
    string name=Console.ReadLine();
    Console.WriteLine("Price");
    int price=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Stock");
    int stock=Convert.ToInt32(Console.ReadLine());
    try{
   
    con.Open();
    SqlCommand cmd=new SqlCommand(cmdText,con);
    cmd.Parameters.AddWithValue("@id",id);
    cmd.Parameters.AddWithValue("@name",name);
    cmd.Parameters.AddWithValue("@price",price);
    cmd.Parameters.AddWithValue("@stock",stock);
    Console.WriteLine(cmd.ExecuteNonQuery()+" records added.");
    
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        con.Close();
    }
}
void Show()
{

string cmdText="select * from product";
try{
con.Open();
Console.WriteLine("Connection Opened Successfuly");
SqlCommand cmd=new SqlCommand(cmdText,con);
SqlDataReader reader=cmd.ExecuteReader();
while(reader.Read())
{
    //reader.NextResult();
    Console.WriteLine($"{reader["Id"]} ---  {reader["Name"]} --- {reader["Price"]} --- {reader["stock"]}");
}

reader.Close();
con.Close();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
}