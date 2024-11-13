using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFGestionUsuarios : System.Web.UI.Page
    {
        // Instancia de la clase de lógica de usuarios
        UserLogic objUser = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            DataSet ds = objUser.showUsers();
            if (ds != null && ds.Tables.Count > 0)
            {
                GVUsers.DataSource = ds.Tables[0];
                GVUsers.DataBind();
            }
            else
            {
                // Maneja el caso en que no haya datos
                GVUsers.DataSource = null;
                GVUsers.DataBind();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Recoger los valores de los campos de la interfaz
            string nombre = TBFirstName.Text;
            string apellido = TBLastName.Text;
            string correo = TBEmail.Text;
            string contrasena = TBPassword.Text;
            string salt = TBSalt.Text;
            string rol = DDLRole.SelectedValue; // Obtenemos el rol seleccionado
            string nivelEstudios = DDLEducationLevel.SelectedValue; // Obtenemos el nivel de estudios seleccionado

            // Aquí llamamos al método saveUser para guardar el usuario
            bool success = objUser.saveUser(nombre, apellido, correo, contrasena, salt, rol, nivelEstudios);
            if (success)
            {
                LblMessage.Text = "Usuario guardado exitosamente.";
            }
            else
            {
                LblMessage.Text = "Error al guardar el usuario.";
            }

            // Limpiar los campos después de guardar
            ClearForm();
            LoadUsers();  // Recargar los usuarios para reflejar los cambios
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Actualizar un usuario existente
            int userId = int.Parse(HFUserId.Value);
            string nombre = TBFirstName.Text;
            string apellido = TBLastName.Text;
            string correo = TBEmail.Text;
            string contrasena = TBPassword.Text;
            string salt = TBSalt.Text;
            string rol = DDLRole.SelectedValue; // Obtenemos el rol seleccionado
            string nivelEstudios = DDLEducationLevel.SelectedValue; // Obtenemos el nivel de estudios seleccionado

            bool success = objUser.updateUser(userId, nombre, apellido, correo, contrasena, salt, rol, nivelEstudios);
            LblMessage.Text = success ? "Usuario actualizado con éxito." : "Error al actualizar el usuario.";

            ClearForm();
            LoadUsers();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // Eliminar el usuario seleccionado
            int userId = int.Parse(HFUserId.Value);

            bool success = objUser.deleteUser(userId);
            LblMessage.Text = success ? "Usuario eliminado con éxito." : "Error al eliminar el usuario.";

            ClearForm();
            LoadUsers();
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVUsers.SelectedRow;
            HFUserId.Value = row.Cells[0].Text;
            TBFirstName.Text = row.Cells[1].Text;
            TBLastName.Text = row.Cells[2].Text;
            TBEmail.Text = row.Cells[3].Text;

            // Obtén el texto del rol y del nivel de estudios de las celdas del GridView
            string rol = row.Cells[4].Text; // Asegúrate de que esté en el índice correcto
            string nivelEstudios = row.Cells[5].Text; // Asegúrate de que esté en el índice correcto

            // Asigna el valor al DropDownList correspondiente
            DDLRole.SelectedValue = rol;
            DDLEducationLevel.SelectedValue = nivelEstudios;
        }

        private void ClearForm()
        {
            // Limpiar los campos del formulario
            HFUserId.Value = string.Empty;
            TBFirstName.Text = string.Empty;
            TBLastName.Text = string.Empty;
            TBEmail.Text = string.Empty;
            TBPassword.Text = string.Empty;
            TBSalt.Text = string.Empty;
            DDLRole.SelectedIndex = 0; // Reiniciar el valor del DropDownList de roles
            DDLEducationLevel.SelectedIndex = 0; // Reiniciar el valor del DropDownList de niveles de estudios
            LblMessage.Text = string.Empty;
        }
    }
}
