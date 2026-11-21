using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.SkinTypeModel;
using ThanhCometics.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    public class SkinTypeProfile:Profile
    {
        public SkinTypeProfile()
        {
            CreateMap<SkinType, SkinTypeViewModel>();
            CreateMap<SkinType, SkinTypeUpdateRequestModel>();
            CreateMap<SkinType, SkinTypeCreateRequestModel>();
            CreateMap<SkinTypeCreateRequestModel, SkinType >();
        }
        
    }
}
