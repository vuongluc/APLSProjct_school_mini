using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;

namespace ProjectDomain.Business.Login
{
    public class LoginEF : ILoginBusiness
    {
        public void createAccount(AccountDTO newAccount)
        {
            using (var db = new ProjectDbContext())
            {
                var account = DTOEFMapper.GetEntityFromDTO(newAccount);
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public AccountDTO findById(string username)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                if (entity != null)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
        }

        public void updateAccount(AccountDTO currentAccount)
        {
            using (var db = new ProjectDbContext())
            {
                var account = db.Accounts.Where(m => m.username == currentAccount.username).FirstOrDefault();
                if (account != null)
                {
                    db.Entry(account).CurrentValues.SetValues(currentAccount);
                    db.SaveChanges();
                }
            }
        }
    }
}
