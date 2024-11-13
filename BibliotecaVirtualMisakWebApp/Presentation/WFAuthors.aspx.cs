using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFAuthors : System.Web.UI.Page
    {

        AuthorsLog objPre = new AuthorsLog();

        private int _idAuthor;
        private string _nombre, _apellido, _municipio;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            /* 
             * Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!Page.IsPostBack)
            {
                showAuthors(); // Se invoca el metodo para mostrar todos los autores

            }

        }

        //Metodo para mostrar todos los autores
        private void showAuthors()
        {
            DataSet ds = new DataSet();
            ds = objPre.showAuthors();
            GVAuthors.DataSource = ds;
            GVAuthors.DataBind();
        }


        // Metodo para limpiar las cajas de texto 
        private void clear()
        {
            TBId.Text = "";
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBMunicipio.Text = "";
        }

        //Evento que permite ocultar columnas en la GridView (Optional)
        protected void GVAutors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
        }

        //Evento que se ejecuta al dar clic en el boton Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _municipio = TBMunicipio.Text;

            bool executed = objAut.saveAuthors(_nombre, _apellido, _municipio); // Replace with your save method

            if (executed)
            {
                LblMsj.Text = "El autor se guardo exitosamente!";
                showAuthors();
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
            _id = Convert.ToInt32(TBId.Text);
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _municipio = TBMunicipio.Text;

            bool executed = objAut.updateAuthors(_id, _nombre, _apellido, _municipio);

            if (executed)
            {
                LblMsj.Text = "El autor se actualizo exitosamente!";
                showAuthors();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        //Evento que permite pasar los datos de la GridView a los TextBox 
        protected void GVAutors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID del autor al campo de texto TBId.
            TBId.Text = GVAuthors.SelectedRow.Cells[1].Text;
            TBNombre.Text = GVAuthors.SelectedRow.Cells[1].Text;
            TBApellido.Text = GVAuthors.SelectedRow.Cells[1].Text;
            TBMunicipio.Text = GVAuthors.SelectedRow.Cells[1].Text;





        }


    }
}
}