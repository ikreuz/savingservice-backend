using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Domain.Entity
{
    public class Users
    {
        #region Properties
        public int Usuario_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public string Nombre_Usuario { get; set; }
        public string Fh_Registro { get; set; }
        public string Fh_Modificacion { get; set; }
        public string Usr_Registra { get; set; }
        public string Usr_Modifica { get; set; }
        #endregion
    }
}
