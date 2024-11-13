using System;
using System.Data;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFCategorias : System.Web.UI.Page
    {
        CategoryLog categoryLogic = new CategoryLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias(); // Llamada para cargar las categorías al inicio
            }
        }

        // Dentro de la clase 'WFCategorias'
        private void CargarCategorias()
        {
            // Instancia de la capa lógica de categorías
            CategoryLog categoriaLogica = new CategoryLog();

            // Configura el origen de datos del GridView con el resultado del método showCategories de la capa lógica
            gvCategorias.DataSource = categoriaLogica.showCategories();

            // Vuelve a enlazar el GridView con los datos
            gvCategorias.DataBind();
        }


        private void LoadCategories()
        {
            DataSet ds = categoryLogic.showCategories();
            gvCategorias.DataSource = ds;
            gvCategorias.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;

            if (string.IsNullOrEmpty(txtID.Text)) // Nueva Categoría
            {
                if (categoryLogic.saveCategory(nombre, descripcion))
                {
                    lblMensaje.Text = "Categoría guardada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al guardar la categoría.";
                }
            }
            else // Actualizar Categoría
            {
                int id = int.Parse(txtID.Text);
                if (categoryLogic.updateCategory(id, nombre, descripcion))
                {
                    lblMensaje.Text = "Categoría actualizada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar la categoría.";
                }
            }

            ClearForm();
            LoadCategories();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlFormulario.Visible = true;
        }
        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvCategorias.Rows[e.NewEditIndex];
            txtID.Text = row.Cells[0].Text; // Asigna el ID al campo oculto
            txtNombre.Text = row.Cells[1].Text;
            txtDescripcion.Text = row.Cells[2].Text;

            pnlFormulario.Visible = true;
            gvCategorias.EditIndex = -1;
        }
        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCategorias.DataKeys[e.RowIndex].Value);

            if (categoryLogic.deleteCategory(id))
            {
                lblMensaje.Text = "Categoría eliminada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Error al eliminar la categoría.";
            }

            LoadCategories();
        }
        protected void gvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancela la edición en el GridView y regresa al modo de visualización normal
            gvCategorias.EditIndex = -1;

            // Vuelve a cargar las categorías en el GridView para mostrar los datos actualizados
            CargarCategorias();
        }

    }
}