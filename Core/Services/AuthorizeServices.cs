using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Core
{
    public class AuthorizeServices : IAuthorize
    {
        private readonly Context _context;
        public AuthorizeServices(Context context)
        {
            _context = context;
        }

        public void CreateRole(Role role)
        {
            _context.roles.Add(role);
            _context.SaveChanges();
        }

        public void CreateRolePermission(RolePermission rolp)
        {
            _context.RolePermissions.Add(rolp);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            Role role = _context.roles.Find(id);
            _context.roles.Remove(role);
            _context.SaveChanges();
        }

        public void DeleteRolePermission(int id)
        {
            RolePermission rolp = _context.RolePermissions.Find(id);
            _context.RolePermissions.Remove(rolp);
            _context.SaveChanges();
        }

        public List<Permission> GetAllPermission()
        {
            return _context.Permissions.ToList();
        }

        public List<RolePermission> GetAllRolePermission()
        {
            return _context.RolePermissions.Include(r => r.Role).Include(t => t.Permission).ToList();
        }

        public List<Role> GetAllRoles()
        {
            return _context.roles.ToList();
        }

        public Role GetRole(int id)
        {
            return _context.roles.Find(id);
        }

        public List<Role> GetRolebyid(int id)
        {
            return _context.roles.Where(r => r.RoleId == id).ToList();
        }

        public RolePermission GetRolePermission(int id)
        {
            return _context.RolePermissions.Find(id);
        }

        public List<RolePermission> GetRolePermissionsByRoleID(int roleid)
        {
            return _context.RolePermissions.Include(r =>  r.Role).Include(p => p.Permission).Where(r => r.RoleId == roleid).ToList();
        }

        public void UpdateRole(int id, string roleName)
        {
            Role role = _context.roles.Find(id);
            role.RoleName = roleName;

            _context.SaveChanges();
        }

        public void UpdateRolePermission(int id, RolePermission rolp)
        {
            RolePermission myrolp = _context.RolePermissions.Find(id);
            myrolp.PermissionId = rolp.PermissionId;
            myrolp.RoleId = rolp.RoleId;
            _context.SaveChanges();
        }
    }
}
