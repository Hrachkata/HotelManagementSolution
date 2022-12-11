using HotelManagement.Data.Services.AccountServices.Contracts;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageEmployeesController : Controller
    {
        public IEmployeeServices employeeServices { get; set; }
        public IAccountServices accountServices { get; set; }
        public ManageEmployeesController(
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
            catch (ArgumentNullException ex)
            {
                TempData["status"] = 404;

                throw;
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
            catch (ArgumentNullException ex)
            {
                TempData["status"] = 404;

                throw;
            }
            catch (ArgumentException ex)
            {
                TempData["status"] = 404;

                throw;
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

                if (result.Errors.Count() > 0)
                {
                    throw new DbUpdateException();
                }
            }
            catch (ArgumentNullException e)
            {
                TempData["status"] = 404;

                throw;
            }
            catch (InvalidOperationException e)
            {
                TempData["status"] = 400;

                throw;
            }
            catch (DbUpdateException e)
            {
                TempData["status"] = 400;

                throw;
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

                if (!result)
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentException ex)
            {
                TempData["status"] = 404;

                throw;
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
                if (!result)
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentException ex)
            {
                TempData["status"] = 404;

                throw;
            }

            return Redirect($"Edit/{model.Id.ToString()}");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Disable(string id)
        {

            var result = new IdentityResult();
            try
            {
                result = await employeeServices.DisableUser(id);
                if (result.Errors.Count() > 0)
                {
                    throw new DbUpdateException();
                }
            }
            catch (DbUpdateException e)
            {
                TempData["status"] = 400;

                throw;
            }
            
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "ManageEmployees", new {id = id});
                
            }
            
            return RedirectToAction("Edit", new {id = id});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Enable(string id)
        {

            var result = new IdentityResult();
            try
            {
                result = await employeeServices.EnableUser(id);
                if (result.Errors.Count() > 0)
                {
                    throw new DbUpdateException();
                }
            }
            catch (DbUpdateException e)
            {
                TempData["status"] = 400;

                throw;
            }

            if (result.Succeeded)
            {
                return RedirectToAction("Details", "ManageEmployees", new { id = id });

            }

            return RedirectToAction("Edit", new { id = id });
        }
    }
}
