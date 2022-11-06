using AutoMapper;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.UserServices.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ManageEmployees : Controller
    {
        public IAccountDataService dataService { get; set; }
        public ManageEmployees(
            IAccountDataService _dataService
            )
        {
           
            dataService = _dataService;

        }

        public IActionResult Index()
        {
            var model = dataService.GetUserViewModelsAsync();

            return View(model);

        }
    }
}
