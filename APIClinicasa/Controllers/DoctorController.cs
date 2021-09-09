using APIClinicasa.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIClinicasa.Models;
using System.Data.SqlClient;
using System.Data;

namespace APIClinicasa.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult NuevoDoc(Doctor modelo)
        {
            Conexion con = new Conexion();
            con.Conectaar();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con.con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "ControlDoctor"; //Stored Procedure Name

            com.Parameters.Add("@i_metodo", SqlDbType.Int).Value = 1;
            com.Parameters.Add("@i_JVM", SqlDbType.NVarChar).Value = modelo.JVM;
            com.Parameters.Add("@i_idpersona", SqlDbType.Int).Value = modelo.idPersona;
            com.Parameters.Add("@i_idespecialidad", SqlDbType.NVarChar).Value = modelo.idespecialidad;
            
            com.ExecuteNonQuery();

            con.Desconectar();
            return Ok("Doctor Agregado!");
        }
    }
}
