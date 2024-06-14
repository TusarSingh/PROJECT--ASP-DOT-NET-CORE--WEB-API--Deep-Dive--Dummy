using Radhey.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radhey.Repository.Interface.IAccountRepo.IGetAllUserRepo
{
    public interface IGetAllUserWithEFC
    {
        public Task<ResponseComModel<object>> GetAllUser();



    }
}
