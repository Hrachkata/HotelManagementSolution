﻿using HotelManagement.Data.Models.Models;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;

public class ReservationQueryServiceModel
{
    public int TotalReservationsCount { get; set; }

    public IEnumerable<SingleReservationViewModel> Reservations { get; set; } = new HashSet<SingleReservationViewModel>();
}