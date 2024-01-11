﻿namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IBookingOrderRepository BookingOrders { get; }
    IRestaurantRepository Restaurants { get; }
    Task SaveChangesAsync();
}