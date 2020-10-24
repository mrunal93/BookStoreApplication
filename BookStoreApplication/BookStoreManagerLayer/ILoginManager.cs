using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public interface ILoginManager
    {
        LoginModelClass AddLoginDetails(LoginModelClass login);
        LoginModelClass UpdateLoginUser(LoginModelClass login);
        string GenerateToken(LoginModelClass login, string type);
    }
}
