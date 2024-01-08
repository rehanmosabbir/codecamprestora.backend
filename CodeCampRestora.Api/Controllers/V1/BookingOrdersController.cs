﻿using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingOrdersController : ApiBaseController
    {
        private readonly ILogger<BookingOrdersController> _logger;
        private readonly IMediator _mediator;

        public BookingOrdersController(ILogger<BookingOrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingOrderDTO>>> GetAll()
        {
            var request = new GetAllBookingsQuery();
            var response = await Sender.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingOrderDTO>> Get(Guid id)
        {
            var response = await Sender.Send(new GetBookingOrderByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookingOrderCommand bookingOrder)
        {
            var response = await Sender.Send(bookingOrder);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookingOrderCommand bookingOrder)
        {
            var response = await Sender.Send(bookingOrder);
            return Ok(response);
        }


    }
}
