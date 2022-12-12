using AutoMapper;

namespace Catalog.API.Profiles;

public class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        // From Db entities to models
        CreateMap<Product, ReadProduct>();

        // From models to Db entities
        CreateMap<UpdateProduct, Product>();
        CreateMap<AddProduct, Product>();
    }
}
