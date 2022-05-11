using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Domain.Entity
{
    public class TransactionCreditCmp
    {
        #region Properties
        public int Credit_Id { get; set; }
        public int Tipo_Cuenta { get; set; }
        public Guid Numero_Cuenta { get; set; }
        public int Cliente_Id { get; set; }
        public string Cliente { get; set; }
        public int Documento_Id { get; set; }
        public string Documento_Txt { get; set; }
        public decimal Cobrado { get; set; }

        public decimal Por_Cobrar { get; set; }
        public string Cobrado_Txt { get; set; }
        public decimal Total { get; set; }
        public int Status_Id { get; set; }
        public string Status_Txt { get; set; }
        #endregion
    }
}
