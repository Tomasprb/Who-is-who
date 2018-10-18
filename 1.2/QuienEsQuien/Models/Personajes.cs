using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuienEsQuien.Models
{
    public class Personajes
    {
        private int _IdPersonaje;
        private string _Nombre;
        private int _IdCategoria;
        public Personajes()
        {
            IdPersonaje = _IdPersonaje;
            Nombre = _Nombre;
            IdCategoria = _IdCategoria;
        }

        public Personajes(int _IdPersonaje, string _Nombre, int _IdCategoria)
        {
            this._IdPersonaje = _IdPersonaje;
            this._Nombre = _Nombre;
            this._IdCategoria = _IdCategoria;
        }

        public int IdPersonaje
        {
            get
            {
                return _IdPersonaje;
            }

            set
            {
                _IdPersonaje = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
            }
        }
    }
}