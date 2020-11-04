using NUnit.Framework;
using HotelReservationSystem;
using System;
using System.Collections.Generic;

namespace HotelReservationSystemNUnitTest
{
    public class Tests
    {
        [Test]
        public void WhenGiven_HotelName_To_HotelDetails_Should_AddHotel()
        {
            bool expected = true;
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            bool result = hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void WhenGiven_WrongHotelName_To_HotelDetails_ShouldThrow_HotelReservationException()
        {
            try
            {
                HotelDetails hotelDetailsTestObj = new HotelDetails();
                bool result = hotelDetailsTestObj.AddHotel(null, 110, 90);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Hotel Name");
            }
        }
        [Test]
        public void WhenGiven_StartDate_And_EndDAte_To_FindCheapestHotel_ShouldReturn_CheapestHotelName()
        {
            string expected = "Lakewood";
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
            hotelDetailsTestObj.AddHotel("Bridgewood", 150, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
            HotelReservation hotelReservationTestOj = new HotelReservation();
            List<string> result = hotelReservationTestOj.FindCheapestHotels(Convert.ToDateTime("10/09/2020"), Convert.ToDateTime("11/09/2020"));
            Assert.AreEqual(expected, result[0]);
        }
        [Test]
        public void WhenGiven_StartDateGreaterThenEndDate_To_FindCheapestHotel_ShouldThrow_HotelReservationException()
        {
            try
            {
                HotelDetails hotelDetailsTestObj = new HotelDetails();
                hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
                hotelDetailsTestObj.AddHotel("Bridgewood", 150, 50);
                hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
                HotelReservation hotelReservationTestOj = new HotelReservation();
                List<string> result = hotelReservationTestOj.FindCheapestHotels(Convert.ToDateTime("16/09/2020"), Convert.ToDateTime("11/09/2020"));
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Start Date greater then End Date");
            }
        }
        [Test]
        public void WhenGiven_StartDate_And_EndDate_To_FindCheapestTotalRate_ShouldReturn_CheapestTotalRate()
        {
            int expected = 200;
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 110, 90);
            hotelDetailsTestObj.AddHotel("Bridgewood", 150, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
            HotelReservation hotelReservationTestOj = new HotelReservation();
            int result = hotelReservationTestOj.FindCheapestTotalRate(Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020"));
            Assert.AreEqual(expected, result);
        }
    }
}