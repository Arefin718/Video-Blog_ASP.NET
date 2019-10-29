using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeService.Interface;

namespace YoutubeService.Class
{
    public class ForgetPasswordService : Service<PasswordRecovery>, IForgetPasswordService
    {
        ForgetPasswordRepository forgetPassRepo = new ForgetPasswordRepository();

        public User ChangePassword(User user)
        {
           return forgetPassRepo.ChangePassword(user);
        }

        public void DeletePassRecoveryCodeByUserId(int id)
        {
            forgetPassRepo.DeletePassRecoveryCodeByUserId(id);
        }

        public PasswordRecovery GetPassRecoveryCodeByUserId(int id)
        {
            return forgetPassRepo.GetPassRecoveryCodeByUserId(id);
        }

        public User GetUserByEmail(string email)
        {
            return forgetPassRepo.GetUserByEmail(email);
        }

        public int InsertPasswordResetCode(PasswordRecovery passRecover)
        {
            return forgetPassRepo.InsertPasswordResetCode(passRecover);
        }
    }
}
