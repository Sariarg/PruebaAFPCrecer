using APIClinicasa.Models;
using APIClinicasa.Resource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIClinicasa.Controllers
{
    public class ExpedienteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CompletarExpediente(Expediente modelo)
        {
            Conexion con = new Conexion();
            con.Conectaar();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con.con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "ControlExpediente"; //Stored Procedure Name

            com.Parameters.Add("@i_metodo", SqlDbType.Int).Value = 1;
            com.Parameters.Add("@i_cita", SqlDbType.Int).Value = modelo.Cita;
            com.Parameters.Add("@i_Observacion", SqlDbType.NVarChar).Value = modelo.Observacion;
            com.Parameters.Add("@i_Medicamento", SqlDbType.NVarChar).Value = modelo.Medicamento;
            com.Parameters.Add("@i_Diagnostico", SqlDbType.NVarChar).Value = modelo.Diagnostico;

            com.ExecuteNonQuery();

            con.Desconectar();
            return Ok("Expediente Completado!");
        }
    }
}
