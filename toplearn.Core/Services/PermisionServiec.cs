using System;
using System.Collections.Generic;
using System.Text;
using toplearn.Core.Services.Interfaces;
using toplearn.Datalayer.Entities.User;
using toplearn.Datalayer.Context;
using System.Linq;

namespace toplearn.Core.Services
{
    public class PermisionServiec : IPermisionServiec
    {
        private ToplearnContext _Context;
        public PermisionServiec (ToplearnContext Context)
        {
            _Context = Context;
        }

        public int AddRole(Role Role)
        {
            _Context.Roles.Add(Role);
            _Context.SaveChanges();
            return Role.RolID;
        }

        public void AddRolstoUser(List<int> rolIds, int userid)
        {

            foreach (var rolid in rolIds)
            {

                _Context.userRoles.Add(new UserRole()
                {
                    RolID = rolid,
                    UserID = userid
                      
                });

            _Context.SaveChanges();
            }
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            EditRoles(role);
           
        }

        public void EditRoles(Role role)
        {
            _Context.Roles.Update(role);
            _Context.SaveChanges();
        }

        public void EditRolsUser(int userid, List<int> RolesId)
        {
            //remove roles
            _Context.userRoles.Where(r => r.UserID == userid).ToList().ForEach(r => _Context.userRoles.Remove(r));
            AddRolstoUser(RolesId,userid);
        }

      

        public Role GetRoleByRoleId(int rolID)
        {
            return _Context.Roles.Find(rolID);
        }

        public List<Role> GetRols()
        {
            return _Context.Roles.ToList();
        }
    }
}
