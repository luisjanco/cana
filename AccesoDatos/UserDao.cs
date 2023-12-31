﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
     public class UserDao:ConnectionToSql
    {
        public bool Login(string user, string pass) 
        {
            using(var connection = GetConeccion()) 
            {
                connection.Open();
                using (var command=new SqlCommand()) 
                {
                    command.Connection= connection;
                    command.CommandText= "select *from Usuario where Usuario=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
