using News.Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace News.DataLayer.SharedKernel
{
    public class DbFactory : IDbFactory
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(GlobalContext.Instance.ConnectionString);
        }
    }
}
