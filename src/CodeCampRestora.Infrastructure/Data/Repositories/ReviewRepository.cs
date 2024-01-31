using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;


[ScopedLifetime]
public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Review> _reviewDbSet;
    public ReviewRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
        _dbContext = (DbContext)applicationDbContext;
        _reviewDbSet = _dbContext.Set<Review>();
    }

    public async Task<IList<Review>> GetReviewsByBranchId(
        Guid branchId,
        string includeProperties = "",
        int pageIndex = 1,
        int pageSize = 10)
    {
        IQueryable<Review> query = _reviewDbSet;


        if (branchId != null)
        {
            query = query.Where(review => review.BranchId == branchId);
        }

        foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);


        var reviewList = await result.ToListAsync();
        return reviewList;
    }
}
