using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFVisits : System.Web.UI.Page
    {
        VisitsLog objVis = new VisitsLog();
        UsersLog objVis = new UsersLog();



        private string _fecha_ingreso, _duracion;
        private int _usu_id;
        private bool executed = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showVisits();
                showUserDDL();

            }
        }

        //Metodo para mostrar todos las visitas
        private void showVisits()
        {
            DataSet ds = new DataSet();
            ds = objVis.showVisits();
            GVVisits.DataSource = ds;
            GVVisits.DataBind();
        }

        //Metodo para mostrar los usuarios en el DDL
        private void showUserDDL()
        {
            DDLUsers.DataSource = objVis.showUserDDL();
            DDLUsers.DataValueField = "usu_id";//Nombre de la llave primaria
            DDLUsers.DataBind();
            DDLUsers.Items.Insert(0, "Seleccione");
        }
        //Metodo para limpiar las cajas de texto y los selectores
        private void clear()
        {
            TBId.Text = "";
            TBFechaIngreso.Text = "";
            TBDuracion.Text = "";
            DDLUsers.SelectedIndex = 0;

        }
        //Evento que permite ocultar columnas en la GridView
        protected void GVVisits_RowDataBound(object sender, GridViewRowEventArgs e)
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

        //Metodo para mostrar las usuarios en el DDL
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
            _fecha_ingreso = TBFechaIngreso.Text;
            _duracion = TBDuracion.Text;
            _usu_id = Convert.ToInt32(DDLUsers.SelectedValue);


            executed = objVis.saveVisits(_fecha_ingreso, _duracion, _usu_id);

            if (executed)
            {
                LblMsj.Text = "La visita se guardo exitosamente!";
                showVisits();
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
            _fecha_ingreso = TBFechaIngreso.Text;
            _duracion = TBDuracion.Text;
            _usu_id = Convert.ToInt32(DDLUsers.SelectedValue);


            executed = objVis.updateVisits(_fecha_ingreso, _duracion, _usu_id);

            if (executed)
            {
                LblMsj.Text = "La visita se actualizo exitosamente!";
                showVisits();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        //Evento que permite pasar los datos de la GridView a los TextBox y DropDowList
        protected void GVVisits_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID de la visita al campo de texto TBId.
            TBId.Text = GVVisits.SelectedRow.Cells[1].Text;
            // Se asigna la fecha de ingreso de la visita al campo de texto TBfechaingreso.
            TBFechaIngreso.Text = GVVisits.SelectedRow.Cells[2].Text;
            // Se asigna la duracion de la visita al campo de texto TBDuracion.
            TBDuracion.Text = GVVisits.SelectedRow.Cells[3].Text;
            // Se asigna el usuario en el DropDownList DDLUser.
            DDLUser.SelectedValue = GVVisits.SelectedRow.Cells[4].Text;


        }
    }
}