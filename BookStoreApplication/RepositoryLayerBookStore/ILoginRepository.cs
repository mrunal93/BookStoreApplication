using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface ILoginRepository
    {
        LoginModelClass AddLoginDetails(LoginModelClass login);
        LoginModelClass UpdateLoginUser(LoginModelClass login);
    }
}
