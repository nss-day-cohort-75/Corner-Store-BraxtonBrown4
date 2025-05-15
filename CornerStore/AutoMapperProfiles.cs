using CornerStore.Models;
using CornerStore.Models.DTOS;
using CornerStore.Models.DTOS.Default;
using AutoMapper;

//there are 5 models

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Cashier, DefaultCashierDTO>();
        CreateMap<Category, DefaultCategoryDTO>();
        CreateMap<Order, DefaultOrderDTO>();
        CreateMap<OrderProduct, DefaultOrderProductDTO>();
        CreateMap<Product, DefaultProductDTO>();


        //CreateMap<convert thing 1, to thing 2>();
    }
}