using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.RoomModels;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.ReservationsModels
{
    /// <summary>
    /// Reservation dto
    /// </summary>
    public class ReservationsViewModel
    {
        public string Id { get; set; }

        [Required]
        public string GuestFirstName { get; set; }

        [Required]
        public string GuestLastName { get; set; }

        public string? GuestPhoneNumber { get; set; }
        

        [EmailAddress]
        [Required]
        public string GuestEmail { get; set; }

        [Required]
        public int NumberOfAdultGuests { get; set; }

        [Required]
        public int NumberOfChildren { get; set; }
        
        public decimal Price { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public int RoomId { get; set; }
        public int RoomType { get; set; }

       
    }
}
