using UdemyCarBook.Aplication.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Aplication.Interfaces.CarInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));

builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();


builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();


builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();


builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarqueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
