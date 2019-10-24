using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Model.ModelFilter;
using Business_Logic_Layer.Mappers;
using Business_Logic_Layer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business_Logic_Layer
{
    public static class Injector
    {
        public static IServiceCollection BindInjector(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new CarProfile());
                mc.AddProfile(new OrderProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddTransient<IValidator<OrderBLCreate>, OrderBLCreateValidator>();
            services.AddTransient<IValidator<OrderBLUpdate>, OrderBLUpdateValidator>();
            services.AddTransient<IValidator<OrderBLFilter>, OrderBLFilterValidator>();
            return services;
        }
    }
}
