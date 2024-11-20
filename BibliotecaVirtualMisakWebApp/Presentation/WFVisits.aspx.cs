
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFVisits : System.Web.UI.Page
    {
        VisitsLog objVis = new VisitsLog();
        UserLogic objuser = new UserLogic();


        private int _usu_id, _idVisits;
        private DateTime _fecha_ingreso;
        private TimeSpan _duracion;

        private bool executed = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showVisits();
                showUserDDL();

            }
        }
        //Metodo para mostrar los usuarios en el DDL
        private void showUserDDL()
        {
            DDLUsers.DataSource = objuser.showUserDDL();
            DDLUsers.DataValueField = "usu_id";//Nombre de la llave primaria
            DDLUsers.DataBind();
            DDLUsers.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        //Metodo para mostrar todos las visitas
        private void showVisits()
        {
            DataSet ds = new DataSet();
            ds = objVis.showVisits();
            GVVisits.DataSource = ds;
            GVVisits.DataBind();
        }


        //Metodo para limpiar las cajas de texto y los selectores
        private void clear()
        {
            HFVisitId.Value = "";
            TBFechaIngreso.Text = "";
            TBDuracion.Text = "";
            DDLUsers.SelectedIndex = 0;

        }

        //Evento que se ejecuta al dar clic en el boton Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            DateTime.TryParse(TBFechaIngreso.Text, out _fecha_ingreso);
            _duracion = TimeSpan.Parse(TBDuracion.Text);
            _usu_id = Convert.ToInt32(DDLUsers.SelectedValue);


            executed = objVis.saveVisits(_fecha_ingreso, _duracion, _usu_id);

            if (executed)
            {
                LblMsj.Text = "La visita se guardo exitosamente!";
                clear();
                showVisits();

            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        //Evento que se ejecuta al dar clic en el boton Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(TBFechaIngreso.Text, out _fecha_ingreso))
            {
                if (!string.IsNullOrEmpty(HFVisitId.Value) && int.TryParse(HFVisitId.Value, out _idVisits))
                {
                    _duracion = TimeSpan.Parse(TBDuracion.Text);
                    _usu_id = Convert.ToInt32(DDLUsers.SelectedValue);

                    executed = objVis.updateVisits(_idVisits, _usu_id, _fecha_ingreso, _duracion);


                    if (executed)
                    {
                        LblMsj.Text = "La visita se actualizo exitosamente!";
                        showVisits();
                    }
                    else
                    {
                        LblMsj.Text = "Error al actualizar";
                    }
                }

                else
                {
                    LblMsj.Text = "El ID de la visita es inválido. Por favor, verifica los datos";

                }

            }
        }
        protected void GVVisits_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID de la visita al campo de texto TBId.
            HFVisitId.Value = GVVisits.SelectedRow.Cells[0].Text;
            // Se asigna el usuario en el DropDownList DDLUser.
            DDLUsers.SelectedValue = GVVisits.SelectedRow.Cells[1].Text;
            // Se asigna la fecha de ingreso de la visita al campo de texto TBfechaingreso.
            TBFechaIngreso.Text = GVVisits.SelectedRow.Cells[2].Text;
            // Se asigna la duracion de la visita al campo de texto TBDuracion.
            TBDuracion.Text = GVVisits.SelectedRow.Cells[3].Text;



        }



        protected void GVVisits_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Obtener los parámetros desde los DataKeys del GridView
                int idVisits = Convert.ToInt32(GVVisits.DataKeys[e.RowIndex].Values["vis_id"]);
                int userId = Convert.ToInt32(GVVisits.DataKeys[e.RowIndex].Values["tbl_usuarios_usu_id"]);

                // Llamar al método de eliminación pasando los dos parámetros
                bool executed = objVis.deleteVisits(idVisits, userId);

                if (executed)
                {
                    LblMsj.Text = "¡Visita eliminada exitosamente!";
                    showVisits(); // Actualizar la vista de visitas
                }
                else
                {
                    LblMsj.Text = "Error al eliminar la visita. Inténtalo nuevamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                LblMsj.Text = "Ocurrió un error al intentar eliminar la visita. Por favor, contacta al soporte.";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
