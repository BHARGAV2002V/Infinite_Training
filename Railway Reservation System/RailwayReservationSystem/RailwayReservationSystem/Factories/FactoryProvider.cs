using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Factories.Interfaces;
using RailwayReservationSystem.Implementors.Interfaces;

using RailwayReservationSystem.Implementors;
namespace RailwayReservationSystem.Factories
{
    public static class FactoryProvider
    {
        private static readonly string conn = @"Data Source=ICS-LT-D244D678\SQLEXPRESS;Initial Catalog=RailwayReservationSystem;Integrated Security=true;";
        private static IDatabaseOperations db = new DatabaseManager(conn);
        public static IAdminFactory GetAdminFactory()
        {
            return new AdminFactory(db);
        }
        public static IUserFactory GetUserFactory()
        {
            return new UserFactory(db);
        }
    }
}
