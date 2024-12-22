using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RailwayReservationSystem.Implementors.Interfaces;
namespace RailwayReservationSystem.Implementors
{
    class DatabaseManager:IDatabaseOperations
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public  DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to execute a stored procedure without returning data
        public void ExecuteStoredProc(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters one by one
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        // Method to execute a stored procedure and return a DataTable
        public DataTable ExecuteStoredProcWithResult(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters one by one
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }

        void IDatabaseOperations.DatabaseManager(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
