using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CtrlZ.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly IAuthorize _authorize;
        public AuthorizeController(IAuthorize authorize)
        {
            _authorize = authorize;
        }
        public IActionResult ShowRoles()
        {
            List<Role> roles = _authorize.GetAllRoles();
            return View(roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }  
        [HttpPost]
        public IActionResult CreateRole(RoleViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role()
                {
                    RoleName = viewmodel.RoleName
                };
                _authorize.CreateRole(role);
                return RedirectToAction("ShowRoles");
            }
            return View(viewmodel);
        }
        public IActionResult DeleteRole(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Role role = _authorize.GetRole(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return PartialView(role);
        }
        public IActionResult ConfirmDeleteRole(int? id)
        {
            try
            {
                _authorize.DeleteRole(id.Value);
                return RedirectToAction("ShowRoles");
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult UpdateRole(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Role role = _authorize.GetRole(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            RoleViewModel newrole = new RoleViewModel()
            {
                RoleName = role.RoleName
            };

            return View(newrole);
        }
        [HttpPost]
        public IActionResult UpdateRole(int id, RoleViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                _authorize.UpdateRole(id , viewmodel.RoleName);
                return RedirectToAction("ShowRoles");
            }
            return View(viewmodel);
        }
        public IActionResult ShowRolePermission(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            List<RolePermission> RolePermissions = _authorize.GetRolePermissionsByRoleID(id.Value);
            ViewBag.roleid = id;
            if (RolePermissions == null)
            {
                return NotFound();
            }
            return  View(RolePermissions);
        }
        public IActionResult DeleteRolePermission(int? id)
        {         

            if (id == null)
            {
                return BadRequest();
            }
            RolePermission rolp = _authorize.GetRolePermission(id.Value);
            if (rolp == null )
            {
                return NotFound();
            }
            return PartialView(rolp);
  
        }
        [HttpPost]
        public IActionResult DeleteRolePermission(RolePermission rp)
        {         
            try
            {
                _authorize.DeleteRolePermission(rp.RolePermissionId);
                return Redirect("/authorize/ShowRolePermission/"+rp.RoleId);
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult CreateRolePermission(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ViewBag.roleid = _authorize.GetRolebyid(id.Value);
            ViewBag.PermissionsId = _authorize.GetAllPermission();
            return View();
        }
        [HttpPost]
        public IActionResult CreateRolePermission(RolePermissionViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                RolePermission rolep = new RolePermission()
                {
                    RoleId = viewmodel.RoleId,
                    PermissionId = viewmodel.PermissionId
                };
                _authorize.CreateRolePermission(rolep);
                return Redirect("/Authorize/ShowRolePermission/" + viewmodel.RoleId);
            }
            ViewBag.roleid = _authorize.GetAllRoles();
            ViewBag.PermissionsId = _authorize.GetAllPermission();
            return View(viewmodel);
        }
    }
}