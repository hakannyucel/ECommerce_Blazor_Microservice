using CatalogService.WebApi.Domain.Contexts;
using Common.Responses;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.WebApi.Application.Commands
{
    public class DeleteCatalogItemCommand : IRequest<Response>
    {
        public Guid CatalogItemId { get; set; }

        public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, Response>
        {
            private readonly CatalogContext _context;
            private readonly ILogger<DeleteCatalogItemCommandHandler> _logger;

            public DeleteCatalogItemCommandHandler(CatalogContext context, ILogger<DeleteCatalogItemCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Response> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var catalogItem = await _context.CatalogItems.FirstOrDefaultAsync(x => x.Id == request.CatalogItemId);

                    if (catalogItem is null)
                    {
                        throw new Exception("Catalog Item Not Found");
                    }

                    _context.CatalogItems.Remove(catalogItem);
                    await _context.SaveChangesAsync();

                    return new Response(true, "Successful");
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error an occured: {e.Message}");
                    return new Response(false, $"Error an occured: {e.Message}");
                }
            }
        }

        public class DeleteCatalogItemCommandValidator : AbstractValidator<DeleteCatalogItemCommand>
        {
            public DeleteCatalogItemCommandValidator()
            {
                RuleFor(x => x.CatalogItemId).NotEmpty();
            }
        }
    }
}
