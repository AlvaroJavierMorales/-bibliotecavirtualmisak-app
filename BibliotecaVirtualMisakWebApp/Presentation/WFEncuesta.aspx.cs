using Logic;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFEncuesta : System.Web.UI.Page
    {
        SurveyLogic objSurveyLogic = new SurveyLogic();
        UserLogic objUserLogic = new UserLogic();

        private int _en_id, _usu_id;
        private string _descripcionPregunta;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUserDDL(); //Se invoca el metodo para mostrar todos los usuarios
                showSurveys(); //Se invoca el metodo para mostrar todas las encuestas
            }
        }

        private void showUserDDL()
        {
            ddlUsuario.DataSource = objUserLogic.showUserDDL();
            ddlUsuario.DataValueField = "usu_id";
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, "Seleccione");
        }

        private void showSurveys()
        {
            DataSet ds = objSurveyLogic.showSurveys();
            gvSurveys.DataSource = ds;
            gvSurveys.DataBind();
        }

        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            _descripcionPregunta = txtDescripcionPregunta.Text;
            _usu_id = Convert.ToInt32(ddlUsuario.SelectedValue);

            executed = objSurveyLogic.saveSurvey(_descripcionPregunta, _usu_id);

            if (executed)
            {
                lblMessage.Text = "La pregunta se guardó y se envió exitosamente!";
                clear();
                showSurveys();
            }
            else
            {
                lblMessage.Text = "Error al guardar!";
            }
        }

        protected void btnActualizarEncuesta_Click(object sender, EventArgs e)
        {
            _en_id = Convert.ToInt32(TBCode.Value);
            _descripcionPregunta = txtDescripcionPregunta.Text;
            _usu_id = Convert.ToInt32(ddlUsuario.SelectedValue);

            executed = objSurveyLogic.updateSurvey(_en_id, _usu_id, _descripcionPregunta);

            if (executed)
            {
                lblMessage.Text = "La pregunta se actualizó exitosamente!";
                clear();
                showSurveys();
            }
            else
            {
                lblMessage.Text = "Error al actualizar!";
            }
        }

        protected void btnEliminarEncuesta_Click(object sender, EventArgs e)
        {
            try
            {
                _en_id = Convert.ToInt32(TBCode.Value);
                _usu_id = Convert.ToInt32(ddlUsuario.SelectedValue);

                executed = objSurveyLogic.deleteSurvey(_en_id, _usu_id);

                if (executed)
                {
                    lblMessage.Text = "La encuesta se eliminó exitosamente!";
                    clear();
                    showSurveys();
                }
                else
                {
                    lblMessage.Text = "Error al eliminar!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al eliminar la encuesta: {ex.Message}";
            }
        }

        private void clear()
        {
            TBCode.Value = "";
            txtDescripcionPregunta.Text = "";
            ddlUsuario.SelectedIndex = 0;
        }

        protected void gvSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gvSurveys.SelectedRow;
            TBCode.Value = selectedRow.Cells[0].Text;
            txtDescripcionPregunta.Text = HttpUtility.HtmlDecode(selectedRow.Cells[1].Text);
            ddlUsuario.SelectedValue = selectedRow.Cells[2].Text;
        }
    }
}
