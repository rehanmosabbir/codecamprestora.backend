﻿using System.Net;

namespace CodeCampRestora.Application.Exceptions;

public class ApplicationValidatorException : CommonException
{
    public List<(string Type, string Description)> Messages { get; } = new();
    
    public ApplicationValidatorException(List<(string type, string description)> messages) 
        : base(messages[0].description) 
    {
        Messages = messages;
    }
    
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
