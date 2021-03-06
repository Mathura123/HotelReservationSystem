﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservationException : Exception
    {
        public enum ExceptionType
        {
            INVALID_HOTEL_NAME,
            START_DATE_GREATER_THEN_END_DATE,
            NO_HOTEL_ADDED,
            INVALID_DATE,
            INVALID_CUSTOMER_TYPE
        }
        private ExceptionType type;
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
