using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class SavingAccountDto
    {
        #region Properties
        public int Transaction_Id { get; set; }
        public int Saving_Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public int Cliente_Id { get; set; }
        public string Cliente { get; set; }
        public string Documento_Txt { get; set; }
        #endregion
    }
}
