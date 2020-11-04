using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ColouredPrint.PrintInRed("Welcome to Hotel Reservation System",false,false);
            Console.WriteLine("===================================");
            CallingMethodsClass.ChooseOption();
        }
    }
}
