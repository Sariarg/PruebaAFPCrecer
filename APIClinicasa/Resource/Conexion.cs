using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIClinicasa.Resource
{
    public class Conexion
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-TQ5UTAN\\SQLEXPRESS;Initial Catalog=ClinicaSA;Persist Security Info=True;User ID=sa;Password=123456-");

        public void Conectaar()
        {
            con.Open();
        }


        public void Desconectar()
        {
            con.Close();
        }
    }
}