using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class MaterialEduLog
    {
        MaterialEduDat objMatEdu = new MaterialEduDat();

        // Método para mostrar todos los registros de Material Educativo
        public DataSet showMaterials()
        {
            return objMatEdu.showMaterials();
        }

        // Método para insertar un nuevo Material Educativo
        public bool saveMaterial(string _titulo, DateTime _anoPublicacion, string _urlDescarga, decimal _precio, int _cantidad, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
        {
            return objMatEdu.saveMaterial(_titulo, _anoPublicacion, _urlDescarga, _precio, _cantidad, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);
        }

        // Método para actualizar un Material Educativo
        public bool updateMaterial(int _idMaterial, string _titulo, DateTime _anoPublicacion, string _urlDescarga, decimal _precio, int _cantidad, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
        {
            return objMatEdu.updateMaterial(_idMaterial, _titulo, _anoPublicacion, _urlDescarga, _precio, _cantidad, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);
        }

        // Método para eliminar un Material Educativo
        public bool deleteMaterial(int _idMaterial, int _editorialId, int _categoriaId, int _solicitudCompraId, int _visitasId)
        {
            return objMatEdu.deleteMaterial(_idMaterial, _editorialId, _categoriaId, _solicitudCompraId, _visitasId);
        }
    }
}
