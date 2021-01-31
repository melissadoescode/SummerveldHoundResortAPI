using SummerveldHoundResort.Infrastructure.Enum;
using SummerveldHoundResort.Infrastructure.Interfaces.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Repositories.DbConnection
{
    public class DbConnectionDevRepository
    {
        public IDbConnection DbConnection { get; private set; }

        public DbConnectionDevRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.DbConnection = dbConnectionFactory.CreateDbConnection(DbConnectionName.SummerveldHoundResortDev);
        }
    }
}
