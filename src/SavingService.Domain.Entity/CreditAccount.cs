using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Domain.Entity
{
    public class CreditAccount
    {
        #region Properties
        public int Transaction_Id { get; set; }
        public int Credit_Id { get; set; }
        public decimal Cobrado { get; set; }
        public decimal Por_Cobrar { get; set; }
        public decimal Total { get; set; }
        public int Cliente_Id { get; set; }
        public string Cliente { get; set; }
        public string Documento_Id { get; set; }
        public int Status_Id { get; set; }
        public string Status_Txt { get; set; }
        #endregion
    }
}
