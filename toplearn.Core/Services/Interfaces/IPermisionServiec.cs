using System;
using System.Collections.Generic;
using System.Text;
using toplearn.Datalayer.Entities.User;

namespace toplearn.Core.Services.Interfaces
{
  public  interface IPermisionServiec
    {
        #region Rols
        List<Role> GetRols();
        //void AddRolseToUser(List<int> rolIds, int userId);
        Role GetRoleByRoleId(int rolID);
        void EditRoles(Role role);
        void DeleteRole(Role role);
        void AddRolstoUser(List<int> rolIds, int userid);
        void EditRolsUser(int userid, List<int> RolesId);
        int AddRole(Role Role);
        
        #endregion


    }
}
