﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFEncuesta.aspx.cs" Inherits="Presentation.WFEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>Gestión de Encuestas</h1>
    <div class="container-fluid">
        <%--Mensaje de alerta o éxito--%>
        <div class="row">
            <div class="col">
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <br />

        <%--Formulario para agregar o editar encuestas--%>
        <div class="row">
            <div class="col">
                <%--Id--%>
                <asp:HiddenField ID="TBCode" runat="server" />

                <%--Código--%>
            </div>
            <div class="col">
                <%--Pregunta--%>
                <asp:Label ID="lblPregunta" runat="server" Text="Pregunta:"></asp:Label>
                <asp:TextBox ID="txtDescripcionPregunta" CssClass="form-control" runat="server" Width="300px" />
            </div>
            <div class="col">
                <%--Usuario--%>
                <asp:Label ID="lblUsuario" runat="server" Text="Seleccionar Usuario:"></asp:Label>
                <asp:DropDownList ID="ddlUsuario" CssClass="form-select" runat="server" Width="200px">
                    <%--Los usuarios serán cargados en el código-behind--%>
                </asp:DropDownList>
            </div>
        </div>
      <br />

        <%--Botones para guardar, actualizar y eliminar encuesta--%>
        <div class="row">
            <div class="col">
                <asp:Button ID="btnGuardarEncuesta" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardarEncuesta_Click" />
                <asp:Button ID="btnActualizarEncuesta" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizarEncuesta_Click" />
                <asp:Button ID="btnEliminarEncuesta" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminarEncuesta_Click" />
                <asp:HiddenField ID="hdfEncuestaId" runat="server" />
            </div>
        </div>
        <br />

        <%--Listado de encuestas--%>
        <div class="row">
            <div class="col">
                <h3>Listado de Encuestas</h3>
                <asp:GridView ID="gvSurveys" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSurveys_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="en_id" HeaderText="ID" />
                        <asp:BoundField DataField="en_descripcion_pregunta" HeaderText="Descripción" />
                        <asp:BoundField DataField="tbl_usuarios_usu_id" HeaderText="ID Usuario" />
                        <asp:CommandField HeaderText="Opción" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
