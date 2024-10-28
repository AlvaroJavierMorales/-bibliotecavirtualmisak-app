using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class CategoryLog
    {
        CategoryDat objCat = new CategoryDat();

        // Método para mostrar todas las Categorías
        public DataSet showCategories()
        {
            return objCat.showCategories();
        }

        // Método para mostrar únicamente el ID y la descripción
        public DataSet showCategoriesDDL()
        {
            return objCat.showCategoriesDDL(); 
        }

        // Método para guardar una nueva Categoría
        public bool saveCategory(string _nombre, string _description)
        {
            return objCat.saveCategory(_nombre, _description);
        }

        // Método para actualizar una Categoría
        public bool updateCategory(int _idCategory, string _nombre, string _description)
        {
            return objCat.updateCategory(_idCategory, _nombre, _description);
        }

        // Método para borrar una Categoría
        public bool deleteCategory(int _idCategory)
        {
            return objCat.deleteCategory(_idCategory);
        }
    }
}
