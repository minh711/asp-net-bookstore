using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccountList()
        {
            var accs = new List<Account>();
            try
            {
                using var context = new PRN_Group03Context();
                accs = context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accs;
        }

        public Account GetAccountByID(int accId)
        {
            Account acc = null;
            try
            {
                using var context = new PRN_Group03Context();
                acc = context.Accounts.SingleOrDefault(a => a.Id == accId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }


        public void AddAccount(Account acc)
        {
            try
            {
                Account _account = GetAccountByID(acc.Id);
                if (_account == null)
                {
                    using var context = new PRN_Group03Context();
                    context.Accounts.Add(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This account is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccount(Account acc)
        {
            try
            {
                Account _account = GetAccountByID(acc.Id);
                if (_account != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Accounts.Update(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveAccount(int accountId)
        {
            try
            {
                Account account = GetAccountByID(accountId);
                if (account != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This account does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account Login(string username, string password)
        {
            try
            {
                Account acc = null;
                using var context = new PRN_Group03Context();
                acc = context.Accounts.SingleOrDefault(e => e.Username == username && e.Password == password);

                if (acc != null)
                {
                    return acc;
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
