using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CareBridgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine(" CAREBRIDGE OPERATIONS CONSOLE");
                Console.WriteLine("====================================");
                Console.WriteLine("1. 30 Day Readmissions");
                Console.WriteLine("2. High Risk Patients");
                Console.WriteLine("3. Provider Workload");
                Console.WriteLine("4. Revenue Analysis");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

            Console.Write("Enter Choice : ");

                string choice = Console.ReadLine() ?? "";

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ReadmissionReport();
                        break;

                    case "2":
                        HighRiskPatients();
                        break;

                    case "3":
                        ProviderWorkload();
                        break;

                    case "4":
                        RevenueAnalysis();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ReadmissionReport()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=CareBridgeDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_30_day_readmission", conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            conn.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            Console.WriteLine("30 DAY READMISSION REPORT");
            Console.WriteLine("-------------------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Patient Id : {reader["PatientId"]} | " +
                    $"Readmissions : {reader["ReadmissionCount"]}"
                );
            }
        }

        static void HighRiskPatients()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=CareBridgeDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_high_risk_patients", conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            conn.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            Console.WriteLine("HIGH RISK PATIENTS");
            Console.WriteLine("------------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Patient Id : {reader["PatientId"]} | " +
                    $"Name : {reader["FullName"]} | " +
                    $"Age : {reader["Age"]}"
                );
            }
        }

        static void ProviderWorkload()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=CareBridgeDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_high_workload_provider", conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            conn.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            Console.WriteLine("PROVIDER WORKLOAD");
            Console.WriteLine("-----------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Provider : {reader["FullName"]} | " +
                    $"Encounters : {reader["TotalEncounters"]}"
                );
            }
        }

        static void RevenueAnalysis()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=CareBridgeDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand("SP_CLAIMS", conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            conn.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            Console.WriteLine("REVENUE ANALYSIS");
            Console.WriteLine("----------------");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Status : {reader["Status"]} | " +
                    $"Total Claims : {reader["TotalClaims"]} | " +
                    $"Outstanding Amount : {reader["OutstandingAmount"]}"
                );
            }
        }
    }

}
