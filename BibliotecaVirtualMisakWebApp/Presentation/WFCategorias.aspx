<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategorias.aspx.cs" Inherits="Presentation.WFCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestión de Categorías</h2>

<h2>ingresando categorias</h2>

<!-- Label para mostrar mensajes -->
<asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>

<!-- Formulario para Agregar o Editar Categoría -->
<asp:Panel ID="pnlFormulario" runat="server" Visible="true">
    <asp:Label ID="lblID" runat="server" Text="ID" Visible="false"></asp:Label>
    <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>

    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Panel>

<!-- Grid para Mostrar Categorías -->
<asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" OnRowEditing="gvCategorias_RowEditing"
    OnRowDeleting="gvCategorias_RowDeleting" OnRowCancelingEdit="gvCategorias_RowCancelingEdit">
    <Columns>
        <asp:BoundField DataField="cat_id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="cat_nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="cat_descripcion" HeaderText="Descripción" />
        
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

<asp:Button ID="btnNuevo" runat="server" Text="Nueva Categoría" OnClick="btnNuevo_Click" />
</asp:Content>
