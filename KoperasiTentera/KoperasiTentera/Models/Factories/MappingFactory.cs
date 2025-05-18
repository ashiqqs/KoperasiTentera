using AutoMapper;

namespace KoperasiTentera.Models.Factories
{
    public class MappingFactory<TSource, TDestination> : IMappingFactory<TSource, TDestination>
    {
        private readonly IMapper _mapper;
        public MappingFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TSource Create(TDestination destination)
        {
            return _mapper.Map<TSource>(destination);
        }

        public TDestination Create(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
