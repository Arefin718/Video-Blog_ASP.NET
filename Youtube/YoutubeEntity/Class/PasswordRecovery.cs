using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class PasswordRecovery : Entity
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int PasswordResetCode { get; set; }
        public int PasswordResetCodeStatus { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
