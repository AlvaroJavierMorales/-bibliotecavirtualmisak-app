using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class PurchaseRequestLog
    {
        PurchaseRequestDat objPur = new PurchaseRequestDat();


        // Metodo para mostrar
        public DataSet showPurchaseRequest()
        {
            return objPur.showPurchaseRequest();

        }

        //Metodo DDL
        public DataSet showPurchaseRequestDDL()
        {
            return objPur.showPurchaseRequestDDL();

        }

        // Metodo para guardar
        public bool savePurchaserequest(string _v_solic_ticket, DateTime _v_solic_fecha, int _v_tbl_usu_id)
        {
            return objPur.savePurchaserequest(_v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);
        }

        // Metodo para actualizar 
        public bool updatePurchaserequest(int _v_solic_id, string _v_solic_ticket, DateTime _v_solic_fecha, int _v_tbl_usu_id)
        {
            return objPur.updatePurchaserequest(_v_solic_id, _v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);
        }

        // Metodo para eliminar
        public bool deletePurchaserequest(int _v_solic_id)
        {
            return objPur.deletePurchaserequest(_v_solic_id);
        }
    }
}
