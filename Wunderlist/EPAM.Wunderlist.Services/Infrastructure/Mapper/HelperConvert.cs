using System.Collections.Generic;

namespace EPAM.Wunderlist.Services.Infrastructure.Mapper
{
    public class HelperConvert
    {
        public static TOutput EntityConvert<TInput, TOutput>(TInput source) 
            where TOutput : class
        {
            if (source == null)
                return null;

            AutoMapper.Mapper.CreateMap<TInput, TOutput>();
            return AutoMapper.Mapper.Map<TInput, TOutput>(source);
        }

        public static IEnumerable<TOutput> EntityConvert<TInput, TOutput>(IEnumerable<TInput> source)
        {
            if (source == null)
                return null;
            
            AutoMapper.Mapper.CreateMap<TInput, TOutput>();
            return AutoMapper.Mapper.Map<IEnumerable<TInput>, IEnumerable<TOutput>>(source);
        }
    }
}