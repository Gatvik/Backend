using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
    
    public BadRequestException(string message, IEnumerable<IdentityResult> validationResult) : base(message)
    {
        
    }
    
    public IDictionary<string, string[]> ValidationErrors { get; set; }
    public IDictionary<string, string> IdentityErrors { get; set; }
}