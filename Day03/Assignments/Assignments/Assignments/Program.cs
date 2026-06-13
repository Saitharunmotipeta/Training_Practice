using System;
using System.Collections.Generic;

namespace C_Assignment
{
    class Appointment
    {
        public string PatientName;
        public string Department;
        public string Doctor;
        public string Time;
    }

internal class AppointmentScheduling
    {
        static Appointment appointment = new Appointment();

        static string[] departments =
        {
        "General Medicine",
        "Dental",
        "Orthopedics"
    };

        static List<string> generalDoctors =
            new List<string>()
        {
        "Dr. A. Kumar",
        "Dr. B. Singh"
        };

        static List<string> dentalDoctors =
            new List<string>()
        {
        "Dr. C. Roy",
        "Dr. D. Gupta"
        };

        static List<string> orthopedicDoctors =
            new List<string>()
        {
        "Dr. E. Mehta",
        "Dr. F. Reddy"
        };

        static List<string> timeSlots =
            new List<string>()
        {
        "10:00 AM",
        "11:00 AM",
        "12:00 PM"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("       APPOINTMENT BOOKING SYSTEM");
            Console.WriteLine("--------------------------------------------------");

            Console.Write("Enter Patient Name: ");
            appointment.PatientName = Console.ReadLine();

            while (true)
            {
                ShowDepartments();

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ShowGeneralDoctors();
                        return;

                    case 2:
                        ShowDentalDoctors();
                        return;

                    case 3:
                        ShowOrthopedicDoctors();
                        return;

                    default:
                        Console.WriteLine("Invalid Department Choice");
                        break;
                }
            }
        }

        static void ShowDepartments()
        {
            Console.WriteLine();
            Console.WriteLine("Select Department:");
            Console.WriteLine("1. General Medicine");
            Console.WriteLine("2. Dental");
            Console.WriteLine("3. Orthopedics");
            Console.Write("Enter Choice: ");
        }

        static void ShowGeneralDoctors()
        {
            appointment.Department = departments[0];

            Console.WriteLine();
            Console.WriteLine("Select Doctor:");

            for (int i = 0; i < generalDoctors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + generalDoctors[i]);
            }

            Console.Write("Enter Choice: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 ||
                   choice > generalDoctors.Count)
            {
                Console.WriteLine("Invalid Doctor Choice");
            }

            appointment.Doctor =
                generalDoctors[choice - 1];

            ShowTimeSlots();
        }

        static void ShowDentalDoctors()
        {
            appointment.Department = departments[1];

            Console.WriteLine();
            Console.WriteLine("Select Doctor:");

            for (int i = 0; i < dentalDoctors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + dentalDoctors[i]);
            }

            Console.Write("Enter Choice: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 ||
                   choice > dentalDoctors.Count)
            {
                Console.WriteLine("Invalid Doctor Choice");
            }

            appointment.Doctor =
                dentalDoctors[choice - 1];

            ShowTimeSlots();
        }

        static void ShowOrthopedicDoctors()
        {
            appointment.Department = departments[2];

            Console.WriteLine();
            Console.WriteLine("Select Doctor:");

            for (int i = 0; i < orthopedicDoctors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + orthopedicDoctors[i]);
            }

            Console.Write("Enter Choice: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 ||
                   choice > orthopedicDoctors.Count)
            {
                Console.WriteLine("Invalid Doctor Choice");
            }

            appointment.Doctor =
                orthopedicDoctors[choice - 1];

            ShowTimeSlots();
        }

        static void ShowTimeSlots()
        {
            Console.WriteLine();
            Console.WriteLine("Select Time Slot:");

            for (int i = 0; i < timeSlots.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + timeSlots[i]);
            }

            Console.Write("Enter Choice: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 ||
                   choice > timeSlots.Count)
            {
                Console.WriteLine("Invalid Time Slot Choice");
            }

            appointment.Time =
                timeSlots[choice - 1];

            DisplayTicket();
        }

        static void DisplayTicket()
        {
            Console.WriteLine();
            Console.WriteLine("[Booking Confirmed]");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("            APPOINTMENT TICKET");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Patient:    " + appointment.PatientName);
            Console.WriteLine("Department: " + appointment.Department);
            Console.WriteLine("Doctor:     " + appointment.Doctor);
            Console.WriteLine("Time:       " + appointment.Time);
            Console.WriteLine("Status:     Confirmed");

            Console.WriteLine();
            Console.WriteLine("Please arrive 15 mins before your slot.");
            Console.WriteLine("--------------------------------------------------");
        }
    }

}
