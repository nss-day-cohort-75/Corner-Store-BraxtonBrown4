using CornerStore.Models;
using CornerStore.Models.DTOS.Default;
using CornerStore.Models.DTOS.Detailed;
using AutoMapper;

//there are 5 models

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        #region Cashiers

        CreateMap<Cashier, DefaultCashierDTO>();
        CreateMap<DefaultCashierDTO, Cashier>();

        CreateMap<Cashier, CashierExpandOrdersDTO>();
        CreateMap<CashierExpandOrdersDTO, Cashier>();

        #endregion

        #region Orders

        CreateMap<Order, DefaultOrderDTO>().ForMember(DTO => DTO.Total, opt => opt.MapFrom(order => order.OrderProducts.Sum(op => op.Product.Price * op.Quantity)));
        CreateMap<DefaultOrderDTO, Order>();

        CreateMap<Order, OrderExpandOPsDTO>().ForMember(DTO => DTO.Total, opt => opt.MapFrom(order => order.OrderProducts.Sum(op => op.Product.Price * op.Quantity)));
        CreateMap<OrderExpandOPsDTO, Order>();

        #endregion

        CreateMap<Category, DefaultCategoryDTO>();
        CreateMap<OrderProduct, DefaultOrderProductDTO>();
        CreateMap<Product, DefaultProductDTO>();


        //CreateMap<convert thing 1, to thing 2>();
    }
}