using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IForgetPasswordService : IService<PasswordRecovery>
    {
        User GetUserByEmail(string email);
        int InsertPasswordResetCode(PasswordRecovery passRecover);
        PasswordRecovery GetPassRecoveryCodeByUserId(int id);
        void DeletePassRecoveryCodeByUserId(int id);
        User ChangePassword(User user);
    }
}
