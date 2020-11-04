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
        label1:
            try
            {
                CallHotelReservation.CallingHotelReservation();
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try Again");
                Console.WriteLine("------------------------------------");
                goto label1;
            }
        }
    }
}
