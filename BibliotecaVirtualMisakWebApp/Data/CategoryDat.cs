using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CategoryDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todas las Categorías
        public DataSet showCategories()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectCategory"; // Nombre actualizado del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        // Método para mostrar unicamente el id y el nombre de la categoria
        public DataSet showCategoriesDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectCategoryDDL"; // Nombre actualizado del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }



        // Método para guardar una nueva Categoría
        public bool saveCategory(string _nombre, string _description)
        {
            bool executed = false;
            int row;

            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "procInsertCategory"; // Nombre del procedimiento almacenado actualizado
            objInsertCmd.CommandType = CommandType.StoredProcedure;
            objInsertCmd.Parameters.Add("v_nombre", MySqlDbType.Enum).Value = _nombre;
            objInsertCmd.Parameters.Add("v_description", MySqlDbType.Text).Value = _description;

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

        // Método para actualizar una Categoría
        public bool updateCategory(int _idCategory, string _nombre, string _description)
        {
            bool executed = false;
            int row;

            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "procUpdateCategory"; // Nombre actualizado del procedimiento almacenado
            objUpdateCmd.CommandType = CommandType.StoredProcedure;
            objUpdateCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCategory;
            objUpdateCmd.Parameters.Add("v_nombre", MySqlDbType.Enum).Value = _nombre;
            objUpdateCmd.Parameters.Add("v_descripcion", MySqlDbType.Text).Value = _description;

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

        // Método para borrar una Categoría
        public bool deleteCategory(int _idCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "procDeleteCategory"; // Nombre actualizado del procedimiento almacenado
            objDeleteCmd.CommandType = CommandType.StoredProcedure;
            objDeleteCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCategory;

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