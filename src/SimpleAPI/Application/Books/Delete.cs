using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAPI.Models;

namespace SimpleAPI.Application.Books
{
  public class Delete
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
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

        _context.Remove(book);

        var success = await _context.SaveChangesAsync() > 0;
        if (success) return Unit.Value;
        throw new Exception("Ocorreu um problema ao salvar os dados!");
      }
    }
  }
}
