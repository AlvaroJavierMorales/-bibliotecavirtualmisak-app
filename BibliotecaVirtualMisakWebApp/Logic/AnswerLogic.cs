using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class AnswerLogic
    {
        AnswerDat objAnswerDat = new AnswerDat();

        // Método para mostrar todas las Respuestas
        public DataSet showAnswers()
        {
            return objAnswerDat.showAnswers();
        }

        // Método para guardar una nueva Respuesta
        public bool saveAnswer(string _respuesta, int _en_id)
        {
            return objAnswerDat.saveAnswer(_respuesta, _en_id);
        }

        // Método para actualizar una Respuesta
        public bool updateAnswer(int _idRespuesta, string _respuesta, int _en_id)
        {
            return objAnswerDat.updateAnswer(_idRespuesta, _respuesta, _en_id);
        }

        // Método para borrar una Respuesta
        public bool deleteAnswer(int _idRespuesta)
        {
            return objAnswerDat.deleteAnswer(_idRespuesta);
        }
    }
