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
    public class UserOperations : IUserOperations
    {
        private readonly IDatabaseOperations db;

        public UserOperations(IDatabaseOperations databaseManager)
        {
            db = databaseManager;
        }

        public void register()
        {
            try {
                Console.WriteLine("Enter user name:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                Console.WriteLine("Enter phone number:");
                string phone = Console.ReadLine();

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@username", username),

                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
                new SqlParameter("@phone", phone),
                };

                db.ExecuteStoredProcWithResult("adduser", parameters);
                Console.WriteLine("user registered successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

            
        }
        public bool Authenticate()
        {
            try
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                // Email validation 
                if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                {
                    Console.WriteLine("Invalid email format.");
                }

                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                // Password validation 
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty.");
                }

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password)
                };

                DataTable result = db.ExecuteStoredProcWithResult("authenticateuser", parameters);

                if (result.Rows.Count > 0)
                {
                    string username = result.Rows[0]["Username"].ToString();
                    int userId = Convert.ToInt32(result.Rows[0]["UserId"]);

                    Console.WriteLine("===========================================");
                    Console.WriteLine($"Welcome back, {username}!");
                    Console.WriteLine($"Your unique User ID is: {userId}");
                    Console.WriteLine("===========================================");

                    return true;
                }
                else
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Invalid credentials. Please check your username and password.");
                    Console.WriteLine("===========================================");

                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false;
            }
        }


        // 1. View Available Trains
        public void ViewAvailableTrains()
        {
            try {
                Console.WriteLine("Enter Source Station:");
                string source = Console.ReadLine();
                Console.WriteLine("Enter Destination Station:");
                string destination = Console.ReadLine();


                var parameters = new SqlParameter[]
                {
                new SqlParameter("@Source", source),
                new SqlParameter("@Destination", destination),


                };

                DataTable result = db.ExecuteStoredProcWithResult("searchtrains", parameters);
                Console.WriteLine("Available Trains:");
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine($"Train ID       : {row["TrainId"]}");
                    Console.WriteLine($"Train Name     : {row["TrainName"]}");
                    Console.WriteLine($"Source         : {row["Source"]}");
                    Console.WriteLine($"Destination    : {row["Destination"]}");
                    Console.WriteLine($"Travel Time    : {row["TravelTime"]}");
                    Console.WriteLine("===========================================");
                }
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

          
        }

        public void viewAllTrains()
        {

            try {
                DataTable result = db.ExecuteStoredProcWithResult("getalltrains", null);
                Console.WriteLine("Available Trains:");
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine($"Train ID       : {row["TrainId"]}");
                    Console.WriteLine($"Train Name     : {row["TrainName"]}");
                    Console.WriteLine($"Source         : {row["Source"]}");
                    Console.WriteLine($"Destination    : {row["Destination"]}");
                    Console.WriteLine($"Travel Time    : {row["TravelTime"]}");
                    Console.WriteLine("===========================================");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
           
        }

        // 2. View Train Classes
       
        // 3. Book Ticket
        public void BookTicket()
        {
            try {
                Console.WriteLine("Enter User ID:");

                int userId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Class ID:");
                int classId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Passenger Name:");
                string passengerName = Console.ReadLine();
                Console.WriteLine("Enter Passenger Age:");
                int passengerAge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Passenger Gender:");
                string passengerGender = Console.ReadLine();
                Console.WriteLine("Enter Seats Booked:");
                int Seatsbooked = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Travel Date:");
                DateTime traveldate = Convert.ToDateTime(Console.ReadLine());
                DateTime date = traveldate.Date;
                Console.WriteLine();

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@UserId", userId),

                new SqlParameter("@TrainId", trainId),
                new SqlParameter("@ClassId", classId),
                new SqlParameter("@PassengerName", passengerName),
                new SqlParameter("@passengerage", passengerAge),
                new SqlParameter("@passengergender", passengerGender),
                new SqlParameter("@seatsbooked", Seatsbooked),
                new SqlParameter("@traveldate", date),


                };

                db.ExecuteStoredProcWithResult("BookTicket", parameters);
                Console.WriteLine("Ticket booked successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"An error occurred while booking a ticket. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

          
        }

        // 4. View Booking History
        public void ViewBookedTickets()
        {
            try {
                Console.WriteLine("Enter User ID:");
                int userId = int.Parse(Console.ReadLine());

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@UserId", userId)
                };

                DataTable result = db.ExecuteStoredProcWithResult("bookinghistory", parameters);

                Console.WriteLine("Booking History:");
                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No Details Found.");
                }
                Console.WriteLine("============================== Booking History ==============================");
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("----------------------------------------------------------------------------");
                    Console.WriteLine($"PNR             : {row["BookingId"]}");
                    Console.WriteLine($"Train ID        : {row["trainid"]}");
                    Console.WriteLine($"Class ID        : {row["classid"]}  ");
                    Console.WriteLine($"Class Name      : {row["classname"]}    ");
                    Console.WriteLine($"Passenger Name  : {row["passengername"]}        ");
                    Console.WriteLine($"Passenger Age   : {row["passengerage"]}      ");
                    Console.WriteLine($"Passenger Gender: {row["passengergender"]}  ");
                    Console.WriteLine($"Seats Booked    : {row["seatsbooked"]}");
                    Console.WriteLine($"Source          : {row["source"]}");
                    Console.WriteLine($"Destination     : {row["destination"]}");
                    Console.WriteLine($"Travel Date     : {Convert.ToDateTime(row["traveldate"]).ToString("dd-MMM-yyyy")}");
                    Console.WriteLine($"Booking Status  : {row["bookingstatus"]}");
                    Console.WriteLine($"Discount Applied: {row["discountapplied"]}");

                    Console.WriteLine($"Total Fare      : {row["totalfare"]}");
                    Console.WriteLine("----------------------------------------------------------------------------");
                }
                Console.WriteLine("=============================================================================");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

           
        }


        public void PrintTicket()
        {
            try
            {
                Console.WriteLine("Enter PNR number:");
                int bookingid = int.Parse(Console.ReadLine());

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@bookingid", bookingid)
                };

                DataTable result = db.ExecuteStoredProcWithResult("printbookingticket", parameters);

                Console.WriteLine("---------YOUR TICKET-----------");
                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No Details Found.");
                }
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("==================================== Ticket Details ====================================");
                    Console.WriteLine($"| PNR                : {row["BookingId"]}                                              ");
                    Console.WriteLine($"| Train ID           : {row["trainid"]}                                               ");
                    Console.WriteLine($"| Class ID           : {row["classid"]}                                               ");
                    Console.WriteLine($"| Class Name         : {row["classname"]}                                             ");
                    Console.WriteLine($"| Passenger Name     : {row["passengername"]}                                         ");
                    Console.WriteLine($"| Passenger Age      : {row["passengerage"]}                                          ");
                    Console.WriteLine($"| Passenger Gender   : {row["passengergender"]}                                       ");
                    Console.WriteLine($"| Seats Booked       : {row["seatsbooked"]}                                           ");
                    Console.WriteLine($"| Source Station     : {row["source"]}                                                ");
                    Console.WriteLine($"| Destination Station: {row["destination"]}                                           ");
                    Console.WriteLine($"| Travel Date        : {Convert.ToDateTime(row["traveldate"]).ToString("dd-MMM-yyyy")}");
                    Console.WriteLine($"| Discount Applied   : {row["discountapplied"]}                                       ");
                    Console.WriteLine($"| Total Fare         : {row["totalfare"]}                                             ");
                    Console.WriteLine($"| Booking Status     : {row["bookingstatus"]}                                         ");
                    Console.WriteLine("========================================================================================");
                }
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        // 5. Cancel Ticket
        public void CancelBooking()
        {
            try {
                Console.WriteLine("Enter PNR number:");
                int bookingId = int.Parse(Console.ReadLine());

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@BookingId", bookingId)
                };

                db.ExecuteStoredProcWithResult("cancelbooking", parameters);
                Console.WriteLine("Ticket canceled successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

          
        }

        // 6. View Refund Status
        public void ViewRefundStatus()
        {
            try
            {
                Console.WriteLine("Enter PNR number:");
                if (!int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    Console.WriteLine("Invalid Booking ID. Please enter a valid integer.");
                    return;
                }

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@bookingid", bookingId),
                    new SqlParameter("@refundstatus", SqlDbType.VarChar,20)
                    {
                        Direction = ParameterDirection.Output,
                    },
                    new SqlParameter("@refundamount", DbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    },
                };

                try
                {
                    db.ExecuteStoredProcWithResult("processRefund", parameters);

                    string refundStatus = parameters[1].Value.ToString();
                    decimal refundAmount = Convert.ToDecimal(parameters[2].Value);

                    Console.WriteLine("============== Refund Details ==============");
                    Console.WriteLine($"   Refund Status   : {refundStatus}");
                    Console.WriteLine($"   Refund Amount   : {refundAmount}");

                    if (refundStatus == "Refund Processed")
                    {
                        Console.WriteLine("   Status Message  : Refund Processed Successfully");
                    }
                    else
                    {
                        Console.WriteLine("   Status Message  : Refund Could Not Be Processed");
                    }
                    Console.WriteLine("============================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

          
        }
        // 7. View Train Schedule
        public void ViewTrainSchedules()
        {
            try {
                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@TrainId", trainId)
                };

                DataTable result = db.ExecuteStoredProcWithResult("gettrainschedule", parameters);
                Console.WriteLine("Train Schedule:");
                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No Details Found.");
                }
                Console.WriteLine("=============== Train Schedules ===============");
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"   Train ID            : {row["trainid"]}");
                    Console.WriteLine($"   Station Name        : {row["stationname"]}");
                    Console.WriteLine($"   Arrival Time        : {row["arrivaltime"]}");
                    Console.WriteLine($"   Departure Time      : {row["departuretime"]}");
                    Console.WriteLine($"   Distance from Source: {row["distancefromsource"]} km");
                }
                Console.WriteLine("================================================");

            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

            
        }

        //view train classes
        public void ViewAllTrainClasses()
        {
            try {
                Console.WriteLine("Enter train id");
                int trainid = Convert.ToInt32(Console.ReadLine());
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@trainid",trainid)
                };
                DataTable result = db.ExecuteStoredProcWithResult("gettrainclasses", parameters);
                Console.WriteLine("Train Classes:");
                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No classes found for the provided Train ID.");
                }
                Console.WriteLine("============== Train Classes ==============");
                int index = 1;
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine($"Class {index++}:");
                    Console.WriteLine($"   Class ID        : {row["ClassId"]}");
                    Console.WriteLine($"   Class Name      : {row["ClassName"]}");
                    Console.WriteLine($"   Price           : {row["Price"]}");
                    Console.WriteLine($"   Total Berths    : {row["TotalBerths"]}");
                    Console.WriteLine($"   Available Berths: {row["AvailableBerths"]}");
                    Console.WriteLine($"   Waitlist Limit  : {row["WaitlistLimit"]}");
                    Console.WriteLine("------------------------------------------");
                }
                Console.WriteLine("===========================================");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

           
        }
        // 8. View Waitlist Position
        public void ViewWaitlistPosition()
        {
            try {
                Console.WriteLine("Enter PNR number:");
                int bookingId = int.Parse(Console.ReadLine());

                var parameters = new SqlParameter[]
                {
                new SqlParameter("@BookingId", bookingId)
                };

                DataTable result = db.ExecuteStoredProcWithResult("GetWaitlistPosition", parameters);
                Console.WriteLine("Waitlist Position:");
                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No Details Found.");
                }
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine($"WaitlistId: {row["WaitlistId"]}, Position: {row["WaitlistPosition"]}");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

         
        }

       
    }
}
