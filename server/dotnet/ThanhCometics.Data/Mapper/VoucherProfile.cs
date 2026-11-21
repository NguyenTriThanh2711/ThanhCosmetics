using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.VoucherModel;
using ThanhCometics.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    public class VoucherProfile:Profile
    {
        public VoucherProfile()
        {
            CreateMap<Voucher, VoucherViewModel>();     
            CreateMap<VoucherViewModel, Voucher>();
            CreateMap<VoucherCreateRequestModel, Voucher>();
            CreateMap<VoucherUpdateRequestModel, Voucher>();
        }
    }
}
