﻿using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Commands.HiddenReview
{
    public class HiddenReviewCommand : ICommand<IResult<ReviewDTO>>
    {
        public Guid ReviewId { get; set; }
        public bool HideReview { get; set; }

    }
}
