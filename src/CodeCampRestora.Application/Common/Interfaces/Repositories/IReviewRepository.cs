using CodeCampRestora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
        Task<IList<Review>> GetReviewsByBranchId(
        Guid branchId,
        string includeProperties = "",
        int pageIndex = 1,
        int pageSize = 10);
    }
}
