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
    public class CitaController : ApiController
    {
        [HttpPost]
        public IHttpActionResult NuevaCita(Cita modelo)
        {
            Conexion con = new Conexion();
            con.Conectaar();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con.con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "ControlCitas"; //Stored Procedure Name

            com.Parameters.Add("@i_metodo", SqlDbType.Int).Value = 1;
            com.Parameters.Add("@i_paciente", SqlDbType.NVarChar).Value = modelo.Paciente;
            com.Parameters.Add("@i_doctor", SqlDbType.Int).Value = modelo.Doctor;
            com.Parameters.Add("@i_fecha", SqlDbType.Date).Value = modelo.fecha;
            com.Parameters.Add("@i_hora", SqlDbType.Int).Value = modelo.Hora;

            com.ExecuteNonQuery();

            con.Desconectar();
            return Ok("Cita Agregada!");
        }

        [HttpPut]
        public IHttpActionResult EditarCita(Cita modelo)
        {
            Conexion con = new Conexion();
            con.Conectaar();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con.con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "ControlCitas"; //Stored Procedure Name

            com.Parameters.Add("@i_metodo", SqlDbType.Int).Value = 2;
            com.Parameters.Add("@i_idCita", SqlDbType.Int).Value = modelo.Citaid;
            com.Parameters.Add("@i_doctor", SqlDbType.Int).Value = modelo.Doctor;
            com.Parameters.Add("@i_fecha", SqlDbType.Date).Value = modelo.fecha;
            com.Parameters.Add("@i_hora", SqlDbType.Int).Value = modelo.Hora;

            com.ExecuteNonQuery();

            con.Desconectar();
            return Ok("Cita Modificada!");
        }

        [HttpPost]
        public IHttpActionResult EliminarCita(int id)
        {
            Conexion con = new Conexion();
            con.Conectaar();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con.con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "ControlCitas"; //Stored Procedure Name

            com.Parameters.Add("@i_metodo", SqlDbType.Int).Value = 3;
            com.Parameters.Add("@i_idCita", SqlDbType.Int).Value = id;
            com.ExecuteNonQuery();

            con.Desconectar();
            return Ok("Cita Eliminada!");
        }
    }
}
