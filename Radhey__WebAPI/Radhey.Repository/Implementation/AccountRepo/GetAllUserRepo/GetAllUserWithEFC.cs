using Radhey.Model.CommonModel;
using Radhey.Repository.Interface.IAccountRepo.IGetAllUserRepo;
using Radhey.Repository.Interface.IAccountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Implementation.AccountRepo.GetAllUserRepo
{
    public class GetAllUserWithEFC : IGetAllUserWithEFC
    {
        private readonly ICustomUserManager _customUserManager;
        private readonly ICustomSignInManager _customSignInManager;


        public GetAllUserWithEFC(
                                 ICustomUserManager customUserManager,
                                 ICustomSignInManager customSignInManager
                                )
        {
            this._customUserManager = customUserManager;
            this._customSignInManager = customSignInManager;
        }


        #region GetAllUser
        public async Task<ResponseComModel<object>> GetAllUser()
        {
            ResponseComModel<object> response = new ResponseComModel<object>();

            response = await _customUserManager.GetUser().ConfigureAwait(false);

            return response;

        }


        #endregion





    }
}
