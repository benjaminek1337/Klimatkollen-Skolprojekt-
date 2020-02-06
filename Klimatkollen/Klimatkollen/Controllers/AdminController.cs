using Klimatkollen.Data;
using Klimatkollen.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Controllers
{
    //[Authorize (Roles = "Admin,Superadmin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository db;
        IRepository repo;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IUserRepository db, IRepository repo)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
            this.repo = repo;
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Rolename
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("listroles", "admin");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return View("ListRoles");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
                
            };

            foreach(var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {model.Id} kan inte hittas.";
                return View("ListRoles");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return View("ListRoles");
            }
            else
            {
                await roleManager.DeleteAsync(role);
                var result = await roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");

                }
            }

            return RedirectToAction("ListRoles");
        }

        [HttpGet]
        public async Task<IActionResult> EditUserRole(string id)
        {
            ViewBag.roleId = id;
            var role = await roleManager.FindByIdAsync(id);
            ViewBag.roleName = role.Name;

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return RedirectToAction("EditRole", id);
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                var userRole = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }
                model.Add(userRole);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRole(List<UserRoleViewModel> model, string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return RedirectToAction("EditRole", id);
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if (model[i].IsSelected &! await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if(result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = id });
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = id });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            ViewBag.People = db.GetPeople();
            var model = userManager.Users;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var person = db.GetPerson(id);
            var observations = repo.GetObservations(person.Id);
            ViewBag.Observations = observations;
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return RedirectToAction("ListUsers", id);
            }
            var roles = await userManager.GetRolesAsync(user);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Roles = roles,
                FirstName = person.FirstName,
                Lastname = person.Lastname
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            var person = db.GetPerson(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {model.Id} kan inte hittas.";
                return RedirectToAction("ListUsers", model.Id);
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                person.FirstName = model.FirstName;
                person.Lastname = model.Lastname;
                person.Email = model.Email;
                person.UserName = model.Email;

                var result = await userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            
        }

        public async Task<IActionResult> DeleteUser (string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var person = db.GetPerson(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Systemroll ID: {id} kan inte hittas.";
                return View("ListRoles");
            }
            else
            {
                db.DeletePerson(person);
                await userManager.DeleteAsync(user);
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");

                }
            }

            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public async Task<IActionResult> EditRolesForUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            ViewBag.userName = user.UserName;
            ViewBag.userId = user.Id;

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Användare ID: {id} kan inte hittas.";
                return RedirectToAction("EditUser", id);
            }
            var model = new List<UserRoleViewModel>();
            foreach (var role in roleManager.Roles)
            {
                var roleUser = new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    roleUser.IsSelected = true;
                }
                else
                {
                    roleUser.IsSelected = false;
                }
                model.Add(roleUser);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRolesForUser(List<UserRoleViewModel> model, string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Användare ID: {id} kan inte hittas.";
                return RedirectToAction("EditUser", id);
            }

            for (int i = 0; i < model.Count; i++)
            {
                var role = await roleManager.FindByIdAsync(model[i].RoleId);
                IdentityResult result = null;
                if (model[i].IsSelected & !await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditUser", new { Id = id });
                    }
                }
            }
            return RedirectToAction("EditUser", new { Id = id });
        }

    }
}
