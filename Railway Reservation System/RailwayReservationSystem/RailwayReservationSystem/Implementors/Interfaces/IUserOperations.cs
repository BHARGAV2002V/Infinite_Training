using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.Implementors.Interfaces
{
    public interface IUserOperations
    {
        void register();
        bool Authenticate();
        void ViewAvailableTrains();
        void viewAllTrains();
        void PrintTicket();
        void BookTicket();
        void ViewBookedTickets();
        void CancelBooking();
        void ViewRefundStatus();
        void ViewTrainSchedules();
        void ViewAllTrainClasses();

    }
}
