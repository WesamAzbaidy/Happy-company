using AutoMapper;
using Happy_company.Model.Domain;
using Happy_company.Model.DTO;

namespace Happy_company.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<ItemRequest, Items>().ReverseMap();
            CreateMap<Items, ItemsDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<WarehouseRequest, Warehouse>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
        }
    }
}
