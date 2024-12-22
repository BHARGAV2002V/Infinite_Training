using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Implementors.Interfaces;

namespace RailwayReservationSystem.Factories.Interfaces
{
    public interface IAdminFactory
    {
        IAdminOperations GetAdminOperations();
    }
}
