using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using toplearn.Core.Convertor;
using toplearn.Core.DTOs;
using toplearn.Core.Generator;
using toplearn.Core.Services.Interfaces;
using toplearn.Datalayer.Context;
using toplearn.Datalayer.Entities.User;
using toplearn.Datalayer.Entities.Wallet;
using TopLearn.Core.Security;

namespace toplearn.Core.Services
{
    public class UserServiec : IUserServiec
    {
        private ToplearnContext _Context;
        public UserServiec(ToplearnContext Context)
        {
            _Context = Context;
        }

        public bool ActiveAccount(string ActiveCode)
        {
            var user = _Context.Users.SingleOrDefault(u => u.ActiveCode == ActiveCode);
            if (user == null || user.IsActive == false)
                return false;
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _Context.SaveChanges();
            return true;

        }

        public int AddfromAdmin(CreateUserViewModel user)
        {
            User adduser = new User();
            adduser.PassWord = PasswordHelper.EncodePasswordMd5(user.PassWord);
            adduser.IsActive = true;
            adduser.Email = user.Email;
            adduser.RegisterDate = DateTime.Now;
            adduser.ActiveCode = NameGenerator.GenerateUniqCode();
            adduser.UserName = user.UserName;
            #region SaveAvatar
            if (user.UserAtar != null)
            {
                string imagePath = "";
                adduser.Avatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAtar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvator", adduser.Avatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAtar.CopyTo(stream);
                }
            }

            #endregion
            return AddUser(adduser);
        }

        public int AddUser(User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
            return user.UserID;

        }


        public void AddWallet(Wallet wallet)
        {
            _Context.Wallets.Add(wallet);
            _Context.SaveChanges();
        }

        public int BalnceWalletUser(string usernme)
        {
            var userid = GetUserIDByUsername(usernme);

            var payin = _Context.Wallets.Where(w => w.UserID == userid && w.TypId == 1 && w.IsPay).Select(w => w.Amount).ToList();
            var payout = _Context.Wallets.Where(w => w.UserID == userid && w.TypId == 2 && w.IsPay).Select(w => w.Amount).ToList();
            return (payin.Sum() - payout.Sum());
        }

        public void ChangePassword(string username, string NewPassword)
        {

            var user = GetuserByUsername(username);
            user.PassWord = PasswordHelper.EncodePasswordMd5(NewPassword);
            UpdateUser(user);
        }

