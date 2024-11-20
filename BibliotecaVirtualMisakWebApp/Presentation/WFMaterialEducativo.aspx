<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFMaterialEducativo.aspx.cs" Inherits="Presentation.WFMaterialEducativo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <h2>Gestión de Materias Educativas</h2>

<h2>Ingresando MateriaLes</h2>

<!-- Formulario para Agregar o Editar Materia -->
<div>
    <asp:HiddenField ID="HFMaterialID" runat="server" />
    <!-- HiddenField para almacenar el ID de la materia seleccionada -->

    <asp:Label ID="Label1" runat="server" Text="Titulo del material:"></asp:Label>
    <asp:TextBox ID="TBTitulo" runat="server"></asp:TextBox>

    <asp:Label ID="Label2" runat="server" Text="Año Publicacion:"></asp:Label>
    <asp:TextBox ID="TBAnopublicado" runat="server"></asp:TextBox>

    <asp:Label ID="Label3" runat="server" Text="Url:"></asp:Label>
    <asp:TextBox ID="TBUrl" runat="server"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="Precio:"></asp:Label>
    <asp:TextBox ID="TBPrecio" runat="server"></asp:TextBox>
    <br />
     <br />
     <!-- Seleccionar editorial -->
    <asp:Label ID="Label5" runat="server" Text="Seleccione la Editorial:"></asp:Label>
    <asp:DropDownList ID="DDLEditorial" runat="server" ></asp:DropDownList>
    <br />
     <!-- Seleccionar Categorias -->
    <asp:Label ID="Label6" runat="server" Text="Seleccione la Categoria:"></asp:Label>
    <asp:DropDownList ID="DDLCategories" runat="server" ></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
    
    
    <!-- Label para mostrar mensajes -->
    <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="green"></asp:Label>
</div>

    <!-- Grid para Mostrar Materias -->
    <asp:GridView ID="GVMaterial" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVMaterial_SelectedIndexChanged"
         OnRowDeleting="GVMaterial_RowDeleting"  DataKeyNames="mat_id" >
        <Columns>
            <asp:BoundField DataField="mat_id" HeaderText="ID" />
            <asp:BoundField DataField="mat_titulo" HeaderText="Titulo" />
            <asp:BoundField DataField="mat_ano_publicacion" HeaderText="Año Publicaion" />
            <asp:BoundField DataField="mat_url_descarga" HeaderText="url" />
            <asp:BoundField DataField="mat_precio" HeaderText="Precio" />
            <asp:BoundField DataField="tbl_editorial_edi_id" HeaderText="fkEditorial" />
            <asp:BoundField DataField="edi_nombre" HeaderText="Editorial" />
            <asp:BoundField DataField="tbl_categorias_cat_id" HeaderText="fkcategoria" />
            <asp:BoundField DataField="cat_descripcion" HeaderText="Categoría" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
