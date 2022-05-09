using System;

namespace SavingService.Domain.Entity
{
    public class Customers
    {
        #region Properties
        public int Cliente_Id { get; set; }
        public int User_Access_Id { get; set; }
        public int Sucursal_Id { get; set; }
        public Guid Numero_Cuenta { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Tel_1 { get; set; }
        public bool C_Credito { get; set; }
        public bool C_Ahorro { get; set; }
        public DateTime Fh_Registro { get; set; }
        public DateTime Fh_Modificacion { get; set; }
        public DateTime Fh_Autorizacion { get; set; }
        public int Usr_Registra_Id { get; set; }
        public int Usr_Modifica_Id { get; set; }
        public int Usr_Autoriza_Id { get; set; }
        #endregion
    }
}
