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
            hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90,80,80);
            hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50,110,50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150,100,40);
            CallingMethodsClass.ChooseOption();
        }
    }
}
