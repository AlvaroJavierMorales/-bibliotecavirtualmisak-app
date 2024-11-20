<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFVisits.aspx.cs" Inherits="Presentation.WFVisits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <br />
     <br />
    <div>
    <%--ID--%>
    <asp:HiddenField ID="HFVisitId" runat="server" />


     <%--FECHA INGRESO--%>
 <asp:Label ID="Label1" runat="server" Text="Fecha Ingreso"></asp:Label>  
 <asp:TextBox ID="TBFechaIngreso" runat="server" TextMode="Date"></asp:TextBox>
 <br />
 <br />

 <%--DURACION--%>
 <asp:Label ID="Label2" runat="server" Text="Ingrese la duración"></asp:Label>  
 <asp:TextBox ID="TBDuracion" runat="server" ></asp:TextBox>
 <br />
  <br />

 <%--USUARIO_ID--%>
 <asp:Label ID="Label3" runat="server" Text="ID del usuario"></asp:Label>
 <asp:DropDownList ID="DDLUsers" runat="server"></asp:DropDownList>
 <br />
 <br />
 
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
    

    <%--label para mostrar los mensajes--%> 
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
</div>

    <div>
    <asp:GridView ID="GVVisits" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVVisits_SelectedIndexChanged" 
         OnRowDeleting="GVVisits_RowDeleting" DataKeyNames="vis_id, tbl_usuarios_usu_id">

        <Columns>
            <asp:BoundField DataField="vis_id" HeaderText="Id" />
           <asp:BoundField DataField="tbl_usuarios_usu_id" HeaderText="ID del usuario" />
            <asp:BoundField DataField="vis_fecha_ingreso" HeaderText="Fecha Ingreso" />
            <asp:BoundField DataField="vis_duracion" HeaderText="Ingrese la duración" />


            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True"></asp:CommandField>
        </Columns>
    </asp:GridView>
  </div>
</asp:Content>

