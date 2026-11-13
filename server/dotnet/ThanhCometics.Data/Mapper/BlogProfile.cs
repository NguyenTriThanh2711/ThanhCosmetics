using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.BlogModel;
using ThanhCometics.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    class BlogProfile : Profile
    {
        public BlogProfile()
        {            
            CreateMap<Blog, BlogViewModel>();
            CreateMap<Blog, BlogDetailViewModel>();
            CreateMap<BlogDetail, Content>();

            CreateMap<BlogCreateRequest, Blog>();
            CreateMap<BlogDetailCreateRequest, BlogDetail>();

            CreateMap<BlogUpdateRequest, Blog>();
            CreateMap<BlogDetailUpdateRequest, BlogDetail>();
        }
    }
}
