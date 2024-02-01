using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, IResult<PaginationDto<OrderDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IResult<PaginationDto<OrderDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByBranchId(request.BranchId, "OrderItems", request.PageNumber, request.PageSize);
            var ordersDto = orders.Adapt<List<OrderDTO>>();
            var paginationDto = new PaginationDto<OrderDTO>(ordersDto, orders.TotalCount, orders.TotalPages);

            return Result<PaginationDto<OrderDTO>>.Success(paginationDto);
        }
    }
}
