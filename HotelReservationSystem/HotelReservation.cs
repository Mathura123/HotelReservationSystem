using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    //Class for Hotel Reservation
    public class HotelReservation
    {
        //Method to find cheapest hotel
        public string FindCheapestHotel(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new HotelReservationException(HotelReservationException.ExceptionType.START_DATE_GREATER_THEN_END_DATE, "Start Date greater then End Date");
            if(HotelDetails.hotelRatesDict.Count == 0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NO_HOTEL_ADDED, "No Hotel has been added yet");
            //Variables for saving cheapest hotelName and rate for weekend and weekday
            string cheapestWeekDayHotel = HotelDetails.hotelRatesDict.ElementAt(0).Key;
            string cheapestWeekEndHotel = HotelDetails.hotelRatesDict.ElementAt(0).Key;
            int cheapestWeekDayHotelRate = HotelDetails.hotelRatesDict[cheapestWeekDayHotel][0];
            int cheapestWeekEndHotelRate = HotelDetails.hotelRatesDict[cheapestWeekEndHotel][1];
            //Iterates over every hotel name
            foreach (string hotelName in HotelDetails.hotelRatesDict.Keys)
            {
                int weekDayhotelRate = HotelDetails.hotelRatesDict[hotelName][0];
                int weekEndhotelRate = HotelDetails.hotelRatesDict[hotelName][1];
                if (weekDayhotelRate < cheapestWeekDayHotelRate)
                {
                    cheapestWeekDayHotel = hotelName;
                    cheapestWeekDayHotelRate = weekDayhotelRate;
                }
                if (weekEndhotelRate < cheapestWeekEndHotelRate)
                {
                    cheapestWeekEndHotel = hotelName;
                    cheapestWeekEndHotelRate = weekEndhotelRate;
                }
            }
            DateTime iterartionDate = startDate;
            bool weekEndFalls = false;
            //Iterates over each date
            while (iterartionDate != endDate.AddDays(1))
            {
                if ((iterartionDate.DayOfWeek == DayOfWeek.Saturday) || (iterartionDate.DayOfWeek == DayOfWeek.Sunday))
                {
                    weekEndFalls = true;
                    break;
                }
                iterartionDate = iterartionDate.AddDays(1);
            }
            if ((weekEndFalls == true) && (cheapestWeekEndHotelRate < cheapestWeekDayHotelRate))
            {
                return cheapestWeekEndHotel;
            }
            return cheapestWeekDayHotel;
        }
    }
}
