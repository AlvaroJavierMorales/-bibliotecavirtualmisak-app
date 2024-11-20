using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class SurveyDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todas las Encuestas
        public DataSet showSurveys()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectSurvey"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para mostrar unicamente el id y la descripcion de la pregunta
        public DataSet showSurveysDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectSurveyDDL"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        // Método para guardar una nueva Encuesta
        public bool saveSurvey(string _descripcionPregunta, int _usu_id)
        {
            bool executed = false;
            int row; // Variable para almacenar el número de filas afectadas por la operación.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertSurvey"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_descripcion_pregunta", MySqlDbType.VarChar).Value = _descripcionPregunta; // Tipo VarChar para la descripción de la pregunta
            objSelectCmd.Parameters.Add("v_usu_id", MySqlDbType.Int32).Value = _usu_id; // Tipo Int32 para el ID del usuario
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

        // Método para actualizar una Encuesta
        public bool updateSurvey(int _en_id, int _usu_id, string _descripcionPregunta)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateSurvey"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_en_id", MySqlDbType.Int32).Value = _en_id; // ID de la encuesta
            objSelectCmd.Parameters.Add("v_usu_id", MySqlDbType.Int32).Value = _usu_id; // ID del usuario
            objSelectCmd.Parameters.Add("v_descripcion_pregunta", MySqlDbType.VarChar).Value = _descripcionPregunta; // Tipo VarChar para la descripción de la pregunta
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

        // Método para borrar una Encuesta
        public bool deleteSurvey(int _en_id, int _usu_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteSurvey"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_en_id", MySqlDbType.Int32).Value = _en_id; // ID de la encuesta
            objSelectCmd.Parameters.Add("v_usu_id", MySqlDbType.Int32).Value = _usu_id; // ID del usuario
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
    }
}