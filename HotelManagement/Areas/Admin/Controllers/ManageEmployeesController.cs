using System.Data;
using HotelManagement.Data.Services.AccountServices.Contracts;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HotelManagement.Areas.Admin.Controllers
{

    /// <summary>
    /// Manage employees controller, admin controller for managing all the employees.
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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

        /// <summary>
        /// Query that returns all users that correspond to the query params.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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

        /// <summary>
        /// Details method (Get) about user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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

        /// <summary>
        /// Get Edit View method by UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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

        /// <summary>
        /// Save edit fields about user.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>

        [HttpPost]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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
                Log.Logger.Information("User {0} edited user {1}", this.User?.Identity?.Name ?? "NAME MISSING", employee.UserName);

                return RedirectToAction("Details", "ManageEmployees", new { id = employee.Id.ToString() });

            }
            
            ModelState.AddModelError("", "Updating failed.");

            return View(await employeeServices.GetUserEditViewModelByIdAsync(employee.Id.ToString()));

        }

        /// <summary>
        /// Removes a
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        [HttpPost]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
        public async Task<ActionResult> RemoveDepartment(EmployeeEditViewModel model)
        {
            bool result;
            try
            {
                result = await employeeServices.RemoveDepartmentFromUser(model.DepartmentOfEmployeeId,
                    model.Id.ToString());

                if (!result)
                {
                    throw new DBConcurrencyException("No rows changed");
                }
            }
            catch (ArgumentNullException)
            {
                TempData["status"] = 400;

                throw;
            }
            catch (ArgumentException)
            {
                TempData["status"] = 404;

                throw;
            }
            catch (DBConcurrencyException)
            {
                TempData["status"] = 400;

                throw;
            }
            
            Log.Logger.Information("User {0} removed department with id: {1} from user {2}", this.User?.Identity?.Name ?? "NAME MISSING", model.DepartmentOfEmployeeId, model.UserName);


            return Redirect($"Edit/{model.Id.ToString()}");
        }


        /// <summary>
        /// Adds department to user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
        public async Task<ActionResult> AddDepartment(EmployeeEditViewModel model)
        {
            bool result;

            try
            {
                result = await employeeServices.AddDepartmentToUser(model.DepartmentEmployeeDoesntHaveId, model.Id.ToString());
                if (!result)
                {
                    throw new DBConcurrencyException("No rows changed");
                }
            }
            catch (ArgumentNullException)
            {
                TempData["status"] = 400;

                throw;
            }
            catch (ArgumentException)
            {
                TempData["status"] = 404;

                throw;
            }
            catch (DBConcurrencyException)
            {
                TempData["status"] = 400;

                throw;
            }

            Log.Logger.Information("User {0} added department with id: {1} to user {2}", this.User?.Identity?.Name ?? "NAME MISSING", model.DepartmentEmployeeDoesntHaveId, model.UserName);


            return Redirect($"Edit/{model.Id.ToString()}");
        }


        /// <summary>
        /// Disables employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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
                Log.Logger.Information("User {0} disabled user with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

                return RedirectToAction("Details", "ManageEmployees", new {id = id});
                
            }
            
            return RedirectToAction("Edit", new {id = id});
        }

        /// <summary>
        /// Enables employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
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
                Log.Logger.Information("User {0} enabled user with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

                return RedirectToAction("Details", "ManageEmployees", new { id = id });

            }

            return RedirectToAction("Edit", new { id = id });
        }
    }
}
