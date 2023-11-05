using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddNew(Account account) => AccountDAO.Instance.AddAccount(account);

        public void Delete(int id) =>AccountDAO.Instance.RemoveAccount(id);

        public Account GetAccount(int id) => AccountDAO.Instance.GetAccountByID(id);

        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccountList();

        public Account Login(string username, string password) => AccountDAO.Instance.Login(username, password);

        public void Update(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
