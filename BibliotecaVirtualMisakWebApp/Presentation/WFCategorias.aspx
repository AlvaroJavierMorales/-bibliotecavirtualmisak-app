<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategorias.aspx.cs" Inherits="Presentation.WFCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2>Ingresando Categorías</h2>
    <!-- Formulario para Agregar o Editar Categoría -->
    <div>
        
        <asp:HiddenField ID="HFCatId" runat="server" /> <!-- HiddenField para almacenar el ID de la categoría seleccionada -->
        <br />
        <h4>las categorias que puedes elejir son: </h4>
        <h5>'Libro', 'Cartilla', 'Folleto', 'Guía Didactica', 'Juego Lúdico', 'Pendón', 'Multimedia'</h5>
        <br />
        
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
       <asp:TextBox ID="TBDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnSave" CssClass="form-control" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" CssClass="form-control" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
         
        <!-- Label para mostrar mensajes -->
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="green"></asp:Label>
    </div>
    <div>
        <!-- Grid para Mostrar Categorías -->
        <asp:GridView ID="GVCategorias" runat="server" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVCategorias_SelectedIndexChanged"
            OnRowDeleting="GVCategorias_RowDeleting" Height="86px" Width="724px" DataKeyNames="cat_id">
            <columns>
                <asp:BoundField DataField="cat_id" HeaderText="ID" />
                <asp:BoundField DataField="cat_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="cat_descripcion" HeaderText="Descripción" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </columns>
        </asp:GridView>
    </div>
    </asp:Content>

