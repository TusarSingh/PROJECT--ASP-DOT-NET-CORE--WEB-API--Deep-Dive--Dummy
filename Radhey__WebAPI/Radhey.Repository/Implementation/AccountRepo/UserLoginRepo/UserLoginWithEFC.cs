using Radhey.DAL.IdentityTables;
using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;
using Radhey.Repository.Interface.IAccountRepo;
using Radhey.Repository.Interface.IAccountRepo.IUserLoginRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Implementation.AccountRepo.UserLoginRepo
{
    public class UserLoginWithEFC : IUserLoginWithEFC
    {


        private readonly ICustomUserManager _userManager;
        private readonly ICustomSignInManager _signInManager;




        public UserLoginWithEFC(
                                 ICustomUserManager userManager
                               , ICustomSignInManager signInManager
                                )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }








        #region UserLogin

        public async Task<ResponseComModel<object>> UserLogin(UserLoginReqModel userLoginReq)
        {
            ResponseComModel<object> response = new ResponseComModel<object>();

            TblApplicationUser tblApplicationUser = new TblApplicationUser();

            var chkUserEmail = await _userManager.GetFindByEmailAsync(userLoginReq.Email).ConfigureAwait(false);

            if (chkUserEmail != null)
            {
                var chkPass = await _userManager.GetCheckPasswordAsync(chkUserEmail, userLoginReq.Password).ConfigureAwait(false);



                if (chkPass)
                {
                    //var userLogin = await _signInManager.GetPasswordSignInAsync(chkUserEmail, userLoginReq.Password, false, false);
                    var userLogin = await _signInManager.GetPasswordSignInAsync(userLoginReq.Email, userLoginReq.Password, false, false);


                    response.StatusCode = 200;
                    response.Data = userLoginReq.Email;
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Password is Wrong.";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusMessage = "Please Check your Email";
            }

            return response;
        }


        #endregion



        






















    }
}
