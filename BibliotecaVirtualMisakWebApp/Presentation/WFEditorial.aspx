<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFEditorial.aspx.cs" Inherits="Presentation.WFEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Gestión de Editoriales</h2>

    <h2>Ingresando Editoriales</h2>

    <!-- Label para mostrar mensajes -->
    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>

    <!-- Formulario para Agregar o Editar Editorial -->

    <asp:Panel ID="pnlFormulario" runat="server" Visible="true">
        <asp:Label ID="lblID" runat="server" Text="ID" Visible="false"></asp:Label>
        <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>

        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" Width="352px"></asp:TextBox>

        <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
        <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>

        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

        <asp:Label ID="lblCorreo" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" Width="390px"></asp:TextBox>
        <br /> <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <br /> 
    </asp:Panel>
    
    <!-- Grid para Mostrar Editoriales -->
    <asp:GridView ID="gvEditoriales" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEditoriales_RowEditing"
        OnRowDeleting="gvEditoriales_RowDeleting" OnRowCancelingEdit="gvEditoriales_RowCancelingEdit" Height="86px" Width="724px">
        <Columns>
            
            <asp:BoundField DataField="edi_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="edi_ciudad" HeaderText="Ciudad" />
            <asp:BoundField DataField="edi_telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="edi_correo" HeaderText="Correo" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            
        </Columns>
        
    </asp:GridView>

    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Editorial" OnClick="btnNuevo_Click" Height="26px" Width="162px" />
</asp:Content>


