using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Interface.IAccountRepo.IUserLoginRepo
{
    public interface IUserLoginWithEFC
    {
        public Task<ResponseComModel<object>> UserLogin(UserLoginReqModel userLoginReq);
    }
}
