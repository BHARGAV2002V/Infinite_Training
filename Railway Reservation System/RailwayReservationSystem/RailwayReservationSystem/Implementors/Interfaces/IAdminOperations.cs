using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.Implementors.Interfaces
{
    public interface IAdminOperations
    {
        void viewAllTrains();
        void AddNewTrain();
        void ModifyTrainDetails();
        void DeleteTrain();
        void ViewTrainSchedules();
        void AddNewTrainClass();
        void UpdateTrainClass();
        void ViewAllTrainClasses();
        void Addtrainschedules();

    }
}
