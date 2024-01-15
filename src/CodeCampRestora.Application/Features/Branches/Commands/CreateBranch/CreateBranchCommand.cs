﻿using MediatR;
using CodeCampRestora.Domain.Enums;
using CodeCampRestora.Application.DTOs;
using System.Windows.Input;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public record CreateBranchCommand : ICommand<IResult<BranchDTO>>
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
    public IList<BranchOpeningClosingTimeDTO>? BranchOpeningClosingTime { get; set;}
    public IList<BranchCuisineTypeDTO>? BranchCuisineType { get; set; }
    public BranchAddressDTO? BranchAddress { get; set; }
    public Guid RestaurantId { get; set; }
}

