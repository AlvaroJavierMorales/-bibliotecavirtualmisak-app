using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
        public class MaterialEduDat
        {
            Persistence objPer = new Persistence();

            // Método para mostrar todos los registros de Material Educativo
            public DataSet showMaterials()
            {
                MySqlDataAdapter objAdapter = new MySqlDataAdapter();
                DataSet objData = new DataSet();

                MySqlCommand objSelectCmd = new MySqlCommand();
                objSelectCmd.Connection = objPer.openConnection();
                objSelectCmd.CommandText = "procSelectEducation_mat"; // Nombre actualizado del procedimiento almacenado
                objSelectCmd.CommandType = CommandType.StoredProcedure;
                objAdapter.SelectCommand = objSelectCmd;
                objAdapter.Fill(objData);
                objPer.closeConnection();
                return objData;
            }

            // Método para insertar un nuevo Material Educativo
            public bool saveMaterial(string _titulo, DateTime _anoPublicacion, string _urlDescarga, decimal _precio, int _cantidad, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
            {
                bool executed = false;
                int row;

                MySqlCommand objInsertCmd = new MySqlCommand();
                objInsertCmd.Connection = objPer.openConnection();
                objInsertCmd.CommandText = "procInsertEducation_mat"; // Nombre del procedimiento almacenado
                objInsertCmd.CommandType = CommandType.StoredProcedure;
                objInsertCmd.Parameters.Add("v_mat_titulo", MySqlDbType.VarChar).Value = _titulo;
                objInsertCmd.Parameters.Add("v_mat_ano_publicacion", MySqlDbType.Date).Value = _anoPublicacion;
                objInsertCmd.Parameters.Add("v_mat_url_descarga", MySqlDbType.Text).Value = _urlDescarga;
                objInsertCmd.Parameters.Add("v_mat_precio", MySqlDbType.Decimal).Value = _precio;
                objInsertCmd.Parameters.Add("v_mat_cantidad", MySqlDbType.SmallInt).Value = _cantidad;
                objInsertCmd.Parameters.Add("v_tbl_editorial_edi_id", MySqlDbType.Int32).Value = _editorialId;
                objInsertCmd.Parameters.Add("v_tbl_categorias_cat_id", MySqlDbType.Int32).Value = _categoriaId;
                objInsertCmd.Parameters.Add("v_tbl_solicitud_compra_solic_id", MySqlDbType.Int32).Value = _solicitudCompraId;
                objInsertCmd.Parameters.Add("v_tbl_visitas_vis_id", MySqlDbType.Int32).Value = _visitasId;

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

            // Método para actualizar un Material Educativo
            public bool updateMaterial(int _idMaterial, string _titulo, DateTime _anoPublicacion, string _urlDescarga, decimal _precio, int _cantidad, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
            {
                bool executed = false;
                int row;

                MySqlCommand objUpdateCmd = new MySqlCommand();
                objUpdateCmd.Connection = objPer.openConnection();
                objUpdateCmd.CommandText = "procUpdateEducation_mat"; // Nombre actualizado del procedimiento almacenado
                objUpdateCmd.CommandType = CommandType.StoredProcedure;
                objUpdateCmd.Parameters.Add("v_mat_id", MySqlDbType.Int32).Value = _idMaterial;
                objUpdateCmd.Parameters.Add("v_mat_titulo", MySqlDbType.VarChar).Value = _titulo;
                objUpdateCmd.Parameters.Add("v_mat_ano_publicacion", MySqlDbType.Date).Value = _anoPublicacion;
                objUpdateCmd.Parameters.Add("v_mat_url_descarga", MySqlDbType.Text).Value = _urlDescarga;
                objUpdateCmd.Parameters.Add("v_mat_precio", MySqlDbType.Decimal).Value = _precio;
                objUpdateCmd.Parameters.Add("v_mat_cantidad", MySqlDbType.SmallInt).Value = _cantidad;
                objUpdateCmd.Parameters.Add("v_tbl_editorial_edi_id", MySqlDbType.Int32).Value = _editorialId;
                objUpdateCmd.Parameters.Add("v_tbl_categorias_cat_id", MySqlDbType.Int32).Value = _categoriaId;
                objUpdateCmd.Parameters.Add("v_tbl_solicitud_compra_solic_id", MySqlDbType.Int32).Value = _solicitudCompraId;
                objUpdateCmd.Parameters.Add("v_tbl_visitas_vis_id", MySqlDbType.Int32).Value = _visitasId;

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

            // Método para eliminar un Material Educativo
            public bool deleteMaterial(int _idMaterial, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
            {
                bool executed = false;
                int row;

                MySqlCommand objDeleteCmd = new MySqlCommand();
                objDeleteCmd.Connection = objPer.openConnection();
                objDeleteCmd.CommandText = "procDeleteEducation_mat"; // Nombre actualizado del procedimiento almacenado
                objDeleteCmd.CommandType = CommandType.StoredProcedure;
                objDeleteCmd.Parameters.Add("v_mat_id", MySqlDbType.Int32).Value = _idMaterial;
                objDeleteCmd.Parameters.Add("v_tbl_editorial_edi_id", MySqlDbType.Int32).Value = _editorialId;
                objDeleteCmd.Parameters.Add("v_tbl_categorias_cat_id", MySqlDbType.Int32).Value = _categoriaId;
                objDeleteCmd.Parameters.Add("v_tbl_solicitud_compra_solic_id", MySqlDbType.Int32).Value = _solicitudCompraId;
                objDeleteCmd.Parameters.Add("v_tbl_visitas_vis_id", MySqlDbType.Int32).Value = _visitasId;

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