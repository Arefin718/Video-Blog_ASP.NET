using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class ForgetPasswordRepository : Repository<PasswordRecovery>, IForgetPasswordRepository
    {
        DataContext context = new DataContext();
        Repository<PasswordRecovery> pRecovery = new Repository<PasswordRecovery>();
        Repository<User> pUser = new Repository<User>();
        

        public User ChangePassword(User user)
        {
           User userToUpdate = context.Users.SingleOrDefault(u => u.Id == user.Id);
           userToUpdate.Password = user.Password;
           pUser.Update(userToUpdate);
           return userToUpdate;
        }

        public void DeletePassRecoveryCodeByUserId(int id)
        {
            PasswordRecovery forgetPassword = context.PasswordRecoverys.SingleOrDefault(pr => pr.UserId == id);
            pRecovery.Delete(forgetPassword.Id);
        }
        
        public PasswordRecovery GetPassRecoveryCodeByUserId(int id)
        {
            return context.PasswordRecoverys.SingleOrDefault(pr => pr.UserId == id);
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
        }

        public int InsertPasswordResetCode(PasswordRecovery passRecover)
        {
          
            PasswordRecovery existOrNot = context.PasswordRecoverys.SingleOrDefault(pr => pr.UserId == passRecover.UserId);

            if (existOrNot == null)
            {
                pRecovery.Insert(passRecover);
                context.SaveChanges();
                
            }
            else
            {

                existOrNot.PasswordResetCode = passRecover.PasswordResetCode;
                pRecovery.Update(existOrNot);
                context.SaveChanges();
            }

            return this.context.SaveChanges();
        }
    }
}
