using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class TowerDto
    {
        #region Properties
        public int Tower_Id { get; set; }
        public int Role_Id { get; set; }
        public int Usuario_Id { get; set; }
        public Guid Mid { get; set; }
        public string Auth { get; set; }
        public string Pass { get; set; }
        public bool Is_Staff { get; set; }
        public DateTime Fh_Registro { get; set; }
        public DateTime Fh_Modificacion { get; set; }
        public int Usr_Registra_Id { get; set; }
        public int Usr_Modifica_Id { get; set; }
        #endregion
    }
}
