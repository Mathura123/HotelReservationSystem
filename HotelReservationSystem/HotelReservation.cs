using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    //Class for Hotel Reservation
    public class HotelReservation
    {
        public string FindCheapestHotel(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new HotelReservationException(HotelReservationException.ExceptionType.START_DATE_GREATER_THEN_END_DATE, "Start Date cannot be after end date");
            string cheapestWeekDayHotel = HotelDetails.hotelRatesDict.ElementAt(0).Key;
            string cheapestWeekEndHotel = HotelDetails.hotelRatesDict.ElementAt(0).Key;
            int cheapestWeekDayHotelRate = HotelDetails.hotelRatesDict[cheapestWeekDayHotel][0];
            int cheapestWeekEndHotelRate = HotelDetails.hotelRatesDict[cheapestWeekEndHotel][1];
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
