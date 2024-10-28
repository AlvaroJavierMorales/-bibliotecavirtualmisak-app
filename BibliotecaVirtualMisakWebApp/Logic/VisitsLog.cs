using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Data;

namespace Logic
{
    public class VisitsLog
    {
        VisitsDat objVis = new VisitsDat();

        //Crear metodo showVisits
        public DataSet showVisits()
        {

            return objVis.showVisits();

        }

        //Metodo DDL
        public DataSet showVisitsDDL()
        {

            return objVis.showVisitsDDL();

        }

        public bool saveAuthor(DateTime _fecha_ingreso, TimeSpan _duracion, int _usu_id)
        {
            return objVis.saveAuthor(_fecha_ingreso, _duracion, _usu_id);

        }
        public bool updateAuthor(int _idVisits, DateTime _fecha_ingreso, TimeSpan _duracion, int _usu_id)
        {
            return objVis.updateAuthor(_idVisits, _fecha_ingreso, _duracion, _usu_id);


        }

        public bool deleteAuthor(int _idVisits)
        {
            return objVis.deleteAuthor(_idVisits);
        }



    }

}