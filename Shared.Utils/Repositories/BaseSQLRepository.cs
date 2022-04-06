using System;
using System.Data;
using System.Data.SqlClient;

namespace Shared.Utils.Repositories
{
    public class BaseSQLRepository
    {
        private readonly IDomainConfig _domainConfig;

        public BaseSQLRepository(IDomainConfig domainConfig)
        {
            _domainConfig = domainConfig ?? throw new ArgumentNullException(nameof(domainConfig));
        }

        protected IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_domainConfig.ConnectionString);

            connection.Open();

            return connection;
        }
    }
}
