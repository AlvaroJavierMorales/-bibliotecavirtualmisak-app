using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class UserLogic
    {
        UserDat objUserDat = new UserDat();

        // Método para mostrar todos los Usuarios
        public DataSet showUsers()
        {
            return objUserDat.showUsers();
        }
        // Método para mostrar solamente el id y el nombre completo  los Usuarios por DDL
        public DataSet showUserDDL()
        {
            return objUserDat.showUsersDDL();
        }
        // Método para guardar un nuevo Usuario
        public bool saveUser(string _nombre, string _apellido, string _correo, string _contrasena, string _salt, string _rol, string _nivelEstudios)
        {
            return objUserDat.saveUser(_nombre, _apellido, _correo, _contrasena, _salt, _rol, _nivelEstudios);
        }

        // Método para actualizar un Usuario
        public bool updateUser(int _idUser, string _nombre, string _apellido, string _correo, string _contrasena, string _salt, string _rol, string _nivelEstudios)
        {
            return objUserDat.updateUser(_idUser, _nombre, _apellido, _correo, _contrasena, _salt, _rol, _nivelEstudios);
        }

        // Método para borrar un Usuario
        public bool deleteUser(int _idUser)
        {
            return objUserDat.deleteUser(_idUser);
        }
    }
