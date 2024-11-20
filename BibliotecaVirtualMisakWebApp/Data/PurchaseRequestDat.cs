using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class PurchaseRequestDat
    {

        Persistence objPer = new Persistence();

        // Método para mostrar todos los PurchaseRequest
        public DataSet showPurchaseRequest()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectPurchase_request"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método DDL para mostrar los PurchaseRequest por id y su ticket
        public DataSet showPurchaseRequestDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectPurchase_requestDDL"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un PurchaseRequest
        public bool savePurchaserequest(string _v_solic_ticket, DateTime _v_solic_fecha, int _v_tbl_usu_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertPurchase_request"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_solic_ticket", MySqlDbType.VarChar).Value = _v_solic_ticket;
            objSelectCmd.Parameters.Add("v_solic_fecha", MySqlDbType.DateTime).Value = _v_solic_fecha;
            objSelectCmd.Parameters.Add("v_tbl_usuarios_usu_id", MySqlDbType.Int32).Value = _v_tbl_usu_id;
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

        // Método para actualizar un PurchaseRequest
        public bool updatePurchaserequest(int _v_solic_id, string _v_solic_ticket, DateTime _v_solic_fecha, int _v_tbl_usu_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdatePurchase_request"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_solic_id", MySqlDbType.Int32).Value = _v_solic_id; //Tipo int para el id
            objSelectCmd.Parameters.Add("v_solic_ticket", MySqlDbType.VarChar).Value = _v_solic_ticket; // Tipo VarChar para solicitud de tiquete
            objSelectCmd.Parameters.Add("v_solic_fecha", MySqlDbType.DateTime).Value = _v_solic_fecha; // Tipo DateTime para la fecha solicitud
            objSelectCmd.Parameters.Add("v_tbl_usuarios_usu_id", MySqlDbType.Int32).Value = _v_tbl_usu_id; // Tipo int para el is de usuarios


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

        // Método para borrar un PurchaseRequest
        public bool deletePurchaserequest(int _v_solic_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeletePurchase_request"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_solic_id", MySqlDbType.Int32).Value = _v_solic_id;
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
