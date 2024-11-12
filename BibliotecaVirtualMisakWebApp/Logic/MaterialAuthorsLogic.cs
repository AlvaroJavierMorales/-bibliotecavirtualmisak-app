using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class MaterialAuthorsLogic
    {
        MaterialAuthorsDat objMaterialAuthorsDat = new MaterialAuthorsDat();

        // Método para mostrar todos los registros de la relación entre Materiales Educativos y Autores
        public DataSet showMaterialAuthors()
        {
            return objMaterialAuthorsDat.showMaterialAuthors();
        }

        // Método para insertar un nuevo registro en la relación entre Materiales Educativos y Autores
        public bool saveMaterialAuthor(int autorId, int materialId)
        {
            return objMaterialAuthorsDat.saveMaterialAuthor(autorId, materialId);
        }

        // Método para actualizar un registro de la relación entre Materiales Educativos y Autores
        public bool updateMaterialAuthor(int autorId, int materialId)
        {
            return objMaterialAuthorsDat.updateMaterialAuthor(autorId, materialId);
        }

        // Método para eliminar un registro de la relación entre Materiales Educativos y Autores
        public bool deleteMaterialAuthor(int autorId, int materialId)
        {
            return objMaterialAuthorsDat.deleteMaterialAuthor(autorId, materialId);
        }
    }
}
