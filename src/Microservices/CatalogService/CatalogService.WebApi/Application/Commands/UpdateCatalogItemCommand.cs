using CatalogService.WebApi.Domain.Contexts;
using Common.Responses;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.WebApi.Application.Commands
{
    public class UpdateCatalogItemCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, Response>
        {
            private readonly CatalogContext _context;

            public UpdateCatalogItemCommandHandler(CatalogContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var dbCatalogItem = await _context.CatalogItems.FirstOrDefaultAsync(x => x.Id == request.Id);

                    if (dbCatalogItem is null)
                        return new Response(false, "Catalog item not found!");

                    dbCatalogItem.Name = request.Name;
                    dbCatalogItem.UpdatedDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return new Response(false, $"Error an occured: {e.Message}");
                }

                return new Response(true, "Successful");
            }
        }
    }

    public class UpdateCatalogItemCommandValidator : AbstractValidator<UpdateCatalogItemCommand>
    {
        public UpdateCatalogItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        }
    }
}
