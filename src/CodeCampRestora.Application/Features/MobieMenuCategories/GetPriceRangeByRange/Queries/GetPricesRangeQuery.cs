using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;


namespace CodeCampRestora.Application.Features.MobieMenuCategories.Queries;

public record GetPricesRangeQuery(PriceRange PriceRange) : IQuery<IResult<List<BranchListDTO>>>;

