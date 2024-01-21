using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Orders.Commands.CreateOrder;
using CodeCampRestora.Application.Features.Orders.Commands.UpdateOrder;
using CodeCampRestora.Application.Features.Orders.Queries.GetAllOrder;
using CodeCampRestora.Application.Features.Orders.Queries.GetOrderById;
using CodeCampRestora.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using IResult = CodeCampRestora.Application.Models.IResult;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ApiBaseController
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Get all orders",
        Description = @"Sample Request:
        Get: api/v1/Orders"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Orders not found", typeof(IResult))]
        public async Task<IResult<List<OrderDTO>>> GetAll(int pageNumber, int pageSize)
        {
            var request = new GetAllOrdersQuery(pageNumber, pageSize);
            var response = await Sender.Send(request);
            return response;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerOperation(
        Summary = "Get an order",
        Description = @"Sample Request:
        Get: api/v1/Orders/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found", typeof(IResult))]
        public async Task<IResult<OrderDTO>> Get([FromRoute, SwaggerParameter(Description = "Get order by id", Required = true)] Guid id)
        {
            var response = await Sender.Send(new GetOrderByIdQuery(id));
            return response;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Create an order",
        Description = @"Sample Request:
        Post: api/v1/Orders
        {
            ""id"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB"",
            ""orderStatus"": 0,
        }"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IResult> Post([FromBody] CreateOrderCommand order)
        {
            var result = await Sender.Send(order);
            return result;
        }

        [HttpPatch]
        [SwaggerOperation(
        Summary = "Update an order",
        Description = @"Sample Request:
        Put: api/v1/BookingOrder/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c
        {
            ""id"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB"",
            ""orderStatus"": 0,
        }"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IResult> Update([FromBody] UpdateOrderCommand order)
        {
            var result = await Sender.Send(order);
            return result;
        }
    }
}
