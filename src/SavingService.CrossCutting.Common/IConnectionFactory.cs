using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SavingService.CrossCutting.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
