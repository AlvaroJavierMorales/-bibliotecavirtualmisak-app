using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class EditorialDat
    { 
            Persistence objPer = new Persistence();

            // Método para mostrar todas las Editoriales
            public DataSet showEditorials()
            {
                MySqlDataAdapter objAdapter = new MySqlDataAdapter();
                DataSet objData = new DataSet();

                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "procSelectEditorial"; // Nombre actualizado del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objAdapter.SelectCommand = objSelectCmd;
                objAdapter.Fill(objData);
                objPer.closeConnection();
                return objData;
            }
        // Método para mostrar el id y nombre de las Editoriales
        public DataSet showEditorialsDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectEditorialDDL"; // Nombre actualizado del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        // Método para insertar una nueva Editorial
        public bool saveEditorial(string _nombre, string _ciudad, int _telefono, string _correo)
            {
                bool executed = false;
                int row;

                MySqlCommand objInsertCmd = new MySqlCommand();
                objInsertCmd.Connection = objPer.openConnection();
                objInsertCmd.CommandText = "procInsertEditorial"; // Nombre del procedimiento almacenado
                objInsertCmd.CommandType = CommandType.StoredProcedure;
                objInsertCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre;
                objInsertCmd.Parameters.Add("v_ciudad", MySqlDbType.VarChar).Value = _ciudad;
                objInsertCmd.Parameters.Add("v_telefono", MySqlDbType.Int32).Value = _telefono;
                objInsertCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo;

                try
                {
                    row = objInsertCmd.ExecuteNonQuery();
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

            // Método para actualizar una Editorial
            public bool updateEditorial(int _idEditorial, string _nombre, string _ciudad, int _telefono, string _correo)
            {
                bool executed = false;
                int row;

                MySqlCommand objUpdateCmd = new MySqlCommand();
                objUpdateCmd.Connection = objPer.openConnection();
                objUpdateCmd.CommandText = "procUpdateEditorial"; // Nombre actualizado del procedimiento almacenado
                objUpdateCmd.CommandType = CommandType.StoredProcedure;
                objUpdateCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idEditorial;
                objUpdateCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre;
                objUpdateCmd.Parameters.Add("v_ciudad", MySqlDbType.VarChar).Value = _ciudad;
                objUpdateCmd.Parameters.Add("v_telefono", MySqlDbType.Int32).Value = _telefono;
                objUpdateCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo;

                try
                {
                    row = objUpdateCmd.ExecuteNonQuery();
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

            // Método para eliminar una Editorial
            public bool deleteEditorial(int _idEditorial)
            {
                bool executed = false;
                int row;

                MySqlCommand objDeleteCmd = new MySqlCommand();
                objDeleteCmd.Connection = objPer.openConnection();
                objDeleteCmd.CommandText = "procDeleteEditorial"; // Nombre actualizado del procedimiento almacenado
                objDeleteCmd.CommandType = CommandType.StoredProcedure;
                objDeleteCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idEditorial;

                try
                {
                    row = objDeleteCmd.ExecuteNonQuery();
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
}