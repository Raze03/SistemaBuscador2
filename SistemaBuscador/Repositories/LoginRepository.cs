﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class LoginRepository
    {
        public bool UserExist(string Usuario, string Password)
        {
            bool result = false;
            string connectionString = "server=DESKTOP-9IEFTTU;database=SistemaBuscador;Integrated Security=true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_user", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@user", Usuario));
            cmd.Parameters.Add(new SqlParameter("@password", Password));
            sql.Open();
            int dbResult = (int)cmd.ExecuteScalar();
            if (dbResult > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
