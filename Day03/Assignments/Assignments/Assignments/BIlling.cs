using System;

namespace C_Assignment
{
    class Bill
    {
        public string PatientName { get; set; }
        public int Age { get; set; }

    public decimal BaseAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetAmount { get; set; }
    }

    internal class BillingCalculator
    {
        const decimal ConsultationFee = 500;
        const decimal BloodTestFee = 200;
        const decimal XRayFee = 1000;
        const decimal AdmissionFee = 2000;

        static Bill bill = new Bill();

        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("       HOSPITAL BILLING CALCULATOR");
            Console.WriteLine("--------------------------------------------------");

            GetPatientDetails();

            AddServices();

            CalculateBill();

            DisplayBill();
        }

        static void GetPatientDetails()
        {
            Console.Write("Patient Name: ");
            bill.PatientName = Console.ReadLine();

            Console.Write("Patient Age: ");
            bill.Age = Convert.ToInt32(Console.ReadLine());
        }

        static void AddServices()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Add Services:");
                Console.WriteLine("1. Consultation (500)");
                Console.WriteLine("2. Blood Test (200)");
                Console.WriteLine("3. X-Ray (1000)");
                Console.WriteLine("4. Admission (2000)");
                Console.WriteLine("5. Done");

                Console.WriteLine();
                Console.Write("Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        bill.BaseAmount += ConsultationFee;
                        Console.WriteLine("[Added Consultation]");
                        break;

                    case 2:
                        bill.BaseAmount += BloodTestFee;
                        Console.WriteLine("[Added Blood Test]");
                        break;

                    case 3:
                        bill.BaseAmount += XRayFee;
                        Console.WriteLine("[Added X-Ray]");
                        break;

                    case 4:
                        bill.BaseAmount += AdmissionFee;
                        Console.WriteLine("[Added Admission]");
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void CalculateBill()
        {
            Console.WriteLine();
            Console.WriteLine("[Calculating Bill...]");

            if (bill.Age > 60)
            {
                bill.Discount =
                    bill.BaseAmount * 20 / 100;
            }
            else if (bill.Age < 10)
            {
                bill.Discount =
                    ConsultationFee * 50 / 100;
            }
            else
            {
                bill.Discount = 0;
            }

            decimal amountAfterDiscount =
                bill.BaseAmount - bill.Discount;

            bill.Tax =
                amountAfterDiscount * 5 / 100;

            bill.NetAmount =
                amountAfterDiscount + bill.Tax;
        }

        static void DisplayBill()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("            FINAL BILL INVOICE");
            Console.WriteLine("--------------------------------------------------");

            if (bill.Age > 60)
            {
                Console.WriteLine(
                    "Patient: " +
                    bill.PatientName +
                    " (Senior Citizen)"
                );
            }
            else if (bill.Age < 10)
            {
                Console.WriteLine(
                    "Patient: " +
                    bill.PatientName +
                    " (Child)"
                );
            }
            else
            {
                Console.WriteLine(
                    "Patient: " +
                    bill.PatientName
                );
            }

            Console.WriteLine();

            Console.WriteLine(
                "Base Amount:      " +
                bill.BaseAmount.ToString("0.00")
            );

            Console.WriteLine(
                "Discount:        -" +
                bill.Discount.ToString("0.00")
            );

            Console.WriteLine(
                "Tax (5%):        +" +
                bill.Tax.ToString("0.00")
            );

            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine(
                "TOTAL PAYABLE:    " +
                bill.NetAmount.ToString("0.00")
            );

            Console.WriteLine("--------------------------------------------------");
        }
    }

}
