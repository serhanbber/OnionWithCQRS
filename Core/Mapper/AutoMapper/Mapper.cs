﻿using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.AutoMapper
{
    public class Mapper : Application.Automapper.IMapper
    {

        public static List<TypePair> typePairs = new();

        private IMapper mapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5,ignore);
            return mapperContainer.Map<TSource,TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return mapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination,object>(5, ignore);
            return mapperContainer.Map< TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination,IList<object> >(5, ignore);
            return mapperContainer.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)//default 5 gelir automapperda.5 dtoya kadar
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));
            if (typePairs.Any(x => x.DestinationType == typePair.DestinationType && x.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore,x=>x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                }
            });
            mapperContainer = config.CreateMapper();
        }
    }
}
