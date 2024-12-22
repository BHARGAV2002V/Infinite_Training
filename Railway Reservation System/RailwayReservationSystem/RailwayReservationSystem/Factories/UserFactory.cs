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
    public class UserFactory:IUserFactory
    {
        private readonly IDatabaseOperations db;
        public UserFactory(IDatabaseOperations databaseManager)
        {
            db = databaseManager;
        }
        public IUserOperations GetUserOperations()
        {
            return new UserOperations(db);
        }
    }
}
