using Microsoft.AspNetCore.Identity;
using Radhey.DAL.IdentityTables;
using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;
using Radhey.Repository.Interface.IAccountRepo;
using Radhey.Repository.Interface.IAccountRepo.IUserRegistrationRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Implementation.AccountRepo.UserRegistrationRepo
{
    public class UserRegistrationWithEFC : IUserRegistrationWithEFC
    {


        private readonly ICustomUserManager _userManager;
        private readonly ICustomSignInManager _signInManager;

        public UserRegistrationWithEFC(
                                        ICustomUserManager userManager
                                       , ICustomSignInManager signInManager
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

















        #region User Registration

        #region User Registration Create Async => CreateAsync(User)
        public async Task<ResponseComModel> UserRegistrationCreateAsync(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel response = new ResponseComModel();

            TblApplicationUser User = new TblApplicationUser()
            {
                FirstName = userRegistrationReq.FirstName,
                LastName = userRegistrationReq.LastName,
                UserName = userRegistrationReq.Email,
                Email = userRegistrationReq.Email,
                PasswordHash = userRegistrationReq.Password,
                PhoneNumber = userRegistrationReq.Phone
            };

            var saveResult = await _userManager.PostCreateAsync(User).ConfigureAwait(false);

            if (saveResult.Succeeded)
            {
                response.StatusCode = 200;

            }
            else
            {
                response.StatusCode = 400;
            }

            return response;

        }

        #endregion

        #region User Registration Create Async With Password => CreateAsync(User,userRegistrationReq.Password)
        public async Task<ResponseComModel> UserRegistrationCreateAsyncWithPassword(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel response = new ResponseComModel();

            TblApplicationUser User = new TblApplicationUser()
            {
                FirstName = userRegistrationReq.FirstName,
                LastName = userRegistrationReq.LastName,
                UserName = userRegistrationReq.Email,
                Email = userRegistrationReq.Email,
                PasswordHash = userRegistrationReq.Password,
                PhoneNumber = userRegistrationReq.Phone
            };

            var saveResult = await _userManager.PostCreateAsync(User, userRegistrationReq.Password).ConfigureAwait(false);

            if (saveResult.Succeeded)
            {
                response.StatusCode = 200;
            }
            else
            {
                response.StatusCode = 400;
            }

            return response;

        }

        #endregion
        #endregion
    }
}
