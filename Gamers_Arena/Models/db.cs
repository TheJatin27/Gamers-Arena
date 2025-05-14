using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace Gamers_Arena.Models
{
    public class db
    {

  


        SqlConnection connection = new SqlConnection("Data Source=THE-JATIN;Initial Catalog=Gamers Arena;Integrated Security=True");

        public int InserUpdateDelete(string command)
        {


            SqlCommand cmd = new SqlCommand(command, connection);   
            connection.Open();
       int d =cmd.ExecuteNonQuery();
            connection.Close();



            return d;


        }

        public DataTable SelectStatment(string command) { 
        
            SqlDataAdapter adapter = new SqlDataAdapter(command,connection);
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;


        }



    }
}