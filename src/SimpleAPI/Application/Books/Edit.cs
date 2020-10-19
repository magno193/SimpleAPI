using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAPI.Models;

namespace SimpleAPI.Application.Books
{
  public class Edit
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
        Book book = await _context.Books.FindAsync(request.Id);
        if (book == null) throw new Exception("Não foi possível encontrar livro.");

        book.Title = request.Title ?? book.Title;
        book.Description = request.Description ?? book.Description;
        book.Category = request.Category ?? book.Category;
        book.Author = request.Author ?? book.Author;
        book.Publisher = request.Publisher ?? book.Publisher;
        book.UpdatedAt = DateTime.Now;

        bool success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;
        throw new Exception("Ocorreu um problema ao salvar os dados!");
      }
    }
  }
}
