<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFRegistroUsuarios.aspx.cs" Inherits="Presentation.WFRegistroUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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

        <asp:Label ID="LblRol" runat="server" AssociatedControlID="DDLRole" Text="Rol del usuario:" />
        <asp:DropDownList ID="DDLRole" runat="server">
            <asp:ListItem Value="" Text="Selecciona un rol" />
            <asp:ListItem Value="Administrador" Text="Administrador" />
            <asp:ListItem Value="Docente" Text="Docente" />
            <asp:ListItem Value="Estudiante" Text="Estudiante" />
        </asp:DropDownList>
        <br /> <br />

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

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />

        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
