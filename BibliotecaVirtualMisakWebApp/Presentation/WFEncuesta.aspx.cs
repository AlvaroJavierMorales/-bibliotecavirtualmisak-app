using System;
using System.Data;
using System.Web.UI.WebControls;
using Logic;


namespace Presentation
{
    public partial class WFEncuesta : System.Web.UI.Page
    {
        SurveyLogic objSurveyLogic = new SurveyLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los usuarios en el DropDownList
                LoadUsers();

                // Cargar las encuestas en el GridView
                LoadSurveys();
            }
        }

        // Método para cargar los usuarios en el DropDownList
        private void LoadUsers()
        {
            DataSet dsUsers = objSurveyLogic.showSurveysDDL(); // Asumo que showSurveysDDL() devuelve los usuarios
            ddlUsuario.DataSource = dsUsers;
            ddlUsuario.DataTextField = "usu_nombre"; // Ajusta el campo que deseas mostrar
            ddlUsuario.DataValueField = "usu_id"; // Ajusta el campo que deseas usar como valor
            ddlUsuario.DataBind();
        }

        // Método para cargar las encuestas en el GridView
        private void LoadSurveys()
        {
            DataSet dsSurveys = objSurveyLogic.showSurveys();
            gvSurveys.DataSource = dsSurveys;
            gvSurveys.DataBind();
        }

        // Evento para guardar una nueva encuesta
        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            // Obtener la descripción de la pregunta
            string descripcionPregunta = txtDescripcionPregunta.Text.Trim();

            // Verificar que se ha seleccionado un usuario
            int usuId = 0;
            bool isValidUserId = int.TryParse(ddlUsuario.SelectedValue, out usuId);

            if (!isValidUserId || usuId <= 0)
            {
                lblMessage.Text = "Por favor, seleccione un usuario válido.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return; // Detener la ejecución si el ID del usuario no es válido
            }

            // Llamar al método saveSurvey para guardar la encuesta
            bool result = objSurveyLogic.saveSurvey(descripcionPregunta, usuId);

            // Mostrar mensaje de éxito o error según el resultado
            if (result)
            {
                lblMessage.Text = "Encuesta guardada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearFields(); // Limpiar los campos después de guardar
            }
            else
            {
                lblMessage.Text = "Error al guardar la encuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            // Recargar las encuestas
            gvSurveys.DataBind();
        }

        private void ClearFields()
        {
            txtDescripcionPregunta.Text = string.Empty;
            ddlUsuario.SelectedIndex = -1; // Desmarcar el DropDownList
        }


        // Evento para actualizar una encuesta
        protected void btnActualizarEncuesta_Click(object sender, EventArgs e)
        {
            int enId = int.Parse(hdfEncuestaId.Value);
            string descripcionPregunta = txtDescripcionPregunta.Text.Trim();
            int usuId = int.Parse(ddlUsuario.SelectedValue);

            if (objSurveyLogic.updateSurvey(enId, usuId, descripcionPregunta))
            {
                lblMessage.Text = "Encuesta actualizada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadSurveys(); // Recargar el GridView
                btnActualizarEncuesta.Visible = false; // Ocultar el botón de actualizar
                btnGuardarEncuesta.Visible = true; // Mostrar el botón de guardar
            }
            else
            {
                lblMessage.Text = "Error al actualizar la encuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //Evento de edición de la encuesta
        // Evento de edición de la encuesta
        protected void gvSurveys_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int enId = Convert.ToInt32(gvSurveys.DataKeys[e.NewEditIndex].Value);

            // Obtener el DataSet de las encuestas
            DataSet dsSurveys = objSurveyLogic.showSurveys();

            // Buscar la encuesta por ID
            DataRow[] foundRows = dsSurveys.Tables[0].Select("en_id = " + enId);

            if (foundRows.Length > 0)
            {
                // Obtener los datos de la encuesta encontrada
                DataRow row = foundRows[0];
                txtDescripcionPregunta.Text = row["en_descripcion_pregunta"].ToString();
                ddlUsuario.SelectedValue = row["tbl_usuarios_usu_id"].ToString();
                hdfEncuestaId.Value = enId.ToString();

                // Mostrar el botón de actualizar y ocultar el de guardar
                btnActualizarEncuesta.Visible = true;
                btnGuardarEncuesta.Visible = false;
            }
        }


        // Evento para eliminar una encuesta
        protected void gvSurveys_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int enId = Convert.ToInt32(gvSurveys.DataKeys[e.RowIndex].Value);
            int usuId = int.Parse(ddlUsuario.SelectedValue); // Puedes modificar esta parte según cómo se obtiene el usuario actual

            if (objSurveyLogic.deleteSurvey(enId, usuId))
            {
                lblMessage.Text = "Encuesta eliminada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadSurveys(); // Recargar el GridView
            }
            else
            {
                lblMessage.Text = "Error al eliminar la encuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        // Evento para manejar los comandos de las filas
        protected void gvSurveys_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Verificar si el comando es para eliminar o editar
            if (e.CommandName == "Delete")
            {
                // Obtener el ID de la encuesta
                int enId = Convert.ToInt32(e.CommandArgument);

                // Eliminar la encuesta
                bool success = objSurveyLogic.deleteSurvey(enId, 1);  // Puedes pasar el ID del usuario actual si es necesario

                if (success)
                {
                    lblMessage.Text = "Encuesta eliminada correctamente.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error al eliminar la encuesta.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                // Recargar la lista de encuestas después de la eliminación
                gvSurveys.DataBind();
            }
        }

    }
}