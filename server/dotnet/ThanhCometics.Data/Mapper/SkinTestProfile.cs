using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.SkinTestModel;
using ThanhCometics.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Mapper
{
    public class SkinTestProfile : Profile
    {
        public SkinTestProfile()
        {
            CreateMap<SkinTestCreateRequest, SkinTest>()
            .ForMember(dest => dest.SkinTestName, opt => opt.MapFrom(src => src.SkinTestName))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.SkinTypeQuestions, opt => opt.MapFrom(src => src.SkinTypeQuestions));

            CreateMap<SkinTypeQuestionRequest, SkinTypeQuestion>()
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
               .ForMember(dest => dest.SkinTypeAnswers, opt => opt.MapFrom(src => src.SkinTypeAnswers));

            
            CreateMap<SkinTypeAnswerRequest, SkinTypeAnswer>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SkinTypeAnswerSkinTypes, opt => opt.MapFrom(src => 
                    src.SkinTypeIds.Select(id => new SkinTypeAnswerSkinType
                    {
                        SkinTypeId = id
                    })));
            CreateMap<SkinTestUpdateRequest, SkinTest>()
                .ForMember(dest => dest.SkinTestId, opt => opt.MapFrom(src => src.SkinTestId))
                .ForMember(dest => dest.SkinTestName, opt => opt.MapFrom(src => src.SkinTestName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.SkinTypeQuestions, opt => opt.MapFrom(src => src.SkinTypeQuestions));

            CreateMap<SkinTypeQuestionUpdateRequest, SkinTypeQuestion>()
                .ForMember(dest => dest.SkinTypeQuestionId, opt => opt.MapFrom(src => src.SkinTypeQuestionId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.SkinTypeAnswers, opt => opt.MapFrom(src => src.SkinTypeAnswers)); 

            // Ánh xạ SkinTypeAnswerUpdateRequest -> SkinTypeAnswer
            CreateMap<SkinTypeAnswerUpdateRequest, SkinTypeAnswer>()
                .ForMember(dest => dest.SkinTypeAnswerId, opt => opt.MapFrom(src => src.SkinTypeAnswerId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SkinTypeAnswerSkinTypes, opt => opt.MapFrom(src =>
                    src.SkinTypeIds.Select(id => new SkinTypeAnswerSkinType 
                    {
                        SkinTypeId = id
                    }
                )));


            CreateMap<SkinTest, SkinTestViewModel>()
            .ForMember(dest => dest.SkinTypeQuestions, opt => opt.MapFrom(src => src.SkinTypeQuestions));

            CreateMap<SkinType, SkinTestResultViewModel>()
            .ForMember(dest => dest.SkinTypeId, opt => opt.MapFrom(src => src.SkinTypeId))
            .ForMember(dest => dest.SkinTypeName, opt => opt.MapFrom(src => src.SkinTypeName));

            CreateMap<SkinTypeQuestion, SkinTypeQuestionViewModel>()
                .ForMember(dest => dest.SkinTypeAnswers, opt => opt.MapFrom(src => src.SkinTypeAnswers));

            CreateMap<SkinTypeAnswer, SkinTypeAnswerViewModel>();
            CreateMap<SkinTest, SkinTestGetAllViewModel>();
        }
    }
}
