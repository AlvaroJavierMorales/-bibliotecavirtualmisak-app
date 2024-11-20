using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFEditorial : System.Web.UI.Page
    {
        EditorialLog objEdit = new EditorialLog();

        private int _idEditorial;
        private string _nombre;
        private string _ciudad;
        private int _telefono;
        private string _correo;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showEditorials();      // Llamada para cargar las editoriales al inicio 
            }
        }
        // Mostrar todos los clientes en el GridView
        private void showEditorials()
        {
            DataSet objData = new DataSet();
            objData = objEdit.showEditorials();  // Obtiene todos los clientes
            GVEditorial.DataSource = objData;   // Asigna el DataSet al GridView
            GVEditorial.DataBind();   // Enlaza los datos con el GridView 
        }
        private void Clear()
        {
            HFEditId.Value = "";
            TBNombre.Text = "";
            TBCiudad.Text = "";
            TBTelefono.Text = "";
            TBCorreo.Text = "";
        }
        // Guardar un nuevo editoirial
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Capturar los datos de la ediotorial

            _nombre = TBNombre.Text;
            _ciudad = TBCiudad.Text;
            _telefono = (int)Convert.ToUInt64(TBTelefono.Text);
            _correo = TBCorreo.Text;
            // Llamada a la lógica para guardar la editorial
            executed = objEdit.saveEditorial(_nombre, _ciudad, _telefono, _correo);

            if (executed)
            {
                LblMsj.Text = "¡Editorial guardado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear(); // Limpiar los TextBox después de guardar
                showEditorials(); // Mostrar los clientes actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al guardar editorial!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar un cliente existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Obtener los datos del cliente
            _idEditorial = (int)Convert.ToInt32(HFEditId.Value);
            _nombre = TBNombre.Text;
            _ciudad = TBCiudad.Text;
            _telefono = (int)Convert.ToInt64(TBTelefono.Text);
            _correo = TBCorreo.Text;


            // Llamada a la lógica de negocio para actualizar el cliente
            executed = objEdit.updateEditorial(_idEditorial, _nombre, _ciudad, _telefono, _correo);

            if (executed)
            {
                LblMsj.Text = "¡Editorial actualizado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showEditorials(); // Mostrar los clientes actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar Editorial!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del cliente seleccionado
            GridViewRow row = GVEditorial.SelectedRow;
            HFEditId.Value = GVEditorial.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVEditorial.SelectedRow.Cells[1].Text;
            TBCiudad.Text = GVEditorial.SelectedRow.Cells[2].Text;
            TBTelefono.Text = GVEditorial.SelectedRow.Cells[3].Text;
            TBCorreo.Text = GVEditorial.SelectedRow.Cells[4].Text;
        }

        // Evento para eliminar un cliente
        protected void GVEditorial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idEditorial = Convert.ToInt32(GVEditorial.DataKeys[e.RowIndex].Values[0]);
            executed = objEdit.deleteEditorial(_idEditorial);

            if (executed)
            {
                LblMsj.Text = "Editorial se eliminó exitosamente";
                GVEditorial.EditIndex = -1;
                showEditorials();
            }
            else
            {
                LblMsj.Text = "Error al eliminar Editorial";
            }
        }
    }
}