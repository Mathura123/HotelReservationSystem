using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ColouredPrint.PrintInRed("Welcome to Hotel Reservation System",false,false);
            Console.WriteLine("===================================");
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
            hotelDetailsTestObj.AddHotel("Bridgewood", 150, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
            CallingMethodsClass.ChooseOption();
        }
    }
}
