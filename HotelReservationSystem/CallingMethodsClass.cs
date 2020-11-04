using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace HotelReservationSystem
{
    public class CallingMethodsClass
    {
        private static DateTime startDate;
        private static DateTime endDate;

        //Asks user for entry
        public static void ChooseOption()
        {
            Console.WriteLine("Enter 1 : Add Hotel\nEnter 2 : Show Cheapest Hotels\nEnter 3 : Book Best Hotel\nEnter 4 : Book Highest Rating Hotel\nEnter 5 : Exit");
            Console.Write("Your Entry : ");
            int enteredKey = default(int);
            try
            {
                try
                {
                    enteredKey = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    ColouredPrint.PrintInMagenta("Wrong key entered\nTry Again");
                    ChooseOption();
                }
                switch (enteredKey)
                {
                    case 1:
                        CallingMethodsClass.CallAddHotel();
                        ChooseOption();
                        break;
                    case 2:
                        CallingMethodsClass.GetCheapestHotels();
                        ChooseOption();
                        break;
                    case 3:
                        CallingMethodsClass.GetBestHotel();
                        ChooseOption();
                        break;
                    case 4:
                        CallingMethodsClass.GetHighestRatedHotel();
                        break;
                    case 5:
                        break;
                    default:
                        ColouredPrint.PrintInMagenta("Wrong key entered\nTry Again");
                        ChooseOption();
                        break;
                }
            }
            //Catches exception if hotelName is Invalid
            catch (HotelReservationException e)
            {
                ColouredPrint.PrintInMagenta($"{e.Message}\nTry Again");
                ChooseOption();
            }
        }
        //Private method to call FindCheapestHotels method
        private static void GetCheapestHotels()
        {
            DateTime[] dates = AskStartAndEndDate();
            HotelReservation hotelReservationTestOj = new HotelReservation(dates[0], dates[1]);
            List<string> cheapestHotels = hotelReservationTestOj.FindCheapestHotels();
            int cheapestRate = hotelReservationTestOj.FindCheapestTotalRate();
            ColouredPrint.PrintInRed("Cheapest hotels is/are : ", false, false);
            foreach (string hotel in cheapestHotels)
            {
                ColouredPrint.PrintInRed($"{hotel}");
            }
            ColouredPrint.PrintInRed($"Cheapest Rate is {cheapestRate}");
        }
        private static void GetHighestRatedHotel()
        {
            DateTime[] dates = AskStartAndEndDate();
            HotelReservation hotelReservationObj = new HotelReservation(dates[0], dates[1]);
            string highestRatedHotel = hotelReservationObj.FindHighestRatedHotel();
            int highestRatedHotelTotalRate = hotelReservationObj.FindHigestRatedHotelTotalRate();
            int highestRatedHotelRating = hotelReservationObj.FindHighestRatedHotelRating();
            ColouredPrint.PrintInRed($"Highest Rated hotel is {highestRatedHotel} with Total Fare {highestRatedHotelTotalRate} and Rating {highestRatedHotelRating}");
        }
        //private method to call FindBestHotel Method
        private static void GetBestHotel()
        {
            DateTime[] dates = AskStartAndEndDate();
            HotelReservation hotelReservationObj = new HotelReservation(dates[0], dates[1]);
            string bestHotel = hotelReservationObj.FindBestHotel();
            int cheapestRate = hotelReservationObj.FindCheapestTotalRate();
            ColouredPrint.PrintInRed($"Best Hotel is {bestHotel} with  Total rate {cheapestRate} and Rating {hotelReservationObj.FindBestHotelRating()}");
        }
        //Private method or calling AddHotel Method
        private static void CallAddHotel()
        {
            Console.Write("Enter the Hotel Name : ");
            string hotelName = Console.ReadLine();
        label2:
            Console.Write("Enter the Hotel Rating : ");
            int hotelRating;
            try
            {
                hotelRating = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ColouredPrint.PrintInMagenta("Wrong value");
                goto label2;
            }
        label3:
            Console.Write("Enter the Weekday Rate For Regular Customer : ");
            int weekdayRateForRegularCust;
            int weekendRateForRegularCust;
            int weekdayRateForRewardCust;
            int weekendRateForRewardCust;
            try
            {
                weekdayRateForRegularCust = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ColouredPrint.PrintInMagenta("Wrong value");
                goto label3;
            }
        label4:
            Console.Write("Enter the Weekend Rate For Regular Customer : ");
            try
            {
                weekendRateForRegularCust = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ColouredPrint.PrintInMagenta("Wrong value");
                goto label4;
            }
        label5:
            Console.Write("Enter the Weekday Rate For Reward Customer : ");
            try
            {
                weekdayRateForRewardCust = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ColouredPrint.PrintInMagenta("Wrong value");
                goto label5;
            }
        label6:
            Console.Write("Enter the Weekend Rate For Reward Customer : ");
            try
            {
                weekendRateForRewardCust = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ColouredPrint.PrintInMagenta("Wrong value");
                goto label6;
            }
            HotelDetails hotelDetailsObj = new HotelDetails();
            hotelDetailsObj.AddHotel(hotelName, hotelRating, weekdayRateForRegularCust, weekendRateForRegularCust,weekdayRateForRewardCust,weekendRateForRewardCust);
        }
        private static DateTime[] AskStartAndEndDate()
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
            DateTime[] dates = new DateTime[] { startDate, endDate };
            return dates;
        }
    }
    //Class for printing lines in colour
    public class ColouredPrint
    {
        //For Printing Results and Headings in Red
        public static void PrintInRed(string s, bool header = false, bool footer = true)
        {
            if (header)
                Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("------------------------------------");
        }
        //For printing Errors in Magenta
        public static void PrintInMagenta(string s, bool header = false, bool footer = true)
        {
            if (header)
                Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("------------------------------------");
        }
    }
}
