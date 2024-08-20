using AlbumsIntegration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLendingApplication.Mappers;
public class BookMapper : IMapper<Book, Dtos.Book>
{
    public Dtos.Book Map(Book source)
    {
        return new()
        {
            UserId = source.UserId,
            Id = source.Id,
            Title = source.Title,
        };
    }
}

