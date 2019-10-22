using AutoMapper;
using Business_Logic_Layer.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
            return services;
        }
    }
}
