using AutoMapper;
using ProParcv4.Books;

namespace ProParcv4;

public class ProParcv4ApplicationAutoMapperProfile : Profile
{
    public ProParcv4ApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
