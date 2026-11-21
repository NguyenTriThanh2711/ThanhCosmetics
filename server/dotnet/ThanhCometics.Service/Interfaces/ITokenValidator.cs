using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;

namespace ThanhCometics.Service.Interfaces
{
    public interface ITokenValidator
    {
        bool ValidateRefreshToken(string token);
        MethodResult<string> GetEmailFromExpiredAccesstoken(string token);
        MethodResult<string> ValidateEmailVerificationToken(string token);
        MethodResult<string> ValidatePasswordResetToken(string token);
    }
}
