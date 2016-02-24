using System.Collections.Generic;
using static AutoMapper.Mapper;

namespace Wunderlist.Mapper
{
    public static class HelperConvert
    {
        public static TOutput EntityConvert<TInput, TOutput>(TInput source)
        {
            CreateMap<TInput, TOutput>();
            return Map<TInput, TOutput>(source);
        }
        
        public static IEnumerable<TOutput> EntityConvert<TInput, TOutput>(IEnumerable<TInput> source)
        {
            CreateMap<TInput, TOutput>();
            return Map<IEnumerable<TInput>, IEnumerable<TOutput>>(source);
        }
    }
}