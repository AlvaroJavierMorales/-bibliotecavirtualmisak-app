<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFAuthors.aspx.cs" Inherits="Presentation.WFAuthors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%--ID--%>
 <asp:TextBox ID="TBId" runat="server" Visible="False"></asp:TextBox>
 
 <%--NOMBRE--%>
 <asp:Label ID="Label2" runat="server" Text="Ingrese el nombre"></asp:Label>
 <asp:TextBox ID="TBNombre" runat="server" ></asp:TextBox>
 <br />

<%--APELLIDO--%>
 <asp:Label ID="Label3" runat="server" Text="Ingrese el apellido"></asp:Label>
 <asp:TextBox ID="TBApellido" runat="server" ></asp:TextBox>
 <br />

<%--MUNICIPIO--%>
<asp:Label ID="Label4" runat="server" Text="Ingrese el municipio"></asp:Label>
<asp:TextBox ID="TBMunicipio" runat="server" ></asp:TextBox>
 <br />

    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
    <asp:Button ID="BtnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <div>

    <asp:GridView ID="GVAuthors" runat="server" AutoGenerateColumns="False"
        OnSelectedIndexChanged="GVAuthors_SelectedIndexChanged" OnRowDataBound="GVAuthors_RowDataBound">
        <Columns>
            <asp:BoundField DataField="au_id" HeaderText="Id" />
            <asp:BoundField DataField="au_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="au_apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="au_municipio" HeaderText="Municipio" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
        </Columns>
         </asp:GridView>
        </div>
 
</asp:Content>




