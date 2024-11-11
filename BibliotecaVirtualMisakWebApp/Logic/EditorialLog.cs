using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class EditorialLog
    {
        EditorialDat objEdit = new EditorialDat();

        // Método para mostrar todas las Editoriales
        public DataSet showEditorials()
        {
            return objEdit.showEditorials();
        }

        // Método para mostrar las editoriales en formato DDL
        public DataSet showEditorialsDDL()
        {
            return objEdit.showEditorialsDDL();

            // Método para g una nueva Editorial

            public bool saveEditorial(string _nombre, string _ciudad, int _telefono, string _correo)
            {
                return objEdit.saveEditorial(_nombre, _ciudad, _telefono, _correo);
            }

            // Método para actualizar una Editorial

            public bool updateEditorial(int _idEditorial, string _nombre, string _ciudad, int _telefono, string _correo)
            {
                return objEdit.updateEditorial(_idEditorial, _nombre, _ciudad, _telefono, _correo);
            }

            // Método para eliminar una Editorial
            public bool deleteEditorial(int _idEditorial)
            {
                return objEdit.deleteEditorial(_idEditorial);
            }

        }
    }
}
