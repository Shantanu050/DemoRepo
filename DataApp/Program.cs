// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;
using System.Data;
 string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=db;trusted_connection=false;Persist Security Info=False;Encrypt=False";
  SqlConnection con=new SqlConnection(connectionString);
  //AddDisconnect();
ShowDisconnect();
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
void ShowDisconnect()
{
  //con.Open();
    string cmdText="insert into product values(@id,@name,@price,@stock)";
    SqlDataAdapter adapter=null;
    DataSet ds=null;
    DataTable prodTable=null;

    try
    {
        //con.Open();
        ds=new DataSet();
        adapter=new SqlDataAdapter("select * from product",con);
        adapter.Fill(ds,"Prod");
        prodTable=ds.Tables["Prod"];
        Console.WriteLine($"Rows= {prodTable.Rows.Count}");
        Console.WriteLine($"Columns= {prodTable.Columns.Count}");   

        foreach(DataRow row in prodTable.Rows)
        {
            Console.WriteLine($"{row["id"]}---{row["name"]}--- {row["price"]}----{row["stock"]}");
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }

}
void AddDisconnect()
{
     int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Name");
    string name=Console.ReadLine();
    Console.WriteLine("Price");
    int price=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Stock");
    int stock=Convert.ToInt32(Console.ReadLine());
    SqlDataAdapter adapter=null;
    DataSet ds=null;
    try
    {
        ds=new DataSet();
        adapter=new SqlDataAdapter("select * from product",con);
        adapter.Fill(ds,"Prod");
        DataTable prodTable=ds.Tables["Prod"];
        DataRow prodrow=prodTable.NewRow();
        prodrow["id"]=id;
        prodrow["name"]=name;
        prodrow["price"]=price;
        prodrow["stock"]=stock;
        prodTable.Rows.Add(prodrow);
        SqlCommandBuilder scb=new SqlCommandBuilder(adapter);
        Console.WriteLine(scb.GetInsertCommand().CommandText);
        adapter.Update(prodTable);
        Console.WriteLine("Row added");
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
