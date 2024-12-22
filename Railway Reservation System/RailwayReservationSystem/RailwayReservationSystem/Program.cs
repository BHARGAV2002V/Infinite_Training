using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Factories;
using RailwayReservationSystem.Factories.Interfaces;
using RailwayReservationSystem.Implementors.Interfaces;
using RailwayReservationSystem.Implementors;
namespace RailwayReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("  Welcome to the Railway Reservation System!");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.WriteLine("Please choose an option to continue:");
            Console.WriteLine("  1. Admin Login");
            Console.WriteLine("  2. User Login");
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                IAdminFactory adminFactory = FactoryProvider.GetAdminFactory();
                IAdminOperations adminOps = adminFactory.GetAdminOperations();

                Console.WriteLine("Admin login successful.");

                PerformAdminOperations(adminOps);
            }
            else if (choice == 2)
            {
                IUserFactory userFactory = FactoryProvider.GetUserFactory();

                IUserOperations userOps = userFactory.GetUserOperations();
                Console.WriteLine("1:Register\n2:Login");
                int n = int.Parse(Console.ReadLine());
                if (n == 1){
                    userOps.register();
                    PerformUserOperations(userOps);

                }
                else if (n == 2)
                {
                    bool isauthenticate = userOps.Authenticate();

                    if (isauthenticate)
                    {
                        Console.WriteLine("User login successful.");
                        PerformUserOperations(userOps);
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials");
                    }
                }
               


             
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting the system.");
            }
        }

        // Admin Operations Menu
        private static void PerformAdminOperations(IAdminOperations adminOps)
        {
            while (true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("  Welcome Admin! Please select an action:");
                Console.WriteLine("===========================================");
                Console.WriteLine();
                Console.WriteLine("  1. Add New Train");
                Console.WriteLine("  2. Modify Train Details");
                Console.WriteLine("  3. Delete Train (Soft Delete)");
                Console.WriteLine("  4. View Train Schedules");
                Console.WriteLine("  5. Add New Train Class");
                Console.WriteLine("  6. Update Train Class");
                Console.WriteLine("  7. View All Train Classes");
                Console.WriteLine("  8. Add Train Schedules");
                Console.WriteLine("  9. View All Trains");
                Console.WriteLine(" 10. Exit");
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.Write("Enter your choice: ");

                int adminChoice = int.Parse(Console.ReadLine());

                switch (adminChoice)
                {
                    case 1:
                        adminOps.AddNewTrain();
                        break;
                    case 2:
                        adminOps.ModifyTrainDetails();
                        break;
                    case 3:
                        adminOps.DeleteTrain();
                        break;
                    case 4:
                        adminOps.ViewTrainSchedules();
                        break;
                    case 5:
                        adminOps.AddNewTrainClass();
                        break;
                    case 6:
                        adminOps.UpdateTrainClass();
                        break;
                    case 7:
                        adminOps.ViewAllTrainClasses();
                        break;
                    case 8:
                        adminOps.Addtrainschedules();
                        break;
                    case 9:
                        adminOps.viewAllTrains();
                        break;
                    case 10:
                        Console.WriteLine("Exiting Admin Portal.");
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }
            }
        }

        // User Operations Menu
        private static void PerformUserOperations(IUserOperations userOps)
        {
            while (true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("   Welcome User! Please select an action:");
                Console.WriteLine("===========================================");
                Console.WriteLine();
                Console.WriteLine("  1. Search Trains");
                Console.WriteLine("  2. Book a Ticket");
                Console.WriteLine("  3. View Booked Tickets");
                Console.WriteLine("  4. Cancel a Booking");
                Console.WriteLine("  5. View Refund Status");
                Console.WriteLine("  6. View Train Schedules");
                Console.WriteLine("  7. View Train Classes");
                Console.WriteLine("  8. View All Trains");
                Console.WriteLine("  9. Print Ticket");
                Console.WriteLine(" 10. Exit");
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.Write("Enter your choice: ");

                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        userOps.ViewAvailableTrains();
                        break;
                    case 2:
                        userOps.BookTicket();
                        break;
                    case 3:
                        userOps.ViewBookedTickets();
                        break;
                    case 4:
                        userOps.CancelBooking();
                        break;
                    case 5:
                        userOps.ViewRefundStatus();
                        break;
                    case 6:
                        userOps.ViewTrainSchedules();
                        break;
                    case 7:
                        userOps.ViewAllTrainClasses();
                        break;
                    case 8:
                        userOps.viewAllTrains();
                        break;
                    case 9:
                        userOps.PrintTicket();
                        break;
                    case 10:
                        Console.WriteLine("Exiting User Portal.");
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }
            }
        }
    }
}

