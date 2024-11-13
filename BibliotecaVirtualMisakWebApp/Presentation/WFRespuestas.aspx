<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFRespuestas.aspx.cs" Inherits="Presentation.WFRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEncuesta_SelectedIndexChanged"></asp:DropDownList>

         <%--Selección de la encuesta--%> 
        <asp:Label ID="LabelSurvey" runat="server" Text="Seleccione la encuesta"></asp:Label><br />
        <asp:DropDownList ID="ddlEncuesta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEncuesta_SelectedIndexChanged"></asp:DropDownList><br />

         <%--Muestra la pregunta--%> 
        <asp:Label ID="LabelQuestion" runat="server" Text="Pregunta: "></asp:Label>
        <asp:Literal ID="LitQuestion" runat="server"></asp:Literal><br />

         <%--Respuesta del usuario--%> 
        <asp:Label ID="LabelResponse" runat="server" Text="Ingrese su respuesta (Sí o No)"></asp:Label>
        <asp:TextBox ID="txtRespuesta" runat="server" MaxLength="2"></asp:TextBox><br />

         <%--Mensaje de estado--%> 
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />

         <%--Botones--%> 
        <asp:Button ID="btnGuardar" Text="Guardar Respuesta" OnClick="btnGuardar_Click" runat="server" />
        <asp:Button ID="btnActualizar" Text="Actualizar Respuesta" OnClick="btnActualizar_Click" runat="server" Visible="false" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

         <%--Grid para mostrar las respuestas--%> 
        <asp:GridView ID="gvAnswers" runat="server" AutoGenerateColumns="False" OnRowEditing="gvAnswers_RowEditing" OnRowDeleting="gvAnswers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="res_id" HeaderText="ID" SortExpression="res_id" />
                <asp:BoundField DataField="res_respuesta" HeaderText="Respuesta" SortExpression="res_respuesta" />
                <asp:BoundField DataField="tbl_encuesta_en_id" HeaderText="ID Encuesta" SortExpression="tbl_encuesta_en_id" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <%-- HiddenField para almacenar el ID de la respuesta--%>
        <asp:HiddenField ID="hdfAnswerId" runat="server" />
    </div>
</asp:Content>
