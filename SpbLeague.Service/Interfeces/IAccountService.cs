using SpbLeague.Domain.Models;
using SpbLeague.Domain.Response;
using SpbLeague.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Service.Interfeces
{
    public interface IAccountService
    {
        Task<BaseResponse<User>> Login(LoginViewModel login);
        Task<BaseResponse<User>> Register(RegisterViewModel register);
    }
}
