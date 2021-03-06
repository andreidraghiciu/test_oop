﻿using System;
using System.Threading.Tasks;

namespace CoffeeNation.Service.Interfaces
{
    public interface IMessagingService
    {
        Task SendErrorDetails(string message, Exception exception);
    }
}
