﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Web.ViewModels.RoomModels.ServiceModels
{
    public class RoomTypeDto
    {
        /// <summary>
        /// Room type dto
        /// </summary>
        public int Id{ get; set; }

        public string Type { get; set; }
        public decimal PricePerPerson { get; set; }

    }
}
