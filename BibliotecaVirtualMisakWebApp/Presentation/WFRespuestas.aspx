<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFRespuestas.aspx.cs" Inherits="Presentation.WFRespuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>Por favor registre si respuesta</h1>
    <br />
    <br />
    <h2>La respuesta debe ser "Si" o "No"</h2>
    <div class="container-fluid">
        <%--Mensaje de alerta o éxito--%>
        <div class="row">
            <div class="col">
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <br />

        <%--Formulario para agregar o editar respuestas--%>
        <div class="row">
            <div class="col">
                <%--Id--%>
                <asp:HiddenField ID="hdfAnswerId" runat="server"/>

                <%--Respuesta--%>
                <asp:Label ID="lblRespuesta" runat="server" Text="Respuesta:"></asp:Label>
                <asp:TextBox ID="txtRespuesta" CssClass="form-control" runat="server" Width="300px" />
            </div>
            <div class="col">
                <%--Encuesta--%>
                <asp:Label ID="lblEncuesta" runat="server" Text="Seleccionar Encuesta:"></asp:Label>
                <asp:DropDownList ID="ddlEncuesta" CssClass="form-select" runat="server" Width="200px">
                    <%--Las encuestas serán cargadas en el código-behind--%>
                </asp:DropDownList>
            </div>
        </div>
      <br />

        <%--Botones para guardar, actualizar y eliminar respuesta--%>
        <div class="row">
            <div class="col">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click" Visible="false" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>
        </div>
        <br />

        <%--Listado de respuestas--%>
        <div class="row">
            <div class="col">
                <h3>Listado de Respuestas</h3>
                       <asp:GridView ID="gvAnswers" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAnswers_SelectedIndexChanged" OnRowCommand="gvAnswers_RowCommand">        
                           <Columns>
                        <asp:BoundField DataField="res_id" HeaderText="ID" />
                        <asp:BoundField DataField="tbl_encuesta_en_id" HeaderText="Encuesta" />
                        <asp:BoundField DataField="en_descripcion_pregunta" HeaderText="Descripcion" />
                        <asp:BoundField DataField="res_respuesta" HeaderText="Respuesta" />
                        <asp:CommandField HeaderText="Opción" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
