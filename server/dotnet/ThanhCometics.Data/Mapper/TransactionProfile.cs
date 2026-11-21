using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.ViewModels;
using AutoMapper;

namespace ThanhCometics.Repository.Mapper
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionViewModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Order.Customer.FullName));
        }
    }
}
