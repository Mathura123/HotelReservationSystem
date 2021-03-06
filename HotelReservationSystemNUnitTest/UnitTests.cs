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
            bool result = hotelDetailsTestObj.AddHotel("Lakewood",3, 110, 90, 80, 80);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void WhenGiven_WrongHotelName_To_HotelDetails_ShouldThrow_HotelReservationException()
        {
            try
            {
                HotelDetails hotelDetailsTestObj = new HotelDetails();
                bool result = hotelDetailsTestObj.AddHotel(null,3, 110, 90,80,80);
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
            hotelDetailsTestObj.AddHotel("Lakewood",3, 110, 90,80,80);
            hotelDetailsTestObj.AddHotel("Bridgewood",4, 150, 50,110,50);
            hotelDetailsTestObj.AddHotel("Ridgewood",5, 220, 150,100,40);
            HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REGULAR_CUST,Convert.ToDateTime("10/09/2020"), Convert.ToDateTime("11/09/2020"));
            List<string> result = hotelReservationTestOj.FindCheapestHotels();
            Assert.AreEqual(expected, result[0]);
        }
        [Test]
        public void WhenGiven_StartDateGreaterThenEndDate_To_FindCheapestHotel_ShouldThrow_HotelReservationException()
        {
            try
            {
                HotelDetails hotelDetailsTestObj = new HotelDetails();
                hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90, 80, 80);
                hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50, 110, 50);
                hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150, 100, 40);
                HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REGULAR_CUST,Convert.ToDateTime("16/09/2020"), Convert.ToDateTime("11/09/2020"));
                List<string> result = hotelReservationTestOj.FindCheapestHotels();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Start Date greater then End Date",e.Message);
            }
        }
        [Test]
        public void WhenGiven_StartDate_And_EndDate_To_FindCheapestTotalRate_ShouldReturn_CheapestTotalRate()
        {
            int expected = 200;
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90, 80, 80);
            hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50, 110, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150, 100, 40);
            HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REGULAR_CUST,Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020"));
            int result = hotelReservationTestOj.FindCheapestTotalRate();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void WhenGiven_StartDate_And_EndDate_To_FindBestHotel_ShouldReturn_BestHotel()
        {
            string expected = "Bridgewood";
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90, 80, 80);
            hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50, 110, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150, 100, 40);
            HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REGULAR_CUST,Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020"));
            string result = hotelReservationTestOj.FindBestHotel();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void WhenGiven_StartDate_And_EndDate_To_FindHighestRatedHotel_ShouldReturn_HighestRatedHotel()
        {
            string expected = "Ridgewood";
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90, 80, 80);
            hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50, 110, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150, 100, 40);
            HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REGULAR_CUST,Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020"));
            string result = hotelReservationTestOj.FindHighestRatedHotel();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void WhenGiven_StartDate_EndDate_And_Reward_CustType_To_FindBestHotel_ShouldReturn_BestHotel()
        {
            string expected = "Ridgewood";
            HotelDetails hotelDetailsTestObj = new HotelDetails();
            hotelDetailsTestObj.AddHotel("Lakewood", 3, 110, 90, 80, 80);
            hotelDetailsTestObj.AddHotel("Bridgewood", 4, 150, 50, 110, 50);
            hotelDetailsTestObj.AddHotel("Ridgewood", 5, 220, 150, 100, 40);
            HotelReservation hotelReservationTestOj = new HotelReservation(CustomerType.REWARD_CUST, Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020"));
            string result = hotelReservationTestOj.FindBestHotel();
            Assert.AreEqual(expected, result);
        }
    }
}