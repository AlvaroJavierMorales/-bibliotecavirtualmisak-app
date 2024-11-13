using System;
using System.Data;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFEditorial : System.Web.UI.Page
    {
        EditorialLog editorialLogic = new EditorialLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEditoriales(); // Llamada para cargar las editoriales al inicio
            }
        }

        // Dentro de la clase 'WFEditorial'
        private void CargarEditoriales()
        {
            // Instancia de la capa lógica de editoriales
            EditorialLog editorialLogica = new EditorialLog();

            // Configura el origen de datos del GridView con el resultado del método showEditorials de la capa lógica
            gvEditoriales.DataSource = editorialLogica.showEditorials();

            // Vuelve a enlazar el GridView con los datos
            gvEditoriales.DataBind();
        }

        private void LoadEditoriales()
        {
            DataSet ds = editorialLogic.showEditorials();
            gvEditoriales.DataSource = ds;
            gvEditoriales.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string id = txtNombre.Text;
            string nombre = txtNombre.Text;
            string ciudad = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;

            if (string.IsNullOrEmpty(txtID.Text)) // Nueva Editorial
            {
                if (editorialLogic.SaveEditorial(nombre, ciudad, telefono, correo))
                {
                    lblMensaje.Text = "Editorial guardada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al guardar la editorial.";
                }
            }
            else // Actualizar Editorial
            {
                int id = int.Parse(txtID.Text);
                if (editorialLogic.updateEditorial(id, nombre, ciudad, telefono, correo))
                {
                    lblMensaje.Text = "Editorial actualizada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar la editorial.";
                }
            }

            ClearForm();
            LoadEditoriales();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlFormulario.Visible = true;
        }

        protected void gvEditoriales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvEditoriales.Rows[e.NewEditIndex];
            txtID.Text = row.Cells[0].Text; // Asigna el ID al campo oculto
            txtNombre.Text = row.Cells[2].Text;
            txtCiudad.Text = row.Cells[3].Text;
            txtTelefono.Text = row.Cells[4].Text;
            txtCorreo.Text = row.Cells[5].Text;

            pnlFormulario.Visible = true;
            gvEditoriales.EditIndex = -1;
        }

        protected void gvEditoriales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEditoriales.DataKeys[e.RowIndex].Value);

            if (editorialLogic.deleteEditorial(id))
            {
                lblMensaje.Text = "Editorial eliminada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Error al eliminar la editorial.";
            }

            LoadEditoriales();
        }

        protected void gvEditoriales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancela la edición en el GridView y regresa al modo de visualización normal
            gvEditoriales.EditIndex = -1;

            // Vuelve a cargar las editoriales en el GridView para mostrar los datos actualizados
            CargarEditoriales();
        }
    }
}
