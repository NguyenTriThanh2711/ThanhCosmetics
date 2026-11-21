using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class EmailService : IEmailService
    {
        public Task<MethodResult<string>> SendAccountVerificationEmailAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendMailAsync(MailData mailData)
        {
            throw new NotImplementedException();
        }
    }
}
