using AutoMapper;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ManageEmployees : Controller
    {
        public IEmployeeServices employeeServices { get; set; }

        public IAccountServices accountServices { get; set; }
        public ManageEmployees(
            IEmployeeServices _employeeServices,
            IAccountServices _accountServices)
        {
            employeeServices = _employeeServices;
            accountServices = _accountServices;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All([FromQuery] AllEmployeesViewModel query) 
        {
            var queryResult = await this.employeeServices
                .All(query.EmployeeSorting,
                    query.DepartmentName,
                    query.Active,
                    query.SearchTerm,
                    query.CurrentPage,
                    AllEmployeesViewModel.EmployeesPerPage);

            query.TotalEmployeesCount = queryResult.TotalEmployeesCount;

            query.Employees = queryResult.Employees;

            var employeeDepartments = await this.employeeServices.AllDeparmentsNames();

            query.Departments = employeeDepartments;

            return View(query);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var user = await employeeServices.GetUserDetailsModel(id);

            return View(user);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            EmployeeEditViewModel user = new EmployeeEditViewModel();

            try
            {
                user = await employeeServices.GetUserEditViewModelByIdAsync(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", $"User id invalid.");

                return View(user);
            }

            

            if (String.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError("", $"User with id {id} doesnt exist.");
            }

            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EmployeeEditViewModel employee)
        {
            Console.WriteLine("OK");
            return View(employee);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RemoveDepartment(EmployeeEditViewModel model)
        {
            bool result;
            try
            {
                result = await employeeServices.RemoveDepartmentFromUser(model.DepartmentOfEmployeeId, model.Id.ToString());
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect($"Edit/{model.Id.ToString()}");
            }

            if (!result)
            {
                TempData["Error"] = "Department/User id invalid.";

                return Redirect($"Edit/{model.Id.ToString()}");
            }

            return Redirect($"Edit/{model.Id.ToString()}");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddDepartment(EmployeeEditViewModel model)
        {
            bool result;

            try
            {
                result = await employeeServices.AddDepartmentToUser(model.DepartmentEmployeeDoesntHaveId, model.Id.ToString());
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;

                return Redirect($"Edit/{model.Id.ToString()}");
            }
            

            if (!result)
            {
                TempData["Error"] = "Department/User id invalid.";

                return Redirect($"Edit/{model.Id.ToString()}");
            }

            return Redirect($"Edit/{model.Id.ToString()}");
        }
    }
}
