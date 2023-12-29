﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Server=LUIS\\SQLEXPRESS; DataBase=Cosecha; integrated security=true";
        }
        protected SqlConnection GetConeccion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
