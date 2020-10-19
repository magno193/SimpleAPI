using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAPI.Models;

namespace SimpleAPI.Application.Books
{
  public class Create
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }

      public string Title { get; set; }

      public string Description { get; set; }

      public string Publisher { get; set; }

      public string Author { get; set; }

      public string Category { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly BookContext _context;
      public Handler(BookContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        Book book = new Book
        {
          Id = Guid.NewGuid(),
          Title = request.Title,
          Description = request.Description,
          Publisher = request.Publisher,
          Author = request.Author,
          Category = request.Category,
          UpdatedAt = DateTime.Now
        };

        _context.Books.Add(book);

        bool success = await _context.SaveChangesAsync() > 0;
        if (success) return Unit.Value;
        throw new Exception("Ocorreu um problema ao salvar os dados!");
      }
    }
  }
}
