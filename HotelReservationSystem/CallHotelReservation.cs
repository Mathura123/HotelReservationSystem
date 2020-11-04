using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class CallHotelReservation
    {
        private static DateTime startDate;
        private static DateTime endDate;
        public static void CallingHotelReservation()
        {
            Console.Write("Enter the Start Date in DD/MM/YYYY format : ");
            try
            {
                startDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Start Date is Invalid");
            }
            Console.Write("Enter the End Date in DD/MM/YYYY format : ");
            try
            {
                endDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "End Date is Invalid");
            }
            HotelReservation hotelReservationTestOj = new HotelReservation();
            string cheapestHotel = hotelReservationTestOj.FindCheapestHotel(startDate, endDate);
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Cheapest Hotel is {cheapestHotel}");
        }
    }
}
