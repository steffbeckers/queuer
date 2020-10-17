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
using Queuer.Domain.Entities;

namespace Queuer.Application.Tickets.Queries.GetTicketByIdQuery
{
    public class GetTicketByIdQuery : IRequest<TicketDto>
    {
        public Guid Id { get; set; }
    }

    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tickets
                .Include(x => x.Tenant)
                .ProjectTo<TicketDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
