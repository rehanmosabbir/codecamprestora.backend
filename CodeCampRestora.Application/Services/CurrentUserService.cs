using Microsoft.AspNetCore.Http;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class CurrentUserService : ICurrentUserService
{
    private readonly HttpContext _httpContext;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? new DefaultHttpContext();
    }
}