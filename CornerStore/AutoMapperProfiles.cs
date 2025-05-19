using CornerStore.Models;
using CornerStore.Models.DTOS.Default;
using CornerStore.Models.DTOS.Detailed;
using AutoMapper;

//there are 5 models

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Cashier, DefaultCashierDTO>();
        CreateMap<DefaultCashierDTO, Cashier>();

        CreateMap<Cashier, CashierExpandOrdersDTO>();
        CreateMap<CashierExpandOrdersDTO, Cashier>();

        CreateMap<Order, DefaultOrderDTO>().ForMember(DTO => DTO.Total, opt => opt.MapFrom(order => order.OrderProducts.Sum(op => op.Product.Price * op.Quantity)));
        CreateMap<DefaultOrderDTO, Order>();

        CreateMap<Order, OrderExpandOPsDTO>().ForMember(DTO => DTO.Total, opt => opt.MapFrom(order => order.OrderProducts.Sum(op => op.Product.Price * op.Quantity)));
        CreateMap<OrderExpandOPsDTO, Order>();

        CreateMap<Order, OrderFullExpandDTO>().ForMember(DTO => DTO.Total, opt => opt.MapFrom(order => order.OrderProducts.Sum(op => op.Product.Price * op.Quantity)));
        CreateMap<OrderFullExpandDTO, Order>();

        CreateMap<Order, PostOrderWithJTsDTO>();
        CreateMap<PostOrderWithJTsDTO, Order>();

        CreateMap<Product, Product>();

        CreateMap<Product, DefaultProductDTO>();
        CreateMap<DefaultProductDTO, Product>();

        CreateMap<Product, ProductsExpanCategoryDTO>();
        CreateMap<ProductsExpanCategoryDTO, Product>();

        CreateMap<Product, ProductExpandCDTO>();

        CreateMap<OrderProduct, DefaultOrderProductDTO>();
        CreateMap<DefaultOrderProductDTO, OrderProduct>();

        CreateMap<OrderProduct, OrderProductExpandPDTO>();
        CreateMap<OrderProductExpandPDTO, OrderProduct>();

        CreateMap<Category, DefaultCategoryDTO>();
    }
}