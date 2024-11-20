<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFEditorial.aspx.cs" Inherits="Presentation.WFEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingresando Editoriales</h2>

<!-- Formulario para Agregar o Editar Editorial -->
<div>
    <asp:HiddenField ID="HFEditId" runat="server" />
    
    <!-- HiddenField para almacenar el ID de la editorial selecconada -->

    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>

    <asp:Label ID="Label2" runat="server" Text="Ciudad:"></asp:Label>
    <asp:TextBox ID="TBCiudad" runat="server"></asp:TextBox>

    <asp:Label ID="Label3" runat="server" Text="Teléfono:"></asp:Label>
    <asp:TextBox ID="TBTelefono" runat="server"></asp:TextBox>

    <asp:Label ID="Label4" runat="server" Text="Correo:"></asp:Label>
    <asp:TextBox ID="TBCorreo" runat="server" Width="390px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />

    <!-- Label para mostrar mensajes -->
    <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="green"></asp:Label>
</div>
<div>

    <!-- Grid para Mostrar Editoriales -->
    <asp:GridView ID="GVEditorial" runat="server" AutoGenerateColumns="False"
        OnSelectedIndexChanged="GVEditorial_SelectedIndexChanged"
        OnRowDeleting="GVEditorial_RowDeleting" Height="86px" Width="724px" DataKeyNames="edi_id">
        <Columns>
            <asp:BoundField DataField="edi_id" HeaderText="ID" />
            <asp:BoundField DataField="edi_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="edi_ciudad" HeaderText="Ciudad" />
            <asp:BoundField DataField="edi_telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="edi_correo" HeaderText="Correo" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" EditText="Seleccionar" />

        </Columns>
    </asp:GridView>
</div>
</asp:Content>
