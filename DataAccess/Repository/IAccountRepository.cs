using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        public Account Login(string username, string password);
        public IEnumerable<Account> GetAccounts();
        public Account GetAccount(int id);
        public void AddNew(Account account);
        public void Delete(int id);
        public void Update(Account account);
    }
}
