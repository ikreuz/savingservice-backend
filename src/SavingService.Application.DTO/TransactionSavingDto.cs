using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class TransactionSavingDto
    {
        #region Properties
        public int Saving_Id { get; set; }
        public int Tipo_Cuenta { get; set; }
        public int Apertura { get; set; }
        public Guid Numero_Cuenta { get; set; }
        public int Documento_Id { get; set; }
        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }
        #endregion
    }
}
