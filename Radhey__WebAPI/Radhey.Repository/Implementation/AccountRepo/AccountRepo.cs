using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Identity;
using Radhey.DAL.DatabaseContext;
using Radhey.DAL.IdentityTables;
using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;
using Radhey.Repository.Interface.IAccountRepo;
using Radhey.Repository.Interface.IAccountRepo.IGetAllUserRepo;
using Radhey.Repository.Interface.IAccountRepo.IUserLoginRepo;
using Radhey.Repository.Interface.IAccountRepo.IUserRegistrationRepo;





namespace Radhey.Repository.Implementation.AccountRepo
{
    public class AccountRepo : IAccountRepo
    {
        
        private readonly IUserRegistrationWithEFC _userRegistrationWithEFC;
        private readonly IUserLoginWithEFC _userLoginWithEFC;
        private readonly IGetAllUserWithEFC _allUserWithEFC;




        public AccountRepo(
                            IUserRegistrationWithEFC userRegistrationWithEFC,
                            IUserLoginWithEFC userLoginWithEFC,
                            IGetAllUserWithEFC getAllUserWithEFC
                          )
        {
            this._userRegistrationWithEFC = userRegistrationWithEFC;
            this._userLoginWithEFC = userLoginWithEFC;
            this._allUserWithEFC = getAllUserWithEFC;
        }





        #region User Registration

        #region User Registration Create Async => CreateAsync(User)
        public async Task<ResponseComModel> UserRegistrationCreateAsync(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel response = new ResponseComModel();

            response = await _userRegistrationWithEFC.UserRegistrationCreateAsync(userRegistrationReq).ConfigureAwait(false);

            return response;

        }

        #endregion

        #region User Registration Create Async With Password => CreateAsync(User,userRegistrationReq.Password)
        public async Task<ResponseComModel> UserRegistrationCreateAsyncWithPassword(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel response = new ResponseComModel();

            response = await _userRegistrationWithEFC.UserRegistrationCreateAsyncWithPassword(userRegistrationReq).ConfigureAwait(false);

            return response;

        }

        #endregion

        #endregion


        #region UserLogin

        public async Task<ResponseComModel<object>> UserLogin(UserLoginReqModel userLoginReq)
        {
            ResponseComModel<object> response = new ResponseComModel<object>();

            response = await _userLoginWithEFC.UserLogin(userLoginReq).ConfigureAwait(false);;

            return response;
        }

        #endregion

        #region GetAllUser
        public async Task<ResponseComModel<object>> GetAllUser()
        {
            ResponseComModel<object> response = new ResponseComModel<object>();

            response = await _allUserWithEFC.GetAllUser().ConfigureAwait(false);

            return response;
        }

        #endregion

    }










}
