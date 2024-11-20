
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public bool saveVisits(DateTime _fecha_ingreso, TimeSpan _duracion, int _usu_id)
        {
            return objVis.saveVisits(_fecha_ingreso, _duracion, _usu_id);

        }
        public bool updateVisits(int _idVisits, int _usu_id, DateTime _fecha_ingreso, TimeSpan _duracion)
        {
            return objVis.updateVisits(_idVisits, _usu_id, _fecha_ingreso, _duracion);


        }

        public bool deleteVisits(int _idVisits, int _userId)
        {
            return objVis.deleteVisits(_idVisits, _userId);
        }

    }

}