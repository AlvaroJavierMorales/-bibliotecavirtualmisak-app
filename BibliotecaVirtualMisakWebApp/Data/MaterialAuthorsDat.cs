using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class MaterialAuthorsDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los registros de la relación entre Materiales Educativos y Autores
        public DataSet showMaterialAuthors()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectAuthors_has_education_mat"; // Nombre actualizado del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para insertar un nuevo registro en la relación entre Materiales Educativos y Autores
        public bool saveMaterialAuthor(int _autorId, int _materialId)
        {
            bool executed = false;
            int row;

            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "proInsertAuthors_has_education_mat"; // Nombre del procedimiento almacenado
            objInsertCmd.CommandType = CommandType.StoredProcedure;
            objInsertCmd.Parameters.Add("v_tbl_autores_autor_id", MySqlDbType.Int32).Value = _autorId;
            objInsertCmd.Parameters.Add("v_tbl_material_edu_mat_id", MySqlDbType.Int32).Value = _materialId;

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

        // Método para actualizar un registro de la relación entre Materiales Educativos y Autores
        public bool updateMaterialAuthor(int _autorId, int _materialId)
        {
            bool executed = false;
            int row;

            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "procUpdateAuthors_has_education_mat"; // Nombre actualizado del procedimiento almacenado
            objUpdateCmd.CommandType = CommandType.StoredProcedure;
            objUpdateCmd.Parameters.Add("v_tbl_autores_au_id", MySqlDbType.Int32).Value = _autorId;
            objUpdateCmd.Parameters.Add("v_tbl_material_edu_mat_id", MySqlDbType.Int32).Value = _materialId;

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

        // Método para eliminar un registro de la relación entre Materiales Educativos y Autores
        public bool deleteMaterialAuthor(int _autorId, int _materialId)
        {
            bool executed = false;
            int row;

            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "procDeleteAuthors_has_education_mat"; // Nombre actualizado del procedimiento almacenado
            objDeleteCmd.CommandType = CommandType.StoredProcedure;
            objDeleteCmd.Parameters.Add("v_tbl_autores_au_id", MySqlDbType.Int32).Value = _autorId;
            objDeleteCmd.Parameters.Add("v_tbl_material_edu_mat_id", MySqlDbType.Int32).Value = _materialId;

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