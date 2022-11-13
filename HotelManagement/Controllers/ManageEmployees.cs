using AutoMapper;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Authorize]
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
            EmployeeDetailsModel user = new EmployeeDetailsModel();

            try
            {
                 user =  await employeeServices.GetUserDetailsModel(id);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

                return View(user);
            }

            

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
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

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
            IdentityResult result;
            try
            {
                result = await employeeServices.EditUserFromEditViewModel(employee);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(await employeeServices.GetUserEditViewModelByIdAsync(employee.Id.ToString()));
            }
            

            if (result.Succeeded)
            {
                return RedirectToAction("Details", "ManageEmployees", new { id = employee.Id.ToString() });

            }
            
            ModelState.AddModelError("", "Updating failed.");

            return View(await employeeServices.GetUserEditViewModelByIdAsync(employee.Id.ToString()));

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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Disable(string id)
        {
            var errorModel = new ErrorViewModel();

            var result = new IdentityResult();
            try
            {
                result = await employeeServices.DisableUser(id);
            }
            catch (Exception e)
            { 
                errorModel.RequestId = id;
                errorModel.ErrorMessage = e.Message;
                

                return View("Error", errorModel);

            }

          

            if (result.Succeeded)
            {
                return RedirectToAction("Details", "ManageEmployees", new {id = id});
                
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            errorModel.RequestId = id;
            errorModel.ErrorMessage = String.Join("\n", result.Errors.Select(e => e.Description));


            return View("Error", errorModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Enable(string id)
        {
            var errorModel = new ErrorViewModel();

            var result = new IdentityResult();
            try
            {
                result = await employeeServices.EnableUser(id);
            }
            catch (Exception e)
            {
                errorModel.RequestId = id;
                errorModel.ErrorMessage = e.Message;


                return View("Error", errorModel);

            }



            if (result.Succeeded)
            {
                return RedirectToAction("Details", "ManageEmployees", new { id = id });

            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            errorModel.RequestId = id;
            errorModel.ErrorMessage = String.Join("\n", result.Errors.Select(e => e.Description));


            return View("Error", errorModel);
        }
    }
}
