using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAuthorize
    {
        public void CreateRole(Role role);
        public void UpdateRole(int id,string roleName);
        public void DeleteRole(int id);
        public List<Role> GetAllRoles();
        public Role GetRole(int id);

        #region RolePermission
        public void CreateRolePermission(RolePermission rolp);
        public void DeleteRolePermission(int id);
        public void UpdateRolePermission(int id, RolePermission rolp);
        public RolePermission GetRolePermission(int id);
        public List<RolePermission> GetAllRolePermission();
        public List<RolePermission> GetRolePermissionsByRoleID(int roleid);
        #endregion

        public List<Permission> GetAllPermission();
        public List<Role> GetRolebyid(int id);
    }
}
