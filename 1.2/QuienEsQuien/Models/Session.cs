using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuienesQuien.Models
{
    public class Session
    {
        private string _NombreUser;
        private bool _Admin;


        public Session()
        {

        }

        public Session(string NombreUser, bool Admin)
        {
            _NombreUser = NombreUser;
            _Admin = Admin;
        }

        public string NombreUser
        {
            get
            {
                return _NombreUser;
            }

            set
            {
                _NombreUser = value;
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