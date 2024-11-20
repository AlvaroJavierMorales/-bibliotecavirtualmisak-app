using System;
using Logic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;

namespace Presentation
{
    public partial class WFRegistroUsuarios : System.Web.UI.Page
    {
        UserLogic objUserLogic = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            // No es necesario cargar nada para el GridView
        }

        // Método que se ejecuta cuando se hace clic en el botón "Guardar"
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string nombre = TBFirstName.Text.Trim();
            string apellido = TBLastName.Text.Trim();
            string correo = TBEmail.Text.Trim();
            string contrasena = TBPassword.Text.Trim();
            string salt = TBSalt.Text.Trim();
            string rol = DDLRole.SelectedValue;
            string nivelEstudios = DDLEducationLevel.SelectedValue;

            // Validación básica (puedes agregar más validaciones según sea necesario)
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(rol) ||
                string.IsNullOrEmpty(nivelEstudios))
            {
                LblMessage.Text = "Por favor, complete todos los campos.";
                return;
            }

            // Validación del nivel de estudios (opcional)
            List<string> nivelesValidos = new List<string> { "Primaria", "Secundaria", "Bachillerato", "Técnico", "Tecnólogo", "Pregrado", "Especialización", "Maestría", "Doctorado", "Postdoctorado" };
            if (!nivelesValidos.Contains(nivelEstudios))
            {
                LblMessage.Text = "Nivel de estudios no válido.";
                return;
            }

            // Llamamos al método de la lógica de negocio para guardar el usuario
            bool resultado = objUserLogic.saveUser(nombre, apellido, correo, contrasena, salt, rol, nivelEstudios);

            if (resultado)
            {
                LblMessage.Text = "Usuario guardado exitosamente.";
                clearFields(); // Limpiar las casillas después de guardar
            }
            else
            {
                LblMessage.Text = "Error al guardar el usuario.";
            }
        }

        // Método para limpiar las casillas
        private void clearFields()
        {
            TBFirstName.Text = "";
            TBLastName.Text = "";
            TBEmail.Text = "";
            TBPassword.Text = "";
            TBSalt.Text = "";
            DDLRole.SelectedIndex = 0;
            DDLEducationLevel.SelectedIndex = 0;
        }
    }
}
