using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Factories.Interfaces;
using RailwayReservationSystem.Implementors;
using RailwayReservationSystem.Implementors.Interfaces;
namespace RailwayReservationSystem.Factories
{
    public class AdminFactory : IAdminFactory
    {
        private readonly IDatabaseOperations db;
        public AdminFactory(IDatabaseOperations databaseManager)
        {
            db = databaseManager;
        }
        public IAdminOperations GetAdminOperations()
        {
            return new AdminOperations(db);
        }
    }
}
