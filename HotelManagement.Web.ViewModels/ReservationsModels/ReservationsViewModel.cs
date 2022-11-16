using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Web.ViewModels.ReservationsModels
{
    internal class ReservationsViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string GuestFirstName { get; set; }

        [Required]
        public string GuestLastName { get; set; }

        [Required]
        public string GuestNationality { get; set; }

        public string? GuestPhoneNumber { get; set; }

        [EmailAddress]
        [Required]
        public string GuestEmail { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
