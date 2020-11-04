using NUnit.Framework;
using HotelReservationSystem;
using System;

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
            hotelDetailsTestObj.AddHotel("Bridgewood", 160, 60);
            hotelDetailsTestObj.AddHotel("Ridgewood", 220, 150);
            HotelReservation hotelReservationTestOj = new HotelReservation();
            string result = hotelReservationTestOj.FindCheapestHotel(Convert.ToDateTime("10/09/2020"), Convert.ToDateTime("11/09/2020"));
            Assert.AreEqual(expected, result);
        }
    }
}