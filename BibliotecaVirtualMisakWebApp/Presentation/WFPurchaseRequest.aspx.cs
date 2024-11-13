using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFPurchaseRequest : System.Web.UI.Page
    {
        PurchaseRequestLog objPur = new PurchaseRequestLog();
        UsersLog objPur = new UsersLog();


        private int _v_solic_id, _v_tbl_usu_id;
        private string _v_solic_ticket, _v_solic_fecha;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showPurchaseRequest();
                showPurchaseRequestDDL();

            }

        }

        private void showPurchaseRequest()
        {
            DataSet ds = new DataSet();
            ds = objPur.showPurchaseRequest();
            GVRequests.DataSource = ds;
            GVRequests.DataBind();
        }

        //Metodo para mostrar los usuarios en el DDL
        private void showPurchaseRequestDDL()
        {
            DDLUsers.DataSource = objPur.showUserDDL();
            DDLUsers.DataValueField = "usu_id";//Nombre de la llave primaria
            DDLUsers.DataTextField = "usu_nombre";
            DDLUsers.DataBind();
            DDLUsers.Items.Insert(0, "Seleccione");
        }

        private void clear()
        {

            TBId.Text = "";
            TBTicket.Text = "";
            TBFecha.Text = "";
            DDLUsers.SelectedIndex = 0;

        }
        //Evento que permite ocultar columnas en la GridView
        protected void GVRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
        }

        private void showUserDDL()
        {
            // Se asigna el origen de datos al DropDownList,
            // utilizando el método showVisitsDDL de la instancia objCat de la clase VisitsLog.
            DDLUsers.DataSource = objVis.showUserDDL();

            // Se especifica el campo que se utilizará como valor de cada elemento del DropDownList.
            DDLUsers.DataValueField = "usu_id";

            // Se especifica el campo que se mostrará como texto para cada elemento del DropDownList.
            DDLUsers.DataTextField = "usu_correo";

            // Se enlaza el origen de datos con el DropDownList.
            DDLUsers.DataBind();

            // Se agrega un elemento "Seleccione" al principio del DropDownList para indicar al usuario que elija una visita.
            DDLUsers.Items.Insert(0, "Seleccione");
        }

        //Evento que se ejecuta al dar clic en el boton Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            _v_solic_id = TBId.Text;
            _v_solic_ticket = TBTicket.Text;
            _v_solic_fecha = TBFecha.Text;
            _v_tbl_usu_id = Convert.ToInt32(DDLUsers.SelectedValue);


            executed = objPur.savePurchaserequest(_v_solic_id, _v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);

            if (executed)
            {
                LblMsj.Text = "La solicitud de compra se guardo exitosamente!";
                showPurchaseRequest();
                clear();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        //Evento que se ejecuta al dar clic en el boton Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            _v_solic_id = TBId.Text;
            _v_solic_ticket = TBTicket.Text;
            _v_solic_fecha = TBFecha.Text;
            _v_tbl_usu_id = Convert.ToInt32(DDLUsers.SelectedValue);


            executed = objPur.updatePurchaserequest(_v_solic_id, _v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);

            if (executed)
            {
                LblMsj.Text = "La visita se actualizo exitosamente!";
                showPurchaseRequest();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        //Evento que permite pasar los datos de la GridView a los TextBox y DropDowList
        protected void GVRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID de la visita al campo de texto TBId.
            TBId.Text = GVRequests.SelectedRow.Cells[1].Text;
            // Se asigna la fecha de ingreso de la visita al campo de texto TBfechaingreso.
            TBTicket.Text = GVRequests.SelectedRow.Cells[2].Text;
            // Se asigna la duracion de la visita al campo de texto TBDuracion.
            TBFecha.Text = GVRequests.SelectedRow.Cells[3].Text;
            // Se asigna el usuario en el DropDownList DDLUser.
            DDLUser.SelectedValue = GVRequests.SelectedRow.Cells[4].Text;


        }
    }
}
    }
}