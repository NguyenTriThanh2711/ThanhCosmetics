using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;

namespace ThanhCometics.Service.Interfaces
{
    public interface ITokenGenerator
    {
        AccessToken GenerateAccessTokenToCustomer(Customer customer);
        AccessToken GenerateAccessTokenToOthers(Account account);
        string GenerateRefreshToken();
        string GenerateEmailVerificationToken(string email);
        string GeneratePasswordResetToken(string email);
    }
}
