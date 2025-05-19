using CornerStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using AutoMapper.QueryableExtensions;
using CornerStore.Models.DTOS.Default;
using CornerStore.Models.DTOS.Detailed;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core and provides dummy value for testing
builder.Services.AddNpgsql<CornerStoreDbContext>(builder.Configuration["CornerStoreDbConnectionString"] ?? "testing");

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region cashiers

app.MapGet("/cashiers", (CornerStoreDbContext db, IMapper mapper) =>
{
    return db.Cashiers.ProjectTo<DefaultCashierDTO>(mapper.ConfigurationProvider).ToList();
});

app.MapGet("/cashiers/{id}", (int id, CornerStoreDbContext db, IMapper mapper, string? expand) =>
{
    IQueryable query = db.Cashiers.Where(c => c.Id == id);

    if (expand == "orders")
    {
        CashierExpandOrdersDTO cashierDTO = query.ProjectTo<CashierExpandOrdersDTO>(mapper.ConfigurationProvider).SingleOrDefault();
        return cashierDTO != null ? Results.Ok(cashierDTO) : Results.NotFound();
    }
    else
    {
        DefaultCashierDTO cashierDTO = query.ProjectTo<DefaultCashierDTO>(mapper.ConfigurationProvider).SingleOrDefault();
        return cashierDTO != null ? Results.Ok(cashierDTO) : Results.NotFound();
    }
});

app.MapPost("/cashiers", (CornerStoreDbContext db, IMapper mapper, Cashier newCashier) =>
{
    try
    {
        db.Cashiers.Add(newCashier);
        db.SaveChanges();

        return Results.Created($"/cashiers/{newCashier.Id}", mapper.Map<DefaultCashierDTO>(newCashier));
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data");
    }
});

#endregion

#region products

app.MapGet("/products", (CornerStoreDbContext db, IMapper mapper, string? productName, string? categoryName) =>
{
    if (productName != null && categoryName != null)
    {
        return Results.Ok(db.Products.Where(p => p.ProductName == productName && p.Category.CategoryName == categoryName).ProjectTo<ProductsExpanCategoryDTO>(mapper.ConfigurationProvider));
    }
    else if (productName != null || categoryName != null)
    {
        return Results.Ok(db.Products.Where(p => p.ProductName == productName || p.Category.CategoryName == categoryName).ProjectTo<ProductsExpanCategoryDTO>(mapper.ConfigurationProvider));
    }

    return Results.Ok(db.Products.ProjectTo<ProductsExpanCategoryDTO>(mapper.ConfigurationProvider));
});

app.MapPost("/products", (CornerStoreDbContext db, IMapper mapper, Product newProduct) =>
{
    try
    {
        db.Products.Add(newProduct);
        db.SaveChanges();

        return Results.Created($"/products/{newProduct.Id}", mapper.Map<DefaultProductDTO>(newProduct));
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data");
    }
});

app.MapPut("/products/{id}", (CornerStoreDbContext db, IMapper mapper, Product newProduct, int id) =>
{
    try
    {
        Product oldProduct = db.Products.SingleOrDefault(p => p.Id == id);

        if (oldProduct == null)
        {
            return Results.NotFound();
        }

        if (id != newProduct.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }

        mapper.Map(newProduct, oldProduct);
        db.SaveChanges();

        return Results.Ok(mapper.Map<DefaultProductDTO>(oldProduct));
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data");
    }


});

#endregion

#region orders

app.MapGet("/orders/{id}", (int id, CornerStoreDbContext db, IMapper mapper) =>
{
    IQueryable query = db.Orders.Where(c => c.Id == id);

    OrderFullExpandDTO cashierDTO = query.ProjectTo<OrderFullExpandDTO>(mapper.ConfigurationProvider).SingleOrDefault();
    return cashierDTO != null ? Results.Ok(cashierDTO) : Results.NotFound();
});

app.MapGet("/orders", (CornerStoreDbContext db, IMapper mapper, DateTime? paidondate) =>
{
    if (paidondate != null)
    {
        return Results.Ok(db.Orders.Where(o => o.PaidOnDate == paidondate).ProjectTo<DefaultOrderDTO>(mapper.ConfigurationProvider));
    }
    else
    {
        return Results.Ok(db.Orders.ProjectTo<DefaultOrderDTO>(mapper.ConfigurationProvider));
    }
});

app.MapDelete("/orders/{id}", (int id, CornerStoreDbContext db, IMapper mapper) =>
{
    Order order = db.Orders.SingleOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound();
    }

    db.Orders.Remove(order);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapPost("/orders", (CornerStoreDbContext db, IMapper mapper, PostOrderWithJTsDTO newOrder) =>
{
    try
    {
        Order order = new Order
        {
            Id = newOrder.Id,
            CashierId = newOrder.CashierId,
            PaidOnDate = newOrder.PaidOnDate,
            OrderProducts = newOrder.OrderProducts
        };

        db.Orders.Add(order);
        db.SaveChanges();

        Order savedOrder = db.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefault(o => o.Id == order.Id);

        return Results.Created($"/orders/{order.Id}", mapper.Map<OrderExpandOPsDTO>(savedOrder));

    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid Data");
    }
});

#endregion

/*
{
  "id": 0,
  "cashierId": 1,
  "total": 0,
  "paidOnDate": "2025-05-19T14:45:12.729Z",
  "orderProducts": [
    {
      "id": 0,
      "productId": 1,
      "orderId": 0,
      "quantity": 2
    }
  ]
}
*/

app.Run();

//don't move or change this!
public partial class Program { }