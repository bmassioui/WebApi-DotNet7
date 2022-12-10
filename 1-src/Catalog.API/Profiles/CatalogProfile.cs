using AutoMapper;

namespace Catalog.API.Profiles;

public class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        CreateMap<Product, ReadProduct>();
    }
}
