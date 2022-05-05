using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class TransactionCreditDto
    {
        #region Properties
        public int Credit_Id { get; set; }
        public int Transaction_Id { get; set; }
        public int Documento_Id { get; set; }
        public decimal Cobrado { get; set; }

        public decimal Por_Cobrar { get; set; }
        public decimal Total { get; set; }
        public int Status_Id { get; set; }
        #endregion
    }
}
