
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFPurchaseRequest : System.Web.UI.Page
    {
        PurchaseRequestLog objPur = new PurchaseRequestLog();
        UserLogic objuser = new UserLogic();


        private int _v_solic_id, _v_tbl_usu_id;
        private string _v_solic_ticket;
        private DateTime _v_solic_fecha;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showPurchaseRequest();
                showUserDDL();

            }

        }
        private void showUserDDL()
        {
            DDLUsers.DataSource = objuser.showUserDDL();
            DDLUsers.DataValueField = "usu_id";//Nombre de la llave primaria
            DDLUsers.DataBind();
            DDLUsers.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void showPurchaseRequest()
        {
            DataSet ds = new DataSet();
            ds = objPur.showPurchaseRequest();
            GVRequests.DataSource = ds;
            GVRequests.DataBind();
        }

        //Metodo para mostrar los usuarios en el DDL


        private void clear()
        {

            HFPurchaId.Value = "";
            TBTicket.Text = "";
            TBFecha.Text = "";
            DDLUsers.SelectedIndex = 0;

        }


        //Evento que se ejecuta al dar clic en el boton Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(TBFecha.Text, out _v_solic_fecha))
            {
                _v_solic_ticket = TBTicket.Text;
                _v_tbl_usu_id = Convert.ToInt32(DDLUsers.SelectedValue);

                executed = objPur.savePurchaserequest(_v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);

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
            else
            {
                LblMsj.Text = "Por favor, ingrese una fecha válida.";
            }

        }



        //Evento que se ejecuta al dar clic en el boton Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(TBFecha.Text, out _v_solic_fecha))
            {
                // Convertir el valor del HiddenField a entero
                if (!string.IsNullOrEmpty(HFPurchaId.Value) && int.TryParse(HFPurchaId.Value, out _v_solic_id))
                {
                    _v_solic_ticket = TBTicket.Text;
                    _v_tbl_usu_id = Convert.ToInt32(DDLUsers.SelectedValue);

                    executed = objPur.updatePurchaserequest(_v_solic_id, _v_solic_ticket, _v_solic_fecha, _v_tbl_usu_id);

                    if (executed)
                    {
                        LblMsj.Text = "¡La solicitud se actualizó exitosamente!";
                        showPurchaseRequest();
                    }
                    else
                    {
                        LblMsj.Text = "Error al actualizar";
                    }
                }
                else
                {
                    LblMsj.Text = "El ID de la solicitud es inválido. Por favor, verifica los datos.";
                }
            }
            else
            {
                LblMsj.Text = "Por favor, ingresa una fecha válida.";
            }
        }

        protected void GVRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID de la visita al campo de texto TBId.
            HFPurchaId.Value = GVRequests.SelectedRow.Cells[0].Text;
            // Se asigna la fecha de ingreso de la visita al campo de texto TBfechaingreso.
            TBTicket.Text = GVRequests.SelectedRow.Cells[1].Text;
            // Se asigna la duracion de la visita al campo de texto TBDuracion.
            TBFecha.Text = GVRequests.SelectedRow.Cells[2].Text;
            // Se asigna el usuario en el DropDownList DDLUser.
            DDLUsers.SelectedValue = GVRequests.SelectedRow.Cells[3].Text;


        }

        protected void GVRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Obtener el ID de la solicitud desde las claves de datos del GridView
                int idVisits = Convert.ToInt32(GVRequests.DataKeys[e.RowIndex].Values[0]);

                // Llamar al método de eliminación con el ID correcto
                bool executed = objPur.deletePurchaserequest(idVisits);

                if (executed)
                {
                    LblMsj.Text = "¡Solicitud eliminada exitosamente!";
                    showPurchaseRequest(); // Actualizar la vista de solicitudes
                }
                else
                {
                    LblMsj.Text = "Error al eliminar la solicitud. Inténtalo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                LblMsj.Text = "Ocurrió un error al intentar eliminar la solicitud. Por favor, contacta al soporte.";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }




    }


}

