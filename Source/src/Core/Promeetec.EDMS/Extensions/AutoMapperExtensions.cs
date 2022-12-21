﻿using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services, IEnumerable<Type> types)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            foreach (var type in types)
            {
                var typesToMap = type.Assembly.GetTypes()
                    .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && (
                        typeof(ICommand).IsAssignableFrom(t) ||
                        typeof(IEvent).IsAssignableFrom(t) ||
                        typeof(IQuery<>).IsAssignableFrom(t)))
                    .ToList();

                foreach (var typeToMap in typesToMap)
                {
                    cfg.CreateMap(typeToMap, typeToMap);
                }
            }
        });

        services.AddSingleton(sp => autoMapperConfig.CreateMapper());

        return services;
    }
}