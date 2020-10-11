using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    using System.Linq;

    namespace OOD_RestaurantDesign
    {

        class Customer
        {
            public int Id { get; set; }
            public int Phone { get; set; }
            public string Name { get; set; }
        }

        class Table
        {
            public int Id { get; set; }
            public int Capacity { get; set; }
        }

        class Booking
        {
            public Booking(DateTime today)
            {
                EndTime = today.Date.AddDays(1).AddMinutes(-1);
            }
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Status { get; set; }
            public DateTime CreatedOn { get; set; }

        }

        class TableBooking
        {
            public int TableId { get; set; }
            public int BookingId { get; set; }
            public string Status { get; set; }
        }


        class ResTaurant
        {
            Dictionary<int, Booking> Bookings { get; set; }
            Dictionary<(int TableId, int BookingId), Booking> TableBookings { get; set; }

            public ResTaurant()
            {
                LoadBookings(DateTime.Today);
            }

            Dictionary<int, Booking> LoadBookings(DateTime date)
            {
                throw new NotImplementedException();
            }

            bool IsAvailable(int capacity, DateTime date)
            {
                throw new NotImplementedException();
            }
        }
    }
}
