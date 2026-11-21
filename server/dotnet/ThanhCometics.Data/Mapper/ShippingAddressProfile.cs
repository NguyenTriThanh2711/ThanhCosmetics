using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Repository.Models.ShippingAddressModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    public class ShippingAddressProfile : Profile
    {
        public ShippingAddressProfile()
        {
            CreateMap<ShippingAdressCreateRequest, ShippingAddress>();
            CreateMap<ShippingAdressUpdateRequest, ShippingAddress>();


      
        }
    }
}
