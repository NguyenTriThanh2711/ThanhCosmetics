using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.FeedbackModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.ViewModels;

namespace BeautySCProject.Data.Mapper
{
    public class FeedbackProfile :Profile
    {
        public FeedbackProfile() 
        {
            CreateMap<Feedback, FeedbackCreateRequestModel>();
            CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer));
            CreateMap<FeedbackCreateRequestModel, Feedback>();
            CreateMap<Customer, CustomerFeedbackViewModel>()
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}
