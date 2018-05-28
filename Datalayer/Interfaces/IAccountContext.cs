using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Datalayer.Interfaces
{
    public interface IAccountContext
    {
        Account InsertAccount(Account account);
        Account Login(string email, string password);
    }
}
