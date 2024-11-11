using System;
using System.Data;

namespace Logic
{
    internal class MaterialEduDat
    {
        internal bool deleteMaterial(int idMaterial, int editorialId, int categoriaId, int solicitudCompraId, int visitasId)
        {
            throw new NotImplementedException();
        }

        internal bool saveMaterial(string titulo, DateTime anoPublicacion, string urlDescarga, decimal precio, int cantidad, int editorialId, int categoriaId, int solicitudCompraId, int visitasId)
        {
            throw new NotImplementedException();
        }

        internal DataSet showMaterials()
        {
            throw new NotImplementedException();
        }

        internal bool updateMaterial(int idMaterial, string titulo, DateTime anoPublicacion, string urlDescarga, decimal precio, int cantidad, int editorialId, int categoriaId, int solicitudCompraId, int visitasId)
        {
            throw new NotImplementedException();
        }
    }
}