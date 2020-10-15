using Queuer.Application.Common.Interfaces;
using System;

namespace Queuer.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
