using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFCategorias : System.Web.UI.Page
    {
        CategoryLog objCat = new CategoryLog();

        private int _idCategory;
        private string _nombre;
        private string _descripcion;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCategories();      // Llamada para cargar las categorías al inicio 
            }
        }

        // Mostrar todas las categorías en el GridView
        private void showCategories()
        {
            DataSet objData = new DataSet();
            objData = objCat.showCategories();  // Obtiene todas las categorías
            GVCategorias.DataSource = objData;   // Asigna el DataSet al GridView
            GVCategorias.DataBind();   // Enlaza los datos con el GridView 
        }

        private void Clear()
        {
            HFCatId.Value = "";
            TBNombre.Text = "";
            TBDescripcion.Text = "";
        }

        // Guardar una nueva categoría
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Capturar los datos de la categoría
            _nombre = TBNombre.Text;
            _descripcion = TBDescripcion.Text;
            // Llamada a la lógica para guardar la categoría
            executed = objCat.saveCategory(_nombre, _descripcion);

            if (executed)
            {
                LblMsj.Text = "¡Categoría guardada exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear(); // Limpiar los TextBox después de guardar
                showCategories(); // Mostrar las categorías actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al guardar categoría! Esta categoria no existe en el registro";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar una categoría existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCategory = Convert.ToInt32(HFCatId.Value);  // Obtener el ID de la categoría seleccionada
            _nombre = TBNombre.Text;    // Obtener el nombre de la categoría

            // Llamada a la lógica de negocio para actualizar la categoría
            executed = objCat.updateCategory(_idCategory, _nombre, _descripcion);

            if (executed)
            {
                LblMsj.Text = "¡Categoría actualizada exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showCategories();        // Mostrar las categorías actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar la categoría!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID de la categoría seleccionada

            HFCatId.Value = GVCategorias.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVCategorias.SelectedRow.Cells[1].Text;
            TBDescripcion.Text = GVCategorias.SelectedRow.Cells[2].Text;
        }

        // Evento para eliminar una categoría
        protected void GVCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idCategoria = Convert.ToInt32(GVCategorias.DataKeys[e.RowIndex].Values[0]);
            executed = objCat.deleteCategory(_idCategoria);

            if (executed)
            {
                LblMsj.Text = "Categoría se eliminó exitosamente";
                GVCategorias.EditIndex = -1;
                showCategories();
            }
            else
            {
                LblMsj.Text = "Error al eliminar categoría";
            }
        }
    }
}