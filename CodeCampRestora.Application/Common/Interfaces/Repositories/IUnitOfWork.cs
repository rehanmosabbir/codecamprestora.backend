﻿namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IReviewRepository Reviews { get; }
    Task SaveChangesAsync();
}