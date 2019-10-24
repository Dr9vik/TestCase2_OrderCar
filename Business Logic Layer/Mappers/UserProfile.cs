using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Data_Access_Layer.Common.Models;

namespace Business_Logic_Layer.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserBL, UserDB>()
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ReverseMap();

            CreateMap<UserBLCL, UserDB>()
                .ForMember(x => x.TimeModified, y => y.Ignore())
                .ForMember(x => x.TimeAdd, y => y.Ignore())
                .ForMember(x => x.Orders, y => y.Ignore())
                .ReverseMap();
        }
    }
}
