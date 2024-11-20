
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class VisitsDat
    {
        Persistence objPer = new Persistence();


        // Método para mostrar todos las visitas
        public DataSet showVisits()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectVisits"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método DDL para mostrar con id y fecha de ingreso
        public DataSet showVisitsDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectVisitsDDL"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar una nueva visita
        public bool saveVisits(DateTime _fecha_ingreso, TimeSpan _duracion, int _usu_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertVisits"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_fecha_ingreso", MySqlDbType.DateTime).Value = _fecha_ingreso; // Tipo DateTime fecha de ingreso
            objSelectCmd.Parameters.Add("vis_duracion", MySqlDbType.Time).Value = _duracion; // Tipo TimeSpan para la duracion
            objSelectCmd.Parameters.Add("tbl_usuarios_usu_id", MySqlDbType.Int32).Value = _usu_id; // Tipo int para el usu_id
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar una visita
        public bool updateVisits(int _idVisits, int _usu_id, DateTime _fecha_ingreso, TimeSpan _duracion)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateVisits"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Parametros de fecha y duracion

            objSelectCmd.Parameters.Add("v_vis_id", MySqlDbType.Int32).Value = _idVisits; // Tipo int para el id de visitas
            objSelectCmd.Parameters.Add("v_usu_id", MySqlDbType.Int32).Value = _usu_id; // Tipo int para el usuario id
            objSelectCmd.Parameters.Add("vis_fecha_ingreso", MySqlDbType.DateTime).Value = _fecha_ingreso; // Tipo DateTime para la fecha de ingreso
            objSelectCmd.Parameters.Add("vis_duracion", MySqlDbType.Time).Value = _duracion; // Tipo Time para la duracion (en lugar de TimeSpan)


            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para borrar una Visita
        public bool deleteVisits(int _idVisits, int _userId) // Agregar parámetro de usuario
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteVisits"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetro de ID de visita
            objSelectCmd.Parameters.Add("v_vis_id", MySqlDbType.Int32).Value = _idVisits;

            // Si el procedimiento también necesita un ID de usuario, agrega este parámetro
            objSelectCmd.Parameters.Add("v_us_id", MySqlDbType.Int32).Value = _userId;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }


    }
}