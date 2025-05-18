namespace KoperasiTentera.Models.Factories
{
    public interface IMappingFactory<TSource, TDestination>
    {
        TSource Create(TDestination destination);
        TDestination Create(TSource source);
    }
}
