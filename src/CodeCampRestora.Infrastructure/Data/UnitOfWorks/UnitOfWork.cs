using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IOrderRepository Orders { get; }
    public IRestaurantRepository Restaurants { get; }
    public IBranchRepository Branches { get; }
    public IMenuItemRepository MenuItem { get; }
    public IReviewCommentRepository Comments { get; }
    public IMenuCategoryRepository MenuCategory { get; }
    public IReviewRepository Reviews { get; }

    private readonly IApplicationDbContext _appplicationDbContext;

    public UnitOfWork(
        IImageRepository images,
        IOrderRepository orders,
        IBranchRepository branches,
        IMenuItemRepository menuItem,
        IRestaurantRepository restaurants,
        IMenuCategoryRepository menuCategory,
        IReviewCommentRepository reviewComment,
        IReviewRepository review,
        IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        Orders = orders;
        Branches = branches;
        MenuItem = menuItem;
        Comments = reviewComment;
        Restaurants = restaurants;
        MenuCategory = menuCategory;
        Reviews = review;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }
}
