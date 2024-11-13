<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFPurchaseRequest.aspx.cs" Inherits="Presentation.WFPurchaseRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:TextBox ID="TBId" runat="server"></asp:TextBox>
 <br />

    <%--Ticket--%>
    <asp:Label ID="Label1" runat="server" Text=" Su Ticket"></asp:Label>
     <asp:TextBox ID="TBTicket" runat="server"></asp:TextBox>
    <br />

 
    <%--Fecha--%>
     <asp:Label ID="Label2" runat="server" Text="Selecione la fecha"></asp:Label>
  <asp:TextBox ID="TBFecha" runat="server"></asp:TextBox>
 <br />

     <%--DDL--%>
    <asp:Label ID="Label3" runat="server" Text="Seleccione el usuario"></asp:Label>
<asp:DropDownList ID="DDLUser" runat="server"></asp:DropDownList>
<br />

    

    <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    <br />

    <div>
    <asp:GridView ID="GVRequests" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVRequests_SelectedIndexChanged">
        <Columns>
             <asp:BoundField DataField="solic_id" HeaderText="Id" />
            <asp:BoundField DataField="solic_ticket" HeaderText="Su Ticket " />
            <asp:BoundField DataField="solic_fecha" HeaderText="Selecione la fecha " />
            <asp:BoundField DataField="tbl_usuarios_usu_nombre" HeaderText="Selecione el usuario" />
          
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
            </asp:GridView>
    </div>
</asp:Content>
