using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Interface.IAccountRepo.IUserRegistrationRepo
{
    public interface IUserRegistrationWithEFC
    {
        public Task<ResponseComModel> UserRegistrationCreateAsync(UserRegistrationReqModel userRegistrationReq);
        public Task<ResponseComModel> UserRegistrationCreateAsyncWithPassword(UserRegistrationReqModel userRegistrationReq);
    }
}
