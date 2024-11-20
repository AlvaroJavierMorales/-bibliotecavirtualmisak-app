<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFGestionUsuarios.aspx.cs" Inherits="Presentation.WFGestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
        <h2>Modificar datos del Usuario</h2>

        <asp:HiddenField ID="HFUserId" runat="server" />
        <br />
        <asp:Label ID="LblFirstName" runat="server" AssociatedControlID="TBFirstName" Text="Nombre:" />
        <asp:TextBox ID="TBFirstName" runat="server" />

        <asp:Label ID="LblLastName" runat="server" AssociatedControlID="TBLastName" Text="Apellido:" />
        <asp:TextBox ID="TBLastName" runat="server" />
        <br /> <br />
        <asp:Label ID="LblEmail" runat="server" AssociatedControlID="TBEmail" Text="Correo electrónico:" />
        <asp:TextBox ID="TBEmail" runat="server" />
        <br /> <br />
        <asp:Label ID="LblPassword" runat="server" AssociatedControlID="TBPassword" Text="Contraseña:" />
        <asp:TextBox ID="TBPassword" runat="server" TextMode="Password" />
        <br /> <br />
        <asp:Label ID="LblSalt" runat="server" AssociatedControlID="TBSalt" Text="Salt para la contraseña:" />
        <asp:TextBox ID="TBSalt" runat="server" />
        <br /> <br />

        <!-- Cambiamos el campo de rol a DropDownList con roles específicos -->
        <asp:Label ID="LblRol" runat="server" AssociatedControlID="DDLRole" Text="Rol del usuario:" />
        <asp:DropDownList ID="DDLRole" runat="server">
            <asp:ListItem Value="" Text="Selecciona un rol" />
            <asp:ListItem Value="Administrador" Text="Administrador" />
            <asp:ListItem Value="Docente" Text="Docente" />
            <asp:ListItem Value="Estudiante" Text="Estudiante" />
        </asp:DropDownList>
        <br /> <br />

        <!-- Cambiamos el campo de nivel de estudios a DropDownList -->
      <asp:Label ID="LblEducationLevel" runat="server" AssociatedControlID="DDLEducationLevel" Text="Nivel de estudios:" />
<asp:DropDownList ID="DDLEducationLevel" runat="server">
    <asp:ListItem Value="" Text="Selecciona un nivel de estudios" />
    <asp:ListItem Value="Primaria" Text="Primaria" />
    <asp:ListItem Value="Secundaria" Text="Secundaria" />
    <asp:ListItem Value="Bachillerato" Text="Bachillerato" />
    <asp:ListItem Value="Técnico" Text="Técnico" />
    <asp:ListItem Value="Tecnólogo" Text="Tecnólogo" />
    <asp:ListItem Value="Pregrado" Text="Pregrado" />
    <asp:ListItem Value="Especialización" Text="Especialización" />
    <asp:ListItem Value="Maestría" Text="Maestría" />
    <asp:ListItem Value="Doctorado" Text="Doctorado" />
    <asp:ListItem Value="Postdoctorado" Text="Postdoctorado" />
</asp:DropDownList>
<br /> <br />

        <br /> <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" />

        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
    </div>

   <div>
    <asp:GridView ID="GVUsers" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="usu_id" HeaderText="ID" />
           <asp:BoundField DataField="usu_nombre" HeaderText="Nombre" />

    <asp:BoundField DataField="usu_apellido" HeaderText="Apellido" />
    <asp:BoundField DataField="usu_correo" HeaderText="Correo electrónico" />
    <asp:BoundField DataField="usu_rol" HeaderText="Rol" />      <%--Nueva columna para el rol --%>
    <asp:BoundField DataField="usu_nivel_estudios" HeaderText="Nivel de estudios" />    <%--Nueva columna para el nivel de estudios--%>
    <asp:CommandField HeaderText="Opción" ShowSelectButton="True" />
<%--           <asp:CommandField ShowDeleteButton="True" />--%>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
