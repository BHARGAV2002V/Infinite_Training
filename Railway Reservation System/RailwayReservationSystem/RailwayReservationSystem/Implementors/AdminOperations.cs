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
    public class TrainException : ApplicationException
    {
        public TrainException(String message) : base(message) { }


    }


    public class AdminOperations : IAdminOperations
    {
        private readonly IDatabaseOperations db;

        public AdminOperations(IDatabaseOperations databaseManager)
        {
            db = databaseManager;
        }



        //view trains
        public void viewAllTrains()
        {
            try
            {
                DataTable result = db.ExecuteStoredProcWithResult("getalltrains", null);
                Console.WriteLine();
                if (result.Rows.Count == 0)
                {
                    throw new TrainException("No trains available in the system.");
                }
                Console.WriteLine();
                Console.WriteLine("Available Trains:");
                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine($"Train ID       : {row["TrainId"]}");
                    Console.WriteLine($"Train Name     : {row["TrainName"]}");
                    Console.WriteLine($"Source         : {row["Source"]}");
                    Console.WriteLine($"Destination    : {row["Destination"]}");
                    Console.WriteLine($"Travel Time    : {row["TravelTime"]}");
                    Console.WriteLine("============================================");
                }
            }
            catch (TrainException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new TrainException($"An unexpected error occurred while viewing trains: {ex.Message}");
            }
        }


        // 2. Add New Train
        public void AddNewTrain()
        {
            try
            {
                Console.WriteLine("Enter Train Id:");
                int trainid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Train Name:");
                string trainName = Console.ReadLine();

                Console.WriteLine("Enter Source Station:");
                string source = Console.ReadLine();

                Console.WriteLine("Enter Destination Station:");
                string destination = Console.ReadLine();

                Console.WriteLine("Enter Travel Time:");
                string travelTime = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(trainName) || string.IsNullOrWhiteSpace(source) ||
                      string.IsNullOrWhiteSpace(destination) || string.IsNullOrWhiteSpace(travelTime))
                {
                    throw new TrainException("All fields are required to add a new train.");
                }
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@trainid", trainid),
                new SqlParameter("@TrainName", trainName),
                new SqlParameter("@Source", source),
                new SqlParameter("@Destination", destination),
                new SqlParameter("@TravelTime", travelTime)
                };

                db.ExecuteStoredProcWithResult("addtrain", parameters);

                Console.WriteLine("Train added successfully.");
            }
            catch (TrainException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // 3. Modify Train Details
        public void ModifyTrainDetails()
        {
            try
            {
                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Updated Train Name:");
                string trainName = Console.ReadLine();

                Console.WriteLine("Enter Updated Source Station:");
                string source = Console.ReadLine();

                Console.WriteLine("Enter Updated Destination Station:");
                string destination = Console.ReadLine();

                Console.WriteLine("Enter Updated Travel Time:");
                string travelTime = Console.ReadLine();

                Console.WriteLine("Enter Train Status (Active/Inactive):");
                string status = Console.ReadLine();
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrainId", trainId),
                    new SqlParameter("@TrainName", trainName),
                    new SqlParameter("@Source", source),
                    new SqlParameter("@Destination", destination),
                    new SqlParameter("@TravelTime", travelTime),
                    new SqlParameter("@Status", status)
                };

                db.ExecuteStoredProcWithResult("modifytrain", parameters);

                Console.WriteLine("Train details updated successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while updating the train details in the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred while modifying train details.");
            }
        }


        // 4. Delete Train (Soft Delete)
        public void DeleteTrain()
        {
            try
            {
                Console.WriteLine("Enter Train ID to delete:");
                int trainId = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrainId", trainId)
                };
                
                db.ExecuteStoredProcWithResult("deletetrain", parameters);


                Console.WriteLine("Train deleted successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while deleting the train from the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred while deleting the train.");
            }
        }



        // 5. View Train Schedules
        public void ViewTrainSchedules()
        {
            try
            {
                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrainId", trainId)
                };

                DataTable result = db.ExecuteStoredProcWithResult("gettrainschedule", parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No schedules found for the provided Train ID.");
                }
                else
                {
                    Console.WriteLine("Train Schedules:");
                    Console.WriteLine("===============================================");

                    foreach (DataRow row in result.Rows)
                    {
                        Console.WriteLine($"Train ID            : {row["TrainId"]}");
                        Console.WriteLine($"Station             : {row["StationName"]}");
                        Console.WriteLine($"Arrival Time        : {row["ArrivalTime"]}");
                        Console.WriteLine($"Departure Time      : {row["DepartureTime"]}");
                        Console.WriteLine($"Distance from Source: {row["distancefromsource"]} KM");
                        Console.WriteLine("-----------------------------------------------");
                    }

                    Console.WriteLine("===============================================");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer for Train ID.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while accessing the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
        }
        // 6. Add New Train Class
        public void AddNewTrainClass()
        {
            try {
                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Class Name:");
                string className = Console.ReadLine();
                Console.WriteLine("Enter Price:");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter Total Berths:");
                int totalBerths = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter available Berths:");
                int availableberths = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Waitlist Limit:");
                int waitlistLimit = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {

                new SqlParameter("@TrainId", trainId),
                new SqlParameter("@ClassName", className),
                new SqlParameter("@Price", price),
                new SqlParameter("@TotalBerths", totalBerths),

                new SqlParameter("@availableberths", availableberths),
                new SqlParameter("@WaitlistLimit", waitlistLimit)
                };

                db.ExecuteStoredProcWithResult("addtrainclass", parameters);
                Console.WriteLine("Train class added successfully.");

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

        // 7. Update Train Class
        public void UpdateTrainClass()
        {
            try {
                Console.WriteLine("Enter Class ID:");
                int classId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated Price:");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated Total Berths:");
                int totalBerths = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated Waitlist Limit:");
                int waitlistLimit = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@ClassId", classId),
                new SqlParameter("@Price", price),
                new SqlParameter("@TotalBerths", totalBerths),
                new SqlParameter("@WaitlistLimit", waitlistLimit)
                };

                db.ExecuteStoredProcWithResult("updatetrainclass", parameters);
                Console.WriteLine("Train class updated successfully.");
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

    

   


        // 11. View All Train Classes
        public void ViewAllTrainClasses()
        {
            try {
                Console.WriteLine("Enter train id");
                int trainid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@trainid",trainid)
                };
                DataTable result = db.ExecuteStoredProcWithResult("gettrainclasses", parameters);
                Console.WriteLine("Train Classes:");
                Console.WriteLine("===============================================");

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("No classes found for the provided Train ID.");
                }
                else
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Console.WriteLine($"Class ID          : {row["ClassId"]}");
                        Console.WriteLine($"Class Name        : {row["ClassName"]}");
                        Console.WriteLine($"Price             : {row["Price"]}");
                        Console.WriteLine($"Total Berths      : {row["totalberths"]}");
                        Console.WriteLine($"Available Berths  : {row["AvailableBerths"]}");
                        Console.WriteLine($"Waitlist Limit    : {row["waitlistlimit"]}");
                        Console.WriteLine("-----------------------------------------------");
                    }
                }

                Console.WriteLine("===============================================");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.",ex.Message);
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

        //12. add train schedules
        public void Addtrainschedules()
        {
            try
            {
                Console.WriteLine("Enter Train Id:");
                int trainid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter station Name:");
                string stationname = Console.ReadLine();
                Console.WriteLine("Enter arrival time:");
                string arrivaltime = Console.ReadLine();
                Console.WriteLine("Enter departure time:");
                string departuretime = Console.ReadLine();
                Console.WriteLine("Enter distance from source:");
                string distancefromsource = Console.ReadLine();
                Console.WriteLine();
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@trainid", trainid),

                new SqlParameter("@stationname", stationname),
                new SqlParameter("@arrivaltime", arrivaltime),
                new SqlParameter("@departuretime", departuretime),
                new SqlParameter("@distancefromsource", distancefromsource)
                };

                db.ExecuteStoredProcWithResult("addtrainschedule", parameters);
                Console.WriteLine("Train schedule added successfully.");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please ensure you enter the correct data type.", ex.Message);
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
