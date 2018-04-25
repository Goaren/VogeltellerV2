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

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }
        public Account Login(string username, string password)
        {
            return context.Login(username, password);
        }
    }
}
