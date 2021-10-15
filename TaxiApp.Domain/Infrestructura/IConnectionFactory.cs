using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaxiApp.Domain.Infrestructura
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
