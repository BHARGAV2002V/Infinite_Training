using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem.Implementors.Interfaces
{
   public interface IDatabaseOperations
    {
        void DatabaseManager(string connectionString);
        void ExecuteStoredProc(string procedureName, SqlParameter[] parameters);
        DataTable ExecuteStoredProcWithResult(string procedureName, SqlParameter[] parameters);
    }
}
