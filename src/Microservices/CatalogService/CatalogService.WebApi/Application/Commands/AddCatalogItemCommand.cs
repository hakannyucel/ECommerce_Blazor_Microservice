using CatalogService.WebApi.Domain.Contexts;
using CatalogService.WebApi.Domain.Entities;
using Common.Responses;
using FluentValidation;
using MediatR;

namespace CatalogService.WebApi.Application.Commands
{
    public class AddCatalogItemCommand : IRequest<Response>
    {
        public string Name { get; set; }

        public class AddCatalogItemCommandHandler : IRequestHandler<AddCatalogItemCommand, Response>
        {
            private readonly CatalogContext _context;

            public AddCatalogItemCommandHandler(CatalogContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
            {
                var catalogItem = new CatalogItem
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    CreatedDate = DateTime.Now,
                };

                try
                {
                    await _context.CatalogItems.AddAsync(catalogItem);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return new Response(false, $"Error an occured: {e.Message}");
                }

                return new Response(true, "Successful");
            }
        }

        public class AddCatalogItemCommandValidator : AbstractValidator<AddCatalogItemCommand>
        {
            public AddCatalogItemCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            }
        }
    }
}
