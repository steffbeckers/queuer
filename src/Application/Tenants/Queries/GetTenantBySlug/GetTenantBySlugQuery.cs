using AutoMapper;
using AutoMapper.QueryableExtensions;
using Queuer.Application.Common.Interfaces;
using Queuer.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Queuer.Application.Tenants.Queries.GetTenantBySlug;

namespace Queuer.Application.TodoLists.Queries.GetTodos
{
    public class GetTenantBySlugQuery : IRequest<TenantDto>
    {
        public string Slug { get; set; }
    }

    public class GetTenantBySlugQueryHandler : IRequestHandler<GetTenantBySlugQuery, TenantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTenantBySlugQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TenantDto> Handle(GetTenantBySlugQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tenants
                    .ProjectTo<TenantDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Slug.ToLower() == request.Slug.ToLower(), cancellationToken);
        }
    }
}
