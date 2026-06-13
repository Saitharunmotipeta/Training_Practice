using System;

namespace C_Assignment
{
    internal class VitalSignsMonitor
    {
        static string patientName;
        static double temperature;
        static int oxygenLevel;
        static int pulseRate;
        static string status;

    static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("       VITAL SIGNS MONITOR");
            Console.WriteLine("--------------------------------------------------");

            GetPatientName();
            GetTemperature();
            GetOxygenLevel();
            GetPulseRate();

            Console.WriteLine();
            Console.WriteLine("[Analyzing Data...]");

            status = CheckStatus();

            DisplayReport();
        }

        static void GetPatientName()
        {
            Console.Write("Enter Patient Name: ");
            patientName = Console.ReadLine();
        }

        static void GetTemperature()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Temperature (C): ");
                    temperature = Convert.ToDouble(Console.ReadLine());

                    if (temperature > 0)
                        break;

                    Console.WriteLine("Invalid Temperature");
                }
                catch
                {
                    Console.WriteLine("Please Enter Numeric Value");
                }
            }
        }

        static void GetOxygenLevel()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Oxygen Level (%): ");
                    oxygenLevel = Convert.ToInt32(Console.ReadLine());

                    if (oxygenLevel >= 0 && oxygenLevel <= 100)
                        break;

                    Console.WriteLine("Oxygen Level Must Be Between 0 And 100");
                }
                catch
                {
                    Console.WriteLine("Please Enter Numeric Value");
                }
            }
        }

        static void GetPulseRate()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Pulse Rate (BPM): ");
                    pulseRate = Convert.ToInt32(Console.ReadLine());

                    if (pulseRate > 0)
                        break;

                    Console.WriteLine("Invalid Pulse Rate");
                }
                catch
                {
                    Console.WriteLine("Please Enter Numeric Value");
                }
            }
        }

        static string CheckStatus()
        {
            if (temperature > 39.0 ||
                oxygenLevel < 90 ||
                pulseRate < 50 ||
                pulseRate > 120)
            {
                return "CRITICAL / EMERGENCY";
            }

            else if (temperature > 37.5 ||
                     oxygenLevel < 95 ||
                     pulseRate > 100)
            {
                return "OBSERVATION NEEDED";
            }

            else
            {
                return "NORMAL";
            }
        }

        static void DisplayReport()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("       MEDICAL ASSESSMENT REPORT");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Patient: " + patientName);

            Console.WriteLine();
            Console.WriteLine("Vitals Recorded:");

            Console.WriteLine("- Temp:   " + temperature + " C");
            Console.WriteLine("- Oxygen: " + oxygenLevel + " %");
            Console.WriteLine("- Pulse:  " + pulseRate + " BPM");

            Console.WriteLine();
            Console.WriteLine("Status Assessment: " + status);

            if (status == "CRITICAL / EMERGENCY")
            {
                Console.WriteLine("Action: Immediate Medical Attention Required.");
            }
            else if (status == "OBSERVATION NEEDED")
            {
                Console.WriteLine("Action: Nurse to monitor every hour.");
            }
            else
            {
                Console.WriteLine("Action: Continue Routine Monitoring.");
            }

            Console.WriteLine("--------------------------------------------------");
        }
    }

}
