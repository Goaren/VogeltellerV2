using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.Repositories
{
    public class AccountRepository
    {
        private IAccountContext context;

        public Account InsertAccount(Account account)
        {
            return context.InsertAccount(account);
        }

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }
        public Account Login(string email, string password)
        {
            return context.Login(email, password);
        }
    }
}
