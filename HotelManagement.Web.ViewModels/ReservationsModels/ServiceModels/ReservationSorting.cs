﻿namespace HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;

public class ReservationSortingClass
{
    public enum ReservationSorting
    {
        Newest = 0,
        Oldest = 1,
        ByArrivalDate = 2,
        ByArrivalDateDescending = 3,
        ByDepartureDate = 4,
        ByDepartureDateDescending = 5,
    }
}