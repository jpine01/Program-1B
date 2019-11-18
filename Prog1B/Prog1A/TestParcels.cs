// Julio Pineda
// Program 1B
// CIS 200-01
// Fall 2018
// Due: 10/03/2018
// By: D9817

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Tommy Lee", "8923 Grove Street",
                "New York", "NY", 00025); // Test Address 5
            Address a6 = new Address("Joe Stanton", "1 Rowena Rd", "Apt. 6",
                "Las Vegas", "Nevada", 12345); // Test Address 6
            Address a7 = new Address("Michael Pineda", "6402 Normandy Way", 
                "Jacksonville", "IN", 59215); // Test Address 7
            Address a8 = new Address("Jack Stone", "888 Laguna Drive", "Unit 4A", 
                "NeverLand", "GA", 86358); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a5, a6, 56.1, 24.8, 23.6,  // Two Day test object
                15.7, TwoDayAirPackage.Delivery.Early);
            NextDayAirPackage ndp2 = new NextDayAirPackage(a7, a8, 67.7, 20, 33.3,  // Next Day test object
                78, 9.50M);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(ndp2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            // Holds the List ordered by Zipcodes
            var sortDestZip = from d in parcels
                              orderby d.DestinationAddress.Zip descending
                              select d;

            Console.WriteLine("===============Sort by Zip List============");
            Console.WriteLine("====================");
            foreach (Parcel parcel in sortDestZip)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("====================");
            }
            Pause();

            // Holds the List ordered by CalcCost
            var sortCost = from d in parcels
                           orderby d.CalcCost() ascending
                           select d;

            Console.WriteLine("===============Sort by Cost List============");
            Console.WriteLine("====================");
            foreach (Parcel parcel in sortCost)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("====================");
            }
            Pause();

            // Holds the list ordered by Parcel Type
            var sortParcelType = from d in parcels
                                 orderby d.GetType().ToString() ascending, d.CalcCost() descending
                                 select d;

            Console.WriteLine("===============Sort by Parel Type List============");
            Console.WriteLine("====================");
            foreach (Parcel parcel in sortParcelType)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("====================");
            }
            Pause();

            // Holds the List of Air Packages ordered by Weight
            var sortWeight = from d in parcels
                             let dp = d as AirPackage
                             where (dp != null) && (dp.IsHeavy())
                             orderby dp.Weight
                             select d;

            Console.WriteLine("===============Sort by Weight List============");
            Console.WriteLine("====================");
            foreach (var parcel in sortWeight)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("====================");
            }
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
