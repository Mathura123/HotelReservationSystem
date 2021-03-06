﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    //Class for Hotel Reservation
    public class HotelReservation
    {
        private DateTime startDate;
        private DateTime endDate;
        private CustomerType custType;
        private int bestHotelRating;
        private string bestHotel;
        public HotelReservation(CustomerType custType, DateTime startDate, DateTime endDate)
        {
            this.custType = custType;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        //Method to find cheapest hotel
        public List<string> FindCheapestHotels()
        {
            ValidateStartAndEndDate();
            List<string> cheapest = GetCheapestRateAndHotel();
            List<string> cheapestHotels = new List<string>();
            for (int i = 1; i < cheapest.Count; i++)
            {
                cheapestHotels.Add(cheapest[i]);
            }
            return cheapestHotels;
        }
        public int FindCheapestTotalRate()
        {
            ValidateStartAndEndDate();
            return Convert.ToInt32(GetCheapestRateAndHotel()[0]);
        }
        public string FindBestHotel()
        {
            List<string> cheapestHotels = FindCheapestHotels();
            bestHotel = cheapestHotels[0];
            bestHotelRating = HotelDetails.hotelRatings[cheapestHotels[0]];
            if (cheapestHotels.Count > 1)
            {
                foreach (string hotelName in cheapestHotels)
                {
                    if (HotelDetails.hotelRatings[hotelName] > bestHotelRating)
                    {
                        bestHotelRating = HotelDetails.hotelRatings[hotelName];
                        bestHotel = hotelName;
                    }
                }
            }
            return bestHotel;
        }
        public int FindBestHotelRating()
        {
            FindBestHotel();
            return bestHotelRating;
        }
        public string FindHighestRatedHotel()
        {
            var hotelRatingsSorted = SortByValues(HotelDetails.hotelRatings);
            return hotelRatingsSorted[hotelRatingsSorted.Count - 1].Key;
        }
        public int FindHigestRatedHotelTotalRate()
        {
            int highestRatedHotelTotalRate = 0;
            foreach (string hotelName in HotelDetails.hotelRatesDict.Keys.Where(x => x == FindHighestRatedHotel()))
            {
                DateTime iterartionDate = startDate;
                while (iterartionDate != endDate.AddDays(1))
                {
                    int custumerInt = 0;
                    if (custType == CustomerType.REWARD_CUST)
                        custumerInt = 2;
                    int dayInt = 0;
                    if ((iterartionDate.DayOfWeek == DayOfWeek.Saturday) || (iterartionDate.DayOfWeek == DayOfWeek.Sunday))
                        dayInt= 1;
                    highestRatedHotelTotalRate += HotelDetails.hotelRatesDict[hotelName][dayInt + custumerInt];
                    iterartionDate = iterartionDate.AddDays(1);
                }
            }
            return highestRatedHotelTotalRate;
        }
        public int FindHighestRatedHotelRating()
        {
            return HotelDetails.hotelRatings[FindHighestRatedHotel()];
        }
        private List<string> GetCheapestRateAndHotel()
        {
            Dictionary<string, int> hotelTotalRates = new Dictionary<string, int>();
            List<string> cheapest = new List<string>();
            foreach (string hotelName in HotelDetails.hotelRatesDict.Keys)
            {
                hotelTotalRates[hotelName] = 0;
                DateTime iterartionDate = startDate;
                while (iterartionDate != endDate.AddDays(1))
                {
                    int custumerInt = 0;
                    if (custType == CustomerType.REWARD_CUST)
                        custumerInt = 2;
                    int dayInt = 0;
                    if ((iterartionDate.DayOfWeek == DayOfWeek.Saturday) || (iterartionDate.DayOfWeek == DayOfWeek.Sunday))
                        dayInt = 1;
                    hotelTotalRates[hotelName] += HotelDetails.hotelRatesDict[hotelName][dayInt + custumerInt];
                    iterartionDate = iterartionDate.AddDays(1);
                }
            }
            var hotelTotalRatesList = SortByValues(hotelTotalRates);
            int cheapestRate = hotelTotalRatesList[0].Value;
            cheapest.Add(cheapestRate.ToString());
            for (int hotelIndex = 0; hotelTotalRatesList[hotelIndex].Value == cheapestRate; hotelIndex++)
            {
                cheapest.Add(hotelTotalRatesList[hotelIndex].Key);
            }
            return cheapest;
        }
        private List<KeyValuePair<string, int>> SortByValues(Dictionary<string, int> dict)
        {
            var dictToList = dict.ToList();
            dictToList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return dictToList;
        }
        private void ValidateStartAndEndDate()
        {
            if (startDate > endDate)
                throw new HotelReservationException(HotelReservationException.ExceptionType.START_DATE_GREATER_THEN_END_DATE, "Start Date greater then End Date");
            if (HotelDetails.hotelRatesDict.Count == 0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NO_HOTEL_ADDED, "No Hotel has been added yet");
        }
    }
}
