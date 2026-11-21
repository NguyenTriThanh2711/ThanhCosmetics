using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models;

namespace ThanhCometics.Service.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(MailData mailData);
        Task<MethodResult<string>> SendAccountVerificationEmailAsync(Customer customer);
    }
}
