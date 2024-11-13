using System;
using System.Data;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFRespuestas : System.Web.UI.Page
    {
        private AnswerLogic answerLogic = new AnswerLogic();

        // Cargar las respuestas al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRespuestas();
                CargarEncuestas();
            }
        }

        // Método para cargar todas las respuestas en el GridView
        private void CargarRespuestas()
        {
            DataSet ds = answerLogic.showAnswers();
            gvAnswers.DataSource = ds;
            gvAnswers.DataBind();
        }

        // Método para cargar las encuestas en el DropDownList
        private void CargarEncuestas()
        {
            // Aquí deberías cargar las encuestas desde la base de datos, algo similar al método CargarRespuestas
            // Por ejemplo, usando el método de la lógica que ya tienes para cargar encuestas
            // ddlEncuesta.DataSource = encuestaLogic.showSurveys();
            // ddlEncuesta.DataTextField = "en_descripcion_pregunta";
            // ddlEncuesta.DataValueField = "en_id";
            // ddlEncuesta.DataBind();
        }

        // Evento para guardar una nueva respuesta
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string respuesta = txtRespuesta.Text; // Se asegura de usar el ID correcto del TextBox
            int encuestaId = int.Parse(ddlEncuesta.SelectedValue);

            if (answerLogic.saveAnswer(respuesta, encuestaId))
            {
                lblMessage.Text = "Respuesta guardada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                CargarRespuestas();
                LimpiarFormulario();
            }
            else
            {
                lblMessage.Text = "Error al guardar la respuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para actualizar una respuesta
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int idRespuesta = int.Parse(hdfAnswerId.Value); // Ahora se toma el ID desde el HiddenField
            string respuesta = txtRespuesta.Text;
            int encuestaId = int.Parse(ddlEncuesta.SelectedValue);

            if (answerLogic.updateAnswer(idRespuesta, respuesta, encuestaId))
            {
                lblMessage.Text = "Respuesta actualizada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                CargarRespuestas();
                LimpiarFormulario();
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
            }
            else
            {
                lblMessage.Text = "Error al actualizar la respuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Método para limpiar el formulario
        private void LimpiarFormulario()
        {
            txtRespuesta.Text = string.Empty;
            ddlEncuesta.SelectedIndex = 0;
            hdfAnswerId.Value = string.Empty; // Escondido para almacenar el ID de la respuesta cuando se edita
        }

        // Evento para editar una respuesta
        protected void gvAnswers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAnswers.EditIndex = e.NewEditIndex;
            CargarRespuestas(); // Recarga los datos después de habilitar la edición
        }

        // Evento para eliminar una respuesta
        protected void gvAnswers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idRespuesta = Convert.ToInt32(gvAnswers.DataKeys[e.RowIndex].Value);

            if (answerLogic.deleteAnswer(idRespuesta))
            {
                lblMessage.Text = "Respuesta eliminada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                CargarRespuestas();
            }
            else
            {
                lblMessage.Text = "Error al eliminar la respuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para obtener los datos de la respuesta a editar
        protected void gvAnswers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAnswers.Rows[rowIndex];

                // Obtén los valores de la respuesta a editar
                hdfAnswerId.Value = row.Cells[0].Text;
                txtRespuesta.Text = row.Cells[1].Text;
                ddlEncuesta.SelectedValue = row.Cells[2].Text;

                // Mostrar el botón de actualización y ocultar el de guardar
                btnGuardar.Visible = false;
                btnActualizar.Visible = true;
            }
        }
        protected void ddlEncuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tu lógica aquí, por ejemplo:
            var selectedValue = ddlEncuesta.SelectedValue;
            // Procesar la selección de la encuesta
        }
    }
}
