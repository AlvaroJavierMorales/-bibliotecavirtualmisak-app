<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFEncuesta.aspx.cs" Inherits="Presentation.WFEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Gestión de Encuestas</h2>

         <%--Etiqueta para el mensaje de alerta o éxito--%>  
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        <br /><br />

         <%--Sección para agregar o editar una encuesta--%>  
        <asp:Label ID="lblPregunta" runat="server" Text="Pregunta: "></asp:Label>
        <asp:TextBox ID="txtDescripcionPregunta" runat="server" Width="300px" />
        <br /><br />

        <asp:Label ID="lblUsuario" runat="server" Text="Seleccionar Usuario: "></asp:Label>
        <asp:DropDownList ID="ddlUsuario" runat="server" Width="200px">
             <%--Los usuarios serán cargados en el código-behind--%> 
        </asp:DropDownList>
        <br /><br />

         <%--Botones para guardar y actualizar encuesta--%>  
        <asp:Button ID="btnGuardarEncuesta" runat="server" Text="Guardar" OnClick="btnGuardarEncuesta_Click" />
        <asp:Button ID="btnActualizarEncuesta" runat="server" Text="Actualizar" OnClick="btnActualizarEncuesta_Click" Visible="false" />

         <%--ID de la encuesta oculta--%>  
        <asp:HiddenField ID="hdfEncuestaId" runat="server" />
        <br /><br />

         <%--Listado de encuestas con opciones de edición y eliminación--%>  
        <h3>Listado de Encuestas</h3>
    <asp:GridView ID="gvSurveys" runat="server" AutoGenerateColumns="False" DataKeyNames="en_id"
        OnRowEditing="gvSurveys_RowEditing"
        OnRowDeleting="gvSurveys_RowDeleting">
        <Columns>
            <asp:BoundField DataField="en_id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="descripcion_pregunta" HeaderText="Descripción" />
            <asp:CommandField ShowEditButton="True" EditText="Editar" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
        </Columns>
    </asp:GridView>

    </div>
</asp:Content>