        public void chargwallet(string username, int amount, string description, bool ispay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                TypId = 1,
                UserID = GetUserIDByUsername(username),
                IsPay = ispay
            };
            AddWallet(wallet);
        }

        public bool CompareOldpassword(string username, string OldPassword)
        {
            string hashOldPassword = PasswordHelper.EncodePasswordMd5(OldPassword);
            return _Context.Users.Any(u => u.UserName == username && u.PassWord == hashOldPassword);

        }

        public void DeleteUser(int userid)
        {
            User user = GetUserByID(userid);
            user.IsDelete = true;
            UpdateUser(user);
            
        }

        public void EditfromAdmin(EditUserViewModel editUser)
        {
            User user = GetUserByID(editUser.Userid);
            user.Email = editUser.Email;
            if (!String.IsNullOrEmpty(editUser.PassWord))
            {
                user.PassWord = PasswordHelper.EncodePasswordMd5(editUser.PassWord);
            }
            if (editUser.UserAtar!=null)
            {
                //delete old img
                if (editUser.Avatarname!= "Defult.jpg")
                {
                   string DeletPath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvator", editUser.Avatarname);
                    if (File.Exists(DeletPath))
                    {
                        File.Delete(DeletPath);
                    }
                }
                //save new img
                string imagePath = "";
                user.Avatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserAtar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvator", user.Avatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAtar.CopyTo(stream);
                }

            }
            _Context.Users.Update(user);
            _Context.SaveChanges();
        }
           





        //public void EditProfile(EditProfilUserPanelViewModel profile)
        //{
        //    if (profile.AvatrName!=null)
        //    {

        //        //چون خیلی ادیت کردن عکس کدهاش زیاد بود قرار شد اینو نخونم تا استاد درم بخت بهم توضیح بده
        //        //پس ویرایش پروفابل نصفه کاره موند

        //    }


        //}

        public User GetByEmail(string Email)
        {
            return _Context.Users.SingleOrDefault(u => u.Email == Email);
        }

        public UserForAdminViewModel GetDeleteUsers(int PageID = 1, string FilterEmail = "", string FilterUserName = "")
        {
            IQueryable<User> result = _Context.Users.IgnoreQueryFilters().Where(u=>u.IsDelete);
            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));

            }
            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));

            }
            //show item in page
            int take = 10;

            int skip = (PageID - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();



            list.CurentPage = PageID;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();

            return list;


        }

        public EditProfilUserPanelViewModel GEtEditUserPanelDate(string username)
        {
            return _Context.Users.Where(u => u.UserName == username).Select(u => new EditProfilUserPanelViewModel()
            {
                UserName = u.UserName,
                Email = u.Email,
                AvatrName = u.Avatar

            }).Single();
        }

        public SidBarUserPanelViewModwl GetsideBarUserpanelData(string username)
        {
            return _Context.Users.Where(u => u.UserName == username).Select(u => new SidBarUserPanelViewModwl
            {
                Username = u.UserName,
                ImaageName = u.Avatar,
                RegisterDate = u.RegisterDate


            }).Single();
        }

        public User GetuserByActiveCode(string activecode)
        {
            return _Context.Users.SingleOrDefault(u => u.ActiveCode == activecode);
        }

        public User GetUserByID(int Userid)
        {
            return _Context.Users.Find(Userid);
        }

        //public int GetUserByUserID(string username)
        //{
        //    return _Context.Users.Single(u => u.UserName == username).UserID;
        //}

        public User GetuserByUsername(string username)
        {
            return _Context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public EditUserViewModel GetUserforShowinEditMode(int userid)
        {
            return _Context.Users.Where(u => u.UserID == userid).
                Select(u => new EditUserViewModel()
                {
                    Userid=u.UserID,
                    Email = u.Email,
                    UserName = u.UserName, 
                    Avatarname = u.Avatar,
                    UserRols = u.UserRoles.Select(r => r.RolID).ToList()

                }).Single();

        }

        public int GetUserIDByUsername(string username)
        {
            return _Context.Users.Single(u => u.UserName == username).UserID;
        }

        public InformatinUserViewModel GetUserInformation(string username)
        {
            var user = GetuserByUsername(username);


            InformatinUserViewModel informatin = new InformatinUserViewModel();

            informatin.Udername = user.UserName;
            informatin.Email = user.Email;
            informatin.RegisterDate = user.RegisterDate;
            informatin.Wallet = BalnceWalletUser(username);
            return informatin;
        }

        public InformatinUserViewModel GetUserInformation(int id)
        {
            var user =GetUserByID(id);


            InformatinUserViewModel informatin = new InformatinUserViewModel();

            informatin.Udername = user.UserName;
            informatin.Email = user.Email;
            informatin.RegisterDate = user.RegisterDate;
            informatin.Wallet = BalnceWalletUser(user.UserName);
            return informatin;
        }

        public UserForAdminViewModel GetUsers(int PageID = 1, string FilterEmail = "", string FilterUserName = "")
        {
            IQueryable<User> result = _Context.Users;
            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));

            }
            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));

            }
            //show item in page
            int take = 10;

            int skip = (PageID - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();



            list.CurentPage = PageID;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();

            return list;

        }

        public bool IsExistEmail(string Email)
        {
            return _Context.Users.Any(u => u.Email == Email);
        }

        public bool IsExistUserName(string username)
        {
            return _Context.Users.Any(u => u.UserName == username);
        }

        public User loginuser(LoginViewModel login)
        {
            string hashpassword = PasswordHelper.EncodePasswordMd5(login.PassWord);
            string email = FixedText.FixedEmail(login.Email);
            return _Context.Users.SingleOrDefault(u => u.PassWord == hashpassword && u.Email == email);
        }



        public void UpdateUser(User user)
        {
            _Context.Update(user);
            _Context.SaveChanges();

        }

        List<WalletViewModel> IUserServiec.GetWalletUser(string username)
        {

            int UserID = GetUserIDByUsername(username);
            return _Context.Wallets.Where(w => w.UserID == UserID && w.IsPay).Select(w => new WalletViewModel()
            {
                Amount = w.Amount,
                CreateDate = w.CreateDate,
                Description = w.Description,
                Type = w.TypId


            }).ToList();
        }
    }
}
