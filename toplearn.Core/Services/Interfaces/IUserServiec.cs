using System;
using System.Collections.Generic;
using System.Text;
using toplearn.Core.DTOs;
using toplearn.Datalayer.Entities.User;
using toplearn.Datalayer.Entities.Wallet;

namespace toplearn.Core.Services.Interfaces
{
   public interface IUserServiec
    {
        bool IsExistUserName(string username);
        bool IsExistEmail(string Email);

        int AddUser(User user);
        User GetuserByActiveCode(string activecode);
        void UpdateUser(User user);
        User GetuserByUsername(string username);
        User GetUserByID(int Userid);
        int GetUserIDByUsername(string username);
        User GetByEmail(string Email);

       User loginuser(LoginViewModel login);

        bool ActiveAccount(string ActiveCode);

        #region Userpanel

        InformatinUserViewModel GetUserInformation(String username);
        InformatinUserViewModel GetUserInformation(int id);

        SidBarUserPanelViewModwl GetsideBarUserpanelData(string username);
        EditProfilUserPanelViewModel GEtEditUserPanelDate(string username);
        // void EditProfile(EditProfilUserPanelViewModel profile);

        bool CompareOldpassword(string username, string OldPassword);

        void ChangePassword(string username, string NewPassword);

        #endregion
        #region Wallet

        int BalnceWalletUser(string usernme);
      
        List<WalletViewModel> GetWalletUser(string username);
        void chargwallet(string username, int amount, string description, bool ispay=false);
        void AddWallet(Wallet wallet);
        #endregion

        #region Admin Panel

        UserForAdminViewModel GetUsers(int PageID = 1, string FilterEmail = "", string FilterUserName = "");
        UserForAdminViewModel GetDeleteUsers(int PageID = 1, string FilterEmail = "", string FilterUserName = "");
        //int Adduserforadmin(CreateUserViewModel user);
        int AddfromAdmin(CreateUserViewModel user);
        // int EditUserforAdmin(EditUserViewModel user);
        EditUserViewModel GetUserforShowinEditMode(int userid);
        void EditfromAdmin(EditUserViewModel editUser);
        void DeleteUser(int userid);
        #endregion

        
    }
}
