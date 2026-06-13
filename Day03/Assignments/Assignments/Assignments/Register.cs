using System;

namespace C_Assignment
{
    class Patient
    {
        public string PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }

internal class PatientRegistration
    {
        static Patient patient = new Patient();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("       HOSPITAL PATIENT REGISTRATION SYSTEM");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Exit");
                Console.WriteLine();

                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterPatient();
                        break;

                    case 2:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void RegisterPatient()
        {
            GetPatientName();
            GetPatientAge();
            GetPatientGender();
            GetPhoneNumber();
            GetCity();

            patient.PatientID = "PAT-2025-001";

            DisplaySlip();
        }

        static void GetPatientName()
        {
            Console.Write("Enter Patient Name: ");
            patient.Name = Console.ReadLine();
        }

        static void GetPatientAge()
        {
            Console.Write("Enter Age: ");
            patient.Age = Convert.ToInt32(Console.ReadLine());
        }

        static void GetPatientGender()
        {
            Console.Write("Enter Gender (Male/Female/Other): ");
            patient.Gender = Console.ReadLine();
        }

        static void GetPhoneNumber()
        {
            Console.Write("Enter Phone Number: ");
            patient.PhoneNumber = Console.ReadLine();
        }

        static void GetCity()
        {
            Console.Write("Enter City: ");
            patient.City = Console.ReadLine();
        }

        static void DisplaySlip()
        {
            Console.WriteLine();
            Console.WriteLine("[Registration Complete]");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("            PATIENT REGISTRATION SLIP");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Date: " + DateTime.Now.ToShortDateString());

            Console.WriteLine();

            Console.WriteLine("Patient ID: " + patient.PatientID);
            Console.WriteLine("Name:       " + patient.Name);
            Console.WriteLine("Age:        " + patient.Age + " years");
            Console.WriteLine("Gender:     " + patient.Gender);
            Console.WriteLine("Contact:    " + patient.PhoneNumber);
            Console.WriteLine("Location:   " + patient.City);

            Console.WriteLine();
            Console.WriteLine("Instructions:");
            Console.WriteLine("Please proceed to the waiting area.");

            Console.WriteLine("--------------------------------------------------");
        }
    }

}
