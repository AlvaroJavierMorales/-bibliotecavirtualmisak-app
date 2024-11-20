using Logic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFRespuestas : System.Web.UI.Page
    {
        AnswerLogic objAnswerDat = new AnswerLogic();
        SurveyLogic objSurveyDat = new SurveyLogic();


        private int _idRespuesta, _en_id;
        private string _respuesta;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showAnswers(); // Se invoca el método para mostrar todas las respuestas
                showSurveysDDL(); // Se invoca el método para mostrar las encuestas en el DDL
            }
        }
        // Método para mostrar las encuestas en el DropDownList
        private void showSurveysDDL()
        {
            ddlEncuesta.DataSource = objSurveyDat.showSurveys();
            ddlEncuesta.DataValueField = "en_id";
            ddlEncuesta.DataTextField = "en_descripcion_pregunta";
            ddlEncuesta.DataBind();
            ddlEncuesta.Items.Insert(0, "Seleccione");
        }




        //Metodo para mostrar las respuestas 
        // Modificación del método showAnswers() para evitar duplicados
        private void showAnswers()
        {
            gvAnswers.DataSource = null; // Limpia cualquier dato previo.
            DataSet ds = objAnswerDat.showAnswers();  // Aquí debes revisar si hay duplicados en la base de datos

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                // Eliminar filas duplicadas por ID
                var distinctRows = dt.AsEnumerable()
                                     .GroupBy(r => r.Field<int>("res_id"))
                                     .Select(g => g.First())
                                     .CopyToDataTable();

                gvAnswers.DataSource = distinctRows;
                gvAnswers.DataBind();
            }
            else
            {
                lblMessage.Text = "No hay respuestas disponibles.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                lblMessage.Text = "Por favor, ingrese una respuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(ddlEncuesta.SelectedValue))
            {
                lblMessage.Text = "Por favor, seleccione una encuesta válida.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Llamada al método para guardar la respuesta
            _respuesta = txtRespuesta.Text;
            _en_id = Convert.ToInt32(ddlEncuesta.SelectedValue);

            bool executed = objAnswerDat.saveAnswer(_respuesta, _en_id);
            if (executed)
            {
                lblMessage.Text = "Respuesta guardada exitosamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                clear();
                showAnswers();
            }
            else
            {
                lblMessage.Text = "Error al guardar la respuesta o ya tienes registrado esta pregunta";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                lblMessage.Text = "Por favor, ingrese una respuesta válida.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlEncuesta.SelectedValue == "Seleccione")
            {
                lblMessage.Text = "Por favor, seleccione una encuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            _idRespuesta = Convert.ToInt32(hdfAnswerId.Value);
            _respuesta = txtRespuesta.Text.Trim();
            _en_id = Convert.ToInt32(ddlEncuesta.SelectedValue);

            try
            {
                executed = objAnswerDat.updateAnswer(_idRespuesta, _respuesta, _en_id);

                if (executed)
                {
                    lblMessage.Text = "Respuesta actualizada exitosamente.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    clear();
                    showAnswers();
                    btnGuardar.Visible = true;
                    btnActualizar.Visible = false;
                }
                else
                {
                    lblMessage.Text = "Error al actualizar la respuesta. Verifique los datos.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Ocurrió un error al intentar actualizar: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Recuperar valores de los campos
            _idRespuesta = Convert.ToInt32(hdfAnswerId.Value); // ID de la respuesta desde el HiddenField
            _en_id = Convert.ToInt32(ddlEncuesta.SelectedValue); // ID de la encuesta desde el DropDownList

            // Llamar a la capa lógica para eliminar la respuesta
            executed = objAnswerDat.deleteAnswer(_idRespuesta, _en_id);

            // Validar si la eliminación fue exitosa
            if (executed)
            {
                lblMessage.Text = "¡Respuesta eliminada exitosamente!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                // Limpiar los campos
                clear();

                // Actualizar el listado de respuestas
                showAnswers();
            }
            else
            {
                lblMessage.Text = "Error al eliminar la respuesta.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void clear()
        {
            hdfAnswerId.Value = string.Empty;
            txtRespuesta.Text = string.Empty;
            ddlEncuesta.ClearSelection();
            lblMessage.Text = string.Empty;

            // Restablecer visibilidad de los botones
            btnGuardar.Visible = true;   // Mostrar el botón Guardar
            btnActualizar.Visible = false; // Ocultar el botón Actualizar
        }

        protected void gvAnswers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Obtener el índice de la fila seleccionada
                int index = Convert.ToInt32(e.CommandArgument);

                // Recuperar la fila seleccionada
                GridViewRow selectedRow = gvAnswers.Rows[index];

                // Cargar los datos en los controles del formulario
                hdfAnswerId.Value = selectedRow.Cells[0].Text; // Columna ID de la respuesta
                txtRespuesta.Text = selectedRow.Cells[3].Text; // Columna Respuesta

                // Recargar el DropDownList con las encuestas disponibles
                showSurveysDDL(); // Método que carga las encuestas en el DropDownList
                ddlEncuesta.SelectedValue = selectedRow.Cells[1].Text; // Asignar el valor de la Encuesta seleccionada

                // No ocultamos ninguno de los botones, simplemente dejamos ambos visibles
                btnActualizar.Visible = true;
                btnGuardar.Visible = true; // Mantenemos ambos botones visibles
            }
        }

        protected void gvAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Establecer el valor del HiddenField para el ID de la respuesta
            hdfAnswerId.Value = gvAnswers.SelectedRow.Cells[0].Text;

            // Asignar la respuesta seleccionada al TextBox
            txtRespuesta.Text = gvAnswers.SelectedRow.Cells[3].Text;

            // Recargar las encuestas
            showSurveysDDL();

            // Asignar el valor de Encuesta al DropDownList
            ddlEncuesta.SelectedValue = gvAnswers.SelectedRow.Cells[1].Text;

            // Asegurarnos de que ambos botones estén visibles
            btnGuardar.Visible = true; // Botón Guardar visible
            btnActualizar.Visible = true; // Botón Actualizar visible
        }

    }
}
