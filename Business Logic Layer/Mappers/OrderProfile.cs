using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Data_Access_Layer.Common.Models;

namespace Business_Logic_Layer.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderBL, OrderDB>()
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ReverseMap();

            CreateMap<OrderBLCreate, OrderDB>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ReverseMap();

            CreateMap<OrderBLUpdate, OrderDB>()
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ReverseMap();

            CreateMap<OrderBLCL, OrderDB>()
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ReverseMap();
        }
    }
}
