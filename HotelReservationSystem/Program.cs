using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            Console.WriteLine("===================================");
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
            hotelDetailsTestObj.AddHotel("Bridgewood", 160, 60);
            hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
            HotelReservation hotelReservationTestOj = new HotelReservation();
            string result = hotelReservationTestOj.FindCheapestHotel(Convert.ToDateTime("12/09/2020"), Convert.ToDateTime("11/09/2020"));
            Console.WriteLine(result);
        }
    }
}
