using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuienEsQuien.Models
{
    public class Preguntas
    {
        private int _IdPregunta;
        private string _Texto;

        public Preguntas(int _IdPregunta, string _Texto)
        {
            this._IdPregunta = _IdPregunta;
            this._Texto = _Texto;
        }
        public Preguntas()
        {
            IdPregunta = _IdPregunta;
            Texto = _Texto;
        }

        public int IdPregunta
        {
            get
            {
                return _IdPregunta;
            }

            set
            {
                _IdPregunta = value;
            }
        }

        public string Texto
        {
            get
            {
                return _Texto;
            }

            set
            {
                _Texto = value;
            }
        }
    }
}