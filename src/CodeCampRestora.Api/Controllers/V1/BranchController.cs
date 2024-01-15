﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.Branches.Queries.GetById;
using CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;
using CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
using CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Api.Controllers.V1;

public class BranchController : ApiBaseController
{
    private readonly ILogger<BranchController> _logger;
    private readonly IMediator _mediator;

    public BranchController(ILogger<BranchController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("resturant/{resturantId}")]
    [SwaggerOperation(
        Summary = "Get all branches for a restaurant",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Branch not found", typeof(IResult))]
    public async Task<IResult> GetAll(Guid resturantId)
    {
        var result = await Sender.Send(new GetAllBranchesQuery(resturantId));
        return result;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a branch by ID",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult<BranchDTO>> Get(Guid id)
    {
        var result = await Sender.Send(new GetBranchByIdQuery(id));
        return result;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new branch",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult> Post([FromBody] CreateBranchCommand newItem)
    {
        var result = await Sender.Send(newItem);
        return result;
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Update an existing branch",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult> Put(UpdateBranchCommand updatedItem)
    {
        var result = await Sender.Send(updatedItem);
        return result;
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a branch",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult> Delete(Guid id)
    {
        var result = await Sender.Send(new DeleteBranchCommand { Id = id });
        return result;
    }
}

