using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class SurveyLog

    {
        SurveyDat objSurveyDat = new SurveyDat();

        // Método para mostrar todas las Encuestas
        public DataSet showSurveys()
        {
            return objSurveyDat.showSurveys();
        }
        // Método para mostrar unicamente el id y la descripcion de la pregunta
        public DataSet showSurveysDDL()
        {
            return objSurveyDat.showSurveysDDL();
        }
        // Método para guardar una nueva Encuesta
        public bool saveSurvey(string _descripcionPregunta, int _usu_id)
        {
            return objSurveyDat.saveSurvey(_descripcionPregunta, _usu_id);
        }

        // Método para actualizar una Encuesta
        public bool updateSurvey(int _en_id, int _usu_id, string _descripcionPregunta)
        {
            return objSurveyDat.updateSurvey(_en_id, _usu_id, _descripcionPregunta);
        }

        // Método para borrar una Encuesta
        public bool deleteSurvey(int _en_id, int _usu_id)
        {
            return objSurveyDat.deleteSurvey(_en_id, _usu_id);
        }
    }
}
