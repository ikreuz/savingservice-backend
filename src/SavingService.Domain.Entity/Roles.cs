﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SavingService.Domain.Entity
{
    public class Roles
    {
        #region Constants
        public const string Master = "Master";
        public const string Capturista = "Capturista";
        public const string Cliente = "Cliente";
        #endregion

        #region Properties
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        #endregion
    }
}
