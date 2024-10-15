using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class UserDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los Usuarios
        public DataSet showUsers()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectUsers"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo Usuario
        public bool saveUser(string _nombre, string _apellido, string _correo, string _contrasena, string _salt, string _rol, string _nivelEstudios)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertUsers"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre; // Tipo VarChar para el nombre
            objSelectCmd.Parameters.Add("v_apellido", MySqlDbType.VarChar).Value = _apellido; // Tipo VarChar para el apellido
            objSelectCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo; // Tipo VarChar para el correo
            objSelectCmd.Parameters.Add("v_contrasena", MySqlDbType.Text).Value = _contrasena; // Tipo Text para la contraseña
            objSelectCmd.Parameters.Add("v_salt", MySqlDbType.Text).Value = _salt; // Tipo Text para el salt
            objSelectCmd.Parameters.Add("v_rol", MySqlDbType.Enum).Value = _rol; // Tipo Enum para el rol
            objSelectCmd.Parameters.Add("v_nivel_estudios", MySqlDbType.Enum).Value = _nivelEstudios; // Tipo Enum para el nivel de estudios
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

        // Método para actualizar un Usuario
        public bool updateUser(int _idUser, string _nombre, string _apellido, string _correo, string _contrasena, string _salt, string _rol, string _nivelEstudios)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateUsers"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idUser; // ID del usuario
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre; // Tipo VarChar para el nombre
            objSelectCmd.Parameters.Add("v_apellido", MySqlDbType.VarChar).Value = _apellido; // Tipo VarChar para el apellido
            objSelectCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo; // Tipo VarChar para el correo
            objSelectCmd.Parameters.Add("v_contrasena", MySqlDbType.Text).Value = _contrasena; // Tipo Text para la contraseña
            objSelectCmd.Parameters.Add("v_salt", MySqlDbType.Text).Value = _salt; // Tipo Text para el salt
            objSelectCmd.Parameters.Add("v_rol", MySqlDbType.Enum).Value = _rol; // Tipo Enum para el rol
            objSelectCmd.Parameters.Add("v_nivel_estudios", MySqlDbType.Enum).Value = _nivelEstudios; // Tipo Enum para el nivel de estudios
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

        // Método para borrar un Usuario
        public bool deleteUser(int _idUser)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteUsers"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idUser; // ID del usuario
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