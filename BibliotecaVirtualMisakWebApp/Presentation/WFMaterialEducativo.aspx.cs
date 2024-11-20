using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFMaterialEducativo : System.Web.UI.Page
    {
        // Instancias de clases para interactuar con la lógica de negocio.
        MaterialEduLog objMatEdu = new MaterialEduLog();
        EditorialLog objEdit = new EditorialLog();
        CategoryLog objCat = new CategoryLog();
        // Asegúrate de tener esta clase

        private int _idMaterial, _editorialId, _categoriaId, _solicitudCompraId, _visitasId;
        private string _titulo, _urlDescarga;
        private DateTime _anoPublicacion;
        private decimal _precio;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showMaterials();
                showEditorialDDL();
                ShowCategoriesDDL();

            }
        }

        // Método para mostrar las categorías en el DropDownList.
        private void ShowCategoriesDDL()
        {

            DDLCategories.DataSource = objCat.showCategoriesDDL();
            DDLCategories.DataValueField = "cat_id";
            DDLCategories.DataTextField = "cat_nombre";
            DDLCategories.DataBind();
            DDLCategories.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        // Método para mostrar las editoriales en el DropDownList.
        private void showEditorialDDL()
        {
            DDLEditorial.DataSource = objEdit.showEditorialsDDL();
            DDLEditorial.DataValueField = "edi_id";
            DDLEditorial.DataTextField = "edi_nombre";
            DDLEditorial.DataBind();
            DDLEditorial.Items.Insert(0, new ListItem("Seleccione", "0"));
        }


        // Método para mostrar todo el material educativo en el GridView.
        private void showMaterials()
        {
            DataSet ds = new DataSet();
            ds = objMatEdu.showMaterials();
            GVMaterial.DataSource = ds;
            GVMaterial.DataBind();
        }

        // Método para limpiar los TextBox y DropDownList.
        private void clear()
        {
            HFMaterialID.Value = "";
            TBTitulo.Text = "";
            TBUrl.Text = "";
            TBAnopublicado.Text = "";
            TBPrecio.Text = "";
            DDLCategories.SelectedIndex = 0;
            DDLEditorial.SelectedIndex = 0;

        }

        // Evento para guardar un nuevo material educativo.
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _titulo = TBTitulo.Text;
            DateTime.TryParse(TBAnopublicado.Text, out _anoPublicacion); // Validación de la fecha
            _urlDescarga = TBUrl.Text;
            decimal.TryParse(TBPrecio.Text, out _precio);
            _categoriaId = Convert.ToInt32(DDLCategories.SelectedValue);
            _editorialId = Convert.ToInt32(DDLEditorial.SelectedValue);


            executed = objMatEdu.saveMaterial(_titulo, _anoPublicacion, _urlDescarga, _precio, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);

            if (executed)
            {
                LblMsj.Text = "El material educativo se guardó exitosamente";
                clear();
                showMaterials();
            }
            else
            {
                LblMsj.Text = "Error al guardar el material educativo";
            }
        }

        // Evento para actualizar un material educativo existente.
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idMaterial = Convert.ToInt32(HFMaterialID.Value);
            _titulo = TBTitulo.Text;
            _urlDescarga = TBUrl.Text;
            DateTime.TryParse(TBAnopublicado.Text, out _anoPublicacion); // Validación de la fecha
            decimal.TryParse(TBPrecio.Text, out _precio);
            _categoriaId = Convert.ToInt32(DDLCategories.SelectedValue);
            _editorialId = Convert.ToInt32(DDLEditorial.SelectedValue);


            executed = objMatEdu.updateMaterial(_idMaterial, _titulo, _anoPublicacion, _urlDescarga, _precio, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);

            if (executed)
            {
                LblMsj.Text = "El material educativo se actualizó exitosamente";
                clear();
                showMaterials();
            }
            else
            {
                LblMsj.Text = "Error al actualizar el material educativo";
            }
        }

        // Evento para seleccionar una fila del GridView.
        protected void GVMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFMaterialID.Value = GVMaterial.SelectedRow.Cells[0].Text;
            TBTitulo.Text = GVMaterial.SelectedRow.Cells[1].Text;
            TBAnopublicado.Text = GVMaterial.SelectedRow.Cells[2].Text;
            TBPrecio.Text = GVMaterial.SelectedRow.Cells[3].Text;
            DDLCategories.SelectedValue = GVMaterial.SelectedRow.Cells[4].Text;
            DDLEditorial.SelectedValue = GVMaterial.SelectedRow.Cells[7].Text;

        }
        protected void GVMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pro_id = Convert.ToInt32(GVMaterial.DataKeys[e.RowIndex].Values[0]);
            executed = objMatEdu.deleteMaterial(_idMaterial, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);

            if (executed)
            {
                LblMsj.Text = "¡Orden eliminada exitosamente!";
                GVMaterial.EditIndex = -1;
                showMaterials();
            }
            else
            {
                LblMsj.Text = "¡Error al eliminar la orden!";
            }
        }
    }
}