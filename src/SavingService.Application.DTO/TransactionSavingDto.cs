﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Application.DTO
{
    public class TransactionSavingDto
    {
        #region Properties
        public int Saving_ID { get; set; }
        public int Transaction_Id { get; set; }
        public int Documento_Id { get; set; }
        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }
        #endregion
    }
}
