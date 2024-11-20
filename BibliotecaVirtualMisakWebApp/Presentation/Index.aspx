<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentation.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar títulos o meta tags adicionales si lo necesitas -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Aplicar imagen de fondo directamente al formulario */
        #form1 {
            background-image: url('Recursos/images/fondo.jpg');
            background-size: cover;
            background-position: center center;
            background-attachment: fixed;
            font-family: Arial, sans-serif;
            min-height: 100vh;
        }

        /* Estilo general para header y footer */
        header {
            background: linear-gradient(to bottom, rgba(0, 0, 0, 0.8), rgba(0, 0, 0, 0.5));
            color: white; /* Texto blanco para contraste */
            padding: 15px 0;
            position: relative;
            z-index: 10;
        }

        /* Centrar texto */
        header .container, .container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            flex-wrap: wrap;
        }

        /* Enlaces en el header */
        .navbar a {
            color: white;
            text-decoration: none;
            margin: 0 10px;
        }

        .navbar a:hover {
            text-decoration: underline;
        }

        /* Pie de página */
        footer .social-media a {
            margin: 0 5px;
        }

        /* Espaciado general */
        .mt-5 {
            margin-top: 5rem;
        }

/* Estilo para el carrusel */
.carousel {
    display: flex;
    overflow: hidden;
    width: 100%;
    height: 300px; /* Ajusta la altura del carrusel */
    position: relative;
    background-color: transparent; /* Fondo transparente */
}

.carousel img {
    width: 80%; /* Reduce el tamaño de las imágenes para crear espacio entre ellas */
    margin-right: 10%; /* Añade espacio entre las imágenes */
    height: 100%; /* Las imágenes ocupan toda la altura del carrusel */
    object-fit: cover; /* Las imágenes se ajustan al contenedor sin deformarse */
    animation: slide 15s infinite; /* Animación de deslizamiento */
}

/* Animación de deslizamiento */
@keyframes slide {
    0% {transform: translateX(0%);}
    25% {transform: translateX(-100%);}
    50% {transform: translateX(-200%);}
    75% {transform: translateX(-300%);}
    100% {transform: translateX(0%);}
}

    </style>

   

    <!-- Contenido de la página -->
    <div class="container text-center text-white mt-5">
        <h1>Bienvenido a la Biblioteca Virtual Misak</h1>
        <p>Explora nuestro contenido educativo y más.</p>
        <!-- Carrusel de imágenes -->
<div class="carousel">
    <img src="Recursos/images/Cartilla.jpg" alt="Imagen 1">
    <img src="Recursos/images/Cartilla1.jpg" alt="Imagen 2">
    <img src="Recursos/images/Libro.jpg" alt="Imagen 3">
    <img src="Recursos/images/Libro1.jpg" alt="Imagen 4">
</div>

    </div>

</asp:Content>
