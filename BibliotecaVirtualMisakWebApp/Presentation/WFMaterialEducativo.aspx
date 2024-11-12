<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFMaterialEducativo.aspx.cs" Inherits="Presentation.WFMaterialEducativo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Material Educativo</h1>
    <h2>Agregar Nuevo Material</h2>
    <div>
        <%-- ID oculto --%>
        <asp:HiddenField ID="HFMaterialID" runat="server" />

        <%-- Título --%>
        <asp:Label ID="Label1" runat="server" Text="Título del material "></asp:Label>
        <asp:TextBox ID="TBTitle" runat="server"></asp:TextBox>
        <br />
         <%-- Autor --%>
        <asp:Label ID="Label10" runat="server" Text="Autor"></asp:Label>
        <asp:TextBox ID="TBAutor" runat="server"></asp:TextBox>
        <br />

        <%-- Año de Publicación --%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese año de publicación"></asp:Label>
        <asp:TextBox ID="TBYear" runat="server" TextMode="Date"></asp:TextBox>
        <br />

        <%-- URL de Descarga --%>
        <asp:Label ID="Label3" runat="server" Text="Ingrese la URL de descarga"></asp:Label>
        <asp:TextBox ID="TBDownloadURL" runat="server"></asp:TextBox>
        <br />

        <%-- Precio --%>
        <asp:Label ID="Label4" runat="server" Text="Ingrese el precio"></asp:Label>
        <asp:TextBox ID="TBPrice" runat="server"></asp:TextBox>
        <br />

        <br />

        <%-- Editorial --%>
        <asp:Label ID="Label6" runat="server" Text="Seleccione la editorial"></asp:Label>
        <asp:DropDownList ID="DDLEditorial" runat="server"></asp:DropDownList>
        <br />

        <%-- Categoría --%>
        <asp:Label ID="Label7" runat="server" Text="Seleccione la categoría"></asp:Label>
        <asp:DropDownList ID="DDLCategories" runat="server"></asp:DropDownList>
        <br />
       

        
        <%-- Botones de Guardar y Actualizar --%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%-- Lista de Materiales Educativos --%>
        <asp:GridView ID="GVMaterials" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVMaterials_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="mat_id" HeaderText="Id" />
                <asp:BoundField DataField="mat_titulo" HeaderText="Título" />
                <asp:BoundField DataField="mat_ano_publicacion" HeaderText="Año de Publicación" />
                <asp:BoundField DataField="mat_url_descarga" HeaderText="URL de Descarga" />
                <asp:BoundField DataField="mat_precio" HeaderText="Precio" />
                <asp:BoundField DataField="tbl_editorial_edi_id" HeaderText="FKeditorial" />
                <asp:BoundField DataField="tbl_categorias_cat_id" HeaderText="FKCategoría" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
