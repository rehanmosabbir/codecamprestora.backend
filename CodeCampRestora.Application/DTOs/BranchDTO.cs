﻿using CodeCampRestora.Domain.Enums;

namespace CodeCampRestora.Application.DTOs;

public class BranchDTO
{
    public BranchDTO()
    {
        Address = new BranchAddressDTO();
        CuisineTypes = new List<BranchCuisineTypeDTO>();
        OpeningClosingTimes = new List<BranchOpeningClosingTimeDTO>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
    public List<BranchCuisineTypeDTO> CuisineTypes { get; set; }
    public BranchAddressDTO Address { get; set; }
    public List<BranchOpeningClosingTimeDTO> OpeningClosingTimes { get; set; }
}

public class BranchCuisineTypeDTO
{
    public string CuisineTag { get; set; } = default!;


}

public class BranchOpeningClosingTimeDTO
{
    public DayOfWeek DayOfWeek { get; set; }
    public string Opening { get; set; }
    public string Closing { get; set; }
    public bool IsClosed { get; set; }
}

public class BranchAddressDTO
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Division { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Thana { get; set; } = default!;
    public string AreaDetails { get; set; } = default!;
}

