using ERP.Core.Models.Admin;
using ERP.Infrastructure.Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace VIGOR
{
    public class SecurityUser
    {
        public int User_Id { get; set; }
        public bool IsSysAdmin { get; set; }
        public string Username { get; set; }
        public List<UserModuleDetails> _userModuleDetailList { set; get; }
        private readonly UserModuleDetailsRepository _userModuleDetailsRepository;
        private readonly UserRepository _userRepository;

        public SecurityUser(string _username)
        {
            _userRepository = new UserRepository();
            _userModuleDetailsRepository = new UserModuleDetailsRepository();
            this.Username = _username;
            this.IsSysAdmin = false;
            this._userModuleDetailList = new List<UserModuleDetails>();
            GetDatabaseUserModuleDetail();
        }

        private void GetDatabaseUserModuleDetail()
        {
            User _user = _userRepository.GetAllUsers().Where(u => u.UserName == this.Username).FirstOrDefault();
            if (_user != null)
            {
                this.User_Id = _user.Id;
                foreach (UserModuleDetails userModuleDetails in _user.UserModuleDetails)
                {
                    _userModuleDetailList.Add(new UserModuleDetails { Id = userModuleDetails.Id, UserId = userModuleDetails.UserId, ModuleDtlId = userModuleDetails.ModuleDtlId, CreatedBy = 0, CreatedOn = DateTime.Now, ModifiedBy = 0, ModifiedOn = DateTime.Now, AdminModuleDetails = userModuleDetails.AdminModuleDetails });
                }
                //this.Roles.Add(_userRole);

                //if (!this.IsSysAdmin)
                //    this.IsSysAdmin = _role.IsSysAdmin;
            }
        }
        public bool HasPermission(string requiredPermission, List<UserModuleDetails> userModuleDetails, int UserId)
        {
            bool bFound = false;
            if (userModuleDetails != null)
            {
                bFound = userModuleDetails.Any(x => x.UserId == UserId && x.AdminModuleDetails.Url.ToLower() == requiredPermission.ToLower());
            }
            return bFound;
        }
    }
    

    //public bool HasRole(string role)
    //{
    //    return (Roles.Where(p => p.RoleName == role).ToList().Count > 0);
    //}

    //public bool HasRoles(string roles)
    //{
    //    bool bFound = false;
    //    string[] _roles = roles.ToLower().Split(';');
    //    foreach (UserRole role in this.Roles)
    //    {
    //        try
    //        {
    //            bFound = _roles.Contains(role.RoleName.ToLower());
    //            if (bFound)
    //                return bFound;
    //        }
    //        catch (Exception)
    //        {
    //        }
    //    }
    //    return bFound;
    //}
    //}

    //public class UserRole
    //{
    //    public int Role_Id { get; set; }
    //    public string RoleName { get; set; }
    //    public List<RolePermission> Permissions = new List<RolePermission>();
    //}


}
