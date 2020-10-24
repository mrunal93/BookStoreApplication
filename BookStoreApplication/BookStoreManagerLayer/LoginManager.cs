using ModelLayerBookStore;
using RepositoryLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public class LoginManager : ILoginManager
    {
        public readonly ILoginRepository loginRepository;
        public LoginManager(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public LoginModelClass AddLoginDetails(LoginModelClass login)
        {
            return loginRepository.AddLoginDetails(login);
        }

        public LoginModelClass UpdateLoginUser(LoginModelClass login)
        {
            return loginRepository.UpdateLoginUser(login);
        }

        public string GenerateToken(LoginModelClass login, string type)
        {
            return loginRepository.GenerateToken(login, type);
        }
    }
}
