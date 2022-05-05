using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class TransactionDto
    {
        #region Properties
        public int Transaction_Id { get; set; }
        public string Folio { get; set; }
        public string Cliente_Id { get; set; }
        public string Sucursal_Id { get; set; }

        public string Fh_Registro { get; set; }
        public string Fh_Modficacion { get; set; }
        public string Usr_Registra { get; set; }
        public string Usr_Modifica { get; set; }
        #endregion
    }
}
