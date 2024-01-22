using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    [ScopedLifetime]
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(IApplicationDbContext applicationDbContext)
            : base((DbContext)applicationDbContext)
        {

        }

    }
}
