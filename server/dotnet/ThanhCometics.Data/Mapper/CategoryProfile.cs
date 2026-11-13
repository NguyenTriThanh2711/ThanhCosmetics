using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.OrderDetailModel;
using ThanhCometics.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
