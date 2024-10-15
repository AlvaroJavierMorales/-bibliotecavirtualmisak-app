using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class AuthorsDat
    {
      
            Persistence objPer = new Persistence();

            // Método para mostrar todos los Autores
            public DataSet showAuthors()
            {
                MySqlDataAdapter objAdapter = new MySqlDataAdapter();
                DataSet objData = new DataSet();
                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "procSelectAuthors"; // nombre del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objAdapter.SelectCommand = objSelectCmd;
                objAdapter.Fill(objData);
                objPer.closeConnection();
                return objData;
            }

            // Método para guardar un nuevo Autor
            public bool saveAuthor(string _nombre, string _apellido, string _municipio)
            {
                bool executed = false;
                int row;
                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "proInsertAuthors"; // nombre del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objSelectCmd.Parameters.Add("v_au_nombre", MySqlDbType.VarChar).Value = _nombre; // Tipo VarChar para el nombre
                objSelectCmd.Parameters.Add("v_au_apellido", MySqlDbType.VarChar).Value = _apellido; // Tipo VarChar para el apellido
                objSelectCmd.Parameters.Add("v_au_municipio", MySqlDbType.VarChar).Value = _municipio; // Tipo VarChar para el municipio
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

            // Método para actualizar un Autor
            public bool updateAuthor(int _idAuthor, string _nombre, string _apellido, string _municipio)
            {
                bool executed = false;
                int row;
                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "procUpdateAuthor"; // nombre del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idAuthor;
                objSelectCmd.Parameters.Add("v_au_nombre", MySqlDbType.VarChar).Value = _nombre; // Tipo VarChar para el nombre
                objSelectCmd.Parameters.Add("v_au_apellido", MySqlDbType.VarChar).Value = _apellido; // Tipo VarChar para el apellido
                objSelectCmd.Parameters.Add("v_au_municipio", MySqlDbType.VarChar).Value = _municipio; // Tipo VarChar para el municipio
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

            // Método para borrar un Autor
            public bool deleteAuthor(int _idAuthor)
            {
                bool executed = false;
                int row;
                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "procDeleteAuthors"; // nombre del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objSelectCmd.Parameters.Add("v_au_id", MySqlDbType.Int32).Value = _idAuthor;
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