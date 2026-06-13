using System;
using System.Collections.Generic;

namespace C_Assignment
{
    class PatientRecord
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BillAmount { get; set; }
        public string Status { get; set; }
    }

    internal class HospitalSummaryReport
    {
        static List<PatientRecord> patients =
            new List<PatientRecord>();

        static void Main(string[] args)
        {
            AddPatients();

            ShowReport();
        }

        static void AddPatients()
        {
            patients.Add(new PatientRecord
            {
                Name = "John Doe",
                Department = "General",
                BillAmount = 500,
                Status = "Discharged"
            });

            patients.Add(new PatientRecord
            {
                Name = "Jane Smith",
                Department = "Dental",
                BillAmount = 1200,
                Status = "Admitted"
            });

            patients.Add(new PatientRecord
            {
                Name = "Bob Brown",
                Department = "General",
                BillAmount = 400,
                Status = "Discharged"
            });

            patients.Add(new PatientRecord
            {
                Name = "Alice W.",
                Department = "Ortho",
                BillAmount = 2500,
                Status = "Admitted"
            });

            patients.Add(new PatientRecord
            {
                Name = "Sam K.",
                Department = "Dental",
                BillAmount = 800,
                Status = "Discharged"
            });
        }

        static void ShowReport()
        {
            int totalPatients = 0;
            decimal totalRevenue = 0;

            int general = 0;
            int dental = 0;
            int ortho = 0;

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("       DAILY HOSPITAL ACTIVITY REPORT");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Date: " + DateTime.Now.ToShortDateString());

            Console.WriteLine();
            Console.WriteLine("Patient List:");

            int i = 1;

            foreach (PatientRecord patient in patients)
            {
                Console.WriteLine(
                    i + ". " +
                    patient.Name + " - " +
                    patient.Department + " - $" +
                    patient.BillAmount);

                totalPatients++;
                totalRevenue += patient.BillAmount;

                if (patient.Department == "General")
                {
                    general++;
                }
                else if (patient.Department == "Dental")
                {
                    dental++;
                }
                else if (patient.Department == "Ortho")
                {
                    ortho++;
                }

                i++;
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("SUMMARY STATISTICS");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Total Patients Visited: " + totalPatients);
            Console.WriteLine("Total Revenue: $" + totalRevenue);

            Console.WriteLine();
            Console.WriteLine("Traffic by Department:");

            Console.WriteLine("- General: " + general);
            Console.WriteLine("- Dental: " + dental);
            Console.WriteLine("- Ortho: " + ortho);

            Console.WriteLine();
            Console.WriteLine("End of Report.");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}