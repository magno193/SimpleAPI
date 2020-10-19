using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;

namespace SimpleAPI.Application.Books
{
  public class List
  {
    public class Query : IRequest<List<Book>> { }

    public class Handler : IRequestHandler<Query, List<Book>>
    {
      public BookContext _context { get; set; }
      public Handler(BookContext context)
      {

        _context = context;
      }

      public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
      {
        List<Book> books = await _context.Books.ToListAsync();

        return books;
      }
    }
  }
}
