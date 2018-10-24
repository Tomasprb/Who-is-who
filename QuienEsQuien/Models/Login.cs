using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuienEsQuien.Models
{
    public class Login
    {
        private string _Nombre;
        private bool _Admin;
     

        public Login(string Nombre, bool Admin)
        {
            _Nombre = Nombre;
            _Admin = Admin;
        }

        public Login()
        {

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

        public bool Admin
        {
            get
            {
                return _Admin;
            }

            set
            {
                _Admin = value;
            }
        }
       


    }
}