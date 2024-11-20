using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class AnswerDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todas las Respuestas
        public DataSet showAnswers()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectAnswer"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar una nueva Respuesta
        public bool saveAnswer(string _respuesta, int _en_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertAnswer"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_respuesta", MySqlDbType.VarChar).Value = _respuesta; // Tipo VarChar para la respuesta
            objSelectCmd.Parameters.Add("v_en_id", MySqlDbType.Int32).Value = _en_id; // Tipo Int32 para el ID de la encuesta
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

        // Método para actualizar una Respuesta
        public bool updateAnswer(int _idRespuesta, string _respuesta, int _en_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateAnswer"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_res_id", MySqlDbType.Int32).Value = _idRespuesta; // Corregido
            objSelectCmd.Parameters.Add("v_en_id", MySqlDbType.Int32).Value = _en_id;       // Corregido
            objSelectCmd.Parameters.Add("v_res_respuesta", MySqlDbType.VarChar).Value = _respuesta; // Corregido

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

        // Método para borrar una Respuesta
        public bool deleteAnswer(int _idRespuesta, int _en_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteAnswer"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Ajustar los nombres de los parámetros
            objSelectCmd.Parameters.Add("v_res_id", MySqlDbType.Int32).Value = _idRespuesta; // ID de la respuesta
            objSelectCmd.Parameters.Add("v_en_id", MySqlDbType.Int32).Value = _en_id; // ID de la encuesta

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